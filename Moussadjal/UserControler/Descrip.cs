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

                if (db.FillscdToSelectCount("SELECT COUNT(*) FROM Description_de_bien WHERE designation = '" + guna2TextBox1.Text + "'") < 1)
                {
                    db.Ajouter("INSERT INTO Description_de_bien (numero_sequentiel, designation, division, annee, quantite, observation) VALUES ((SELECT ISNULL(MAX(numero_sequentiel), 0) + 1 FROM Description_de_bien), '" + guna2TextBox1.Text + "', '" + DivComboBox.SelectedValue.ToString() + "', '" + guna2DateTimePicker1.Text + "', '" + guna2NumericUpDown1.Value + "', '" + guna2TextBox2.Text + "')");
                    int newNumeroSequentiel = db.FillscdToSelectCount("SELECT COUNT(*) FROM Description_de_bien");

                    for (int i = 1 ; i <= guna2NumericUpDown1.Value; i++) 
                    { 
                       db.Ajouter($"INSERT INTO Bien (numero_dinventaire, numero_sequentiel, id_lieu) VALUES ((SELECT ISNULL(MAX(numero_dinventaire), 0) + 1 FROM Bien), '{newNumeroSequentiel}', 'Mgn')");
                    }
                    MessageBox.Show("add secsses", "kjio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Error: " ,"La Description de bien existe déjat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            guna2DateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
        }
    }
}
