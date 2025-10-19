using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using business_logic_layer;
using System;
using System.Windows.Forms;

namespace data_access_layer
{
    public class StationDAL
    {
        private readonly IMongoCollection<Station> Stations;

        public StationDAL()
        {
            var acceso = new AccesoDatosMongo();
            Stations = acceso.GetCollection<Station>("stations");
        }
        public async Task Add(Station station)
        {
            await Stations.InsertOneAsync(station);
        }
        public async Task AddMany(List<Station> stations)
        {
            await Stations.InsertManyAsync(stations);
        }
        public async Task<List<Station>> ToList()
        {
            List<Station> List = new List<Station>();
            try
            {
                 List = await Stations.Find(_ => true).ToListAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error retrieving station list: " + ex.Message);
                MessageBox.Show("An error occurred while retrieving the station list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Station>();
            }
            return List;
        }
        public async Task<Station> GetById(string id)
        {
            var filter = Builders<Station>.Filter.Eq(s => s.Id, id);
            return await Stations.Find(filter).FirstOrDefaultAsync();
        }
        public async Task Modify(Station station)
        {
            var filter = Builders<Station>.Filter.Eq(s => s.Id, station.Id);
            await Stations.ReplaceOneAsync(filter, station);
        }
        public async Task Delete(string id)
        {
            var filter = Builders<Station>.Filter.Eq(s => s.Id, id);
            await Stations.DeleteOneAsync(filter);
        }
        public async Task<int> CountStations()
        {
            return (int) await Stations.CountDocumentsAsync(_ => true);
        }
    }
}
