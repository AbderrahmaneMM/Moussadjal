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
        Crud cr = new Crud();
        Form1 f = new Form1();
        public event EventHandler DataUpdated;
        
        private void DGVdescription_Load(object sender, EventArgs e)
        { 
            f.datagridviewStyle(dtgdve);
        }
        public void Description() 
        {
            db.EmptyDataGridView(dtgdve);
         
            db.remplirgridview("SELECT numero_sequentiel, designation, division, quantite, observation FROM Description_de_bien", dtgdve);

            dtgdve.Columns["numero_sequentiel"].HeaderText = "Ns";
            dtgdve.Columns["designation"].HeaderText = "Designation";
            dtgdve.Columns["division"].HeaderText = "Div";
            dtgdve.Columns["quantite"].HeaderText = "Quantité";
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

            db.remplirgridview("SELECT b.numero_dinventaire, b.numero_sequentiel," +
                " d.division, d.designation, b.annee, b.Id_lieu, d.observation FROM Bien b" +
                " JOIN Description_de_bien d ON b.numero_sequentiel= d.numero_sequentiel", dtgdve);
        
            dtgdve.Columns["numero_dinventaire"].HeaderText = "N°inventaire";
            dtgdve.Columns["numero_sequentiel"].HeaderText = "N°sequentiel";
            dtgdve.Columns["Id_lieu"].HeaderText = "lieu";
            dtgdve.Columns["numero_dinventaire"].MinimumWidth = 40;
            dtgdve.Columns["numero_dinventaire"].Width = 100;
            dtgdve.Columns["numero_sequentiel"].MinimumWidth = 40;
            dtgdve.Columns["numero_sequentiel"].Width = 100;
            dtgdve.Columns["division"].HeaderText = "Div";
            dtgdve.Columns["division"].MinimumWidth = 10;
            dtgdve.Columns["division"].Width = 60;
            dtgdve.Columns["annee"].HeaderText = "Anné d'entrer";
            dtgdve.Columns["observation"].HeaderText = "Observation de description";

            dtgdve.Rows[0].Selected = true;
        }
        public void Responsable()
        {
            db.EmptyDataGridView(dtgdve);

            db.remplirgridview("SELECT Id_Responsable, nometprénom FROM Responsable", dtgdve);

            dtgdve.Columns["nometprénom"].HeaderText = "nom et prénom";
            dtgdve.Columns["Id_Responsable"].HeaderText = " Id de Responsable";
            dtgdve.Rows[0].Selected = true;
        }
        public void Lieu()
        {
            db.EmptyDataGridView(dtgdve);

            db.remplirgridview("SELECT Id_lieu, designationLieu FROM Lieu", dtgdve);

            dtgdve.Columns["Id_lieu"].HeaderText = "Id de lieu";
            dtgdve.Columns["designationLieu"].HeaderText = "designation de Lieu";
          
            dtgdve.Rows[0].Selected = true;
        }
        public void Aff() 
        {
            db.EmptyDataGridView(dtgdve);

            db.remplirgridview("SELECT R.nometprénom AS LeResponsable, L.designationLieu AS Lieu" +
                " FROM Responsable R JOIN Affectation A ON R.Id_Responsable = A.Id_Responsable" +
                " JOIN Lieu L ON A.id_lieu = L.id_lieu", dtgdve);
            dtgdve.Rows[0].Selected = true;
        }
        public void DetaillLieu(string qrr)
        {
            db.EmptyDataGridView(dtgdve);

            db.remplirgridview(qrr, dtgdve);
           
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

        private void picClick(object sender, EventArgs e)
        {

        }
    }
}
