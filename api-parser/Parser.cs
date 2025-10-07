using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using DotNetEnv;

namespace api_parser
{
    public class Parser
    {
        private RestClient Client;
        private RestRequest Request;
        private string Content;
        private readonly string ApiUrl = "https://meteostat.p.rapidapi.com/point/hourly";

        public Parser()
        {
            string start = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            string end = DateTime.Now.ToString("yyyy-MM-dd");

            Env.Load();

            string apiKey = Env.GetString("METEOSTAT_API_KEY");
            string mongoUri = Env.GetString("MONGO_URI");

            Client = new RestClient($"{ApiUrl}?lat=-34.60&lon=-58.38&start={start}&end={end}&tz=America/Argentina/Buenos_Aires");
            Request = new RestRequest();
            Request.Method = Method.Get;
            Request.AddHeader("x-rapidapi-key", apiKey);
            Request.AddHeader("x-rapidapi-host", "meteostat.p.rapidapi.com");

            RestResponse response = Client.Execute(Request);
            Content = response.Content;

            // Optional: filter data here
            Content = FilterToNow(Content);
        }

        private string FilterToNow(string json)
        {
            if (string.IsNullOrEmpty(json))
                return json;

            var now = DateTime.Now;
            var parsed = JObject.Parse(json);
            var data = parsed["data"]?.ToObject<List<JObject>>();

            if (data == null)
                return json;

            // Keep only records up to current time
            var filtered = data
                .Where(d => DateTime.Parse(d["time"].ToString()) <= now)
                .ToList();

            parsed["data"] = JArray.FromObject(filtered);
            return parsed.ToString();
        }

        public string GetContent() => Content;
    }
}
