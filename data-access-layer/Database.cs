using MongoDB.Driver;
using System.Configuration;

namespace data_access_layer
{
    public class AccesoDatosMongo
    {
        private readonly IMongoDatabase Database;
        public AccesoDatosMongo()
        {
            string MongoUrl = ConfigurationManager.AppSettings["MongoUrl"];
            string DbName = ConfigurationManager.AppSettings["MongoDatabase"];

            var client = new MongoClient(MongoUrl);
            Database = client.GetDatabase(DbName);
        }
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return Database.GetCollection<T>(collectionName);
        }
    }
}
