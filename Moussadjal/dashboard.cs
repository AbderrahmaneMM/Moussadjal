using Guna.UI2.WinForms;
using Moussadjal.UserControler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;

namespace Moussadjal
{
    public partial class dashboard : Form1
    {
        public dashboard()
        {
            InitializeComponent();
        }

        AJTbien ab = new AJTbien();
        Division dv = new Division();


        private void dashboard_Load(object sender, EventArgs e)
        {

        }
        private void move(Guna2Button btn) 
        {
            btn.Checked =true;
            guna2PictureBox1.Location = new Point(btn.Location.X +116 , btn.Location.Y-23);
            guna2PictureBox1.SendToBack();
        }
        private void ExpandPanel(Guna2Button btn , FlowLayoutPanel pnl) 
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Guna2Button b && b != btn && b.Checked)
                    b.Checked = false;
                else if (control is FlowLayoutPanel fpl && fpl != pnl)
                    fpl.Height = 0;
            }
            if (btn.Checked)pnl.Height = 183;
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            ExpandPanel(guna2Button10, BienPanel);
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            ExpandPanel(guna2Button11, LieuPanel);
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            ExpandPanel(guna2Button12, RespoPanel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cpanel.Controls.Clear();
            Cpanel.Controls.Add(ab);
            ab.Dock = DockStyle.Fill;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Cpanel.Controls.Clear();
            Cpanel.Controls.Add(dv);
            dv.Dock = DockStyle.Fill;
        }

        private void Printbutton_Click(object sender, EventArgs e)
        {
            ExpandPanel(Printbutton, PrintPanel);
        }

        private void PrintPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
