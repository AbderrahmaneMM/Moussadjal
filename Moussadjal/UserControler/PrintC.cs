using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Moussadjal.UserControler
{
    public partial class PrintC : UserControl
    {
        public PrintC()
        {
            InitializeComponent();
            LoadDocument();
        }
        private int d ; 
        FRepertoire r = new FRepertoire();
        FInventaire i = new FInventaire();
        Bitmap bmprint;

        public int DocumentType
        {
            get => d;
            set
            {
                d = value;
                LoadDocument(); 
            }
        }
  
        private void PrintC_Load(object sender, EventArgs e)
        { 
        }
        private void LoadDocument()
        {
            DocPanel.Controls.Clear();
            switch (d)
            { 
                case 1:
                r.Size = new Size(794, 1123); // A4 
                DocPanel.Controls.Add(r);
                 break;
                case 2:
                i.Size = new Size(1123, 794); // A4  horisontl
                DocPanel.Size = new Size(1123, 794);
                    DocPanel.Controls.Add(i);
                 break;
            }
        }
        private Bitmap GetControlImage(UserControl control)
        {
            Bitmap bmp = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(bmp, new Rectangle(0, 0, control.Width, control.Height));
            return bmp;
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            switch (d)
            {
                case 1:
                    
                    bmprint = GetControlImage(r);
                    break;
                case 2:
                    bmprint = GetControlImage(i);
                    break;
            }
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
            switch (d)
            {
                case 1:

                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
                    printDocument1.DefaultPageSettings.Landscape = false;
                    break;  
                case 2:
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169); // A4 size
                    printDocument1.DefaultPageSettings.Landscape = true;
                    break;
            }
          
            printDocument1.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
             
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
