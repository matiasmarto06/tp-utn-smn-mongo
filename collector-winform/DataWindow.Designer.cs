namespace collector_winform
{
    partial class DataWindow
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel_Top = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cboxCriteria = new System.Windows.Forms.ComboBox();
            this.cboxVariable = new System.Windows.Forms.ComboBox();
            this.cboxStation = new System.Windows.Forms.ComboBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.flowLayoutPanel_bottom = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.flowLayoutPanel_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 29);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(1534, 532);
            this.dgvData.TabIndex = 9;
            this.dgvData.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_ColumnHeaderMouseClick);
            // 
            // flowLayoutPanel_Top
            // 
            this.flowLayoutPanel_Top.AutoSize = true;
            this.flowLayoutPanel_Top.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel_Top.Controls.Add(this.btnSearch);
            this.flowLayoutPanel_Top.Controls.Add(this.txtValue);
            this.flowLayoutPanel_Top.Controls.Add(this.cboxCriteria);
            this.flowLayoutPanel_Top.Controls.Add(this.cboxVariable);
            this.flowLayoutPanel_Top.Controls.Add(this.cboxStation);
            this.flowLayoutPanel_Top.Controls.Add(this.dtpDateTo);
            this.flowLayoutPanel_Top.Controls.Add(this.label1);
            this.flowLayoutPanel_Top.Controls.Add(this.dtpDateFrom);
            this.flowLayoutPanel_Top.Controls.Add(this.lblFrom);
            this.flowLayoutPanel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel_Top.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel_Top.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel_Top.Name = "flowLayoutPanel_Top";
            this.flowLayoutPanel_Top.Size = new System.Drawing.Size(1534, 29);
            this.flowLayoutPanel_Top.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1456, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(1172, 3);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(278, 20);
            this.txtValue.TabIndex = 4;
            // 
            // cboxCriteria
            // 
            this.cboxCriteria.FormattingEnabled = true;
            this.cboxCriteria.Location = new System.Drawing.Point(1045, 3);
            this.cboxCriteria.Name = "cboxCriteria";
            this.cboxCriteria.Size = new System.Drawing.Size(121, 21);
            this.cboxCriteria.TabIndex = 3;
            // 
            // cboxVariable
            // 
            this.cboxVariable.FormattingEnabled = true;
            this.cboxVariable.Location = new System.Drawing.Point(918, 3);
            this.cboxVariable.Name = "cboxVariable";
            this.cboxVariable.Size = new System.Drawing.Size(121, 21);
            this.cboxVariable.TabIndex = 2;
            // 
            // cboxStation
            // 
            this.cboxStation.FormattingEnabled = true;
            this.cboxStation.Location = new System.Drawing.Point(791, 3);
            this.cboxStation.Name = "cboxStation";
            this.cboxStation.Size = new System.Drawing.Size(121, 21);
            this.cboxStation.TabIndex = 5;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(585, 3);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(200, 20);
            this.dtpDateTo.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(556, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "To:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(350, 3);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpDateFrom.TabIndex = 7;
            // 
            // lblFrom
            // 
            this.lblFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(311, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 29);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From:";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel_bottom
            // 
            this.flowLayoutPanel_bottom.AutoSize = true;
            this.flowLayoutPanel_bottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel_bottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel_bottom.Location = new System.Drawing.Point(0, 561);
            this.flowLayoutPanel_bottom.Name = "flowLayoutPanel_bottom";
            this.flowLayoutPanel_bottom.Size = new System.Drawing.Size(1534, 0);
            this.flowLayoutPanel_bottom.TabIndex = 11;
            // 
            // DataWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 561);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.flowLayoutPanel_Top);
            this.Controls.Add(this.flowLayoutPanel_bottom);
            this.MinimumSize = new System.Drawing.Size(1550, 600);
            this.Name = "DataWindow";
            this.Text = "Datos";
            this.Load += new System.EventHandler(this.DataWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.flowLayoutPanel_Top.ResumeLayout(false);
            this.flowLayoutPanel_Top.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Top;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ComboBox cboxCriteria;
        private System.Windows.Forms.ComboBox cboxVariable;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_bottom;
        private System.Windows.Forms.ComboBox cboxStation;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblFrom;
    }
}