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
                 d.Fillscd("SELECT COUNT(*) FROM utilisateur WHERE mail = @mail AND motdepass = @motdepass");
                 d.scd.Parameters.AddWithValue("@mail", mailtextbox.Text);
                 d.scd.Parameters.AddWithValue("@motdepass", passwordtextbox.Text);
                 int result = (int)d.scd.ExecuteScalar();
                 if (result > 0)
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
             d.scn.Close();
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
    }
}
