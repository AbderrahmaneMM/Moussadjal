using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Moussadjal.UserControler
{
    public partial class FRecollement : UserControl
    {
        public FRecollement()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private void FRecollement_Load(object sender, EventArgs e)
        {
            db.EmptyDataGridView(DGV);
            db.remplirgridview("Select numero_sequentiel, division, numero_sequentiel, designation, observation  from Description_de_bien", DGV);
            //N°1
            DGV.Columns["numero_sequentiel"].MinimumWidth = 10;
            DGV.Columns["numero_sequentiel"].Width = 40;
            //DIV
            DGV.Columns["division"].MinimumWidth = 10;
            DGV.Columns["division"].Width = 40;
            //N2
            DGV.Columns["numero_sequentiel1"].MinimumWidth = 10;
            DGV.Columns["numero_sequentiel1"].Width = 40;
            //DESIGNATION
            DGV.Columns["designation"].MinimumWidth = 40;
            //Quantite
            DGV.Columns.Add("Aff", "Aff");
            DGV.Columns["Aff"].MinimumWidth = 10;
            DGV.Columns["Aff"].Width = 50;
            DGV.Columns.Add("Phy", "Phy");
            DGV.Columns["Phy"].MinimumWidth = 10;
            DGV.Columns["Phy"].Width = 50;
            DGV.Columns.Add("Ec", "Ec");
            DGV.Columns["Ec"].MinimumWidth = 10;
            DGV.Columns["Ec"].Width = 50;
            //N°inventaire
            DGV.Columns.Add("Ni", "Ni");
            DGV.Columns["Ni"].Width = DGV.Columns["designation"].Width;
            //Observation
            DGV.Columns["observation"].DisplayIndex = 8;
            DGV.Columns["observation"].MinimumWidth = 10;
            DGV.Columns["observation"].Width = 65;
        }
 

        private void tableLayoutPanel1_Paint2(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Font FFont = new Font("Arabic Transparent", 10, FontStyle.Bold);
            Font sf = new Font("Arabic Transparent", 7, FontStyle.Bold);

            StringFormat centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            int rowHeight = 65;
            int headerHeight = 20;
            int startX = DGV.Location.X;
            int y = DGV.Location.Y - rowHeight;
       
            //N°1
            int nw = DGV.Columns["numero_sequentiel"].Width  ;
            Rectangle n = new Rectangle(startX, y, nw, rowHeight);
            g.FillRectangle(Brushes.LightGray, n);
            g.DrawRectangle(Pens.Black, n);
            g.DrawString("N°", FFont, Brushes.Black, n, centerFormat);

            //  lafiche  
            int fWidth = nw*2;
            Rectangle fRect = new Rectangle(startX + nw, y, fWidth, headerHeight);
            g.FillRectangle(Brushes.LightGray, fRect);
            g.DrawRectangle(Pens.Black, fRect);
            g.DrawString("FICHES", FFont, Brushes.Black, fRect, centerFormat);

            //  N°2 / DIV  
            Rectangle divRect = new Rectangle(startX + nw, y + headerHeight, nw, rowHeight - headerHeight);
            Rectangle numRect = new Rectangle(startX + nw + nw, y + headerHeight, nw, rowHeight - headerHeight);
            g.FillRectangle(Brushes.LightGray, divRect);
            g.DrawRectangle(Pens.Black, divRect);
            g.FillRectangle(Brushes.LightGray, numRect);
            g.DrawRectangle(Pens.Black, numRect);
            g.DrawString("DIV", FFont, Brushes.Black, divRect, centerFormat);
            g.DrawString("N°", FFont, Brushes.Black, numRect, centerFormat);

            //  DESIGNATION
            int designWidth = DGV.Columns["designation"].Width+2;
            Rectangle designationRect = new Rectangle(startX + nw + fWidth, y, designWidth, rowHeight);
            g.FillRectangle(Brushes.LightGray, designationRect);
            g.DrawRectangle(Pens.Black, designationRect);
            g.DrawString("DESIGNATION DES ARTICLES", FFont, Brushes.Black, designationRect, centerFormat);

            //Quantite 
            int Affw = DGV.Columns["Aff"].Width;
            int phw = DGV.Columns["Phy"].Width;
            int ecw = DGV.Columns["Ec"].Width;
            int qw = Affw + phw + ecw;
            Rectangle qr = new Rectangle(startX + nw + fWidth + designWidth, y, qw, headerHeight);
            g.FillRectangle(Brushes.LightGray, qr);
            g.DrawRectangle(Pens.Black, qr);
            g.DrawString("QUANTITE", FFont, Brushes.Black, qr, centerFormat);
            //Aff
            Rectangle affRect = new Rectangle(startX + nw + fWidth + designWidth, y + headerHeight, Affw, rowHeight - headerHeight);
            g.FillRectangle(Brushes.LightGray, affRect);
            g.DrawRectangle(Pens.Black, affRect);
            g.DrawString("Affecté", sf, Brushes.Black, affRect, centerFormat);
            //Phy
            Rectangle phyRect = new Rectangle(startX + nw + fWidth + designWidth + Affw, y + headerHeight, phw, rowHeight - headerHeight);
            g.FillRectangle(Brushes.LightGray, phyRect);
            g.DrawRectangle(Pens.Black, phyRect);
            g.DrawString("Phys.", sf, Brushes.Black, phyRect, centerFormat);
            //Ec
            Rectangle ecRect = new Rectangle(startX + nw + fWidth + designWidth + Affw + phw, y + headerHeight, ecw, rowHeight - headerHeight);
            g.FillRectangle(Brushes.LightGray, ecRect);
            g.DrawRectangle(Pens.Black, ecRect);
            g.DrawString("Ecart", sf, Brushes.Black, ecRect, centerFormat);


            //N°inventaire
            int niWidth = DGV.Columns["ni"].Width;
            Rectangle niRect = new Rectangle(startX + nw + fWidth + designWidth + qw, y, niWidth, rowHeight);
            g.FillRectangle(Brushes.LightGray, niRect);
            g.DrawRectangle(Pens.Black, niRect);
            g.DrawString("N° D'INVENTAIRE", FFont, Brushes.Black, niRect, centerFormat);
            //Observation
            int noteWidth = DGV.Columns["observation"].Width;
            Rectangle noteRect = new Rectangle(startX + nw + fWidth + designWidth + qw + niWidth, y, noteWidth, rowHeight);
            g.FillRectangle(Brushes.LightGray, noteRect);
            g.DrawRectangle(Pens.Black, noteRect);
            g.DrawString("Obs", FFont, Brushes.Black, noteRect, centerFormat);
        }
    }
}
