namespace collector_winform
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStations = new System.Windows.Forms.Button();
            this.btnPolling = new System.Windows.Forms.Button();
            this.btnData = new System.Windows.Forms.Button();
            this.btnGraphs = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnStations);
            this.flowLayoutPanel1.Controls.Add(this.btnPolling);
            this.flowLayoutPanel1.Controls.Add(this.btnData);
            this.flowLayoutPanel1.Controls.Add(this.btnGraphs);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(259, 61);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnStations
            // 
            this.btnStations.Location = new System.Drawing.Point(3, 3);
            this.btnStations.Name = "btnStations";
            this.btnStations.Size = new System.Drawing.Size(75, 23);
            this.btnStations.TabIndex = 0;
            this.btnStations.Text = "Estaciones";
            this.btnStations.UseVisualStyleBackColor = true;
            this.btnStations.Click += new System.EventHandler(this.btnStations_Click);
            // 
            // btnPolling
            // 
            this.btnPolling.Location = new System.Drawing.Point(84, 3);
            this.btnPolling.Name = "btnPolling";
            this.btnPolling.Size = new System.Drawing.Size(75, 23);
            this.btnPolling.TabIndex = 1;
            this.btnPolling.Text = "Polling";
            this.btnPolling.UseVisualStyleBackColor = true;
            // 
            // btnData
            // 
            this.btnData.Location = new System.Drawing.Point(165, 3);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(75, 23);
            this.btnData.TabIndex = 2;
            this.btnData.Text = "Datos";
            this.btnData.UseVisualStyleBackColor = true;
            // 
            // btnGraphs
            // 
            this.btnGraphs.Location = new System.Drawing.Point(3, 32);
            this.btnGraphs.Name = "btnGraphs";
            this.btnGraphs.Size = new System.Drawing.Size(75, 23);
            this.btnGraphs.TabIndex = 3;
            this.btnGraphs.Text = "Graficos";
            this.btnGraphs.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 61);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(275, 100);
            this.MinimumSize = new System.Drawing.Size(275, 100);
            this.Name = "MainWindow";
            this.Text = "Meteostat Collector";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnStations;
        private System.Windows.Forms.Button btnPolling;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.Button btnGraphs;
    }
}

