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
    public partial class Register : Form1
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l= new Login();
            l.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Database d = new Database();
            dashboard da = new dashboard();
            try
            {
                d.Fillscd("INSERT INTO users (name,motdepass) VALUES(@name,@motdepass)");
                d.scd.Parameters.AddWithValue("@name", mailtextbox.Text);
                d.scd.Parameters.AddWithValue("@motdepass", int.Parse(passwordtextbox.Text));
                d.scd.ExecuteNonQuery();
                MessageBox.Show("User added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            d.scn.Close();
        }
    }
}
