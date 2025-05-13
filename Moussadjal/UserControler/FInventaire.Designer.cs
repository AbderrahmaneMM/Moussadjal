namespace Moussadjal.UserControler
{
    partial class FInventaire
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FInventaire));
            this.DocPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.DGVA = new Guna.UI2.WinForms.Guna2DataGridView();
            this.DGVD = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.DocPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVD)).BeginInit();
            this.SuspendLayout();
            // 
            // DocPanel
            // 
            this.DocPanel.BackColor = System.Drawing.Color.Transparent;
            this.DocPanel.Controls.Add(this.panel2);
            this.DocPanel.Controls.Add(this.DGVA);
            this.DocPanel.Controls.Add(this.DGVD);
            this.DocPanel.Controls.Add(this.label5);
            this.DocPanel.Controls.Add(this.label4);
            this.DocPanel.Controls.Add(this.label3);
            this.DocPanel.Location = new System.Drawing.Point(16, 83);
            this.DocPanel.Name = "DocPanel";
            this.DocPanel.Size = new System.Drawing.Size(2940, 2003);
            this.DocPanel.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(2748, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(173, 39);
            this.panel2.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(99, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 19);
            this.label7.TabIndex = 23;
            this.label7.Text = "صفحة 01";
            // 
            // DGVA
            // 
            this.DGVA.AllowUserToAddRows = false;
            this.DGVA.AllowUserToDeleteRows = false;
            this.DGVA.AllowUserToOrderColumns = true;
            this.DGVA.AllowUserToResizeColumns = false;
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVA.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle33;
            this.DGVA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DGVA.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.DGVA.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle34.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVA.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.DGVA.ColumnHeadersHeight = 100;
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVA.DefaultCellStyle = dataGridViewCellStyle35;
            this.DGVA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGVA.GridColor = System.Drawing.Color.Black;
            this.DGVA.Location = new System.Drawing.Point(329, 159);
            this.DGVA.MultiSelect = false;
            this.DGVA.Name = "DGVA";
            this.DGVA.ReadOnly = true;
            this.DGVA.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DGVA.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGVA.RowHeadersVisible = false;
            this.DGVA.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle36.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVA.RowsDefaultCellStyle = dataGridViewCellStyle36;
            this.DGVA.RowTemplate.Height = 30;
            this.DGVA.RowTemplate.ReadOnly = true;
            this.DGVA.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGVA.Size = new System.Drawing.Size(2592, 1468);
            this.DGVA.TabIndex = 33;
            this.DGVA.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVA.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGVA.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGVA.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(184)))), ((int)(((byte)(40)))));
            this.DGVA.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DGVA.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGVA.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.DGVA.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(184)))), ((int)(((byte)(40)))));
            this.DGVA.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.DGVA.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Calibri", 9F);
            this.DGVA.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGVA.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVA.ThemeStyle.HeaderStyle.Height = 100;
            this.DGVA.ThemeStyle.ReadOnly = true;
            this.DGVA.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVA.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.DGVA.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGVA.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGVA.ThemeStyle.RowsStyle.Height = 30;
            this.DGVA.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGVA.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // DGVD
            // 
            this.DGVD.AllowUserToAddRows = false;
            this.DGVD.AllowUserToDeleteRows = false;
            this.DGVD.AllowUserToOrderColumns = true;
            this.DGVD.AllowUserToResizeColumns = false;
            dataGridViewCellStyle37.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle37.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle37.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle37.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle37.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVD.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle37;
            this.DGVD.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DGVD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.DGVD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle38.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle38.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle38.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle38.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle38;
            this.DGVD.ColumnHeadersHeight = 100;
            this.DGVD.ColumnHeadersVisible = false;
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle39.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle39.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVD.DefaultCellStyle = dataGridViewCellStyle39;
            this.DGVD.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGVD.GridColor = System.Drawing.Color.Black;
            this.DGVD.Location = new System.Drawing.Point(17, 243);
            this.DGVD.MultiSelect = false;
            this.DGVD.Name = "DGVD";
            this.DGVD.ReadOnly = true;
            this.DGVD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DGVD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGVD.RowHeadersVisible = false;
            this.DGVD.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle40.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle40.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVD.RowsDefaultCellStyle = dataGridViewCellStyle40;
            this.DGVD.RowTemplate.Height = 30;
            this.DGVD.RowTemplate.ReadOnly = true;
            this.DGVD.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGVD.Size = new System.Drawing.Size(313, 1384);
            this.DGVD.TabIndex = 32;
            this.DGVD.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVD.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGVD.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGVD.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(184)))), ((int)(((byte)(40)))));
            this.DGVD.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DGVD.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGVD.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.DGVD.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(184)))), ((int)(((byte)(40)))));
            this.DGVD.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.DGVD.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGVD.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGVD.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVD.ThemeStyle.HeaderStyle.Height = 100;
            this.DGVD.ThemeStyle.ReadOnly = true;
            this.DGVD.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVD.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.DGVD.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGVD.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGVD.ThemeStyle.RowsStyle.Height = 30;
            this.DGVD.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGVD.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(531, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 22);
            this.label5.TabIndex = 31;
            this.label5.Text = "DIVISION :A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(915, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(396, 24);
            this.label4.TabIndex = 30;
            this.label4.Text = " FUILLE  D\'INVENTAIRE  AU 31/12/2023";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sakkal Majalla", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(356, 32);
            this.label3.TabIndex = 29;
            this.label3.Text = "المعهد الوطني المتخصص في التكوين المهني بواسماعيل";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 16;
            this.guna2Button1.CheckedState.FillColor = System.Drawing.Color.White;
            this.guna2Button1.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(16, 11);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(58, 56);
            this.guna2Button1.TabIndex = 23;
            this.guna2Button1.Text = "Print";
            this.guna2Button1.UseTransparentBackground = true;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // FInventaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.DocPanel);
            this.Name = "FInventaire";
            this.Size = new System.Drawing.Size(2970, 2100);
            this.Load += new System.EventHandler(this.FInventaire_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            this.DocPanel.ResumeLayout(false);
            this.DocPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DocPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        public Guna.UI2.WinForms.Guna2DataGridView DGVA;
        public Guna.UI2.WinForms.Guna2DataGridView DGVD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}
