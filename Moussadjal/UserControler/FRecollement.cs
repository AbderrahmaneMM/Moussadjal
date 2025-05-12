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
using Telerik.WinControls.Themes.ControlDefault;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.RadColorPicker;

namespace Moussadjal.UserControler
{
    public partial class FRecollement : UserControl
    {
        public FRecollement()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private string Query(string id_lieu)
        {    string query = @" SELECT ROW_NUMBER() OVER (ORDER BY b.numero_sequentiel) AS n, db.division, b.numero_sequentiel,   db.designation
             , COUNT(b.numero_sequentiel) AS Aff,"//quantite affectée
             +  "(SELECT COUNT(*) FROM Bien WHERE Id_lieu = '" + id_lieu + "' AND numero_sequentiel = b.numero_sequentiel) AS Phy, " //quantite physique
               + "(COUNT(b.numero_sequentiel) - (SELECT COUNT(*) FROM Bien WHERE Id_lieu = '" + id_lieu + "' AND numero_sequentiel = b.numero_sequentiel)) AS Ec," // ecart
             + "STUFF((SELECT '/' + CAST(b2.numero_dinventaire AS VARCHAR(10))"
             + " FROM Bien b2"
             + "   WHERE b2.Id_lieu = '" + id_lieu + "' AND b2.numero_sequentiel = b.numero_sequentiel"
             + " FOR XML PATH('')), 1, 1, '') AS Ni ,     db.observation FROM  Bien b"
             + "    JOIN    Description_de_bien db ON b.numero_sequentiel = db.numero_sequentiel"
             + " WHERE    b.Id_lieu = '" + id_lieu + "' GROUP BY"
             + " b.numero_sequentiel, db.designation, db.division, db.observation";
            return query;
        }

        private void FRecollement_Load(object sender, EventArgs e)
        {
           
            db.remlirCombo("Lieu", LieuComboBox, "designationLieu", "Id_lieu");


            if (LieuComboBox.SelectedItem != null)
            {
                string selectedIdLieu = LieuComboBox.SelectedValue.ToString();
                Updatelabels(selectedIdLieu);
                FillDGV(selectedIdLieu);
            }
        }
      

        private void DGVDesigne()
        {
            //DIV
            DGV.Columns["n"].Width = 25;
           DGV.Columns["division"].Width = DGV.Columns["n"].Width;
            //N2
            DGV.Columns["numero_sequentiel"].Width = DGV.Columns["n"].Width;
            //DESIGNATION
            DGV.Columns["designation"].Width = 200;
            //Quantite
            DGV.Columns["Aff"].Width = 25;
            DGV.Columns["Phy"].Width = DGV.Columns["Aff"].Width;
            DGV.Columns["Ec"].Width = DGV.Columns["Aff"].Width;
            //N°inventaire

            DGV.Columns["Ni"].Width = DGV.Columns["designation"].Width;
            //Observation
            DGV.Columns["observation"].Width = 40;
        }

        private void FillDGV(string id_lieu)
        {
            db.EmptyDataGridView(DGV);
            db.remplirgridview(Query(id_lieu), DGV);
            DGVDesigne();


        }
        private void Updatelabels(string id_lieu) 
        {
            label6.Text = "Localisation :    "+LieuComboBox.Text;
            label5.Text = "Affectataire: Nom et Prénom:   " + db.SELECT("SELECT r.nometprénom FROM Responsable r JOIN Affectation a ON r.Id_Responsable = a.Id_Responsable WHERE a.Id_lieu = '" + id_lieu + "'");
        
            label4.Text = " FICHE  DE  RECOLLEMENT  D'INVENTAIRE    AU "+guna2DateTimePicker1.Value.ToString("dd-MM-yyyy");
        }
        int nw, Affw, designWidth , noteWidth;
        private void tableLayoutPanel1_Paint2(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
           
            Font FFont = new Font("Arabic Transparent", 10, FontStyle.Bold);
            Font sf = new Font("Arabic Transparent", 7, FontStyle.Bold);
            SolidBrush khdar = new SolidBrush(Color.FromArgb(146, 208, 80));

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
             nw = DGV.Columns["n"].Width+1;
            Rectangle n = new Rectangle(startX, y, nw, rowHeight);
            g.FillRectangle(khdar, n);
            g.DrawRectangle(Pens.Black, n);
            g.DrawString("N°", FFont, Brushes.Black, n, centerFormat);

            //  lafiche
             int   divw=nw;
                int numw = nw;
                int fWidth = nw*2;
            Rectangle fRect = new Rectangle(startX + nw, y, fWidth, headerHeight);
            g.FillRectangle(khdar, fRect);
            g.DrawRectangle(Pens.Black, fRect);
            g.DrawString("FICHES", FFont, Brushes.Black, fRect, centerFormat);

            //  N°2 / DIV  
            Rectangle divRect = new Rectangle(startX + nw, y + headerHeight, divw, rowHeight - headerHeight);
            Rectangle numRect = new Rectangle(startX + nw + divw, y + headerHeight, numw, rowHeight - headerHeight);
            g.FillRectangle(khdar, divRect);
            g.DrawRectangle(Pens.Black, divRect);
            g.FillRectangle(khdar, numRect);
            g.DrawRectangle(Pens.Black, numRect);
            g.DrawString("DIV", FFont, Brushes.Black, divRect, centerFormat);
            g.DrawString("N°", FFont, Brushes.Black, numRect, centerFormat);

            //  DESIGNATION
             designWidth = DGV.Columns["designation"].Width ;
            Rectangle designationRect = new Rectangle(startX + nw + fWidth, y, designWidth, rowHeight);
            g.FillRectangle(khdar, designationRect);
            g.DrawRectangle(Pens.Black, designationRect);
            g.DrawString("DESIGNATION DES ARTICLES", FFont, Brushes.Black, designationRect, centerFormat);

            //Quantite 
             Affw = DGV.Columns["Aff"].Width;
            int phw = Affw;
            int ecw = Affw;
            int qw = Affw*3;
            Rectangle qr = new Rectangle(startX + nw + fWidth + designWidth, y, qw, headerHeight);
            g.FillRectangle(khdar, qr);
            g.DrawRectangle(Pens.Black, qr);
            g.DrawString("QUANTITE", FFont, Brushes.Black, qr, centerFormat);
            //Aff
            Rectangle affRect = new Rectangle(startX + nw + fWidth + designWidth, y + headerHeight, Affw, rowHeight - headerHeight);
            g.FillRectangle(khdar, affRect);
            g.DrawRectangle(Pens.Black, affRect);
            g.DrawString("Affecté", sf, Brushes.Black, affRect, centerFormat);
            //Phy
            Rectangle phyRect = new Rectangle(startX + nw + fWidth + designWidth + Affw, y + headerHeight, phw, rowHeight - headerHeight);
            g.FillRectangle(khdar, phyRect);
            g.DrawRectangle(Pens.Black, phyRect);
            g.DrawString("Phys.", sf, Brushes.Black, phyRect, centerFormat);
            //Ec
            Rectangle ecRect = new Rectangle(startX + nw + fWidth + designWidth + Affw + phw, y + headerHeight, ecw, rowHeight - headerHeight);
            g.FillRectangle(khdar, ecRect);
            g.DrawRectangle(Pens.Black, ecRect);
            g.DrawString("Ecart", sf, Brushes.Black, ecRect, centerFormat);


            //N°inventaire
            int niWidth = designWidth;
            Rectangle niRect = new Rectangle(startX + nw + fWidth + designWidth + qw, y, niWidth, rowHeight);
            g.FillRectangle(khdar, niRect);
            g.DrawRectangle(Pens.Black, niRect);
            g.DrawString("N° D'INVENTAIRE", FFont, Brushes.Black, niRect, centerFormat);
            //Observation
             noteWidth = DGV.Columns["observation"].Width;
            Rectangle noteRect = new Rectangle(startX + nw + fWidth + designWidth + qw + niWidth, y, noteWidth, rowHeight);
            g.FillRectangle(khdar, noteRect);
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void DocPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label4.Text = " FICHE  DE  RECOLLEMENT  D'INVENTAIRE    AU " + guna2DateTimePicker1.Value.ToString("dd-MM-yyyy");

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
            if (LieuComboBox.SelectedItem != null && DGV.DataSource != null)
            {
               
                string selectedIdLieu = LieuComboBox.SelectedValue.ToString();
              Updatelabels(selectedIdLieu);
                FillDGV(selectedIdLieu);
                DGV.Columns["n"].Width = nw-1;
                DGV.Columns["numero_sequentiel"].Width = nw;
                DGV.Columns["division"].Width = nw;
                //DESIGNATION
                DGV.Columns["designation"].Width = designWidth;
                //Quantite
                DGV.Columns["Aff"].Width = Affw;
                DGV.Columns["Phy"].Width = Affw;
                DGV.Columns["Ec"].Width = Affw;
                //N°inventaire
                DGV.Columns["Ni"].Width = designWidth;
                //Observation
                DGV.Columns["observation"].Width = noteWidth;
         
            }
        }

        private void LieuComboBox_Click(object sender, EventArgs e)
        {
     
             
            
        }
    }
}
