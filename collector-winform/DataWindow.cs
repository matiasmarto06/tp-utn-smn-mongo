using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using data_access_layer;
using business_logic_layer;
using MongoDB.Driver;

namespace collector_winform
{
    public partial class DataWindow : Form
    {
        private readonly MeasurementDAL _measurementDAL = new MeasurementDAL();
        private readonly StationDAL _stationDAL = new StationDAL();
        private string _currentSortColumn = "Time";
        private bool _isAscending = false;
        
        private readonly Dictionary<string, string> _columnToMongoFieldMap = new Dictionary<string, string>
        {
            { "Time", "time" },
            { "Temp", "temp" },
            { "DewPoint", "dwpt" },
            { "Humidity", "rhum" },
            { "Precipitation", "prcp" },
            { "Snow", "snow" },
            { "WindSpeed", "wspd" },
            { "WindDir", "wdir" },
            { "WindGust", "gust" },
            { "Pressure", "pres" },
            { "Sunshine", "tsun" },
            { "WeatherCode", "coco" }
        };

        public DataWindow()
        {
            InitializeComponent();
        }

        private async void DataWindow_Load(object sender, EventArgs e)
        {
            await PopulateFilterControls();
            await ApplyFilters();
        }

        private async Task PopulateFilterControls()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var stations = await _stationDAL.ToList();
                stations.Insert(0, new Station { Id = null, Name = "Todas las Estaciones" });

                cboxStation.DataSource = stations;
                cboxStation.DisplayMember = "Name";
                cboxStation.ValueMember = "Id";
                cboxStation.SelectedIndex = 0;

                cboxVariable.DataSource = new BindingSource(_columnToMongoFieldMap, null);
                cboxVariable.DisplayMember = "Key";
                cboxVariable.ValueMember = "Value";
                cboxCriteria.Items.AddRange(new string[] { ">=", "<=", "==" });
                cboxCriteria.SelectedIndex = 0;

                dtpDateFrom.Value = DateTime.Now.AddDays(-7); // Default to last week
                dtpDateTo.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading filters: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private async Task ApplyFilters()
        {
            string stationId = cboxStation.SelectedValue as string;
            DateTime? dateFrom = dtpDateFrom.Value;
            DateTime? dateTo = dtpDateTo.Value;

            string variableName = null;
            string criteria = null;
            double? value = null;

            if (cboxVariable.SelectedValue != null && !string.IsNullOrWhiteSpace(txtValue.Text) && double.TryParse(txtValue.Text, out double filterValue))
            {
                variableName = cboxVariable.SelectedValue.ToString();
                criteria = cboxCriteria.SelectedItem.ToString();
                value = filterValue;
            }

            string mongoField = _columnToMongoFieldMap.ContainsKey(_currentSortColumn)
                ? _columnToMongoFieldMap[_currentSortColumn]
                : "time";

            var sortDef = _isAscending
                ? Builders<Measurement>.Sort.Ascending(mongoField)
                : Builders<Measurement>.Sort.Descending(mongoField);

            List<Measurement> filteredMeasurements;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                filteredMeasurements = await _measurementDAL.GetMeasurementsWithLookupAsync(
                    stationId,
                    dateFrom,
                    dateTo,
                    variableName,
                    criteria,
                    value, 
                    sortDef);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            var displayData = filteredMeasurements.Select(m => new
            {
                Id = m.Id,
                Station = m.StationId,
                Time = m.Time,
                Temp = m.Temperature,
                DewPoint = m.DewPoint,
                Humidity = m.RelativeHumidity,
                Precipitation = m.Precipitation,
                Snow = m.Snow,
                WindDir = m.WindDirection,
                WindSpeed = m.WindSpeed,
                WindGust = m.WindGust,
                Pressure = m.Pressure,
                Sunshine = m.SunshineDuration,
                WeatherCode = m.WeatherCode
            }).ToList();

            dgvData.DataSource = displayData;

            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
            if (dgvData.Columns["Id"] != null)
                dgvData.Columns["Id"].Visible = false;
            if (dgvData.Columns["Station"] != null)
                dgvData.Columns["Station"].HeaderText = "Station";
            if (dgvData.Columns["Time"] != null)
                dgvData.Columns["Time"].HeaderText = "Time";
            if (dgvData.Columns["Temp"] != null)
                dgvData.Columns["Temp"].HeaderText = "Temp (°C)";
            if (dgvData.Columns["DewPoint"] != null)
                dgvData.Columns["DewPoint"].HeaderText = "Dew Point (°C)";
            if (dgvData.Columns["Humidity"] != null)
                dgvData.Columns["Humidity"].HeaderText = "Humidity (%)";
            if (dgvData.Columns["Precipitation"] != null)
                dgvData.Columns["Precipitation"].HeaderText = "Precip. (mm)";
            if (dgvData.Columns["Snow"] != null)
                dgvData.Columns["Snow"].HeaderText = "Snow (mm)";
            if (dgvData.Columns["WindDir"] != null)
                dgvData.Columns["WindDir"].HeaderText = "Wind Dir (°)";
            if (dgvData.Columns["WindSpeed"] != null)
                dgvData.Columns["WindSpeed"].HeaderText = "Wind (km/h)";
            if (dgvData.Columns["WindGust"] != null)
                dgvData.Columns["WindGust"].HeaderText = "Gusts (km/h)";
            if (dgvData.Columns["Pressure"] != null)
                dgvData.Columns["Pressure"].HeaderText = "Pressure (hPa)";
            if (dgvData.Columns["Sunshine"] != null)
                dgvData.Columns["Sunshine"].HeaderText = "Sunshine (min)";
            if (dgvData.Columns["WeatherCode"] != null)
                dgvData.Columns["WeatherCode"].HeaderText = "Weather Code";

            if (dgvData.Columns.Contains(_currentSortColumn))
            {
                dgvData.Columns[_currentSortColumn].HeaderCell.SortGlyphDirection =
                    _isAscending ? SortOrder.Ascending : SortOrder.Descending;
            }
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await ApplyFilters();
        }
        private async void btnClear_Click(object sender, EventArgs e)
        {
            cboxStation.SelectedIndex = 0;
            dtpDateFrom.Value = DateTime.Now.AddMonths(-1);
            dtpDateTo.Value = DateTime.Now;
            txtValue.Text = "";
            cboxVariable.SelectedIndex = 0;

            await ApplyFilters();
        }

        private async void dgvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string clickedColumnName = dgvData.Columns[e.ColumnIndex].Name;

            if (_columnToMongoFieldMap.ContainsKey(clickedColumnName))
            {
                if (clickedColumnName == _currentSortColumn)
                {
                    _isAscending = !_isAscending;
                }
                else
                {
                    _currentSortColumn = clickedColumnName;
                    _isAscending = true;
                }
                await ApplyFilters();
            }
        }
    }
}