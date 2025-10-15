using System;
using System.Configuration;
using System.Windows.Forms;
using api_parser;

namespace collector_winform
{
    public partial class MainWindow : Form
    {
        private readonly string ApiKey = ConfigurationManager.AppSettings["MeteostatApiKey"];
        private readonly string ApiUrl = ConfigurationManager.AppSettings["MeteostatHost"];
        public MainWindow()
        {
            InitializeComponent();
            
            Parser parser = new Parser(ApiKey, ApiUrl, station:"89055");

        }

        private void btnStations_Click(object sender, EventArgs e)
        {
            StationsWindow stations = new StationsWindow();
            stations.ShowDialog();
        }
    }
}
