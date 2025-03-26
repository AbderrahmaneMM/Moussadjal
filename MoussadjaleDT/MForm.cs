using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoussadjaleDT
{
    public partial class MForm : Form
    {
        public MForm()
        {
            InitializeComponent();
        }

        private void MForm_Load(object sender, EventArgs e)
        {

        }
        public void Errorprovider(Guna2TextBox x, string m)
        {
            ErrorProvider ep = new ErrorProvider();
            ep.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            ep.SetError(x, m);
            x.BorderColor = Color.Red;
        }
        public void datagridviewStyle(Guna2DataGridView dtgdve)
        {
            Color primaryColor = Color.FromArgb(0, 180, 216);
            Color secondaryColor = Color.FromArgb(112, 128, 144);
            Color accentColor = Color.FromArgb(125, 184, 40);

            // Main styling
            dtgdve.BackgroundColor = Color.White;
            dtgdve.ThemeStyle.BackColor = Color.White; // Guna-specific
            dtgdve.GridColor = secondaryColor;

            // Column headers
            dtgdve.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dtgdve.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dtgdve.ThemeStyle.HeaderStyle.BackColor = primaryColor; // Guna-specific
            dtgdve.ThemeStyle.HeaderStyle.ForeColor = Color.White;

            // Rows
            dtgdve.DefaultCellStyle.BackColor = Color.White;
            dtgdve.DefaultCellStyle.ForeColor = Color.Black;
            dtgdve.AlternatingRowsDefaultCellStyle.BackColor = secondaryColor;
            dtgdve.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

            // Selection styling (critical for Guna2)
            dtgdve.ThemeStyle.RowsStyle.SelectionBackColor = accentColor; // Guna-specific
            dtgdve.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
            dtgdve.DefaultCellStyle.SelectionBackColor = accentColor; // Fallback
            dtgdve.DefaultCellStyle.SelectionForeColor = Color.White;

            // Fonts
            dtgdve.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dtgdve.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            // Sizing
            dtgdve.ColumnHeadersHeight = 30;
            dtgdve.RowTemplate.Height = 25;
        }

        public void ExpandPanel(Guna2Button btn, FlowLayoutPanel pnl)
        {
            dashboard dbh = new dashboard();
            //foreach (Control control in dbh.flowLayoutPanel1.Controls)
            //{
            //    if (control is Guna2Button b && b != btn && b.Checked)
            //        b.Checked = false;
            //    else if (control is FlowLayoutPanel fpl && fpl != pnl)
            //        fpl.Height = 0;
            //}
            if (btn.Checked) pnl.Height = 183;
        }
    }
}
