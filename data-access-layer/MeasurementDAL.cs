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
        public async Task<List<Measurement>> GetMeasurementsByFilterAsync(
            string stationId,
            DateTime? dateFrom,
            DateTime? dateTo,
            string variableName = null,
            string criteria = null,
            double? value = null)
        {
            var builder = Builders<Measurement>.Filter;
            var filter = builder.Empty;

            if (!string.IsNullOrEmpty(stationId))
            {
                filter &= builder.Eq(m => m.Station.Id, stationId);
            }

            if (dateFrom.HasValue)
            {
                filter &= builder.Gte(m => m.Time, dateFrom.Value.Date);
            }

            if (dateTo.HasValue)
            {
                filter &= builder.Lte(m => m.Time, dateTo.Value.Date.AddDays(1).AddTicks(-1));
            }

            if (!string.IsNullOrEmpty(variableName) && !string.IsNullOrEmpty(criteria) && value.HasValue)
            {
                var field = new StringFieldDefinition<Measurement, double>(variableName);
                switch (criteria)
                {
                    case ">=": filter &= builder.Gte(field, value.Value); break;
                    case "<=": filter &= builder.Lte(field, value.Value); break;
                    case "==": filter &= builder.Eq(field, value.Value); break;
                }
            }

            try
            {
                return await Measurements.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving filtered measurements: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Measurement>();
            }
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
                insertedCount = measurements.Count;
                return insertedCount;
            }
            catch (MongoBulkWriteException ex)
            {
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