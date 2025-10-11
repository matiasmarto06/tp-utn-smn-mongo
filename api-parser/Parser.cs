using RestSharp;
using System;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace api_parser
{
    public class Parser
    {
        private RestClient Client;
        private RestRequest Request;
        private string Content;
        private readonly string ApiKey;
        private readonly string ApiUrl;
        private readonly string station;

        public Parser(string ApiKey_, string ApiUrl_, string station_)
        {
            ApiKey = ApiKey_;
            ApiUrl = ApiUrl_;
            station = station_;

            UpdateContent();
        }

        private void UpdateContent()
        {
            string start = DateTime.Now.ToString("yyyy-MM-dd");
            string end = DateTime.Now.ToString("yyyy-MM-dd");

            Client = new RestClient($"{ApiUrl}?station={station}&start={start}&end={end}&tz=America/Argentina/Buenos_Aires");
            Request = new RestRequest();
            Request.Method = Method.Get;
            Request.AddHeader("x-rapidapi-key", ApiKey);
            Request.AddHeader("x-rapidapi-host", "meteostat.p.rapidapi.com");

            RestResponse response = Client.Execute(Request);
            Content = response.Content;

            Content = FilterToNow(Content);
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
