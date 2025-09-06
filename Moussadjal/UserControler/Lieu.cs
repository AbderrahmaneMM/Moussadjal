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

namespace Moussadjal.UserControler
{
    public partial class Lieu : UserControl
    {
        public Lieu()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private void NStextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ajtbtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (db.FillscdToSelectCount("SELECT COUNT(*) FROM Lieu WHERE Id_lieu = '" + IdLtextbox.Text + "'") < 1)
                {
                    db.Ajouter("INSERT INTO Lieu (Id_lieu, designationLieu) VALUES ('" + IdLtextbox.Text + "', N'" + NomTextBox1.Text + "')");
                    MessageBox.Show("add secsses", NomTextBox1.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Ce Lieu existe déjat ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
