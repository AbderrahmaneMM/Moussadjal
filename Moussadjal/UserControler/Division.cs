using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moussadjal.UserControler
{
    public partial class Division: UserControl
    {
        public Division()
        {
            InitializeComponent();
        }

        Database db = new Database();   
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Division_Load(object sender, EventArgs e)
        {
            db.remplirgridview("SELECT numero_sequentiel, division, designation, observation FROM Description_de_bien", "Description_de_bien", dtgdve);
            dtgdve.Columns["numero_sequentiel"].HeaderText = "NS";
            dtgdve.Columns["numero_sequentiel"].Width = 15;
            dtgdve.Columns["division"].HeaderText = "DIV";
            dtgdve.Columns["division"].Width = 15;
            dtgdve.Columns["designation"].HeaderText = "DESIGNATION";
            dtgdve.Columns["designation"].Width = 40;
            dtgdve.Columns["observation"].HeaderText = "OBSERVATION";
            dtgdve.Columns["observation"].Width = 40;
        }
    }
}
