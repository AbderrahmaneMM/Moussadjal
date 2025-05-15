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
using Guna.UI2.WinForms;

namespace Moussadjal.UserControler
{
    public partial class Descrip : UserControl
    {
        public Descrip()
        {
            InitializeComponent();
        }
        Database db = new Database();
        Form1 f = new Form1();
        private void Ajtbtn_Click(object sender, EventArgs e)
        {
          
            if (guna2CheckBox2.Checked)
            {

                try
                {

                    if (db.FillscdToSelectCount("SELECT COUNT(*) FROM Description_de_bien WHERE designation = '" + guna2TextBox3.Text + "' OR numero_sequentiel = '" + NsTextbox.Text + "' ") < 1)
                    {
                        db.Ajouter("INSERT INTO Description_de_bien (numero_sequentiel, designation, division, quantite, observation) VALUES ('" + NsTextbox.Text + "', '" + guna2TextBox3.Text + "', '" + DivComboBox.SelectedValue.ToString() + "' ,'" + guna2NumericUpDown1.Value + "', '" + guna2TextBox2.Text + "')");
                        MessageBox.Show("add secsses", "kjio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   }
                    else
                    {
                        MessageBox.Show("Error: ", "La Description de bien existe déjat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                      
                        f.Errorprovider(NsTextbox, "numero_sequentiel existe");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                try
                {

                    if (db.FillscdToSelectCount("SELECT COUNT(*) FROM Description_de_bien WHERE designation = '" + guna2TextBox3.Text + "' ") < 1)
                    {
                        db.Ajouter("INSERT INTO Description_de_bien (numero_sequentiel, designation, division, quantite, observation) VALUES ((SELECT ISNULL(MAX(numero_sequentiel), 0) + 1 FROM Description_de_bien), '" + guna2TextBox3.Text + "', '" + DivComboBox.SelectedValue.ToString() + "' ,'" +  guna2NumericUpDown1.Value + "', '" + guna2TextBox2.Text + "')");
                        int newNumeroSequentiel = db.FillscdToSelectCount("SELECT COUNT(*) FROM Description_de_bien");

                        for (int i = 1; i <= guna2NumericUpDown1.Value; i++)
                        {
                            db.Ajouter($"INSERT INTO Bien (numero_dinventaire, numero_sequentiel, id_lieu, Annee) VALUES ((SELECT ISNULL(MAX(numero_dinventaire), 0) + 1 FROM Bien), '{newNumeroSequentiel}', '" + LieuComboBox.SelectedValue.ToString() + "','" + DateTime.Now.Year.ToString() + "')");
                        }
                        MessageBox.Show("add secsses", "kjio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    {         MessageBox.Show("Error: ", "La Description de bien existe déjat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //errorprovider textbox3
                        f.Errorprovider(guna2TextBox3, "numero_sequentiel existe");
                     }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            }
          
        }

        private void Descrip_Load(object sender, EventArgs e)
        {
            db.remlirCombo("Division", DivComboBox, "designation" ,"division");
           db.remlirCombo("Lieu", LieuComboBox, "designationLieu", "Id_lieu");
            LieuComboBox.SelectedIndex = 45;
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            //existe
            if (guna2CheckBox2.Checked) NsTextbox.Enabled = true;
            else NsTextbox.Enabled = false;
        }
    }
}
