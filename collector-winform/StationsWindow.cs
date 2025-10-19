using business_logic_layer;
using data_access_layer;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace collector_winform
{
    public partial class StationsWindow : Form
    {
        private readonly StationDAL _stationDAL = new StationDAL();

        public StationsWindow()
        {
            InitializeComponent();
        }

        private async void StationsWindow_Load(object sender, EventArgs e)
        {
            await LoadStationsAsync();
        }

        private async Task LoadStationsAsync()
        {
            try
            {
                var stations = await _stationDAL.ToList();
                dgvData.DataSource = stations;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Error loading stations: " + ex.Message);
            }
            btnDetails.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var config = new StationConfigure())
            {
                config.ShowDialog();
                await LoadStationsAsync(); // recarga después de cerrar
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            _ = _stationDAL.Delete(id: (string)dgvData.SelectedRows[0].Cells["Id"].Value);
            await LoadStationsAsync();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            using (var config = new StationConfigure(setting:"edit", id: (string)dgvData.SelectedRows[0].Cells["Id"].Value))
            {
                config.ShowDialog();
                await LoadStationsAsync(); // recarga después de cerrar
            }
        }

        private async void btnDetails_Click(object sender, EventArgs e)
        {
            using (var config = new StationConfigure(setting: "details", id: (string)dgvData.SelectedRows[0].Cells["Id"].Value))
            {
                config.ShowDialog();
                await LoadStationsAsync(); // recarga después de cerrar
            }
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                btnDetails.Enabled = true;
            }
        }
    }
}
