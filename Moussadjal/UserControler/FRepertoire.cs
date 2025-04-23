using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moussadjal.UserControler
{
    public partial class FRepertoire : UserControl
    {
        public FRepertoire()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private void FRepertoire_Load(object sender, EventArgs e)
        {
            db.EmptyDataGridView(DGVR);
            db.remplirgridview("Select numero_sequentiel, division, numero_sequentiel, designation, observation  from Description_de_bien", DGVR);

            DGVR.RightToLeft = RightToLeft.Yes;

            //N°1
            DGVR.Columns["numero_sequentiel"].MinimumWidth = 35;
            DGVR.Columns["numero_sequentiel"].Width = 38;
            //DIV 
            DGVR.Columns["division"].MinimumWidth = 20;
            DGVR.Columns["division"].Width = 29;
            //N2 
            DGVR.Columns["numero_sequentiel1"].MinimumWidth = 40;
            DGVR.Columns["numero_sequentiel1"].Width = 52;
            //المواد
            DGVR.Columns["designation"].MinimumWidth = 40;
            DGVR.Columns["designation"].Width = 548;
            //الملاحظات
            DGVR.Columns["observation"].MinimumWidth = 40; 
  
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            Font FFont = new Font("Arial", 10, FontStyle.Bold);
            StringFormat centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };


            int startX = DGVR.Width;
            int y = DGVR.Location.Y-100;
            int rowHeight = 100;
            int headerHeight = 30;
            //N°1
            int nw = DGVR.Columns["numero_sequentiel"].Width+2;
            Rectangle n = new Rectangle(startX - nw, y, nw, rowHeight );
            g.FillRectangle(Brushes.LightGray, n);
            g.DrawRectangle(Pens.Black, n);
            g.DrawString("N°", FFont, Brushes.Black, n, centerFormat);

            //  lafiche  
            int nsWidth = DGVR.Columns["numero_sequentiel1"].Width;
            int divWidth = DGVR.Columns["division"].Width;
            int fWidth = nsWidth + divWidth;
            Rectangle fRect = new Rectangle(startX - nw - fWidth, y, fWidth, headerHeight);
            g.FillRectangle(Brushes.LightGray, fRect);
            g.DrawRectangle(Pens.Black, fRect);
            g.DrawString("البطاقة", FFont, Brushes.Black, fRect, centerFormat);

            //  N°2 / DIV  
            Rectangle divRect = new Rectangle(startX - nw - divWidth, y + headerHeight, divWidth, rowHeight-headerHeight);
            Rectangle numRect = new Rectangle(startX - nw - fWidth, y  + headerHeight, nsWidth, rowHeight - headerHeight);
            g.FillRectangle(Brushes.LightGray, divRect);
            g.DrawRectangle(Pens.Black, divRect);
            g.FillRectangle(Brushes.LightGray, numRect);
            g.DrawRectangle(Pens.Black, numRect);
            g.DrawString("DIV", FFont, Brushes.Black, divRect, centerFormat);
            g.DrawString("N°", FFont, Brushes.Black, numRect, centerFormat);

            //  التعيين
            int designWidth = DGVR.Columns["designation"].Width;
            Rectangle designationRect = new Rectangle(startX - nw - fWidth - designWidth, y, designWidth, headerHeight);
            g.FillRectangle(Brushes.LightGray, designationRect);
            g.DrawRectangle(Pens.Black, designationRect);
            g.DrawString("التعيين", FFont, Brushes.Black, designationRect, centerFormat);

            // المواد
            Rectangle materialRect = new Rectangle(startX - nw - fWidth - designWidth, y + headerHeight, designWidth, rowHeight - headerHeight);
            g.FillRectangle(Brushes.LightGray, materialRect);
            g.DrawRectangle(Pens.Black, materialRect);
            g.DrawString("المواد", FFont, Brushes.Black, materialRect, centerFormat);

            // observation
            int noteWidth = DGVR.Columns["observation"].Width;
            Rectangle noteRect = new Rectangle(startX - nw - fWidth - designWidth - noteWidth, y, noteWidth, rowHeight );
            g.FillRectangle(Brushes.LightGray, noteRect);
            g.DrawRectangle(Pens.Black, noteRect);
            g.DrawString("ملاحظات", FFont, Brushes.Black, noteRect, centerFormat);
        }

        private void DGVR_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
