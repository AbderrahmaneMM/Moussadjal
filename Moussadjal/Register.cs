using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.IO;
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
            Form1     f = new Form1();
            Database  d = new Database();
            dashboard da = new dashboard();
            MailAddress addr = new MailAddress(mailtextbox.Text);
              try
              {
                if (passwordtextbox.Text == confirmtextbox.Text &&  addr.Address == mailtextbox.Text)
                {
              
                    d.FillscdToInsert("INSERT INTO utilisateur (mail ,motdepass, username) VALUES('"+mailtextbox.Text+"', '"+passwordtextbox.Text+"', '"+usernametextbox.Text+"')");
                    MessageBox.Show("Utilisateur ajouté avec succès");
                    this.Hide();
                    da.Show();
                }
                   else 
                   {
                     f.Errorprovider(confirmtextbox, "Le mot de passe ne correspond pas");
                     f.Errorprovider(mailtextbox,   "Le format d'email n'est pas correct");
                   }
              }
              catch (Exception ex)
              {
                    MessageBox.Show(ex.Message);
              }
          
        }
      
        private void passwordtextbox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usernamekey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
               mailtextbox.Focus();
            }
        }

        private void mailkey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                passwordtextbox.Focus();
            }
        }

        private void passwkey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                confirmtextbox.Focus();
            }
        }

        private void confirmkey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
               guna2Button1.PerformClick();
            }
        }
    }
}
