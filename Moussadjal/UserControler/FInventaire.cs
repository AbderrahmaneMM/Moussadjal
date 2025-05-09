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
//using Telerik.WinControls.UI;

namespace Moussadjal.UserControler
{
    public partial class FInventaire : UserControl
    {
        public FInventaire()
        {
            InitializeComponent();
            this.DGVA.CellPainting += DGVA_CellPating;
     
        }
        Database db = new Database();
        private void FInventaire_Load(object sender, EventArgs e)
        {
            RemplirGrids();

        }
        private  void RemplirGrids()
        {
            db.EmptyDataGridView(DGVD);

            // Use Task.Run to offload the database operations to a background thread
          
                db.remplirgridview("Select numero_sequentiel, division, numero_sequentiel, designation  from Description_de_bien", DGVD);
         
            
            // N°1
            DGVD.Columns["numero_sequentiel"].MinimumWidth = 10;
            DGVD.Columns["numero_sequentiel"].Width = 18;

            // DIV
            DGVD.Columns["division"].MinimumWidth = 10;
            DGVD.Columns["division"].Width = 18;

            // N2
            DGVD.Columns["numero_sequentiel1"].MinimumWidth = 10;
            DGVD.Columns["numero_sequentiel1"].Width = 20;

            // العتاد
            DGVD.Columns["designation"].MinimumWidth = 40;

            // Fetch data for Affectation asynchronously
            DataTable dtL = db.DtOfSelect("SELECT Id_lieu, designationLieu FROM Lieu");
            DataTable dtD =  db.DtOfSelect("SELECT numero_sequentiel FROM Description_de_bien");

            for (int l = 0; l < dtL.Rows.Count; l++) // les columns
            {
                string locationName = dtL.Rows[l]["designationLieu"].ToString();
                DGVA.Columns.Add(locationName, locationName);

                DGVA.Width = 30 * dtL.Rows.Count;
            }

            DGVA.Rows.Clear();
            for (int r = 0; r < dtD.Rows.Count; r++) // les lignes
            {
                string seqNum = dtD.Rows[r]["numero_sequentiel"].ToString();
                DGVA.Rows.Add(seqNum);

                for (int colIndex = 0; colIndex < dtL.Rows.Count; colIndex++)
                {
                    string locationId   = dtL.Rows[colIndex]["Id_lieu"].ToString();
                    string locationName = dtL.Rows[colIndex]["designationLieu"].ToString();

                    // Fetch the quantity asynchronously
                    DGVA.Rows[r].Cells[locationName].Value = 
                        db.FillscdToSelectCount($"SELECT COUNT(*) FROM Bien WHERE numero_sequentiel='{seqNum}' AND Id_lieu = '{locationId}'");
                }
            }
            DGVA.Columns.Add("Generaux", "Generaux");
            DGVA.Columns.Add("Sur Fiche", "Sur Fiche");
 
            DGVA.Columns.Add("+", "+");
            DGVA.Columns.Add("-", "-");
            DGVA.Columns.Add("Observation", "Observation");
            DGVA.Columns["Magasin General"].DisplayIndex = DGVA.Columns.Count - 6;
            DGVA.Columns["Instance Reforme"].DisplayIndex = DGVA.Columns.Count - 5;
            DGVA.Columns["Generaux"].DisplayIndex = DGVA.Columns.Count - 4;
            DGVA.Columns["Sur Fiche"].DisplayIndex = DGVA.Columns.Count - 3;
            DGVA.Columns["+"].DisplayIndex = DGVA.Columns.Count - 2;
            DGVA.Columns["-"].DisplayIndex = DGVA.Columns.Count - 1;
            DGVA.Columns["Observation"].DisplayIndex = DGVA.Columns.Count - 1;
            DGVA.Width = DGVA.Columns.Count * 30;
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Font FFont = new Font("Times New Roman", 7, FontStyle.Regular);
            Font DivFont = new Font("Times New Roman", 12, FontStyle.Bold);

            StringFormat centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };


            int startX = DGVD.Location.X;
            int y = DGVD.Location.Y - 128;
            int rowHeight = 128;
            int headerHeight = 18;
            //N°1
            int nw = DGVD.Columns["numero_sequentiel"].Width+2;
            Rectangle n = new Rectangle(startX , y, nw, rowHeight);
            g.FillRectangle(Brushes.White, n);
            g.DrawRectangle(Pens.Black, n);
            g.DrawString("N°", FFont, Brushes.Black, n, centerFormat);

            //  lafiche  
            int nsWidth = DGVD.Columns["numero_sequentiel1"].Width;
            int divWidth = DGVD.Columns["division"].Width;
            int fWidth = nsWidth + divWidth;
            Rectangle fRect = new Rectangle(startX + nw , y, fWidth, headerHeight);
            g.FillRectangle(Brushes.White, fRect);
            g.DrawRectangle(Pens.Black, fRect);
            g.DrawString("FICHES", FFont, Brushes.Black, fRect, centerFormat);

            //  N°2 / DIV  
            Rectangle divRect = new Rectangle(startX + nw , y + headerHeight, divWidth, rowHeight - headerHeight);
            Rectangle numRect = new Rectangle(startX + nw + divWidth, y + headerHeight, nsWidth, rowHeight - headerHeight);
            g.FillRectangle(Brushes.LightGray, divRect);
            g.DrawRectangle(Pens.Black, divRect);
            g.FillRectangle(Brushes.LightGray, numRect);
            g.DrawRectangle(Pens.Black, numRect);
            g.DrawString("DIV", DivFont, Brushes.Black, divRect, centerFormat);
            g.DrawString("N°", FFont, Brushes.Black, numRect, centerFormat);

            //  DESIGNATION
            int designWidth = DGVD.Columns["designation"].Width;
            Rectangle designationRect = new Rectangle(startX + nw + fWidth , y, designWidth, headerHeight);
            g.FillRectangle(Brushes.White, designationRect);
            g.DrawRectangle(Pens.Black, designationRect);
            g.DrawString("DESIGNATION", FFont, Brushes.Black, designationRect, centerFormat);

            // العتاد
            Rectangle materialRect = new Rectangle(startX + nw + fWidth , y + headerHeight, designWidth, rowHeight - headerHeight);
            g.FillRectangle(Brushes.LightGray, materialRect);
            g.DrawRectangle(Pens.Black, materialRect);
            g.DrawString("العتاد", DivFont, Brushes.Black, materialRect, centerFormat);

            //Affectation
            int AffectWidth = DGVA.Width - 208;
            Rectangle AffectRect = new Rectangle(startX + nw + fWidth + designWidth, y, AffectWidth, headerHeight);
            g.FillRectangle(Brushes.White, AffectRect);
            g.DrawRectangle(Pens.Black, AffectRect);
            g.DrawString("AFFECTION (sections ou services)", FFont, Brushes.Black, AffectRect, centerFormat);
            DGVA.ColumnHeadersHeight = materialRect.Height;
            DGVA.ColumnHeadersDefaultCellStyle.Font = FFont;
            //Stocks
            int Stockw = 119;
            Rectangle Stocksr = new Rectangle(startX + nw + fWidth + designWidth + AffectWidth, y, Stockw, headerHeight);
            g.FillRectangle(Brushes.White, Stocksr);
            g.DrawRectangle(Pens.Black, Stocksr);
            g.DrawString("Stocks", FFont, Brushes.Black, Stocksr, centerFormat);
            //Ecrats
            int ecraw = 59; 
            Rectangle Ecrats = new Rectangle(startX + nw + fWidth + designWidth + AffectWidth+ Stockw, y, 59, headerHeight);
            g.FillRectangle(Brushes.White, Ecrats);
            g.DrawRectangle(Pens.Black, Ecrats);
            g.DrawString("Ecrats", FFont, Brushes.Black, Ecrats, centerFormat);
            //observ
            Rectangle observ = new Rectangle(startX + nw + fWidth + designWidth + AffectWidth+Stockw+  ecraw, y, 30, headerHeight);
            g.FillRectangle(Brushes.White, observ);
            g.DrawRectangle(Pens.Black, observ);
            g.DrawString(" ", FFont, Brushes.Black, Stocksr, centerFormat);
        }

        private void DGVA_ViewCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void DGVA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void DGVA_CellPating(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                
                // Paint everything except text
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                // Get header text and styling
                string headerText = DGVA.Columns[e.ColumnIndex].HeaderText;
                Font headerFont = DGVA.ColumnHeadersDefaultCellStyle.Font;
                Brush headerBrush = new SolidBrush(DGVA.ColumnHeadersDefaultCellStyle.ForeColor);

                // Save graphics state
                GraphicsState state = e.Graphics.Save();

                // Calculate the center of the cell for rotation
                float centerX = e.CellBounds.Left + (e.CellBounds.Width / 2);
                float centerY = e.CellBounds.Top + (e.CellBounds.Height / 2);

                // Set up transformation for vertical text
                e.Graphics.TranslateTransform(centerX, centerY);
                e.Graphics.RotateTransform(270); // Rotate 90 degrees clockwise

                // Measure the text and calculate position
                SizeF textSize = e.Graphics.MeasureString(headerText, headerFont);
                float textX = -textSize.Width / 2;
                float textY = -textSize.Height / 2;

                // Draw the text
                e.Graphics.DrawString(headerText, headerFont, headerBrush, textX, textY);

                // Restore graphics state
                e.Graphics.Restore(state);

                // Mark as handled so the default painting doesn't occur
                e.Handled = true;
            }
        }
    }
}
