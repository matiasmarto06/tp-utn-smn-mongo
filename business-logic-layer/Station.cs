using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace business_logic_layer
{
    public class Station
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Code { get; set; }
        public string OACI { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Altitude { get; set; }
    }
}
