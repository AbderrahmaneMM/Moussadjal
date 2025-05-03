using System.Data;
using ZXing.Net;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Maui.Controls;
using ZXing.Common;
using ZXing;
using SkiaSharp;
using ZXing.PDF417.Internal;
using Moussadjal_mobile_app.Pages;

namespace Moussadjal_mobile_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    

      
        private void Logout_Clicked(object sender, EventArgs e)
        {
        
        }
        private  void Scann_Tapped(object sender, TappedEventArgs e)
        {
            this.Navigation.PushAsync(new ScannPage());
        }
    
        private  void Ajouter_Tapped(object sender, TappedEventArgs e)
        {
            this.Navigation.PushAsync(new AjouterBien());
        }
        private  void Local_Tapped(object sender, TappedEventArgs e)
        {
            this.Navigation.PushAsync(new Locaux());
        }
        private  void SettingTapped(object sender, TappedEventArgs e)
        {
            this.Navigation.PushAsync(new Setting());
        }
    }   
}
