using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.Common;
using ZXing.Rendering;
using ZXing;

namespace Moussadjal.UserControler
{
    public partial class Descrip : UserControl
    {
        public Descrip()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private void Ajtbtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (db.FillscdToSelectCount("SELECT COUNT(*) FROM Description_de_bien WHERE numero_sequentiel = '" + int.Parse(NStextbox.Text) + "'") < 1)
                {
                    db.Ajouter("INSERT INTO Description_de_bien (numero_sequentiel, designation, division, annee, quantite, observation) VALUES ('" + int.Parse(NStextbox.Text) + "', '" +guna2TextBox1.Text+ "', '" + DivComboBox.SelectedValue.ToString() + "', '" + guna2DateTimePicker1.Value.Date + "', '" +guna2NumericUpDown1.Value+"', '" +guna2TextBox2.Text+"')");
                    MessageBox.Show("add secsses", NStextbox.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("La Description de bien existe déjat");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Descrip_Load(object sender, EventArgs e)
        {
            guna2DateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            db.remlirCombo("Division", DivComboBox, "designation" ,"division");
        }
    }
}
