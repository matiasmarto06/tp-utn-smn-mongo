using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace business_logic_layer
{
    public class Measurement
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("station_id")]
        public ObjectId StationId { get; set; } = ObjectId.Empty;

        [BsonElement("time")]
        public DateTime Time { get; set; }

        [BsonElement("temp")]
        public double Temperature { get; set; }

        [BsonElement("dwpt")]
        public double DewPoint { get; set; }

        [BsonElement("rhum")]
        public int RelativeHumidity { get; set; }

        [BsonElement("prcp")]
        public double Precipitation { get; set; }

        [BsonElement("snow")]
        public double? Snow { get; set; }

        [BsonElement("wdir")]
        public int WindDirection { get; set; }

        [BsonElement("wspd")]
        public double WindSpeed { get; set; }

        [BsonElement("wpgt")]
        public double? WindGust { get; set; }

        [BsonElement("pres")]
        public double Pressure { get; set; }

        [BsonElement("tsun")]
        public int? SunshineDuration { get; set; }

        [BsonElement("coco")]
        public int WeatherCode { get; set; }
    }
}