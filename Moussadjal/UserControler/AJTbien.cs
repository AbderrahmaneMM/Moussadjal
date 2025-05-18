using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ZXing.Common;
using ZXing.Rendering;
using ZXing;
using System.Drawing.Printing;
using Guna.UI2.WinForms;
using ZXing.Presentation;
using System.Windows.Markup;

namespace Moussadjal.UserControler
{
    public partial class AJTbien: UserControl
    {
        public AJTbien()
        {
            InitializeComponent();
        }

        Database db = new Database();
     
        private void AJTbien_Load(object sender, EventArgs e)
        {
            db.remlirCombo("Description_de_bien", NsComboBox, "designation", "numero_sequentiel");
            db.remlirCombo("Lieu", LieuComboBox, "designationLieu", "Id_lieu");
        
        }
            string Div, Ns, Ann, L, Ni ,Nu;

        private void Ajtbtn_Click(object sender, EventArgs e)
        {
            label3.Text = LieuComboBox.Text;
            try
            {
                        var barcodeWriter = new ZXing.BarcodeWriter
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
                if (guna2CheckBox1.Checked)
                {
                        Ns = NsComboBox.SelectedValue.ToString();
                        Div = db.SELECT("select division from Description_de_bien where numero_sequentiel ='" + Ns + "'");
                         Ni = NiTextBox1.Text;

                        Ann = AnnDTP.Value.Year.ToString();
                        L = LieuComboBox.SelectedValue.ToString();
                         Nu = $"Division: {Div}\nArticle N°: {Ns}/{NsComboBox.Text}\nN° Inventaire: {Ni + 1}\n Année d'entrée: {Ann}\n Lieu d'utilisation: \n {L}.";

                }

                else
                {
                    Ns = NsComboBox.SelectedValue.ToString();
                    Div = db.SELECT("select division from Description_de_bien where numero_sequentiel ='" + Ns + "'");
                    Ni = Convert.ToString( db.FillscdToSelectCount("SELECT COUNT(*)+1 FROM Bien"));

                    Ann = DateTime.Now.Year.ToString();
                     L = LieuComboBox.SelectedValue.ToString();
                     Nu = $"Division: {Div}\nArticle N°: {Ns}/{NsComboBox.Text}\nN° Inventaire: {Ni + 1}\n Année d'entrée: {Ann}\n Lieu d'utilisation:  {L}.";
  
                }

                label6.Text = Div + "/" + Ns + "/" + Ni + "/" + db.SELECT("select '" + Ann + "'% 100 ") + "/" + L;
                Bitmap barcodeBitmap = barcodeWriter.Write(Nu);
                pictureBox1.Image = barcodeBitmap;
                //insert 'bien' to db
                db.Ajouter("  INSERT INTO Bien (numero_dinventaire, numero_sequentiel, Id_lieu ,Annee) VALUES ('" + Convert.ToInt32(Ni) + "', '" + Convert.ToInt32(Ns) + "', '" + L + "','" + Convert.ToInt32(Ann) + "')");
                db.Ajouter("UPDATE Description_de_bien SET quantite = quantite + 1 WHERE numero_sequentiel = '" + Convert.ToInt32(NsComboBox.SelectedValue) + "' ");
                MessageBox.Show("add secsses", (Ni).ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                catch (Exception ex)
                {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
        }

        private void mailtxtboxkey(object sender, KeyEventArgs e)
        {
       
        }

        private void BarcodPicture_Click(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked) { NiTextBox1.Enabled = true; AnnDTP.Enabled = true; }
            else{ AnnDTP.Enabled = false; NiTextBox1.Enabled = false; }
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

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

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

        private void AnneComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
