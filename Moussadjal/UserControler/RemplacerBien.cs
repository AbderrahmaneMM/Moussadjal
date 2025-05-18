using Guna.UI2.WinForms;
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
    public partial class RemplacerBien : UserControl
    {
        public RemplacerBien()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private void Ajtbtn_Click(object sender, EventArgs e)
        {
            string Div, Ns, Ann, L;
            try
            {
                var barcodeWriter = new BarcodeWriter
                {
                    Format = BarcodeFormat.DATA_MATRIX,
                    Options = new EncodingOptions
                    {
                        Height = 300,
                        Width = 300,
                        Margin = 10,
                    },
                    Renderer = new BitmapRenderer()
                };
                Ns = NsComboBox.SelectedValue.ToString();
                Div = db.SELECT("select division from Description_de_bien where numero_sequentiel ='" + Ns + "'");
                string Ni =  db.SELECT("select numero_dinventaire from Bien where numero_sequentiel ='" + Ns + "'");

                Ann = db.SELECT("select Annee from Bien where numero_sequentiel ='" + Ns + "'");
                L = LieuComboBox.SelectedValue.ToString();
                string Nu = $"Division: {Div}\nArticle N°: {Ns}/{NsComboBox.Text}\nN° Inventaire: {Ni + 1}\n Année d'entrée: {Ann}\n Lieu d'utilisation: \n {L}.";

                label6.Text = Div + "/" + Ns + "/" + Ni + "/" + db.SELECT("select '" + Ann + "'% 100 ") + "/" + L;
                Bitmap barcodeBitmap = barcodeWriter.Write(Nu);
                pictureBox1.Image = barcodeBitmap;


                DataTable nsBien = db.DtOfSelect("SELECT TOP " + guna2NumericUpDown1.Value + " * FROM Bien WHERE numero_sequentiel = '" + Convert.ToInt32(NsComboBox.SelectedValue) + "'");
                int q = Convert.ToInt32(guna2NumericUpDown1.Value.ToString());
                for (int i = 0; i < q; i++) {
                    nsBien.Rows[i]["Id_lieu"] = LieuComboBox.SelectedValue.ToString(); }
                MessageBox.Show(q.ToString());
            }
            catch (Exception ex) {
               MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RemplacerBien_Load(object sender, EventArgs e)
        {
            db.remlirCombo("Description_de_bien", NsComboBox, "designation", "numero_sequentiel");
            db.remlirCombo("Lieu", LieuComboBox, "designationLieu", "Id_lieu");
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmprint = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bmprint, new Rectangle(0, 0, panel1.Width, panel1.Height));
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
            float widthInInches = 80f / 25.4f;
            float heightInInches = 125f / 25.4f;

            PaperSize labelPaperSize = new PaperSize("Label 80x125mm",
                (int)(widthInInches * 100),
                (int)(heightInInches * 100));

            printDocument1.DefaultPageSettings.PaperSize = labelPaperSize;
            printDocument1.DefaultPageSettings.Landscape = false;
            printDocument1.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5);


            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }
    }
}
