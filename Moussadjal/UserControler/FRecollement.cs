using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Styles;
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
            db.remlirCombo("Lieu", LieuComboBox, "designationLieu", "Id_lieu");

            DocPanel.SendToBack();
            //N°1
            DGV.Columns.Add("n","n");
      

            if (LieuComboBox.SelectedValue != null)
            {
                string selectedIdLieu = LieuComboBox.SelectedValue.ToString();
                label8.Text = LieuComboBox.Text;
               // label9.Text = LieuComboBox.SelectedValue.ToString();
                FillDGV(selectedIdLieu);
            } 
       
            
            //DIV
            DGV.Columns["division"].MinimumWidth = 10;
            DGV.Columns["division"].Width = 25;
            //N2
            DGV.Columns["numero_sequentiel"].MinimumWidth = 10;
            DGV.Columns["numero_sequentiel"].Width = 25;

            DGV.Columns["n"].Width = DGV.Columns["numero_sequentiel"].Width;
            //DESIGNATION
            DGV.Columns["designation"].MinimumWidth = 40;
            DGV.Columns["Ni"].Width = DGV.Columns["designation"].Width;
    

              //Quantite
            DGV.Columns.Add("Ec", "Ec");
            DGV.Columns["Aff"].MinimumWidth = 10;
            DGV.Columns["Aff"].Width = 25;
            DGV.Columns["Phy"].MinimumWidth = 10;
            DGV.Columns["Phy"].Width = 25;
       
            DGV.Columns["Ec"].DisplayIndex = DGV.Columns["Phy"].DisplayIndex+1;
            DGV.Columns["Ec"].Width = DGV.Columns["Aff"].Width;
            //N°inventaire
          
            DGV.Columns["Ni"].Width = DGV.Columns["designation"].Width;
            //Observation
           
            DGV.Columns["observation"].MinimumWidth = 10;
            DGV.Columns["observation"].Width = 40;

        }
          private void FillDGV(string id_lieu)
          {
            string query = @" SELECT db.division, b.numero_sequentiel,   db.designation,
              COUNT(b.numero_sequentiel) AS Aff,
               (SELECT COUNT(*) FROM Bien WHERE Id_lieu = '" + id_lieu + "' AND numero_sequentiel = b.numero_sequentiel) AS Phy,"
            + "STUFF((SELECT '/' + CAST(b2.numero_dinventaire AS VARCHAR(10))"
            + " FROM Bien b2"
            + "   WHERE b2.Id_lieu = '"+id_lieu+"' AND b2.numero_sequentiel = b.numero_sequentiel"
            + " FOR XML PATH('')), 1, 1, '') AS Ni ,     db.observation FROM  Bien b"
            + "    JOIN    Description_de_bien db ON b.numero_sequentiel = db.numero_sequentiel"
            + " WHERE    b.Id_lieu = '" + id_lieu+"' GROUP BY"
            + " b.numero_sequentiel, db.designation, db.division, db.observation";
             db.EmptyDataGridView(DGV);
             db.remplirgridview(query, DGV);
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
            int startX = DGV.Location.X+3;
            int y = DGV.Location.Y+37;

            //N°1
            if (DGV.Columns.Contains("n"))
            {
                int nw = DGV.Columns["n"].Width  ;
            Rectangle n = new Rectangle(startX, y, nw, rowHeight);
            g.FillRectangle(Brushes.LightGray, n);
            g.DrawRectangle(Pens.Black, n);
            g.DrawString("N°", FFont, Brushes.Black, n, centerFormat);

            //  lafiche
            int divw = DGV.Columns["division"].Width;
                int numw = DGV.Columns["numero_sequentiel"].Width;
                int fWidth = divw+numw;
            Rectangle fRect = new Rectangle(startX + nw, y, fWidth, headerHeight);
            g.FillRectangle(Brushes.LightGray, fRect);
            g.DrawRectangle(Pens.Black, fRect);
            g.DrawString("FICHES", FFont, Brushes.Black, fRect, centerFormat);

            //  N°2 / DIV  
            Rectangle divRect = new Rectangle(startX + nw, y + headerHeight, divw, rowHeight - headerHeight);
            Rectangle numRect = new Rectangle(startX + nw + divw, y + headerHeight, numw, rowHeight - headerHeight);
            g.FillRectangle(Brushes.LightGray, divRect);
            g.DrawRectangle(Pens.Black, divRect);
            g.FillRectangle(Brushes.LightGray, numRect);
            g.DrawRectangle(Pens.Black, numRect);
            g.DrawString("DIV", FFont, Brushes.Black, divRect, centerFormat);
            g.DrawString("N°", FFont, Brushes.Black, numRect, centerFormat);

            //  DESIGNATION
            int designWidth = DGV.Columns["designation"].Width + 2;
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
            int niWidth = DGV.Columns["Ni"].Width;
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4;

            printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.DefaultPageSettings.Margins = new Margins(10, 10, 10,10);
        
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmprint = new Bitmap(DocPanel.Width, DocPanel.Height);
            DocPanel.DrawToBitmap(bmprint, new Rectangle(0, 0, DocPanel.Width, DocPanel.Height));

            bmprint.SetResolution(300, 300);

            float scale = Math.Min(
                e.MarginBounds.Width / (float)bmprint.Width,
                e.MarginBounds.Height / (float)bmprint.Height
            );


            RectangleF destRect = new RectangleF(
                e.MarginBounds.Left + (e.MarginBounds.Width - bmprint.Width * scale) / 2,
                e.MarginBounds.Top + (e.MarginBounds.Height - bmprint.Height * scale) / 2,
                bmprint.Width * scale,
                bmprint.Height * scale
            );


            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;


            e.Graphics.DrawImage(bmprint, destRect);
            e.HasMorePages = false;
        }

        private void LieuComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
    }
}
