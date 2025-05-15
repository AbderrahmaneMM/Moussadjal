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
using System.Windows.Controls;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;

namespace Moussadjal
{
    public partial class dashboard : Form1
    {
        Database       db = new Database();

        Crud           cr = new Crud();
        DGVdescription dgv = new DGVdescription();//DGV

        AJTbien ab = new AJTbien();
        RemplacerBien rb = new RemplacerBien()    ;
        Descrip dscrip = new Descrip();
        Respo Respo = new Respo();
        Lieu L = new Lieu();

        FRecollement fr = new FRecollement();
        FRepertoire r = new FRepertoire();
        FInventaire i = new FInventaire();
        Etiquette etiquette = new Etiquette();

        System.Windows.Forms.UserControl UC;
        //pour la modification et la supresion
        string Mq,qt1, qt2 ,Sq,srq,dgvM;
      
        public dashboard()
        {
            InitializeComponent();
            cr.Ajt.Click      += Ajouter; 
            cr.modifier.Click += Modifier;
            cr.Suprimer.Click += Suprimer;
            cr.Searchbox.TextChanged += search;
        }
        public void search(object sender, EventArgs e)
        {
            db.EmptyDataGridView(dgv.dtgdve);
            db.remplirgridview($"{srq}{cr.ParCob.SelectedValue} like '%{cr.Searchbox.Text}%'", dgv.dtgdve);
        }
        public void UCAjouter(System.Windows.Forms.UserControl uc)
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
                    MessageBox.Show("la 1 ere column est vide", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                switch (UC) 
                {
                    case AJTbien ab:

                        db.Enregistrer2T(qt1,qt2);
                        break;
                    case Descrip dscrip:
                        db.Enregistrer(Mq);
                        break;
                    case Lieu L:
                        db.Enregistrer(Mq);
                        break;
                    case Respo Respo:
                        db.Enregistrer(Mq);
                        break;
                }
            
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
            {
                db.Suprimer(Sq);
                dgv.dtgdve.Rows.Remove(dgv.dtgdve.CurrentRow);
            }

        }
        private void dashboard_Load(object sender, EventArgs e)
        {
            Cpanel.Size = new Size(guna2Panel1.Width - 15, flowLayoutPanel1.Height - guna2Panel1.Height);


            Crud cr = new Crud();
            DGVdescription dgv = new DGVdescription();//DGV

            AJTbien ab = new AJTbien();
            RemplacerBien rb = new RemplacerBien();
            Descrip dscrip = new Descrip();
            Respo Respo = new Respo();
            Lieu L = new Lieu();

            FRecollement fr = new FRecollement();
            FRepertoire r = new FRepertoire();
            FInventaire i = new FInventaire();
            Etiquette etiquette = new Etiquette();
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DesplaydgvControl()
        {
            Cpanel.Controls.Clear();

           Cpanel.Controls.Add(dgvPanel);
            dgvPanel.Dock = DockStyle.Fill;


            Cpanel.Controls.Add(cr);
            cr.Dock = DockStyle.Top;

            dgvPanel.Controls.Clear();

            dgvPanel.Controls.Add(dgv);
            dgv.Dock = DockStyle.Fill;
            dgv.Padding = new Padding(3, 5, 5, 5);
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            ExpandPanel(guna2Button10, BienPanel, 86);
            dgv.Bien();
            UC = ab;
            DesplaydgvControl();

          
            dgvM = dgv.dtgdve.SelectedRows[0].Cells["numero_dinventaire"].Value.ToString();
            string deleteRow = dgv.dtgdve.CurrentRow.Cells["numero_dinventaire"].Value.ToString();

            //modifer querys
       
            qt1 = "SELECT numero_dinventaire, numero_sequentiel, Id_lieu, annee FROM Bien";
            qt2 = "select numero_sequentiel, designation, division, observation from Description_de_bien";
            //suprimer query
            Sq = "delete from Bien where numero_dinventaire = " + deleteRow;
            //search query
            srq = "SELECT b.numero_dinventaire, b.numero_sequentiel," +
                " d.division, d.designation, b.annee, b.Id_lieu, d.observation FROM Bien b" +
                " JOIN Description_de_bien d ON b.numero_sequentiel= d.numero_sequentiel where ";

            //filter de recherche
            var items = new[]
            {
             new { Text = "Recharche par numéro sequentiel", Value = "d.numero_sequentiel" },
             new { Text = "Recharche par Lieu", Value = "b.Id_lieu" },
              new { Text = "Recharche par année", Value = "b.annee" }
             };

            cr.ParCob.DataSource = items;
            cr.ParCob.DisplayMember = "Text";
            cr.ParCob.ValueMember = "Value";

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            ExpandPanel(guna2Button11, LieuPanel, 86);

            dgv.Lieu();
            UC = L;
            DesplaydgvControl();


            dgvM = dgv.dtgdve.SelectedRows[0].Cells["Id_lieu"].Value.ToString();
            string deleteRow = dgv.dtgdve.CurrentRow.Cells["Id_lieu"].Value.ToString();

            Mq = "SELECT Id_lieu, designationLieu FROM Lieu";
            Sq = "delete from Lieu where Id_lieu = " + deleteRow;
            srq = "Select Id_lieu, designationLieu FROM Lieu where  ";

            ///////////
             var items = new[]
             {
               new { Text = "Recharche par Lieu", Value = "Id_lieu" },
              // new { Text = "Recharche par résponsble", Value = "Id_Responsable" }
             };

            cr.ParCob.DataSource = items;
            cr.ParCob.DisplayMember = "Text";
            cr.ParCob.ValueMember = "Value";
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            ExpandPanel(guna2Button12, RespoPanel, 86);

            dgv.Responsable();
            UC = Respo;
            DesplaydgvControl();


            dgvM = dgv.dtgdve.SelectedRows[0].Cells["Id_Responsable"].Value.ToString();
            string deleteRow = dgv.dtgdve.CurrentRow.Cells["Id_Responsable"].Value.ToString();

            Mq = "SELECT Id_Responsable, nometprénom FROM Responsable";
            Sq = "delete from Responsable where Id_Responsable = " + deleteRow;
            srq = "Select Id_Responsable, nometprénom FROM Responsable where ";
            // recharche responsable
            var items = new[]
            {
             new { Text = "Recharche par Nom", Value = "nometprénom"},
             new { Text = "Recharche par ID", Value = "Id_Responsable"}
            };

            cr.ParCob.DataSource = items;
            cr.ParCob.DisplayMember = "Text";
            cr.ParCob.ValueMember = "Value";
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
            ExpandPanel(Printbutton, PrintPanel, 172);
        }

        private void PrintPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {//remplacer
         //guna2Button10_Click( sender,  e);
            UCAjouter(rb);
        }

        private void button14_Click(object sender, EventArgs e)
        {
     
        }

        private void button14_Click_1(object sender, EventArgs e)
        {    //repertoire
          
            UCAjouter(r);
          //  p.DocumentType=1 ;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // FUILLE  D'INVENTAIRE
            UCAjouter(i);
           // p.DocumentType = 2;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // FUILLE  de recollement
            UCAjouter(fr);
            //p.DocumentType = 3;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            UCAjouter(etiquette);
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
          Cpanel.Size = new Size(guna2Panel1.Width-15, flowLayoutPanel1.Height-guna2Panel1.Height);
            this.Location = new Point(175,100);
        }

        private void Cpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ExpandPanel(guna2Button1,DescriPanel,86);
            dgv.Description();
            UC = dscrip;

            DesplaydgvControl();

            dgvM = dgv.dtgdve.SelectedRows[0].Cells["numero_sequentiel"].Value.ToString();
            string deleteRow = dgv.dtgdve.CurrentRow.Cells["numero_sequentiel"].Value.ToString();

                Mq = "select numero_sequentiel, designation, division, quantite, observation from Description_de_bien";
                Sq = "delete from Description_de_bien where numero_sequentiel = '" + deleteRow+"'";
                srq = "Select numero_sequentiel, designation, division, quantite, observation from Description_de_bien where ";
            var items = new[]
            {
             new { Text = "Recharche par designation", Value = "designation" }
            };

            cr.ParCob.DataSource = items;
            cr.ParCob.DisplayMember = "Text";
            cr.ParCob.ValueMember = "Value";

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
