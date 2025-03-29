using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Moussadjal.UserControler
{
    public partial class DGVdescription: UserControl
    {
        public DGVdescription()
        {
            InitializeComponent();
        }
        Database db = new Database();
        Form1 f = new Form1();
        public event EventHandler DataUpdated;
    
        private void DGVdescription_Load(object sender, EventArgs e)
        {
                //case "Lieu":
                //    {//mzl
                //        db.remplirgridview("SELECT numero_sequentiel, designation, division, annee, quantite, observation FROM Description_de_bien", "Description_de_bien", dtgdve);
                //        dtgdve.Columns["numero_sequentiel"].HeaderText = "Ns";
                //        dtgdve.Columns["designation"].HeaderText = "Designation";
                //        dtgdve.Columns["division"].HeaderText = "Div";
                //        dtgdve.Columns["annee"].HeaderText = "Anné d'entrer";
                //        dtgdve.Columns["quantite"].HeaderText = "Quantité";
                //        // dtgdve.Columns["photo"].HeaderText = "PHOTO";
                //        dtgdve.Columns["observation"].HeaderText = "Observation";
                //        dtgdve.Columns["numero_sequentiel"].MinimumWidth = 40;
                //        dtgdve.Columns["numero_sequentiel"].Width = 40;
                //        dtgdve.Columns["division"].MinimumWidth = 40;
                //        dtgdve.Columns["division"].Width = 40;
                //        dtgdve.Rows[0].Selected = true;
                //        break;
                //    }
                //case "Responsable":
                //    {//mzl
                //        db.remplirgridview("SELECT numero_sequentiel, designation, division, annee, quantite, observation FROM Description_de_bien", "Description_de_bien", dtgdve);
                //        dtgdve.Columns["numero_sequentiel"].HeaderText = "Ns";
                //        dtgdve.Columns["designation"].HeaderText = "Designation";
                //        dtgdve.Columns["division"].HeaderText = "Div";
                //        dtgdve.Columns["annee"].HeaderText = "Anné d'entrer";
                //        dtgdve.Columns["quantite"].HeaderText = "Quantité";
                //        // dtgdve.Columns["photo"].HeaderText = "PHOTO";
                //        dtgdve.Columns["observation"].HeaderText = "Observation";
                //        dtgdve.Columns["numero_sequentiel"].MinimumWidth = 40;
                //        dtgdve.Columns["numero_sequentiel"].Width = 40;
                //        dtgdve.Columns["division"].MinimumWidth = 40;
                //        dtgdve.Columns["division"].Width = 40;
                //        dtgdve.Rows[0].Selected = true;
                //        break;
                //    }
        }
        public void Description() 
        {

            dgvB.Visible = false;
            dgvB.Columns.Clear();
            db.EmptyDataGridView(dgvB);
            dgvB.DataSource = null;
            foreach (DataGridViewColumn column in dgvB.Columns)
            {
                dgvB.Columns.Remove(column);
            }
            f.datagridviewStyle(dtgdve);


            this.Controls.Clear();
            this.Controls.Add(dtgdve);


            db.remplirgridview("SELECT numero_sequentiel, designation, division, annee, quantite, observation FROM Description_de_bien", "Description_de_bien", dtgdve);
            dtgdve.Visible = true;
            dtgdve.Columns["numero_sequentiel"].HeaderText = "Ns";
            dtgdve.Columns["designation"].HeaderText = "Designation";
            dtgdve.Columns["division"].HeaderText = "Div";
            dtgdve.Columns["annee"].HeaderText = "Anné d'entrer";
            dtgdve.Columns["quantite"].HeaderText = "Quantité";
            // dtgdve.Columns["photo"].HeaderText = "PHOTO";
            dtgdve.Columns["observation"].HeaderText = "Observation";
            dtgdve.Columns["numero_sequentiel"].MinimumWidth = 40;
            dtgdve.Columns["numero_sequentiel"].Width = 40;
            dtgdve.Columns["division"].MinimumWidth = 40;
            dtgdve.Columns["division"].Width = 40;
            dtgdve.Rows[0].Selected = true;
        }
       
        public void Bien()
        {
            
            dtgdve.Visible = false;
            dtgdve.Columns.Clear();
            db.EmptyDataGridView(dtgdve);
            dtgdve.DataSource = null;
            foreach (DataGridViewColumn column in dtgdve.Columns)
            {
                dtgdve.Columns.Remove(column);
            }
            f.datagridviewStyle(dgvB);
           

            this.Controls.Clear();
            this.Controls.Add(dgvB);


            db.remplirgridview("SELECT numero_dinventaire, numero_sequentiel, Id_lieu FROM Bien", "Bien", dgvB);
            dgvB.Visible = true;
            dgvB.Columns["numero_dinventaire"].HeaderText = "NI";
            dgvB.Columns["numero_sequentiel"].HeaderText = "NS";
            dgvB.Columns["Id_lieu"].HeaderText = "Id_lieu";
            dgvB.Columns["numero_dinventaire"].MinimumWidth = 40;
            dgvB.Columns["numero_dinventaire"].Width = 60;
            dgvB.Columns["numero_sequentiel"].MinimumWidth = 40;
            dgvB.Columns["numero_sequentiel"].Width = 60;
            dgvB.Rows[0].Selected = true;
        }
        public void OnDataUpdated(EventArgs e)
        {
            if (DataUpdated != null)
            {
                DataUpdated.Invoke(this, e);
            }
        }
        private void dtgdve_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OnDataUpdated(EventArgs.Empty);
        }
    }
}
