using System.Configuration;
using System.Windows.Forms;
using data_access_layer;

namespace collector_winform

{
    public partial class StationsWindow : Form
    {
        private readonly string MongoUri = ConfigurationManager.AppSettings["MongoUri"];
        private readonly string DatabaseName = ConfigurationManager.AppSettings["DatabaseName"];
        public StationsWindow()
        {
            Database.Initialize(MongoUri, DatabaseName);

            InitializeComponent();
        }
    }
}
