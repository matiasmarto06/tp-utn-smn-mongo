using System;
using MongoDB.Driver;

namespace data_access_layer
{
    public partial class Database
    {
        private static IMongoDatabase _database;
        public static void Initialize(string mongoUri, string dbName)
        {
            var client = new MongoClient(mongoUri);
            _database = client.GetDatabase(dbName);
        }
        public static IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            if (_database == null)
                throw new InvalidOperationException("Database not initialized. Call Database.Initialize() first.");

            return _database.GetCollection<T>(collectionName);
        }
    }
}
