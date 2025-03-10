using System.Data;
using ZXing.Net;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Maui.Controls;
using ZXing.Common;
using ZXing;
using SkiaSharp;
using ZXing.PDF417.Internal;



namespace Moussadjal_mobile_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        byte[] convertToByte(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
               // img.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }

        }
        private async Task<byte[]> ConvertImageToByteArray(ImageSource imageSource)
        {
            if (imageSource is StreamImageSource streamImageSource)
            {
                using (Stream stream = await streamImageSource.Stream(CancellationToken.None))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        await stream.CopyToAsync(ms);
                        return ms.ToArray();
                    }
                }
            }
            return null;
        }

        private async void GenerateButton_Clicked(object sender, EventArgs e)
        {
            c_central db = new c_central();
            //desplay the barcode 
             bgv.Value = $"Numero sequential: {SequentialEntry.Text}\nNumero d'inventaire: {InventoryEntry.Text}\nLieu: {PlaceEntry.Text}";
             BarcodeImage.Source = bgv.Value;
            //convert image to byte array 
            byte[] img = await ConvertImageToByteArray(BarcodeImage.Source);
            //save in database 
            db.FillscdToInsert("INSERT INTO Bien (numero_dinventaire, numero_sequentiel, id_lieu, datamatrix_code) VALUES ('"+ int.Parse(InventoryEntry.Text) + "', '"+ int.Parse(SequentialEntry.Text) + "', '"+ PlaceEntry.Text + "', '"+img+"')");
            DisplayAlert("add secsses", InventoryEntry.Text + SequentialEntry.Text, "ok");

        }

        private void GoToScann_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ScannPage());
        }
    }

}
