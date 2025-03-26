using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoussadjaleDT.UserController;

namespace MoussadjaleDT
{
    public partial class dashboard : MForm
    {
        public dashboard()
        {
            InitializeComponent();
            cr.Ajt.Click += Ajouter;
            cr.modifier.Click += Modifier;
            cr.Suprimer.Click += button6_Click;
        }
        AJTbien ab = new AJTbien();
        DGVdescription dgv = new DGVdescription();
        Crud cr = new Crud();
        Database db = new Database();

        UserControl UC;
        //pour la modification
        string Mq;
        string dgvM;

        public void UCAjouter(UserControl uc)
        {
            if (uc == null) return;

            Cpanel.Controls.Clear();
            Cpanel.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }
        public void Ajouter(object sender, EventArgs e)
        {
            UCAjouter(UC);
        }
        public void Modifier(object sender, EventArgs e)
        {
            db.query = "SELECT numero_sequentiel, designation, division, annee, quantite, observation FROM Description_de_bien";
            db.Enregistrer( dgv.dtgdve);
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            ExpandPanel(guna2Button10, BienPanel);
            Cpanel.Controls.Clear();

            Cpanel.Controls.Add(dgvPanel);
            dgvPanel.Dock = DockStyle.Fill;


            Cpanel.Controls.Add(cr);
            cr.Dock = DockStyle.Top;

            dgvPanel.Controls.Clear();

            dgvPanel.Controls.Add(dgv);
            dgv.Dock = DockStyle.Fill;
            dgv.Padding = new Padding(3, 5, 5, 5);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            AJTbien ab = new AJTbien();
            DGVdescription dgv = new DGVdescription();
            Crud cr = new Crud();

            UCAjouter(ab);
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
