namespace Moussadjal.UserControler
{
    partial class FRecollement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRecollement));
            this.DocPanel = new System.Windows.Forms.Panel();
            this.DGV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LieuComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.DocPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DocPanel
            // 
            this.DocPanel.BackColor = System.Drawing.Color.Transparent;
            this.DocPanel.Controls.Add(this.label9);
            this.DocPanel.Controls.Add(this.label8);
            this.DocPanel.Controls.Add(this.DGV);
            this.DocPanel.Controls.Add(this.label7);
            this.DocPanel.Controls.Add(this.label6);
            this.DocPanel.Controls.Add(this.label2);
            this.DocPanel.Controls.Add(this.label1);
            this.DocPanel.Controls.Add(this.label5);
            this.DocPanel.Controls.Add(this.label4);
            this.DocPanel.Controls.Add(this.label3);
            this.DocPanel.Location = new System.Drawing.Point(3, 78);
            this.DocPanel.Name = "DocPanel";
            this.DocPanel.Size = new System.Drawing.Size(1130, 826);
            this.DocPanel.TabIndex = 0;
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToOrderColumns = true;
            this.DGV.AllowUserToResizeColumns = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV.ColumnHeadersHeight = 30;
            this.DGV.ColumnHeadersVisible = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.DefaultCellStyle = dataGridViewCellStyle7;
            this.DGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGV.GridColor = System.Drawing.Color.Black;
            this.DGV.Location = new System.Drawing.Point(5, 301);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGV.RowHeadersVisible = false;
            this.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DGV.RowTemplate.Height = 30;
            this.DGV.RowTemplate.ReadOnly = true;
            this.DGV.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGV.Size = new System.Drawing.Size(1117, 477);
            this.DGV.TabIndex = 49;
            this.DGV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGV.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(184)))), ((int)(((byte)(40)))));
            this.DGV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DGV.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGV.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.DGV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(184)))), ((int)(((byte)(40)))));
            this.DGV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.DGV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV.ThemeStyle.HeaderStyle.Height = 30;
            this.DGV.ThemeStyle.ReadOnly = true;
            this.DGV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.DGV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGV.ThemeStyle.RowsStyle.Height = 30;
            this.DGV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.White;
            this.DGV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(22, 781);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(910, 19);
            this.label7.TabIndex = 48;
            this.label7.Text = "L’utilisateur                            Magasinier                              " +
    "      Comptable matière                                    DAF                  " +
    "            Directeur";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(11, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 19);
            this.label6.TabIndex = 47;
            this.label6.Text = "Localisation :    ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sakkal Majalla", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(921, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 32);
            this.label2.TabIndex = 46;
            this.label2.Text = "وزارة التكوين والتعليم المهنيين";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sakkal Majalla", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(408, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 32);
            this.label1.TabIndex = 45;
            this.label1.Text = "الجمهورية الجزائرية الديمقراطية الشعبية";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(11, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(227, 19);
            this.label5.TabIndex = 44;
            this.label5.Text = "Affectataire: Nom et Prénom:     ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(281, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(569, 22);
            this.label4.TabIndex = 43;
            this.label4.Text = "  FICHE  DE  RECOLLEMENT  D\'INVENTAIRE    AU 31-12-2023";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sakkal Majalla", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(356, 32);
            this.label3.TabIndex = 42;
            this.label3.Text = "المعهد الوطني المتخصص في التكوين المهني بواسماعيل";
            // 
            // LieuComboBox
            // 
            this.LieuComboBox.AutoRoundedCorners = true;
            this.LieuComboBox.BackColor = System.Drawing.Color.Transparent;
            this.LieuComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.LieuComboBox.BorderRadius = 17;
            this.LieuComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LieuComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LieuComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.LieuComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.LieuComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LieuComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.LieuComboBox.ItemHeight = 30;
            this.LieuComboBox.Location = new System.Drawing.Point(107, 20);
            this.LieuComboBox.Name = "LieuComboBox";
            this.LieuComboBox.Size = new System.Drawing.Size(254, 36);
            this.LieuComboBox.TabIndex = 30;
            this.LieuComboBox.SelectedIndexChanged += new System.EventHandler(this.LieuComboBox_SelectedIndexChanged);
            this.LieuComboBox.Click += new System.EventHandler(this.LieuComboBox_Click);
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
            this.guna2Button1.Location = new System.Drawing.Point(18, 0);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(58, 56);
            this.guna2Button1.TabIndex = 29;
            this.guna2Button1.Text = "Print";
            this.guna2Button1.UseTransparentBackground = true;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(132, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 19);
            this.label8.TabIndex = 50;
            this.label8.Text = " ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(244, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 19);
            this.label9.TabIndex = 51;
            this.label9.Text = " ";
            // 
            // FRecollement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.LieuComboBox);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.DocPanel);
            this.Name = "FRecollement";
            this.Size = new System.Drawing.Size(1136, 907);
            this.Load += new System.EventHandler(this.FRecollement_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint2);
            this.DocPanel.ResumeLayout(false);
            this.DocPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DocPanel;
        public Guna.UI2.WinForms.Guna2DataGridView DGV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox LieuComboBox;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}
