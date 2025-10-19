using api_parser;
using business_logic_layer;
using data_access_layer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace collector_winform
{
    public partial class PollingWindow : Form
    {
        private StationDAL Stations = new StationDAL();
        private int StationsCount = 0;
        private ApiRequestLogDAL ApiLog = new ApiRequestLogDAL();
        private Timer PollingTimer;
        private bool IsPollingActive = false;
        private int PollingIntervalHours = 6;
        public PollingWindow()
        {
            InitializeComponent();
        }
        private async Task StationCounts_Load()
        {
            try
            {
                int count = await Stations.CountStations();
                StationsCount = count;
                //txtLog.AppendText($"{DateTime.Now}: Total Stations: {count}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error retrieving station count: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLog.AppendText($"{DateTime.Now}: Error retrieving station count: {ex.Message}{Environment.NewLine}");
            }
        }
        private int CalculatePollingIntervalHours(int stationCount, int monthlyLimit = 500)
        {
            if (stationCount <= 0)
                return 24;

            double totalHoursInMonth = 30 * 24;
            double idealInterval = (totalHoursInMonth * stationCount) / (double)monthlyLimit;
            int[] allowedIntervals = { 3, 6, 8, 12, 24, 48 };
            int suggestedInterval = allowedIntervals[allowedIntervals.Length - 1];

            foreach (int interval in allowedIntervals)
            {
                if (interval >= idealInterval)
                {
                    suggestedInterval = interval;
                    break;
                }
            }
            return suggestedInterval;
        }
        private async Task PerformPollingCycle(bool scheduled = true)
        {
            if (scheduled) txtLog.AppendText($"{DateTime.Now}: Scheduled polling triggered.{Environment.NewLine}");
            else txtLog.AppendText($"{DateTime.Now}: Manual polling triggered.{Environment.NewLine}");
            txtLog.AppendText($"{DateTime.Now}: Starting polling cycle...{Environment.NewLine}");
            int totalInserted = 0;
            try
            {
                foreach (var station in await Stations.ToList())
                {
                    MeasurementDAL measurementDAL = new MeasurementDAL();
                    txtLog.AppendText($"{DateTime.Now}: Polling station: {station.Name}{Environment.NewLine}");
                    Parser parser = new Parser(station);
                    List<Measurement> measurements = parser.GetContent();
                    int inserted = await measurementDAL.AddMany(measurements);
                    txtLog.AppendText($"{DateTime.Now}: Waiting 2 second before next station...{Environment.NewLine}");
                    await Task.Delay(2000);
                }
                txtLog.AppendText($"{DateTime.Now}: Polling cycle complete.{Environment.NewLine}");
                if (IsPollingActive)
                    txtLog.AppendText($"{DateTime.Now}: Time off next polling: {DateTime.Now.AddHours(PollingIntervalHours)} {Environment.NewLine}");
                else 
                    txtLog.AppendText($"{DateTime.Now}: Time off next polling: never {Environment.NewLine}");
                txtLog.AppendText($"{DateTime.Now}: Measurements added: {totalInserted}{Environment.NewLine}");
                PrintInformation();
            }
            catch (Exception ex)
            {
                txtLog.AppendText($"{DateTime.Now}: Error during polling cycle: {ex.Message}{Environment.NewLine}");
            }
        }
        private void TogglePolling()
        {
            if (!IsPollingActive)
            {
                PollingTimer?.Start();
                IsPollingActive = true;
                txtLog.AppendText($"{DateTime.Now}: Polling started.{Environment.NewLine}");
            }
            else
            {
                PollingTimer?.Stop();
                IsPollingActive = false;
                txtLog.AppendText($"{DateTime.Now}: Polling stopped.{Environment.NewLine}");
            }
        }
        private async void PrintInformation()
        {
            int remainingQuota = await ApiLog.RemainingQuota();
            int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            int requestsPerStation = (int)Math.Floor((24.0 / PollingIntervalHours) * daysInMonth);
            int totalProjected = StationsCount * requestsPerStation;

            if (totalProjected > remainingQuota)
            {
                txtLog.AppendText($"{DateTime.Now}: ⚠ WARNING: Projected calls exceed monthly quota ({totalProjected}/{remainingQuota}).{Environment.NewLine}");
            }
            txtLog.AppendText($"{DateTime.Now}: Polling interval set to every {PollingIntervalHours} hours.{Environment.NewLine}");
            txtLog.AppendText($"{DateTime.Now}: Stations: {StationsCount}{Environment.NewLine}");
            txtLog.AppendText($"{DateTime.Now}: Estimated monthly API calls: {totalProjected}{Environment.NewLine}");
            txtLog.AppendText($"{DateTime.Now}: Remaining API quota this month: {remainingQuota}{Environment.NewLine}");
        }
        private void SetupPollingInterval()
        {
            if (StationsCount <= 0)
            {
                txtLog.AppendText($"{DateTime.Now}: No stations loaded yet.\n" + Environment.NewLine);
                return;
            }
            int PollingIntervalHours = CalculatePollingIntervalHours(StationsCount);
            int intervalMs = PollingIntervalHours * 60 * 60 * 1000;

            PollingTimer = new Timer();
            PollingTimer.Interval = intervalMs;
            PollingTimer.Tick += async (s, e) => await PerformPollingCycle();

            PrintInformation();
        }
        private async void PollingWindow_Load(object sender, EventArgs e)
        {
            await StationCounts_Load();
            SetupPollingInterval();
            await PerformPollingCycle(false);
        }
    }
}
