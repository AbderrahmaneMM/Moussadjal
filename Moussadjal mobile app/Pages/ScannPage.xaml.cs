using Moussadjal_mobile_app.Pages;
using ZXing.Net.Maui;
namespace Moussadjal_mobile_app;

public partial class ScannPage : ContentPage
{
	public ScannPage()
	{
		InitializeComponent();
        BcReader.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormat.DataMatrix,
            AutoRotate = true,
            Multiple = true
        };
    }
    string lastLine;
    c_central db = new c_central();
    private void BcReader_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        var first = e.Results.FirstOrDefault();
        if (first is null) return;
        Dispatcher.DispatchAsync(async () =>
        {
            string barcodeText = first.Value ?? string.Empty;

            string[] lines = barcodeText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
             lastLine = lines.LastOrDefault() ;
            await DisplayAlert("Barcode Detected", first.Value, "OK");

        });
    }
    private void ConfirmScanClicked(object sender, EventArgs e)
       {
    }
    private void CancelScanClicked(object sender, EventArgs e)
    {
    }
    private void TorchClicked(object sender, EventArgs e)
    {
       
        try
        {
            if (string.IsNullOrWhiteSpace(lastLine))
            {
                 DisplayAlert("Erreur", "Aucun code scanné", "OK");
                return;
            }
            else 
            { 
                this.Navigation.PushAsync(new Detaildelieu(lastLine.Normalize(), db.SELECT("select designationLieu from Lieu where Id_lieu = '" + lastLine + "'").ToString()));
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }
    }
    private async void BackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}