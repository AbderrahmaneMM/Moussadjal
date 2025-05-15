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
    public partial class RemplacerBien : UserControl
    {
        public RemplacerBien()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private void Ajtbtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable nsBien = db.DtOfSelect("SELECT TOP " + guna2NumericUpDown1.Value + " * FROM Bien WHERE numero_sequentiel = '" + Convert.ToInt32(NsComboBox.SelectedValue) + "'");
                int q = Convert.ToInt32(guna2NumericUpDown1.Value.ToString());
                for (int i = 0; i < q; i++) {
                    nsBien.Rows[i]["Id_lieu"] = LieuComboBox.SelectedValue.ToString(); }
                MessageBox.Show(q.ToString());
            }
            catch (Exception ex) {
               MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RemplacerBien_Load(object sender, EventArgs e)
        {
            db.remlirCombo("Description_de_bien", NsComboBox, "designation", "numero_sequentiel");
            db.remlirCombo("Lieu", LieuComboBox, "designationLieu", "Id_lieu");
        }
    }
}
