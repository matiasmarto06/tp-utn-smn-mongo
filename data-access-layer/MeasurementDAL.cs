using business_logic_layer;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace data_access_layer
{
    public class MeasurementDAL
    {
        private readonly IMongoCollection<Measurement> Measurements;
        public MeasurementDAL()
        {
            var acceso = new AccesoDatosMongo();
            Measurements = acceso.GetCollection<Measurement>("measurements");
            EnsureIndexes();
        }
        private void EnsureIndexes()
        {
            var indexKeys = Builders<Measurement>.IndexKeys
                .Ascending(m => m.Station)
                .Ascending(m => m.Time);

            var options = new CreateIndexOptions { Unique = true };
            var model = new CreateIndexModel<Measurement>(indexKeys, options);

            Measurements.Indexes.CreateOne(model);
        }
        public async Task<List<Measurement>> GetAllMeasurementsAsync()
        {
            try
            {
                return await Measurements.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving measurements: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Measurement>();
            }
        }
        public async Task<int> AddMany(List<Measurement> measurements)
        {
            int insertedCount = 0;
            try
            {
                await Measurements.InsertManyAsync(measurements, new InsertManyOptions { IsOrdered = false });
                insertedCount = measurements.Count; // todos se insertaron correctamente
                return insertedCount;
            }
            catch (MongoBulkWriteException ex)
            {
                // Ignoramos duplicados
                if (ex.WriteErrors.All(e => e.Category == ServerErrorCategory.DuplicateKey))
                    return 0;
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show($"Error adding measurements: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public async Task AddMeasurementAsync(Measurement measurement)
        {
            try
            {
                await Measurements.InsertOneAsync(measurement);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding measurement: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
