using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;

namespace Moussadjal
{
    public partial class dashboard : Form1
    {
        public dashboard()
        {
            InitializeComponent();
        }

        Database db = new Database();
    

       
        private void dashboard_Load(object sender, EventArgs e)
        {
            db.remlirCombo("Description_de_bien", NsComboBox, "designation", "numero_sequentiel"); 
            db.remlirCombo("Lieu", LieuComboBox, "designation", "Id_lieu");

        }
         private void move(Guna2Button btn) 
         {
            btn.Checked =true;
            guna2PictureBox1.Location = new Point(btn.Location.X +116 , btn.Location.Y-23);
            guna2PictureBox1.SendToBack();
         }
        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*private void Homebutton_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }*/

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            move(guna2Button1);
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            move(guna2Button2);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            move(guna2Button3);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            move(guna2Button4);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            move(guna2Button5);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            move(guna2Button6);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            move(guna2Button7);
        }

        private void gererlesbien1_Load(object sender, EventArgs e)
        {

        }
           //save barcode as image
           byte[] convertImageToByte(Image img)
           {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }

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
                   Bitmap barcodeBitmap = barcodeWriter.Write($"{NItextbox.Text}/{NsComboBox.Text}/{LieuComboBox.Text}");
                   BarcodPicture.Image = barcodeBitmap;
                   //convert image barcode to byte array
                   byte[] img = convertImageToByte(BarcodPicture.Image);
                   //insert 'bien' to db
                   db.FillscdToInsert("INSERT INTO Bien (numero_dinventaire, numero_sequentiel, id_lieu, datamatrix_code) VALUES ('" + int.Parse(NItextbox.Text)+ "', '"+ Convert.ToInt32(NsComboBox.SelectedValue) + "', '"+LieuComboBox.SelectedValue+"', '"+img+"')");
                   MessageBox.Show("add secsses", NItextbox.Text, MessageBoxButtons.OK , MessageBoxIcon.Information);
              }
              catch (Exception ex)
              {
                  MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }
        }

        private void NsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
             
           
        }

        /* private void Ltextbox_TextChanged(object sender, EventArgs e)
         {

         }*/
    }
}
