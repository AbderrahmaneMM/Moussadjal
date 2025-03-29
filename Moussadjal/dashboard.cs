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
        Descrip dscrip = new Descrip();
        Database       db = new Database();

        UserControl UC;
        //pour la modification et la supresion
      //  Guna2DataGridView gdgv = new Guna2DataGridView();
        string Mq;
        string Sq;
        string dgvM;
        public dashboard()
        {
            InitializeComponent();
            cr.Ajt.Click      += Ajouter; 
            cr.modifier.Click += Modifier;
            cr.Suprimer.Click += Suprimer;
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
                    MessageBox.Show("la 1ere column est vide", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else db.Enregistrer(Mq, dgv.dtgdve);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Suprimer(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment supprimer cet enregistrement?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                db.Suprimer(Sq);
            dgv.dtgdve.Rows.Remove(dgv.dtgdve.CurrentRow);

        }
        private void dashboard_Load(object sender, EventArgs e)
        {
         
            AJTbien ab = new AJTbien();
            DGVdescription dgv = new DGVdescription();
            Crud cr = new Crud();
            Descrip dscrip = new Descrip();

            UCAjouter(ab);
        }

       
        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            ExpandPanel(guna2Button10, BienPanel);
            dgv.Bien();
            UC = ab;

            Cpanel.Controls.Clear();

            Cpanel.Controls.Add(dgvPanel);
            dgvPanel.Dock = DockStyle.Fill;


            Cpanel.Controls.Add(cr);
            cr.Dock = DockStyle.Top;

            dgvPanel.Controls.Clear();

            dgvPanel.Controls.Add(dgv);
            dgv.Dock = DockStyle.Fill;
            dgv.Padding = new Padding(3, 5, 5, 5);

          
            dgvM = dgv.dtgdve.SelectedRows[0].Cells["numero_dinventaire"].Value.ToString();
            string deleteRow = dgv.dtgdve.CurrentRow.Cells["numero_dinventaire"].Value.ToString();

                Mq = "select numero_dinventaire, numero_sequentiel, Id_lieu from Bien";
                Sq = "delete from Bien where numero_dinventaire = " + deleteRow;
            
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
            UCAjouter(ab);
          
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
            guna2Button10_Click( sender,  e);
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
          Cpanel.Size = new Size(guna2Panel1.Width-15, flowLayoutPanel1.Height-guna2Panel1.Height);
        }

        private void Cpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ExpandPanel(guna2Button1,DescriPanel);
            dgv.Description();
            UC = dscrip;

            Cpanel.Controls.Clear();


            Cpanel.Controls.Add(dgvPanel);
            dgvPanel.Dock = DockStyle.Fill;

            Cpanel.Controls.Add(cr);
            cr.Dock = DockStyle.Top;

            dgvPanel.Controls.Clear();

            dgvPanel.Controls.Add(dgv);
            dgv.Dock = DockStyle.Fill;
            dgv.Padding = new Padding(3, 5, 5, 5);

            dgvM = dgv.dtgdve.SelectedRows[0].Cells["numero_sequentiel"].Value.ToString();
            string deleteRow = dgv.dtgdve.CurrentRow.Cells["numero_sequentiel"].Value.ToString();

                Mq = "select numero_sequentiel, designation, division, annee, quantite, observation from Description_de_bien";
                Sq = "delete from Description_de_bien where numero_sequentiel = " + deleteRow;
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UCAjouter(dscrip);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            guna2Button1_Click( sender, e);
        }
    }
}
