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
        AJTbien ab = new AJTbien();
        DGVdescription dgv = new DGVdescription();
        Crud cr = new Crud();
        Database db = new Database();
        public dashboard()
        {
            InitializeComponent();
            cr.Ajt.Click      += Ajouter; 
            cr.modifier.Click += Modifier;
            cr.Suprimer.Click += button6_Click;
        }

        public void Ajouter(object sender, EventArgs e)
        {

            Cpanel.Controls.Clear();
            Cpanel.Controls.Add(ab);
            ab.Dock = DockStyle.Fill;

        }
        public void Modifier(object sender, EventArgs e)
        {
            dgv.dtgdve.SelectedRows[0].Cells["ID"].Value.ToString();
            
            
            
            
            




            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(txtDesignation.Text))
                {
                    MessageBox.Show("La désignation ne peut pas être vide.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update database

                {//numero_sequentiel, designation, division, annee, quantite, photo, observation
                  db.Modifier("UPDATE Description_de_bien  SET numero_sequentiel = '"+dgv.dtgdve.SelectedRows[0].Cells["NS"].Value.ToString();+"', designation = '"+dgv.dtgdve.SelectedRows[0].Cells["DESIGNATION"].Value.ToString();+"', division = '"+dgv.dtgdve.SelectedRows[0].Cells["DIV"].Value.ToString();+"', annee = '"+dgv.dtgdve.SelectedRows[0].Cells["ANNEE"].Value.ToString();+"', quantite = '"+dgv.dtgdve.SelectedRows[0].Cells["QUANTITE"].Value.ToString();+"', photo = '"+dgv.dtgdve.SelectedRows[0].Cells["PHOTO"].Value.ToString();+"',  observation = '"+dgv.dtgdve.SelectedRows[0].Cells["OBSERVATION"].Value.ToString();+"' WHERE numero_sequentiel = '"+dgv.dtgdve.SelectedRows[0].Cells["NS"].Value.ToString();+"'");

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Modification effectuée avec succès.", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Notify parent form to refresh data
                        OnDataUpdated(EventArgs.Empty);

                        // Return to main view (clear panel)
                        Parent.Controls.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Aucune modification n'a été effectuée.", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
            
        }

        private void ExpandPanel(Guna2Button btn , FlowLayoutPanel pnl) 
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Guna2Button b && b != btn && b.Checked)
                    b.Checked = false;
                else if (control is FlowLayoutPanel fpl && fpl != pnl)
                    fpl.Height = 0;
            }
            if (btn.Checked)pnl.Height = 183;
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            ExpandPanel(guna2Button10, BienPanel);
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

        
    }
}
