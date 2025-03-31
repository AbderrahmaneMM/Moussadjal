using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialDesignThemes.Wpf;
using System.Windows.Shapes;

namespace Moussadjal.UserControler
{
    public partial class Crud: UserControl
    {

        public Crud()
        {
            InitializeComponent();
            Searchbox.TextChanged += serch;
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Ajt_Click(object sender, EventArgs e)
        {

        }

        private void modifier_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        Database db = new Database();
        DGVdescription dgv = new DGVdescription();
        private void serch(object sender, EventArgs e)
        {
            //if (Searchbox.TextLength >=4) 
             

            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
          db.remplirgridview("Select numero_sequentiel, designation, division, annee, quantite, observation from Description_de_bien where designation like N'c%'", dgv.dtgdve);
        }
    }
}
