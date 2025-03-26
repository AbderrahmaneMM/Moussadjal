using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoussadjaleDT.UserController
{
    public partial class DGVdescription : UserControl
    {
        public DGVdescription()
        {
            InitializeComponent();
        }
        Database db = new Database();
        MForm f = new MForm();
        public event EventHandler DataUpdated;
        private void dtgdve_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGVdescription_Load(object sender, EventArgs e)
        {
            db.remplirgridview("SELECT numero_sequentiel, designation, division, annee, quantite, observation FROM Description_de_bien", "Description_de_bien", dtgdve);
            dtgdve.Columns["numero_sequentiel"].HeaderText = "NS";
            dtgdve.Columns["designation"].HeaderText = "DESIGNATION";
            dtgdve.Columns["division"].HeaderText = "DIV";
            dtgdve.Columns["annee"].HeaderText = "ANNé D'ENTRER";
            dtgdve.Columns["quantite"].HeaderText = "QUANTIITé";
            // dtgdve.Columns["photo"].HeaderText = "PHOTO";
            dtgdve.Columns["observation"].HeaderText = "OBSERVATION";
            dtgdve.Columns["numero_sequentiel"].MinimumWidth = 40;
            dtgdve.Columns["numero_sequentiel"].Width = 40;
            dtgdve.Columns["division"].MinimumWidth = 40;
            dtgdve.Columns["division"].Width = 40;
            dtgdve.Rows[0].Selected = true;
            f.datagridviewStyle(dtgdve);
        }
    }
}
