using RestSharp;
using System;
using System.Configuration;
using System.Text.Json;
using System.Text.Json.Nodes;
using data_access_layer;
using business_logic_layer;

namespace api_parser
{
    public class Parser
    {
        private RestClient Client;
        private RestRequest Request;
        private string Content { get; set; }
        private string ApiKey { get; set; }
        private string ApiUrl { get; set; }
        private string Station { get; set; }
        public Parser(string station)
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

            Client = new RestClient($"{ApiUrl}?station={Station}&start={start}&end={end}&tz=America/Argentina/Buenos_Aires");
            Request = new RestRequest();
            Request.Method = Method.Get;
            Request.AddHeader("x-rapidapi-key", ApiKey);
            Request.AddHeader("x-rapidapi-host", "meteostat.p.rapidapi.com");

            RestResponse response = Client.Execute(Request);
            Content = response.Content;

            Content = FilterToNow(Content);

            // Registrar consulta
            var logDAL = new ApiRequestLogDAL();
            var log = new ApiRequestLog
            {
                StationName = Station,
                Timestamp = DateTime.Now,
                IsScheduled = false, // O true si es programada
                Success = response.IsSuccessful,
                Message = response.IsSuccessful ? "OK" : response.ErrorMessage
            };
            _ = logDAL.Add(log);
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
        public string GetContent() => Content;
    }
}
