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
            db.remplirgridview("Select numero_sequentiel, division, numero_sequentiel, designation, observation  from Description_de_bien", DGVR);

            DGVR.RightToLeft = RightToLeft.Yes;

            DGVR.Columns["numero_sequentiel"].HeaderText = "N°";
            DGVR.Columns["numero_sequentiel"].MinimumWidth = 35;
            DGVR.Columns["numero_sequentiel"].Width = 38;
            DGVR.Columns["division"].HeaderText = "DIV";
            DGVR.Columns["division"].MinimumWidth = 20;
            DGVR.Columns["division"].Width = 29;
            DGVR.Columns["numero_sequentiel1"].HeaderText = "N°";
            DGVR.Columns["numero_sequentiel1"].MinimumWidth = 40;
            DGVR.Columns["numero_sequentiel1"].Width = 52;
            DGVR.Columns["designation"].HeaderText = "المواد";
            DGVR.Columns["designation"].MinimumWidth = 40;
            DGVR.Columns["designation"].Width = 548;
            DGVR.Columns["observation"].HeaderText = "الملاحظات";
            DGVR.Columns["observation"].MinimumWidth = 40;
            //DGVR.Columns["observation"].Width = 245;
  
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // تنسيقات الخطوط
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            Font subHeaderFont = new Font("Arial", 10, FontStyle.Bold);
            StringFormat centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // الحصول على عرض اللوحة
            int panelWidth = DGVR.Width;

            // إحداثيات البداية (من اليمين)
            int startX = panelWidth;
            int y = DGVR.Location.Y-100;
            int rowHeight = 50;
            //N°1
            int nw = DGVR.Columns["numero_sequentiel"].Width+2;
            Rectangle n = new Rectangle(startX - nw, y, nw, rowHeight * 2);
            g.FillRectangle(Brushes.LightGray, n);
            g.DrawRectangle(Pens.Black, n);
            g.DrawString("N", headerFont, Brushes.Black, n, centerFormat);

            // 🔷 البطاقة (العنوان الكبير)
            int nsWidth = DGVR.Columns["numero_sequentiel1"].Width;
            int divWidth = DGVR.Columns["division"].Width;
            int cardWidth = nsWidth + divWidth;
            Rectangle carteRect = new Rectangle(startX - nw - cardWidth, y, cardWidth, rowHeight);
            g.FillRectangle(Brushes.LightGray, carteRect);
            g.DrawRectangle(Pens.Black, carteRect);
            g.DrawString("البطاقة", headerFont, Brushes.Black, carteRect, centerFormat);

            // 🔹 N° و DIV تحت البطاقة (بالترتيب العكسي)
           
            Rectangle divRect = new Rectangle(startX - nw - divWidth, y + rowHeight, divWidth, rowHeight);
            Rectangle numRect = new Rectangle(startX - nw - cardWidth, y + rowHeight, nsWidth, rowHeight);
            g.FillRectangle(Brushes.LightGray, divRect);
            g.DrawRectangle(Pens.Black, divRect);
            g.FillRectangle(Brushes.LightGray, numRect);
            g.DrawRectangle(Pens.Black, numRect);
            g.DrawString("DIV", subHeaderFont, Brushes.Black, divRect, centerFormat);
            g.DrawString("N°", subHeaderFont, Brushes.Black, numRect, centerFormat);

            // 🔷 التعيين
            int designWidth = DGVR.Columns["designation"].Width;
            Rectangle designationRect = new Rectangle(startX - nw - cardWidth - designWidth, y, designWidth, rowHeight);
            g.FillRectangle(Brushes.LightGray, designationRect);
            g.DrawRectangle(Pens.Black, designationRect);
            g.DrawString("التعيين", headerFont, Brushes.Black, designationRect, centerFormat);

            // 🔹 المواد
            Rectangle materialRect = new Rectangle(startX - nw - cardWidth - designWidth, y + rowHeight, designWidth, rowHeight);
            g.FillRectangle(Brushes.LightGray, materialRect);
            g.DrawRectangle(Pens.Black, materialRect);
            g.DrawString("المواد", subHeaderFont, Brushes.Black, materialRect, centerFormat);

            // 🔷 ملاحظات
            int noteWidth = DGVR.Columns["observation"].Width;
            Rectangle noteRect = new Rectangle(startX - nw - cardWidth - designWidth - noteWidth, y, noteWidth, rowHeight * 2);
            g.FillRectangle(Brushes.LightGray, noteRect);
            g.DrawRectangle(Pens.Black, noteRect);
            g.DrawString("ملاحظات", headerFont, Brushes.Black, noteRect, centerFormat);
        }
    }
}
