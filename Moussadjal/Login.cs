using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
// Viréfication
namespace Moussadjal
{
    public partial class Login : Form1
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void guna2VSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {        
           Database d = new Database();
           dashboard da = new dashboard();
            try
            { 
                 if (d.FillscdToSelectCount("SELECT COUNT(*) FROM utilisateur WHERE mail = '" + mailtextbox.Text + "' AND motdepass = '" + passwordtextbox.Text + "'") > 0)
                 {
                     this.Hide();
                     da.Show();
                 }
                 else
                     MessageBox.Show("Nom d'utilisateur ou mot de passe invalide");
            }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
           
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register r = new Register();
            r.Show();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mailtxtboxkey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                passwordtextbox.Focus();
            }
        }

        private void motdepasskey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                guna2Button1.PerformClick();
            }
        }
    }
}
