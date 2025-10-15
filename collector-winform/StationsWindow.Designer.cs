namespace collector_winform
{
    partial class StationsWindow
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
            this.cboxField = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.flowLayoutPanel_bottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.flowLayoutPanel_Top.SuspendLayout();
            this.flowLayoutPanel_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 29);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(684, 203);
            this.dgvData.TabIndex = 6;
            // 
            // flowLayoutPanel_Top
            // 
            this.flowLayoutPanel_Top.AutoSize = true;
            this.flowLayoutPanel_Top.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel_Top.Controls.Add(this.btnSearch);
            this.flowLayoutPanel_Top.Controls.Add(this.txtValue);
            this.flowLayoutPanel_Top.Controls.Add(this.cboxCriteria);
            this.flowLayoutPanel_Top.Controls.Add(this.cboxField);
            this.flowLayoutPanel_Top.Controls.Add(this.lblSearch);
            this.flowLayoutPanel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel_Top.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel_Top.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel_Top.Name = "flowLayoutPanel_Top";
            this.flowLayoutPanel_Top.Size = new System.Drawing.Size(684, 29);
            this.flowLayoutPanel_Top.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(606, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(322, 3);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(278, 20);
            this.txtValue.TabIndex = 4;
            // 
            // cboxCriteria
            // 
            this.cboxCriteria.FormattingEnabled = true;
            this.cboxCriteria.Location = new System.Drawing.Point(195, 3);
            this.cboxCriteria.Name = "cboxCriteria";
            this.cboxCriteria.Size = new System.Drawing.Size(121, 21);
            this.cboxCriteria.TabIndex = 3;
            // 
            // cboxField
            // 
            this.cboxField.FormattingEnabled = true;
            this.cboxField.Location = new System.Drawing.Point(68, 3);
            this.cboxField.Name = "cboxField";
            this.cboxField.Size = new System.Drawing.Size(121, 21);
            this.cboxField.TabIndex = 2;
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(27, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(35, 29);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Filtrar:";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel_bottom
            // 
            this.flowLayoutPanel_bottom.AutoSize = true;
            this.flowLayoutPanel_bottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel_bottom.Controls.Add(this.btnDelete);
            this.flowLayoutPanel_bottom.Controls.Add(this.btnEdit);
            this.flowLayoutPanel_bottom.Controls.Add(this.btnAdd);
            this.flowLayoutPanel_bottom.Controls.Add(this.btnDetails);
            this.flowLayoutPanel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel_bottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel_bottom.Location = new System.Drawing.Point(0, 232);
            this.flowLayoutPanel_bottom.Name = "flowLayoutPanel_bottom";
            this.flowLayoutPanel_bottom.Size = new System.Drawing.Size(684, 29);
            this.flowLayoutPanel_bottom.TabIndex = 8;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(606, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(525, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(444, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(363, 3);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 6;
            this.btnDetails.Text = "Detalles";
            this.btnDetails.UseVisualStyleBackColor = true;
            // 
            // StationsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 261);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.flowLayoutPanel_Top);
            this.Controls.Add(this.flowLayoutPanel_bottom);
            this.MinimumSize = new System.Drawing.Size(700, 300);
            this.Name = "StationsWindow";
            this.Text = "Stations";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.flowLayoutPanel_Top.ResumeLayout(false);
            this.flowLayoutPanel_Top.PerformLayout();
            this.flowLayoutPanel_bottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Top;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ComboBox cboxCriteria;
        private System.Windows.Forms.ComboBox cboxField;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_bottom;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDetails;
    }
}