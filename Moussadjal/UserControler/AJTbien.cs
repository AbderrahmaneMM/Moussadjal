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

namespace Moussadjal.UserControler
{
    public partial class AJTbien: UserControl
    {
        public AJTbien()
        {
            InitializeComponent();
        }

        Database db = new Database();
        //save barcode as image
        byte[] convertImageToByte(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }

        }
        private void AJTbien_Load(object sender, EventArgs e)
        {
            db.remlirCombo("Description_de_bien", NsComboBox, "designation", "numero_sequentiel");
            db.remlirCombo("Lieu", LieuComboBox, "designationLieu", "Id_lieu");
        }

        private void Ajtbtn_Click(object sender, EventArgs e)
        {
            try
            {
                    //generation datamatrix barcode
                    var barcodeWriter = new BarcodeWriter
                    {
                        Format = BarcodeFormat.DATA_MATRIX,
                        Options = new EncodingOptions
                        {
                            Height = 300,
                            Width = 300,
                            Margin = 10
                        },
                        Renderer = new BitmapRenderer()
                    };
                    string NumIn = (db.FillscdToSelectCount("SELECT COUNT(*) FROM Bien")+1).ToString();
                    Bitmap barcodeBitmap = barcodeWriter.Write($"{NumIn}/{NsComboBox.Text}/{LieuComboBox.Text}");
                    BarcodPicture.Image = barcodeBitmap;
                    //convert image barcode to byte array
                    byte[] img = convertImageToByte(BarcodPicture.Image);
                    //insert 'bien' to db
                    db.Ajouter("INSERT INTO Bien (numero_dinventaire, numero_sequentiel, id_lieu, datamatrix_code) VALUES ((SELECT ISNULL(MAX(numero_dinventaire), 0) + 1 FROM Bien), '" + Convert.ToInt32(NsComboBox.SelectedValue) + "', '" + LieuComboBox.SelectedValue + "', '" + img + "')");
                     db.Ajouter("UPDATE Description_de_bien SET quantite = quantite + 1 WHERE numero_sequentiel = '" + Convert.ToInt32(NsComboBox.SelectedValue) + "' ");
                    MessageBox.Show("add secsses", NumIn, MessageBoxButtons.OK, MessageBoxIcon.Information);
              
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
    }
}
