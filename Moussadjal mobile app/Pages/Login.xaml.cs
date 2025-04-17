namespace Moussadjal_mobile_app.Pages;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
     
    private void LoginButton_Clicked(object sender, EventArgs e)
    {
        this.Navigation.PushAsync(new MainPage());
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {

    }
}