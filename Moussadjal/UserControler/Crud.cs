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
    public partial class Crud: UserControl
    {
        public Crud()
        {
            InitializeComponent();
        }
        public string InsertQuery { get; set; }
        public string UpdateQuery { get; set; }
        public string SelectQuery { get; set; }
        public string DeleteQuery { get; set; }
        Database dt = new Database();
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Ajt_Click(object sender, EventArgs e)
        {
            dt.Ajouter(InsertQuery);
        }
    }
}
