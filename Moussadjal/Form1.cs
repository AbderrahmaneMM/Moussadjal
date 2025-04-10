using Guna.UI2.WinForms;
using Moussadjal.UserControler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moussadjal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      
        public void Errorprovider(Guna2TextBox x,string m)
        {
           ErrorProvider ep = new ErrorProvider();
            ep.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            ep.SetError(x,m);
            x.BorderColor = Color.Red;
        }
        
        public void datagridviewStyle(Guna2DataGridView dg)
        {
            Color primaryColor = Color.FromArgb(0, 180, 216);
            Color secondaryColor = Color.FromArgb(112, 128, 144);
            Color accentColor = Color.FromArgb(125, 184, 40);

            // Main styling
            dg.BackgroundColor = Color.White;
            dg.ThemeStyle.BackColor = Color.White; // Guna-specific
            dg.GridColor = secondaryColor;

            // Column headers
            dg.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dg.ThemeStyle.HeaderStyle.BackColor = primaryColor; // Guna-specific
            dg.ThemeStyle.HeaderStyle.ForeColor = Color.White;

            // Rows
            dg.DefaultCellStyle.BackColor = Color.White;
            dg.DefaultCellStyle.ForeColor = Color.Black;
            dg.AlternatingRowsDefaultCellStyle.BackColor = secondaryColor;
            dg.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

            // Selection styling (critical for Guna2)
            dg.ThemeStyle.RowsStyle.SelectionBackColor = accentColor; // Guna-specific
            dg.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
            dg.DefaultCellStyle.SelectionBackColor = accentColor; // Fallback
            dg.DefaultCellStyle.SelectionForeColor = Color.White;

            // Fonts
            dg.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dg.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            // Sizing
            dg.ColumnHeadersHeight = 30;
            dg.RowTemplate.Height = 25;
        }

        public void ExpandPanel(Guna2Button btn, FlowLayoutPanel pnl)
        {
            FlowLayoutPanel parentPanel = (FlowLayoutPanel)btn.Parent;

            foreach (Control c in parentPanel.Controls)
            {
                if (c is FlowLayoutPanel panel)
                {
                    if (panel == pnl && btn.Checked) panel.Height = 86; 

                    else panel.Height = 0;
                }
            }
        }

    
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
