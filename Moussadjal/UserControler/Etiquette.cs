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
using ZXing.Common;
using ZXing.Rendering;
using ZXing;

namespace Moussadjal.UserControler
{
    public partial class Etiquette : UserControl
    {
        Database db = new Database();
        public Etiquette()
        {
            InitializeComponent();
            LieuComboBox.SelectedIndexChanged += LieuComboBox_SelectedIndexChanged;
        }
        private void FillCB(object sender, EventArgs e)
        {
            if (LieuComboBox.Items.Count > 0 && LieuComboBox.SelectedValue != null)
            {
                db.FillComboWithJoinedData(
                    "Bien",
                    "numero_sequentiel",
                    "Description_de_bien",
                    "designation",
                    "Bien.numero_sequentiel = Description_de_bien.numero_sequentiel",
                    "Bien.Id_lieu",
                    LieuComboBox.SelectedValue.ToString(),
                    DescreptionComboBox);

                if (DescreptionComboBox.Items.Count > 0 && DescreptionComboBox.SelectedValue != null)
                {
                    db.FillComboWithJoinedData(
                        "Description_de_bien",
                        "numero_sequentiel",
                        "Bien",
                        "numero_dinventaire",
                        "Description_de_bien.numero_sequentiel =Bien.numero_sequentiel  ",
                        "Bien.numero_sequentiel",
                         DescreptionComboBox.SelectedValue.ToString(),
                        guna2ComboBox2 );
                  
                }
              label3.Text = LieuComboBox.Text;
            }
        }

        private void guna2VSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
             Bitmap bmprint = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bmprint, new Rectangle(0, 0, panel1.Width,  panel1.Height));
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
            FillCB( sender,  e);
        }

        private void DescreptionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DescreptionComboBox.Items.Count > 0 && DescreptionComboBox.SelectedValue != null)
            {
                db.FillComboWithJoinedData(
                    "Description_de_bien",
                    "numero_sequentiel",
                    "Bien",
                    "numero_dinventaire",
                    "Description_de_bien.numero_sequentiel =Bien.numero_sequentiel  ",
                    "Bien.numero_sequentiel",
                     DescreptionComboBox.SelectedValue.ToString(),
                     guna2ComboBox2);
            }
        }

        private void Etiquette_Load(object sender, EventArgs e)
        {
            db.remlirCombo("Lieu", LieuComboBox, "designationLieu", "Id_lieu");
            FillCB( sender,  e);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4;

            printDocument1.DefaultPageSettings.Landscape = false;
            printDocument1.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string Div, Ns, Ann, Ni, L;
            try
            {
                var barcodeWriter = new BarcodeWriter
                {
                    Format = BarcodeFormat.DATA_MATRIX,
                    Options = new EncodingOptions
                    {
                        Height = 450,
                        Width = 450,
                        Margin = 10,
                    },
                    Renderer = new BitmapRenderer()
                };
                Div = db.SELECT("select division from Description_de_bien where numero_sequentiel ='" + DescreptionComboBox.SelectedValue.ToString() + "'");
                Ns = DescreptionComboBox.SelectedValue.ToString();
                Ni = guna2ComboBox2.Text;
                Ann = db.SELECT("select annee from Description_de_bien where numero_sequentiel ='" + DescreptionComboBox.SelectedValue.ToString() + "'");
                L = LieuComboBox.SelectedValue.ToString();
                string Nu = Div+"/"+Ns+"/"+Ni+"/"+Ann+"/"+L;
                label6.Text = Nu ;
                Bitmap barcodeBitmap = barcodeWriter.Write(Nu);
                pictureBox1.Image = barcodeBitmap;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
