namespace collector_winform
{
    partial class PollingWindow
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPolling = new System.Windows.Forms.Label();
            this.btnPolling = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.txtLog);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(656, 271);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.lblPolling);
            this.flowLayoutPanel2.Controls.Add(this.btnPolling);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(129, 29);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // lblPolling
            // 
            this.lblPolling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPolling.AutoSize = true;
            this.lblPolling.Location = new System.Drawing.Point(3, 0);
            this.lblPolling.MinimumSize = new System.Drawing.Size(42, 0);
            this.lblPolling.Name = "lblPolling";
            this.lblPolling.Size = new System.Drawing.Size(42, 29);
            this.lblPolling.TabIndex = 7;
            this.lblPolling.Text = "Polling:";
            this.lblPolling.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPolling
            // 
            this.btnPolling.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPolling.Location = new System.Drawing.Point(51, 3);
            this.btnPolling.Name = "btnPolling";
            this.btnPolling.Size = new System.Drawing.Size(75, 23);
            this.btnPolling.TabIndex = 6;
            this.btnPolling.Text = "Disabled";
            this.btnPolling.UseVisualStyleBackColor = false;
            this.btnPolling.Click += new System.EventHandler(this.btnPolling_Click);
            // 
            // txtLog
            // 
            this.txtLog.AllowDrop = true;
            this.txtLog.Location = new System.Drawing.Point(3, 38);
            this.txtLog.MaximumSize = new System.Drawing.Size(650, 230);
            this.txtLog.MinimumSize = new System.Drawing.Size(650, 230);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(650, 230);
            this.txtLog.TabIndex = 1;
            // 
            // PollingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 271);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(672, 310);
            this.MinimumSize = new System.Drawing.Size(672, 310);
            this.Name = "PollingWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Polling";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.PollingWindow_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblPolling;
        private System.Windows.Forms.Button btnPolling;
    }
}