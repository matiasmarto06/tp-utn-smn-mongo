using business_logic_layer;
using data_access_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace collector_winform
{
    public partial class GraphWindow : Form
    {
        private readonly StationDAL _stationDAL = new StationDAL();
        private readonly MeasurementDAL _measurementDAL = new MeasurementDAL();
        private Dictionary<string, string> _variableMap = new Dictionary<string, string>
        {
            { "Temperature", "temp" },
            { "Humidity", "rhum" },
            { "Pressure", "pres" },
            { "WindSpeed", "wspd" },
            { "DewPoint", "dwpt" },
            { "Precipitation", "prcp" }
        };

        public GraphWindow()
        {
            InitializeComponent();
        }

        private async void GraphWindow_Load(object sender, EventArgs e)
        {
            await PopulateFilterControls();
            await PlotDefaultGraph();
        }

        private async Task PopulateFilterControls()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                var stations = await _stationDAL.ToList();
                cboxStation.DataSource = stations;
                cboxStation.DisplayMember = "Name";
                cboxStation.ValueMember = "Id";

                cboxVariable.DataSource = new BindingSource(_variableMap, null);
                cboxVariable.DisplayMember = "Key";
                cboxVariable.ValueMember = "Value";
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

        private async Task PlotDefaultGraph()
        {
            string defaultStationName = "BASE MARAMBIO";
            string defaultVariableName = "Temperature";

            var stationItem = cboxStation.Items.Cast<Station>().FirstOrDefault(s => s.Name.Equals(defaultStationName, StringComparison.OrdinalIgnoreCase));
            if (stationItem != null)
            {
                cboxStation.SelectedValue = stationItem.Id;
            }

            var variableItem = cboxVariable.Items.Cast<KeyValuePair<string, string>>().FirstOrDefault(kv => kv.Key == defaultVariableName);
            if (variableItem.Key != null)
            {
                cboxVariable.SelectedValue = variableItem.Value;
            }

            dtpDateFrom.Value = DateTime.Now.Date;
            dtpDateTo.Value = DateTime.Now.Date.AddDays(1);

            await PlotFromControls();
        }

        private async void btnPlot_Click(object sender, EventArgs e)
        {
            await PlotFromControls();
        }

        private async Task PlotFromControls()
        {
            if (cboxStation.SelectedValue == null || cboxVariable.SelectedValue == null)
            {
                MessageBox.Show("Please select a station and a variable.");
                return;
            }

            string stationId = cboxStation.SelectedValue.ToString();
            string stationName = cboxStation.Text;
            string variableBsonName = cboxVariable.SelectedValue.ToString();
            string variableDisplayName = ((KeyValuePair<string, string>)cboxVariable.SelectedItem).Key;

            DateTime dateFrom = dtpDateFrom.Value;
            DateTime dateTo = dtpDateTo.Value;

            List<Measurement> measurements;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                measurements = await _measurementDAL.GetMeasurementsByFilterAsync(stationId, dateFrom, dateTo);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            if (measurements == null || !measurements.Any())
            {
                MessageBox.Show($"No data found for {stationName} between {dateFrom.ToShortDateString()} and {dateTo.ToShortDateString()}.");
                chartMain.Series.Clear();
                chartMain.Titles.Clear();
                return;
            }

            PlotData(measurements, stationName, variableDisplayName, variableBsonName);
        }
        private void PlotData(List<Measurement> measurements, string stationName, string variableDisplayName, string variableBsonName)
        {
            // --- NEW: Calculate Y-Axis range ---
            var dataPoints = measurements
                .Select(m => GetMeasurementValue(m, variableBsonName))
                .Where(v => v.HasValue)
                .Select(v => v.Value)
                .ToList();

            var chartArea = chartMain.ChartAreas[0];

            if (dataPoints.Any())
            {
                double dataMin = dataPoints.Min();
                double dataMax = dataPoints.Max();
                double padding = (dataMax - dataMin) * 0.10; // 10% padding

                // Handle cases where all data points are the same, or just 0
                if (padding == 0)
                {
                    padding = Math.Abs(dataMax * 0.1); // 10% of the value
                }
                if (padding == 0)
                {
                    padding = 5; // Default padding if value is 0
                }

                chartArea.AxisY.Minimum = Math.Floor(dataMin - padding);
                chartArea.AxisY.Maximum = Math.Ceiling(dataMax + padding);
            }
            else
            {
                // Reset to auto-scaling if no data
                chartArea.AxisY.Minimum = Double.NaN;
                chartArea.AxisY.Maximum = Double.NaN;
            }
            // --- END NEW ---

            chartMain.Series.Clear();
            chartMain.Titles.Clear();

            var series = new Series(variableDisplayName)
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 5,
                BorderWidth = 2 // Make the line a bit thicker
            };

            var sortedMeasurements = measurements.OrderBy(m => m.Time);

            foreach (var m in sortedMeasurements)
            {
                double? value = GetMeasurementValue(m, variableBsonName);
                if (value.HasValue)
                {
                    series.Points.AddXY(m.Time, value.Value);
                }
            }

            chartMain.Series.Add(series);
            chartMain.Titles.Add($"{variableDisplayName} at {stationName} ({dtpDateFrom.Value.ToShortDateString()} to {dtpDateTo.Value.ToShortDateString()})");

            chartArea.AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm";
            chartArea.AxisX.Title = "Date / Time";
            chartArea.AxisY.Title = $"{variableDisplayName} ({GetUnit(variableBsonName)})"; // Added units to title
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Auto;
            chartArea.AxisX.LabelStyle.Angle = -45;
        }
        private double? GetMeasurementValue(Measurement m, string variableBsonName)
        {
            switch (variableBsonName)
            {
                case "temp": return m.Temperature;
                case "rhum": return m.RelativeHumidity;
                case "pres": return m.Pressure;
                case "wspd": return m.WindSpeed;
                case "dwpt": return m.DewPoint;
                case "prcp": return m.Precipitation; 
                default: return null;
            }
        }
        private string GetUnit(string variableBsonName)
        {
            switch (variableBsonName)
            {
                case "temp": return "°C";
                case "rhum": return "%";
                case "pres": return "hPa";
                case "wspd": return "km/h";
                case "dwpt": return "°C";
                case "prcp": return "mm";
                default: return "";
            }
        }
    }
}

