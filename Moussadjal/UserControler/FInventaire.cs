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
    
        private  void  RemplirGrids()
        {
           db.EmptyDataGridView(DGVD);
           db.remplirgridview("Select TOP 30 numero_sequentiel, division, numero_sequentiel, designation from Description_de_bien", DGVD);

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
        //  Affectation  
            DataTable dtD = db.DtOfSelect("SELECT  numero_sequentiel FROM Description_de_bien WHERE numero_sequentiel BETWEEN 1 AND 30");

            DataTable dtL = db.DtOfSelect("SELECT Id_lieu, designationLieu FROM Lieu");

            //DGVA
            //  columns first
            DGVA.SuspendLayout();
            Dictionary<string, string> locationIdToName = new Dictionary<string, string>();
            foreach (DataRow locRow in dtL.Rows)
            {
                string locationName = locRow["designationLieu"].ToString();
                DGVA.Columns.Add(locationName, locationName);
                locationIdToName[locRow["Id_lieu"].ToString()] = locRow["designationLieu"].ToString();
            }
            /***/
            List<string> seqNums = new List<string>();

            DataTable countResults;

            if (seqNums.Count == 0)
            {

                DataTable emptyTable = new DataTable();
                emptyTable.Columns.Add("numero_sequentiel");
                emptyTable.Columns.Add("Id_lieu");
                emptyTable.Columns.Add("ItemCount", typeof(int));
                countResults = emptyTable;
            }
            else
            {
                string allSeqNumsStr = string.Join(",", seqNums);

                string countQuery = $@" SELECT numero_sequentiel, Id_lieu, COUNT(*) as ItemCount   FROM Bien 
                   WHERE numero_sequentiel IN ({allSeqNumsStr})  GROUP BY numero_sequentiel, Id_lieu";

                countResults = db.DtOfSelect(countQuery);
            }

            // Now countResults is in scope for the rest of your code
            // Continue with the dictionary creation and grid population
            Dictionary<string, Dictionary<string, int>> countsBySeqAndLoc = new Dictionary<string, Dictionary<string, int>>();
            foreach (DataRow row in countResults.Rows)
            {
                string seqNum = row["numero_sequentiel"].ToString();
                string locId = row["Id_lieu"].ToString();
                int count = Convert.ToInt32(row["ItemCount"]);

                if (!countsBySeqAndLoc.ContainsKey(seqNum))
                {
                    countsBySeqAndLoc[seqNum] = new Dictionary<string, int>();
                }

                countsBySeqAndLoc[seqNum][locId] = count;
            }

            // Create dictionary to store counts for fast lookup
            foreach (DataRow row in countResults.Rows)
            {
                string seqNum = row["numero_sequentiel"].ToString();
                string locId = row["Id_lieu"].ToString();
                int count = Convert.ToInt32(row["ItemCount"]);

                if (!countsBySeqAndLoc.ContainsKey(seqNum))
                {
                    countsBySeqAndLoc[seqNum] = new Dictionary<string, int>();
                }

                countsBySeqAndLoc[seqNum][locId] = count;
            }
            /**/
            // Add rows 
            DGVA.Rows.Clear();

            foreach (DataRow seqRow in dtD.Rows)
            {
                string seqNum = seqRow["numero_sequentiel"].ToString();
                int rowIndex = DGVA.Rows.Add(seqNum);

                foreach (DataRow locRow in dtL.Rows)
                {
                    string locId = locRow["Id_lieu"].ToString();
                    string locName = locRow["designationLieu"].ToString();


                    int count = 0;
                    if (countsBySeqAndLoc.ContainsKey(seqNum) && countsBySeqAndLoc[seqNum].ContainsKey(locId))
                    {
                        count = countsBySeqAndLoc[seqNum][locId];
                    }

                    DGVA.Rows[rowIndex].Cells[locName].Value = count > 0 ? count.ToString() : "";

                }
            }

            // Add  last columns  //Stocks   //Ecrats //observ
            DGVA.Columns.Add("Generaux", "Generaux");
            DGVA.Columns.Add("Sur Fiche", "Sur Fiche");
            DGVA.Columns.Add("+", "+");
            DGVA.Columns.Add("|", "|");
            DGVA.Columns.Add("Observation", "Observation");
            DGVA.Columns["Magasin General"].DisplayIndex = DGVA.Columns.Count - 6;
            DGVA.Columns["Instance Reforme"].DisplayIndex = DGVA.Columns.Count - 5;
            DGVA.Columns["Generaux"].DisplayIndex = DGVA.Columns.Count - 4;
            DGVA.Columns["Sur Fiche"].DisplayIndex = DGVA.Columns.Count - 3;
            DGVA.Columns["+"].DisplayIndex = DGVA.Columns.Count - 2;
            DGVA.Columns["|"].DisplayIndex = DGVA.Columns.Count - 1;
            DGVA.Columns["Observation"].DisplayIndex = DGVA.Columns.Count - 1;

         
        
            //make the same row height in the bouth dgv
            DGVD.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            DGVA.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            int rowCount = Math.Min(30, Math.Min(DGVD.Rows.Count, DGVA.Rows.Count));

            for (int i = 0; i < rowCount; i++)
            {
                 int  height = DGVD.Rows[i].Height;
                DGVA.Rows[i].Height = height;
            }

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
            int nw = DGVD.Columns["numero_sequentiel"].Width + 2;
            Rectangle n = new Rectangle(startX, y, nw, rowHeight);
            g.FillRectangle(Brushes.White, n);
            g.DrawRectangle(Pens.Black, n);
            g.DrawString("N°", FFont, Brushes.Black, n, centerFormat);

            //  lafiche  
            int nsWidth = DGVD.Columns["numero_sequentiel1"].Width;
            int divWidth = DGVD.Columns["division"].Width;
            int fWidth = nsWidth + divWidth;
            Rectangle fRect = new Rectangle(startX + nw, y, fWidth, headerHeight);
            g.FillRectangle(Brushes.White, fRect);
            g.DrawRectangle(Pens.Black, fRect);
            g.DrawString("FICHES", FFont, Brushes.Black, fRect, centerFormat);

            //  N°2 / DIV  
            Rectangle divRect = new Rectangle(startX + nw, y + headerHeight, divWidth, rowHeight - headerHeight);
            Rectangle numRect = new Rectangle(startX + nw + divWidth, y + headerHeight, nsWidth, rowHeight - headerHeight);
            g.FillRectangle(Brushes.LightGray, divRect);
            g.DrawRectangle(Pens.Black, divRect);
            g.FillRectangle(Brushes.LightGray, numRect);
            g.DrawRectangle(Pens.Black, numRect);
            g.DrawString("DIV", DivFont, Brushes.Black, divRect, centerFormat);
            g.DrawString("N°", FFont, Brushes.Black, numRect, centerFormat);

            //  DESIGNATION
            int designWidth = DGVD.Columns["designation"].Width;
            Rectangle designationRect = new Rectangle(startX + nw + fWidth, y, designWidth, headerHeight);
            g.FillRectangle(Brushes.White, designationRect);
            g.DrawRectangle(Pens.Black, designationRect);
            g.DrawString("DESIGNATION", FFont, Brushes.Black, designationRect, centerFormat);

            // العتاد
            Rectangle materialRect = new Rectangle(startX + nw + fWidth, y + headerHeight, designWidth, rowHeight - headerHeight);
            g.FillRectangle(Brushes.LightGray, materialRect);
            g.DrawRectangle(Pens.Black, materialRect);
            g.DrawString("العتاد", DivFont, Brushes.Black, materialRect, centerFormat);

            int obsw = DGVA.Columns["Observation"].Width;
            int ecraw = DGVA.Columns["+"].Width + DGVA.Columns["|"].Width;
            int Stockw = DGVA.Columns["Sur Fiche"].Width+ DGVA.Columns["Generaux"].Width + DGVA.Columns["Instance Reforme"].Width + DGVA.Columns["Magasin General"].Width ;
           
            //Affectation
            int AffectWidth = DGVA.Width - (obsw+ecraw+Stockw);
            Rectangle AffectRect = new Rectangle(startX + nw + fWidth + designWidth, y, AffectWidth, headerHeight);
            g.FillRectangle(Brushes.White, AffectRect);
            g.DrawRectangle(Pens.Black, AffectRect);
            g.DrawString("AFFECTION (sections ou services)", FFont, Brushes.Black, AffectRect, centerFormat);
            DGVA.ColumnHeadersHeight = materialRect.Height;
            DGVA.ColumnHeadersDefaultCellStyle.Font = FFont;
            //Stocks
           
           Rectangle Stocksr = new Rectangle(startX + nw + fWidth + designWidth + AffectWidth -2, y, Stockw, headerHeight);
            g.FillRectangle(Brushes.White, Stocksr);
            g.DrawRectangle(Pens.Black, Stocksr);
            g.DrawString("Stocks", FFont, Brushes.Black, Stocksr, centerFormat);
            //Ecrats
            Rectangle Ecrats = new Rectangle(startX + nw + fWidth + designWidth + AffectWidth + Stockw-2, y, ecraw, headerHeight);
            g.FillRectangle(Brushes.White, Ecrats);
            g.DrawRectangle(Pens.Black, Ecrats);
            g.DrawString("Ecrats", FFont, Brushes.Black, Ecrats, centerFormat);
            //observ
            Rectangle observ = new Rectangle(startX + nw + fWidth + designWidth + AffectWidth + Stockw + ecraw-2, y, obsw, headerHeight);
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

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGVA.Rows)
            {
                // Assuming the designation column is at index 0
                string designation = row.Cells[0].Value?.ToString() ?? string.Empty;

                // Measure the text size
                Size textSize = TextRenderer.MeasureText(designation, DGVA.Font, new Size(DGVA.Columns[0].Width, int.MaxValue), TextFormatFlags.WordBreak);

                // Set the row height based on the text size
                row.Height = Math.Max(textSize.Height + 4, DGVA.RowTemplate.Height);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4;

            printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
