using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using business_logic_layer;

namespace data_access_layer
{
    public partial class StationDAL
    {
        private readonly IMongoCollection<Station> Stations;
        public StationDAL()
        {
            Stations = Database.GetCollection<Station>("stations");
        }
        public async Task AddStationAsync(Station station)
        {
            await Stations.InsertOneAsync(station);
        }
        public async Task<List<Station>> GetAllStationsAsync()
        {
            return await Stations.Find(_ => true).ToListAsync();
        }
        public async Task<Station> GetStationByIdAsync(string stationId)
        {
            return await Stations.Find(s => s.Id == stationId).FirstOrDefaultAsync();
        }
    }
}
