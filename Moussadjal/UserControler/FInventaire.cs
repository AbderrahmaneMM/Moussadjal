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
    public partial class FInventaire : UserControl
    {
        public FInventaire()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private void FInventaire_Load(object sender, EventArgs e)
        {
            db.EmptyDataGridView(DGVD);
            db.remplirgridview("Select numero_sequentiel, division, numero_sequentiel, designation  from Description_de_bien", DGVD);

            //N°1
            DGVD.Columns["numero_sequentiel"].MinimumWidth = 10;
            DGVD.Columns["numero_sequentiel"].Width = 18;
            //DIV
            DGVD.Columns["division"].MinimumWidth = 10;
            DGVD.Columns["division"].Width = 18;
            //N2
            DGVD.Columns["numero_sequentiel1"].MinimumWidth = 10;
            DGVD.Columns["numero_sequentiel1"].Width = 20;
            //العتاد
            DGVD.Columns["designation"].MinimumWidth = 40;
           // DGVD.Columns["designation"].Width = 250;

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
            int y = DGVD.Location.Y - 100;
            int rowHeight = 100;
            int headerHeight = 18;
            //N°1
            int nw = DGVD.Columns["numero_sequentiel"].Width + 2;
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
        }
    }
}
