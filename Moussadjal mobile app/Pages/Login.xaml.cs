namespace Moussadjal_mobile_app.Pages;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
     
    private async void LoginButton_Clicked(object sender, EventArgs e)
    {c_central db = new c_central();
        try
        {
            if (db.FillscdToSelectCount("SELECT COUNT(*) FROM utilisateur WHERE mail = '" + UsernameEntry.Text + "' AND motdepass = '" + PasswordEntry.Text + "'") > 0)
            {
               await this.Navigation.PushAsync(new MainPage());
            }
            else
            await DisplayAlert("Error","Nom d'utilisateur ou mot de passe invalide", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message , "OK");
        }
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {

    }
}