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
        private void DGVdescription_Load(object sender, EventArgs e)
        {
            db.remplirgridview("SELECT numero_sequentiel, designation, division, annee, quantite, photo, observation FROM Description_de_bien", "Description_de_bien", dtgdve);
            dtgdve.Columns["numero_sequentiel"].HeaderText = "NS";
            dtgdve.Columns["designation"].HeaderText = "DESIGNATION";
            dtgdve.Columns["division"].HeaderText = "DIV";
            dtgdve.Columns["annee"].HeaderText = "ANNé D'ENTRER";
            dtgdve.Columns["quantite"].HeaderText = "QUANTIITé";
            dtgdve.Columns["photo"].HeaderText = "PHOTO";
            dtgdve.Columns["observation"].HeaderText = "OBSERVATION";
            dtgdve.Columns["numero_sequentiel"].MinimumWidth = 40;
            dtgdve.Columns["numero_sequentiel"].Width = 40;
            dtgdve.Columns["division"].MinimumWidth = 40;
            dtgdve.Columns["division"].Width = 40;
            f.datagridviewStyle(dtgdve);
        }

        private void dtgdve_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
