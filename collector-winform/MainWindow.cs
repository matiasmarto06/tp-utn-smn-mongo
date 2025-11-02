using System;
using System.Configuration;
using System.Windows.Forms;
using api_parser;

namespace collector_winform
{
    public partial class MainWindow : Form
    {
        private PollingWindow Polling = new PollingWindow();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnStations_Click(object sender, EventArgs e)
        {
            StationsWindow stations = new StationsWindow();
            stations.ShowDialog();
        }

        private void btnPolling_Click(object sender, EventArgs e)
        {
            if (!Polling.Visible)
                Polling.Show();

            if (Polling.WindowState == FormWindowState.Minimized)
                Polling.WindowState = FormWindowState.Normal;
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            DataWindow dataWindow = new DataWindow();
            dataWindow.ShowDialog();
        }

        private void btnGraphs_Click(object sender, EventArgs e)
        {
            GraphWindow graphWindow = new GraphWindow();
            graphWindow.ShowDialog();
        }
    }
}
