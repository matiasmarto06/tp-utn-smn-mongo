using api_parser;
using data_access_layer;
using System;
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
            // 30 días * 24 horas = 720 horas/mes
            double totalHoursInMonth = 30 * 24;
            // Calculamos el intervalo ideal teórico
            double idealInterval = (totalHoursInMonth * stationCount) / (double)monthlyLimit;
            // Valores de intervalos permitidos
            int[] allowedIntervals = { 3, 6, 8, 12, 24, 48 };
            // Buscamos el más cercano que no viole el límite mensual (es decir, >= ideal)
            int suggestedInterval = allowedIntervals[allowedIntervals.Length - 1]; // valor máximo por defecto
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
            if (scheduled) txtLog.AppendText($"{DateTime.Now}: ⏱ Scheduled polling triggered.{Environment.NewLine}");
            else txtLog.AppendText($"{DateTime.Now}: ▶ Manual polling triggered.{Environment.NewLine}");
            txtLog.AppendText($"{DateTime.Now}: Starting polling cycle...{Environment.NewLine}");
            try
            {
                foreach (var station in await Stations.ToList())
                {
                    // Aquí iría la lógica de consulta a la API para cada estación
                    txtLog.AppendText($"{DateTime.Now}: Polling station ID: {station.Id}{Environment.NewLine}");
                    Parser parser = new Parser(station.Code);
                    //parser.GetContent();
                }
                await Task.Delay(2000); // simulamos trabajo
                txtLog.AppendText($"{DateTime.Now}: Polling cycle complete.{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                txtLog.AppendText($"{DateTime.Now}: ❌ Error during polling cycle: {ex.Message}{Environment.NewLine}");
            }
        }
        private void TogglePolling()
        {
            if (!IsPollingActive)
            {
                PollingTimer?.Start();
                IsPollingActive = true;
                txtLog.AppendText($"{DateTime.Now}: ✅ Polling started.{Environment.NewLine}");
            }
            else
            {
                PollingTimer?.Stop();
                IsPollingActive = false;
                txtLog.AppendText($"{DateTime.Now}: ⏹ Polling stopped.{Environment.NewLine}");
            }
        }
        private async void SetupPollingInterval()
        {
            if (StationsCount <= 0)
            {
                txtLog.AppendText($"{DateTime.Now}: No stations loaded yet.\n" + Environment.NewLine);
                return;
            }
            int intervalHours = CalculatePollingIntervalHours(StationsCount);
            // Cálculo: cuántas consultas por estación por mes
            int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            int requestsPerStation = (int)Math.Floor((24.0 / intervalHours) * daysInMonth);
            // Total mensual proyectado
            int totalProjected = StationsCount * requestsPerStation;
            // Consultar el DAL para saber cuántas quedan
            int remainingQuota = await ApiLog.RemainingQuota();
            // Log
            txtLog.AppendText($"{DateTime.Now}: Polling interval set to every {intervalHours} hours.{Environment.NewLine}");
            txtLog.AppendText($"{DateTime.Now}: Stations: {StationsCount}{Environment.NewLine}");
            txtLog.AppendText($"{DateTime.Now}: Estimated monthly API calls: {totalProjected}{Environment.NewLine}");
            txtLog.AppendText($"{DateTime.Now}: Remaining API quota this month: {remainingQuota}{Environment.NewLine}");
            if (totalProjected > remainingQuota)
            {
                txtLog.AppendText($"{DateTime.Now}: ⚠ WARNING: Projected calls exceed monthly quota ({totalProjected}/{remainingQuota}).{Environment.NewLine}");
            }

            // Convertir horas a milisegundos
            int intervalMs = PollingIntervalHours * 60 * 60 * 1000;

            PollingTimer = new Timer();
            PollingTimer.Interval = intervalMs;
            PollingTimer.Tick += async (s, e) => await PerformPollingCycle();
        }
        private async void PollingWindow_Load(object sender, EventArgs e)
        {
            await StationCounts_Load();
            SetupPollingInterval();
            await PerformPollingCycle(false);
        }
    }
}
