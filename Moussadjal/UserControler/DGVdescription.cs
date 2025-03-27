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
        public string table;
        private void DGVdescription_Load(object sender, EventArgs e)
        {   f.datagridviewStyle(dtgdve);
            switch (table)
            {
                case "Description_de_bien":
                {
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
                        break; 
                }
                case "Bien":
                    {
                        db.remplirgridview("SELECT numero_dinventaire, numero_sequentiel, Id_lieu FROM Bien", "Bien", dtgdve);
                        dtgdve.Columns["numero_dinventaire"].HeaderText = "numero_dinventaire";
                        dtgdve.Columns["numero_sequentiel"].HeaderText = "numero_sequentiel";
                        dtgdve.Columns["Id_lieu"].HeaderText = "Id_lieu";
                        dtgdve.Columns["numero_dinventaire"].MinimumWidth = 40;
                        dtgdve.Columns["numero_dinventaire"].Width = 40;
                        dtgdve.Columns["numero_sequentiel"].MinimumWidth = 40;
                        dtgdve.Columns["numero_sequentiel"].Width = 40;
                        dtgdve.Rows[0].Selected = true;
                        break;
                    }
                case "Lieu":
                    {//mzl
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
                        break;
                    }
                case "Responsable":
                    {//mzl
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
                        break;
                    }
            }
              
           
                      
   
        }
        //update / refrech datagridview
        
        public void OnDataUpdated(EventArgs e)
        {
            // Check if there are any subscribers before invoking the event
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
