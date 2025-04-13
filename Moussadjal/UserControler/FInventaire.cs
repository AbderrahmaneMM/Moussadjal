using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moussadjal.UserControler
{
    public partial class FInventaire : UserControl
    {
        public FInventaire()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private void FInventaire_Load(object sender, EventArgs e)
        {

          /*  db.remplirgridview("Select division, numero_sequentiel, designation, observation  from Description_de_bien", DGVR);

            DGVR.RightToLeft = RightToLeft.Yes;

            DGVR.Columns["numero_sequentiel"].HeaderText = "N°";
            DGVR.Columns["numero_sequentiel"].MinimumWidth = 40;
            DGVR.Columns["numero_sequentiel"].Width = 40;
            DGVR.Columns["division"].HeaderText = "DIV";
            DGVR.Columns["division"].MinimumWidth = 40;
            DGVR.Columns["division"].Width = 40;
            DGVR.Columns["designation"].HeaderText = "المواد";
            DGVR.Columns["designation"].MinimumWidth = 40;
            DGVR.Columns["designation"].Width = 550;
            DGVR.Columns["observation"].HeaderText = "الملاحظات";
            DGVR.Columns["observation"].MinimumWidth = 40;
            DGVR.Columns["observation"].Width = 250;*/
        }
    }
}
