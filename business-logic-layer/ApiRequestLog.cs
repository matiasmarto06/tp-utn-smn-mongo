using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace business_logic_layer
{
    public class ApiRequestLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("station")]
        public string StationName { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }

        [BsonElement("isScheduled")]
        public bool IsScheduled { get; set; }
        [BsonElement("success")]
        public bool Success { get; set; }
        [BsonElement("message")]
        public string Message { get; set; }
    }
}
