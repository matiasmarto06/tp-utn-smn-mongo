using System;
using System.Configuration;
using System.Windows.Forms;
using api_parser;

namespace collector_winform
{
    public partial class MainWindow : Form
    {
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
            PollingWindow polling = new PollingWindow();
            polling.ShowDialog();
        }
    }
}
