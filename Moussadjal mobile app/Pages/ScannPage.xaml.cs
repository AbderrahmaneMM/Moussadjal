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

    private void BcReader_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        var first = e.Results.FirstOrDefault();
        if (first is null) return;
        Dispatcher.DispatchAsync(async () =>
        {
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
       // BcReader.IsTorchOn = !BcReader.IsTorchOn;
       this.Navigation.PushAsync(new ComfirmScann());
    }
    private void BackClicked(object sender, EventArgs e)
    {
    }
}