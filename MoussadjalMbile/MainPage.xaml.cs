namespace MoussadjalMbile
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            bgv.Value = $"barcode{entry.Text}";
            BarcodeImage.Source = bgv.Value;
        }
    }

}
