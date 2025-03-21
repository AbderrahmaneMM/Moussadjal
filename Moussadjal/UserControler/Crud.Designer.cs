namespace Moussadjal.UserControler
{
    partial class Crud
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.Searchbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.Ajt = new Guna.UI2.WinForms.Guna2Button();
            this.modifier = new Guna.UI2.WinForms.Guna2Button();
            this.Suprimer = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.Searchbox);
            this.guna2Panel1.Controls.Add(this.Ajt);
            this.guna2Panel1.Controls.Add(this.modifier);
            this.guna2Panel1.Controls.Add(this.Suprimer);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(960, 61);
            this.guna2Panel1.TabIndex = 31;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // Searchbox
            // 
            this.Searchbox.AutoRoundedCorners = true;
            this.Searchbox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.Searchbox.BorderRadius = 17;
            this.Searchbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Searchbox.DefaultText = "";
            this.Searchbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Searchbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Searchbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Searchbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Searchbox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Searchbox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Searchbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.Searchbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Searchbox.IconRight = global::Moussadjal.Properties.Resources.icons8_search_50;
            this.Searchbox.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.Searchbox.IconRightOffset = new System.Drawing.Point(5, 0);
            this.Searchbox.Location = new System.Drawing.Point(349, 9);
            this.Searchbox.Margin = new System.Windows.Forms.Padding(0);
            this.Searchbox.Name = "Searchbox";
            this.Searchbox.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.Searchbox.PasswordChar = '\0';
            this.Searchbox.PlaceholderText = "Search";
            this.Searchbox.SelectedText = "";
            this.Searchbox.Size = new System.Drawing.Size(320, 36);
            this.Searchbox.TabIndex = 30;
            // 
            // Ajt
            // 
            this.Ajt.BackColor = System.Drawing.Color.Transparent;
            this.Ajt.BorderRadius = 22;
            this.Ajt.CheckedState.FillColor = System.Drawing.Color.White;
            this.Ajt.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.Ajt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Ajt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Ajt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Ajt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Ajt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.Ajt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Ajt.ForeColor = System.Drawing.Color.White;
            this.Ajt.Image = global::Moussadjal.Properties.Resources.icons8_add_40;
            this.Ajt.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Ajt.Location = new System.Drawing.Point(0, 3);
            this.Ajt.Margin = new System.Windows.Forms.Padding(0);
            this.Ajt.Name = "Ajt";
            this.Ajt.Size = new System.Drawing.Size(105, 50);
            this.Ajt.TabIndex = 27;
            this.Ajt.Text = "Ajouter";
            this.Ajt.UseTransparentBackground = true;
            this.Ajt.Click += new System.EventHandler(this.Ajt_Click);
            // 
            // modifier
            // 
            this.modifier.BackColor = System.Drawing.Color.Transparent;
            this.modifier.BorderRadius = 22;
            this.modifier.CheckedState.FillColor = System.Drawing.Color.White;
            this.modifier.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.modifier.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.modifier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.modifier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.modifier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.modifier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.modifier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.modifier.ForeColor = System.Drawing.Color.White;
            this.modifier.Image = global::Moussadjal.Properties.Resources.icons8_create_48;
            this.modifier.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.modifier.Location = new System.Drawing.Point(114, 3);
            this.modifier.Margin = new System.Windows.Forms.Padding(0);
            this.modifier.Name = "modifier";
            this.modifier.Size = new System.Drawing.Size(105, 50);
            this.modifier.TabIndex = 29;
            this.modifier.Text = "Modifier";
            this.modifier.UseTransparentBackground = true;
            this.modifier.Click += new System.EventHandler(this.modifier_Click);
            // 
            // Suprimer
            // 
            this.Suprimer.BackColor = System.Drawing.Color.Transparent;
            this.Suprimer.BorderRadius = 22;
            this.Suprimer.CheckedState.FillColor = System.Drawing.Color.White;
            this.Suprimer.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.Suprimer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Suprimer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Suprimer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Suprimer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Suprimer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            this.Suprimer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Suprimer.ForeColor = System.Drawing.Color.White;
            this.Suprimer.Image = global::Moussadjal.Properties.Resources.icons8_delete_button_24;
            this.Suprimer.Location = new System.Drawing.Point(228, 3);
            this.Suprimer.Margin = new System.Windows.Forms.Padding(0);
            this.Suprimer.Name = "Suprimer";
            this.Suprimer.Size = new System.Drawing.Size(105, 50);
            this.Suprimer.TabIndex = 28;
            this.Suprimer.Text = "Suprimer";
            this.Suprimer.UseTransparentBackground = true;
            // 
            // Crud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "Crud";
            this.Size = new System.Drawing.Size(960, 61);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public Guna.UI2.WinForms.Guna2Button Ajt;
        public Guna.UI2.WinForms.Guna2Button Suprimer;
        public Guna.UI2.WinForms.Guna2Button modifier;
        public Guna.UI2.WinForms.Guna2TextBox Searchbox;
    }
}
