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
            dgvB.Visible = false;
        }
        public void Description() 
        {
            db.EmptyDataGridView(dtgdve);
         
            f.datagridviewStyle(dtgdve);

            db.remplirgridview("SELECT numero_sequentiel, designation, division, annee, quantite, observation FROM Description_de_bien", "Description_de_bien", dtgdve);

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
            db.EmptyDataGridView(dtgdve);
       
            f.datagridviewStyle(dtgdve);

            db.remplirgridview("SELECT numero_dinventaire, numero_sequentiel, Id_lieu FROM Bien", "Bien", dtgdve);

            dtgdve.Columns["numero_dinventaire"].HeaderText = "NI";
            dtgdve.Columns["numero_sequentiel"].HeaderText = "NS";
            dtgdve.Columns["Id_lieu"].HeaderText = "Id_lieu";
            dtgdve.Columns["numero_dinventaire"].MinimumWidth = 40;
            dtgdve.Columns["numero_dinventaire"].Width = 60;
            dtgdve.Columns["numero_sequentiel"].MinimumWidth = 40;
            dtgdve.Columns["numero_sequentiel"].Width = 60;
            dtgdve.Rows[0].Selected = true;
        }
        public void Responsable()
        {
            db.EmptyDataGridView(dtgdve);

            f.datagridviewStyle(dtgdve);

            db.remplirgridview("SELECT Id_Responsable, nometprénom FROM Responsable", "Responsable", dtgdve);

            dtgdve.Columns["nometprénom"].HeaderText = "nom et prénom";
            dtgdve.Columns["Id_Responsable"].HeaderText = " Id de Responsable";
            dtgdve.Rows[0].Selected = true;
        }
        public void Lieu()
        {
            db.EmptyDataGridView(dtgdve);

            f.datagridviewStyle(dtgdve);

            db.remplirgridview("SELECT Id_lieu, designationLieu FROM Lieu", "Lieu", dtgdve);

            dtgdve.Columns["Id_lieu"].HeaderText = "Id de lieu";
            dtgdve.Columns["designationLieu"].HeaderText = "designation de Lieu";
          
            dtgdve.Rows[0].Selected = true;
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
