using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using data_access_layer;
using business_logic_layer;

namespace collector_winform
{
    public partial class DataWindow : Form
    {
        private readonly MeasurementDAL _measurementDAL = new MeasurementDAL();
        private readonly StationDAL _stationDAL = new StationDAL();

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
                var stations = await _stationDAL.ToList();

                stations.Insert(0, new Station { Id = null, Name = "Todas" });

                cboxStation.DataSource = stations;
                cboxStation.DisplayMember = "Name";
                cboxStation.ValueMember = "Id";
                cboxStation.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading stations for filter: " + ex.Message);
            }

            var variableMap = new Dictionary<string, string>
            {
                { "Temperature", "temp" },
                { "Humidity", "rhum" },
                { "Pressure", "pres" },
                { "WindSpeed", "wspd" },
                { "DewPoint", "dwpt" },
                { "Precipitation", "prcp" }
            };

            cboxVariable.DataSource = new BindingSource(variableMap, null);
            cboxVariable.DisplayMember = "Key";
            cboxVariable.ValueMember = "Value";

            cboxCriteria.Items.AddRange(new string[] { ">=", "<=", "==" });
            cboxCriteria.SelectedIndex = 0;

            dtpDateFrom.Value = DateTime.Now.AddMonths(-1);
            dtpDateTo.Value = DateTime.Now;
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
                variableName = cboxVariable.SelectedValue.ToString(); // This gets "temp", "rhum", etc.
                criteria = cboxCriteria.SelectedItem.ToString();
                value = filterValue;
            }

            List<Measurement> filteredMeasurements;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                filteredMeasurements = await _measurementDAL.GetMeasurementsByFilterAsync(
                    stationId,
                    dateFrom,
                    dateTo,
                    variableName,
                    criteria,
                    value);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            var displayData = filteredMeasurements.Select(m => new
            {
                Id = m.Id,
                Station = m.Station.Name,
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
    }
}