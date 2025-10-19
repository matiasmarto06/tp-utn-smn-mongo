using business_logic_layer;
using data_access_layer;
using MongoDB.Bson;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace api_parser
{
    public class Parser
    {
        private RestClient Client;
        private RestRequest Request;
        private List<Measurement> Content { get; set; }
        private string ApiKey { get; set; }
        private string ApiUrl { get; set; }
        private Station Station { get; set; }

        public Parser(Station station)
        {
            ApiKey = ConfigurationManager.AppSettings["MeteostatApiKey"];
            ApiUrl = ConfigurationManager.AppSettings["MeteostatHost"];
            Station = station;

            UpdateContent();
        }
        private void UpdateContent()
        {
            string start = DateTime.Now.ToString("yyyy-MM-dd");
            string end = DateTime.Now.ToString("yyyy-MM-dd");
            string config = $"{ApiUrl}?station={Station.Code}&start={start}&end={end}&tz=America/Argentina/Buenos_Aires";
            Client = new RestClient(config);
            Request = new RestRequest();
            Request.Method = Method.Get;
            Request.AddHeader("x-rapidapi-key", ApiKey);
            Request.AddHeader("x-rapidapi-host", "meteostat.p.rapidapi.com");
            RestResponse response = Client.Execute(Request);
            // Registrar consulta
            var logDAL = new ApiRequestLogDAL();
            var log = new ApiRequestLog
            {
                Station = Station,
                Timestamp = DateTime.Now,
                IsScheduled = false, // O true si es programada
                Success = response.IsSuccessful,
                Message = response.IsSuccessful ? "OK" : response.ErrorMessage
            };
            _ = logDAL.Add(log);

            Content = ParseMeasurementsFromBsonJson(FilterToNow(response.Content));
        }
        private string FilterToNow(string json)
        {
            if (string.IsNullOrEmpty(json))
                return json;

            var now = DateTime.Now;
            var parsed = JsonNode.Parse(json)?.AsObject();
            if (parsed == null || !parsed.ContainsKey("data"))
                return json;

            var data = parsed["data"]?.AsArray();
            if (data == null)
                return json;

            var filtered = new JsonArray();

            foreach (var item in data)
            {
                if (item?["time"] == null)
                    continue;

                if (DateTime.TryParse(item["time"].ToString(), out var time) && time <= now)
                {
                    var clone = JsonNode.Parse(item.ToJsonString());
                    filtered.Add(clone);
                }
            }

            parsed["data"] = filtered;
            return parsed.ToJsonString(new JsonSerializerOptions { WriteIndented = true });
        }
        public List<Measurement> GetContent() => Content;
        public List<Measurement> ParseMeasurementsFromBsonJson(string json)
        {
            var bsonDocument = BsonDocument.Parse(json);
            if (!bsonDocument.Contains("data")) return new List<Measurement>();

            var dataArray = bsonDocument["data"].AsBsonArray;
            List<Measurement> list = new List<Measurement>();

            foreach (var item in dataArray)
            {
                var doc = item.AsBsonDocument;
                Measurement measurement = new Measurement();

                string timeString = doc.Contains("time") ? doc["time"].ToString() : null;
                if (DateTime.TryParse(timeString, out DateTime parsed))
                    measurement.Time = parsed;
                measurement.Temperature = doc.Contains("temp") ? doc["temp"].ToDouble() : 0;
                measurement.DewPoint = doc.Contains("dwpt") ? doc["dwpt"].ToDouble() : 0;
                measurement.RelativeHumidity = doc.Contains("rhum") ? Convert.ToInt32(doc["rhum"].ToDouble()) : 0;
                measurement.Precipitation = doc.Contains("prcp") ? doc["prcp"].ToDouble() : 0;
                if (doc.Contains("snow") && !doc["snow"].IsBsonNull) measurement.Snow = doc["snow"].ToDouble();
                else measurement.Snow = null;
                measurement.WindDirection = doc.Contains("wdir") ? Convert.ToInt32(doc["wdir"].ToDouble()) : 0;
                measurement.WindSpeed = doc.Contains("wspd") ? doc["wspd"].ToDouble() : 0;
                if (doc.Contains("wpgt") && !doc["wpgt"].IsBsonNull) measurement.WindGust = doc["wpgt"].ToDouble();
                else measurement.WindGust = null;
                measurement.Pressure = doc.Contains("pres") ? doc["pres"].ToDouble() : 0;
                if (doc.Contains("tsun") && !doc["tsun"].IsBsonNull) measurement.SunshineDuration = Convert.ToInt32(doc["tsun"].ToDouble());
                else measurement.SunshineDuration = null;
                measurement.WeatherCode = doc.Contains("coco") ? Convert.ToInt32(doc["coco"].ToDouble()) : 0;
                measurement.Station = Station;

                list.Add(measurement);
            }

            return list;
        }

    }
}
