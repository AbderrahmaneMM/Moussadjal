using Guna.UI2.WinForms;
using Moussadjal.UserControler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;

namespace Moussadjal
{
    public partial class dashboard : Form1
    {
        AJTbien        ab = new AJTbien();
        DGVdescription dgv = new DGVdescription();
        Crud           cr = new Crud();
        Database       db = new Database();

        UserControl UC;
        //pour la modification
        string Mq;
        string dgvM;
        public dashboard()
        {
            InitializeComponent();
            cr.Ajt.Click      += Ajouter; 
            cr.modifier.Click += Modifier;
            cr.Suprimer.Click += button6_Click;
        }
        public void UCAjouter(UserControl uc)
        {
            if (uc == null) return;

            Cpanel.Controls.Clear();
            Cpanel.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }
        public void Ajouter(object sender, EventArgs e)
        {
            UCAjouter(UC);
        }
        public void Modifier(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dgvM))
                {
                    MessageBox.Show("Le numero_sequentiel ne peut pas être vide.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (db.Modifier(Mq) > 0)
                {
                    MessageBox.Show("Modification effectuée avec succès.", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);


                    dgv.OnDataUpdated(EventArgs.Empty);

                }
                else
                {
                    MessageBox.Show("Aucune modification n'a été effectuée.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dashboard_Load(object sender, EventArgs e)
        {
         

            AJTbien ab = new AJTbien();
            DGVdescription dgv = new DGVdescription();
            Crud cr = new Crud();  

            UCAjouter(ab);
        }

       
        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {

            ExpandPanel(guna2Button10, BienPanel);
            UC = ab;
            dgvM = dgv.dtgdve.SelectedRows[0].Cells["NS"].Value.ToString(); ;
            // Check if there are any selected rows before trying to access them
            if (dgv.dtgdve.SelectedRows.Count > 0)
            {

                string ns = dgv.dtgdve.SelectedRows[0].Cells["NS"].Value.ToString();
                string dsg = dgv.dtgdve.SelectedRows[0].Cells["DESIGNATION"].Value.ToString();
                string div = dgv.dtgdve.SelectedRows[0].Cells["DIV"].Value.ToString();
                string an = dgv.dtgdve.SelectedRows[0].Cells["ANNEE"].Value.ToString();
                string qt = dgv.dtgdve.SelectedRows[0].Cells["QUANTITE"].Value.ToString();
                string ph = dgv.dtgdve.SelectedRows[0].Cells["PHOTO"].Value.ToString();
                string obs = dgv.dtgdve.SelectedRows[0].Cells["OBSERVATION"].Value.ToString();

                Mq = "UPDATE Description_de_bien SET numero_sequentiel = '" + ns +
                     "', designation = '" + dsg +
                     "', division = '" + div +
                     "', annee = '" + an +
                     "', quantite = '" + qt +
                     "', photo = '" + ph +
                     "', observation = '" + obs +
                     "' WHERE numero_sequentiel = '" + ns + "'";
            }
            else
            {
                // Show a message to the user indicating they need to select a row
                MessageBox.Show("Veuillez sélectionner une ligne dans le tableau.", "Aucune ligne sélectionnée",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear Mq and dgvM since there's no selection
                Mq = string.Empty;
                dgvM = string.Empty;
            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            ExpandPanel(guna2Button11, LieuPanel);
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            ExpandPanel(guna2Button12, RespoPanel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* Cpanel.Controls.Clear();
            Cpanel.Controls.Add(ab);
            ab.Dock = DockStyle.Fill;*/

        }
        private void button6_Click(object sender, EventArgs e)
        {

            
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void Printbutton_Click(object sender, EventArgs e)
        {
            ExpandPanel(Printbutton, PrintPanel);
        }

        private void PrintPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
             Cpanel.Controls.Clear();

             Cpanel.Controls.Add(dgvPanel);
             dgvPanel.Dock = DockStyle.Fill;

            
             Cpanel.Controls.Add(cr);
             cr.Dock = DockStyle.Top;

             dgvPanel.Controls.Clear();

             dgvPanel.Controls.Add(dgv);
             dgv.Dock = DockStyle.Fill;
             dgv.Padding = new Padding(3,5,5,5);
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
          Cpanel.Size = new Size(guna2Panel1.Width-15, flowLayoutPanel1.Height-guna2Panel1.Height);
        }

        private void Cpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
