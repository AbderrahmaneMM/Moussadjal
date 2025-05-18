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
using System.Drawing.Drawing2D;

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
            panel1.DrawToBitmap(bmprint, new Rectangle(0, 0, panel1.Width, panel1.Height));
            bmprint.SetResolution(300, 300);

            // حفظ حالة الرسومات الأصلية
            GraphicsState originalState = e.Graphics.Save();

            // تدوير الرسومات 90 درجة
            e.Graphics.RotateTransform(90);

            // نقل نقطة الأصل بعد التدوير
            e.Graphics.TranslateTransform(0, -e.PageBounds.Width);

            // رسم الصورة (لاحظ أننا نستخدم الأبعاد الأصلية بدون تغيير)
            e.Graphics.DrawImage(bmprint, new Rectangle(0, 0, bmprint.Width, bmprint.Height));

            // استعادة حالة الرسومات الأصلية
            e.Graphics.Restore(originalState);

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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string Div, Ns, Ann, Ni, L,idl;
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
              
                Ann = db.SELECT("select Annee from Bien  where numero_dinventaire ='"+ guna2ComboBox2 .Text.ToString()+ "'");
                L = LieuComboBox.SelectedValue.ToString();
                string Nu = $"Division: {Div}\nArticle N°: {Ns}/{DescreptionComboBox.Text}\nN° Inventaire: {Ni}\n Année d'entrée: {Ann}\n Lieu d'utilisation: \n {L}.";
               
                label6.Text = Div + "/" + Ns + "/" + Ni + "/" + db.SELECT("select Annee% 100 from Bien  where numero_dinventaire ='" + guna2ComboBox2.Text.ToString() + "'") + "/" + L;
                Bitmap barcodeBitmap = barcodeWriter.Write(Nu);
                pictureBox1.Image = barcodeBitmap;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
