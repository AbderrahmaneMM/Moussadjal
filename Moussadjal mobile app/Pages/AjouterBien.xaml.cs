namespace Moussadjal_mobile_app.Pages;

public partial class AjouterBien : ContentPage
{
	public AjouterBien()
	{
		InitializeComponent();
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
    private void PhotoButton_Clicked(object sender, EventArgs e)
	{
        
    }
    private async void SaveClicked(object sender, EventArgs e)
    {
        c_central db = new c_central();
        //desplay the barcode 
        bgv.Value = $"Numero sequential: {NameEntry.Text}\nNumero d'inventaire: {DescriptionEditor.Text}";
        BarcodeImage.Source = bgv.Value;
        // convert image to byte array 
        byte[] img = await ConvertImageToByteArray(BarcodeImage.Source);
        //save in database 
       // db.FillscdToInsert("INSERT INTO Bien (numero_dinventaire, numero_sequentiel, id_lieu, datamatrix_code) VALUES ('" + int.Parse(InventoryEntry.Text) + "', '" + int.Parse(SequentialEntry.Text) + "', '" + PlaceEntry.Text + "', '" + img + "')");
       await DisplayAlert("add secsses", NameEntry.Text + DescriptionEditor.Text, "ok");

    }
    private void CancelClicked(object sender, EventArgs e)
    {

    }
}