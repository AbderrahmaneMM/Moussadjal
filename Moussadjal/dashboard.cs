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

namespace Moussadjal
{
    public partial class dashboard : Form1
    {
        public dashboard()
        {
            InitializeComponent();
        }
        private void move(Guna2Button btn) 
        {
            btn.Checked =true;
            guna2PictureBox1.Location = new Point(btn.Location.X +116 , btn.Location.Y-23);
            guna2PictureBox1.SendToBack();
        }
        private void dashboard_Load(object sender, EventArgs e)
        {

        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*private void Homebutton_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }*/

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            move(guna2Button1);
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            move(guna2Button2);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            move(guna2Button3);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            move(guna2Button4);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            move(guna2Button5);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            move(guna2Button6);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            move(guna2Button7);
        }

        private void gererlesbien1_Load(object sender, EventArgs e)
        {

        }
    }
}
