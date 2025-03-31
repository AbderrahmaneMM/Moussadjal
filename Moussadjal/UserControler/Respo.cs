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
    public partial class Respo : UserControl
    {
        public Respo()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private void Ajtbtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (db.FillscdToSelectCount("SELECT COUNT(*) FROM Responsable WHERE Id_Responsable = '" + IdRtextbox.Text + "'") < 1)
                {
                    db.Ajouter("INSERT INTO Responsable (Id_Responsable, nometprénom) VALUES ('" + IdRtextbox.Text + "', '" + NomTextBox1.Text + "')");
                    MessageBox.Show("add secsses", NomTextBox1.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Ce Responsable existe déjat");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
