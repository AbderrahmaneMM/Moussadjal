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
    public partial class Etiquette : UserControl
    {
        Database db = new Database();
        public Etiquette()
        {
            InitializeComponent();
            LieuComboBox.SelectedIndexChanged += LieuComboBox_SelectedIndexChanged;
        }

        private void guna2VSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void LieuComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DescreptionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
