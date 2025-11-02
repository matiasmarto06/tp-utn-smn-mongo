namespace collector_winform
{
    partial class GraphWindow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.flowLayoutPanel_bottom = new System.Windows.Forms.FlowLayoutPanel();
            this.cboxStation = new System.Windows.Forms.ComboBox();
            this.cboxVariable = new System.Windows.Forms.ComboBox();
            this.btnPlot = new System.Windows.Forms.Button();
            this.flowLayoutPanel_Top = new System.Windows.Forms.FlowLayoutPanel();
            this.chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.flowLayoutPanel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel_bottom
            // 
            this.flowLayoutPanel_bottom.AutoSize = true;
            this.flowLayoutPanel_bottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel_bottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel_bottom.Location = new System.Drawing.Point(0, 461);
            this.flowLayoutPanel_bottom.Name = "flowLayoutPanel_bottom";
            this.flowLayoutPanel_bottom.Size = new System.Drawing.Size(1034, 0);
            this.flowLayoutPanel_bottom.TabIndex = 11;
            // 
            // cboxStation
            // 
            this.cboxStation.FormattingEnabled = true;
            this.cboxStation.Location = new System.Drawing.Point(702, 3);
            this.cboxStation.Name = "cboxStation";
            this.cboxStation.Size = new System.Drawing.Size(121, 21);
            this.cboxStation.TabIndex = 2;
            // 
            // cboxVariable
            // 
            this.cboxVariable.FormattingEnabled = true;
            this.cboxVariable.Location = new System.Drawing.Point(829, 3);
            this.cboxVariable.Name = "cboxVariable";
            this.cboxVariable.Size = new System.Drawing.Size(121, 21);
            this.cboxVariable.TabIndex = 3;
            // 
            // btnPlot
            // 
            this.btnPlot.Location = new System.Drawing.Point(956, 3);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(75, 23);
            this.btnPlot.TabIndex = 0;
            this.btnPlot.Text = "Graficar";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // flowLayoutPanel_Top
            // 
            this.flowLayoutPanel_Top.AutoSize = true;
            this.flowLayoutPanel_Top.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel_Top.Controls.Add(this.btnPlot);
            this.flowLayoutPanel_Top.Controls.Add(this.cboxVariable);
            this.flowLayoutPanel_Top.Controls.Add(this.cboxStation);
            this.flowLayoutPanel_Top.Controls.Add(this.dtpDateTo);
            this.flowLayoutPanel_Top.Controls.Add(this.lblFrom);
            this.flowLayoutPanel_Top.Controls.Add(this.dtpDateFrom);
            this.flowLayoutPanel_Top.Controls.Add(this.label1);
            this.flowLayoutPanel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel_Top.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel_Top.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel_Top.Name = "flowLayoutPanel_Top";
            this.flowLayoutPanel_Top.Size = new System.Drawing.Size(1034, 29);
            this.flowLayoutPanel_Top.TabIndex = 10;
            // 
            // chartMain
            // 
            chartArea2.Name = "ChartArea1";
            this.chartMain.ChartAreas.Add(chartArea2);
            this.chartMain.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartMain.Legends.Add(legend2);
            this.chartMain.Location = new System.Drawing.Point(0, 29);
            this.chartMain.Name = "chartMain";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartMain.Series.Add(series2);
            this.chartMain.Size = new System.Drawing.Size(1034, 432);
            this.chartMain.TabIndex = 12;
            this.chartMain.Text = "chart1";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(496, 3);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(200, 20);
            this.dtpDateTo.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "To:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(251, 3);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpDateFrom.TabIndex = 15;
            // 
            // lblFrom
            // 
            this.lblFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(457, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 29);
            this.lblFrom.TabIndex = 13;
            this.lblFrom.Text = "From:";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GraphWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 461);
            this.Controls.Add(this.chartMain);
            this.Controls.Add(this.flowLayoutPanel_Top);
            this.Controls.Add(this.flowLayoutPanel_bottom);
            this.MinimumSize = new System.Drawing.Size(1050, 500);
            this.Name = "GraphWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "`";
            this.Load += new System.EventHandler(this.GraphWindow_Load);
            this.flowLayoutPanel_Top.ResumeLayout(false);
            this.flowLayoutPanel_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_bottom;
        private System.Windows.Forms.ComboBox cboxStation;
        private System.Windows.Forms.ComboBox cboxVariable;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Top;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMain;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label label1;
    }
}