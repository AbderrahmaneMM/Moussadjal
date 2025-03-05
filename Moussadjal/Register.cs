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

              try
              {
                MailAddress addr = new MailAddress(mailtextbox.Text);
            
                if (passwordtextbox.Text == confirmtextbox.Text &&  addr.Address == mailtextbox.Text)
                {
              
                    d.Fillscd("INSERT INTO utilisateur (mail ,motdepass, username) VALUES(@mail, @motdepass, @username)");
                    d.scd.Parameters.AddWithValue("@mail", mailtextbox.Text);
                    d.scd.Parameters.AddWithValue("@motdepass", passwordtextbox.Text);
                    d.scd.Parameters.AddWithValue("@username", usernametextbox.Text);
                    d.scd.ExecuteNonQuery();
                    d.scn.Close();
                    MessageBox.Show("Utilisateur ajouté avec succès");
                    this.Hide();
                    da.Show();
                }
                   else {
                     f.Errorprovider(confirmtextbox, "Le mot de passe ne correspond pas");
                     f.Errorprovider(mailtextbox,   "Le format d'email n'est pas correct");
                   }
              }
              catch (Exception ex)
              {
                    MessageBox.Show(ex.Message);
              }
          
        }
    }
}
