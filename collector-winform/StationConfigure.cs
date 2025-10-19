using business_logic_layer;
using collector_winform.Properties;
using data_access_layer;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace collector_winform
{
    public partial class StationConfigure : Form
    {
        private readonly StationDAL StationDAL = new StationDAL();
        private readonly string Setting = "new";
        private readonly string Id = null;
        public StationConfigure(string setting = "new", string id = null)
        {
            InitializeComponent();
            Setting = setting;
            Id = id;
        }
        private void StationDetails_Load()
        {
            // Additional initialization for details mode can be added here
            lblTitle.Text = "Detalles Estacion";
            txtId.Enabled = false;
            txtCode.Enabled = false;
            txtOACI.Enabled = false;
            txtName.Enabled = false;
            txtProv.Enabled = false;
            txtLat.Enabled = false;
            txtLong.Enabled = false;
            txtAlt.Enabled = false;
            btnAccept.Visible = false;
            btnCancel.Text = "Close";
            StationDAL.GetById(Id).ContinueWith(task =>
            {
                if (task.Exception != null)
                {
                    MessageBox.Show("Error loading station details: " + task.Exception.Message);
                    return;
                }
                var station = task.Result;
                if (station != null)
                {
                    txtId.Text = station.Id;
                    txtCode.Text = station.Code;
                    txtOACI.Text = station.OACI;
                    txtName.Text = station.Name;
                    txtProv.Text = station.Province;
                    txtLat.Text = station.Latitude.ToString();
                    txtLong.Text = station.Longitude.ToString();
                    txtAlt.Text = station.Altitude.ToString();
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void StationEdit_Load()
        {
            // Additional initialization for edit mode can be added here
            lblTitle.Text = "Editar Estacion";
            txtId.Enabled = false;
            btnAccept.Click -= btnAccept_Click;
            btnAccept.Click += new System.EventHandler(btnEdit_Click);
            StationDAL.GetById(Id).ContinueWith(task =>
            {
                if (task.Exception != null)
                {
                    MessageBox.Show("Error loading station details: " + task.Exception.Message);
                    return;
                }
                var station = task.Result;
                if (station != null)
                {
                    txtId.Text = station.Id;
                    txtCode.Text = station.Code;
                    txtOACI.Text = station.OACI;
                    txtName.Text = station.Name;
                    txtProv.Text = station.Province;
                    txtLat.Text = station.Latitude.ToString();
                    txtLong.Text = station.Longitude.ToString();
                    txtAlt.Text = station.Altitude.ToString();
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;
            try
            {
                var station = new Station
                {
                    Id = txtId.Text,
                    Code = txtCode.Text,
                    OACI = txtOACI.Text,
                    Name = txtName.Text,
                    Province = txtProv.Text,
                    Latitude = Convert.ToDouble(txtLat.Text),
                    Longitude = Convert.ToDouble(txtLong.Text),
                    Altitude = Convert.ToInt32(txtAlt.Text)
                };
                StationDAL.Modify(station).ContinueWith(task =>
                {
                    if (task.Exception != null)
                    {
                        MessageBox.Show("Error updating station: " + task.Exception.Message);
                        return;
                    }
                    MessageBox.Show("Station updated successfully.", "Done!");
                    Close();
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating station: " + ex.Message);
            }
        }
        private void StationConfigure_Load(object sender, EventArgs e)
        {
            switch (Setting)
            {
                case "new":
                    txtId.Enabled = false;
                    break;

                case "details":
                    StationDetails_Load();
                    break;

                case "edit":
                    StationEdit_Load();
                    // Additional initialization for edit mode can be added here
                    break;

                default:
                    txtId.Enabled = false;
                    break;
            }
        }

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            try
            {
                var station = new Station
                {
                    Id = txtId.Text,
                    Code = txtCode.Text,
                    OACI = txtOACI.Text,
                    Name = txtName.Text,
                    Province = txtProv.Text,
                    Latitude = Convert.ToDouble(txtLat.Text),
                    Longitude = Convert.ToDouble(txtLong.Text),
                    Altitude = Convert.ToInt32(txtAlt.Text)
                };

                await StationDAL.Add(station);

                MessageBox.Show("Station added successfully.", "Done!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding station: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text) ||
                string.IsNullOrWhiteSpace(txtOACI.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtProv.Text) ||
                string.IsNullOrWhiteSpace(txtLat.Text) ||
                string.IsNullOrWhiteSpace(txtLong.Text) ||
                string.IsNullOrWhiteSpace(txtAlt.Text))
            {
                MessageBox.Show("All fields must be filled out.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!double.TryParse(txtLat.Text, out _) ||
                !double.TryParse(txtLong.Text, out _) ||
                !int.TryParse(txtAlt.Text, out _))
            {
                MessageBox.Show("Latitude and Longitude must be valid numbers. Altitude must be a valid integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
