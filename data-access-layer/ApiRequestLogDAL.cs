using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using business_logic_layer;

namespace data_access_layer
{
    public class ApiRequestLogDAL
    {
        private readonly IMongoCollection<ApiRequestLog> Logs;

        public ApiRequestLogDAL()
        {
            var acceso = new AccesoDatosMongo();
            Logs = acceso.GetCollection<ApiRequestLog>("api_requests");
        }

        public async Task Add(ApiRequestLog log)
        {
            await Logs.InsertOneAsync(log);
        }

        public async Task<List<ApiRequestLog>> GetByMonth(int year, int month)
        {
            var start = new DateTime(year, month, 1);
            var end = start.AddMonths(1);

            var filter = Builders<ApiRequestLog>.Filter.Gte(l => l.Timestamp, start) &
                         Builders<ApiRequestLog>.Filter.Lt(l => l.Timestamp, end);

            return await Logs.Find(filter).ToListAsync();
        }

        public async Task<int> CountByMonth(int year, int month)
        {
            var start = new DateTime(year, month, 1);
            var end = start.AddMonths(1);

            var filter = Builders<ApiRequestLog>.Filter.Gte(l => l.Timestamp, start) &
                         Builders<ApiRequestLog>.Filter.Lt(l => l.Timestamp, end);

            return (int)await Logs.CountDocumentsAsync(filter);
        }
        public async Task<int> RemainingQuota()
        {
            int limit = 500;
            var used = await CountByMonth(DateTime.Now.Year, DateTime.Now.Month);
            return limit - used;
        }

    }
}
