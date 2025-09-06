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
    public partial class AjtAff : UserControl
    {
        public AjtAff()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private void Ajtbtn_Click(object sender, EventArgs e)
        {
            try
            { 
            if (db.FillscdToSelectCount("SELECT COUNT(*) FROM Affectation") < 1)
            {
                db.Ajouter("INSERT INTO Affectation (Id_Affectation,Id_Responsable, Id_lieu) VALUES ((SELECT ISNULL(MAX(Id_Affectation), 0) + 1 FROM Affectation),'" + RComboBox.SelectedValue.ToString() + "', '" + LieuComboBox.SelectedValue.ToString() + "')");
                MessageBox.Show("add secsses", RComboBox.Text+"on"+ LieuComboBox.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error: ", "L'Affectation' existe déjat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AjtAff_Load(object sender, EventArgs e)
        {
            db.remlirCombo("Lieu", LieuComboBox, "designationLieu", "Id_lieu");
            db.remlirCombo("Responsable", RComboBox, "nometprénom", "Id_Responsable");
        }
    }
}
