
using Moussadjal_mobile_app.Pages;

namespace Moussadjal_mobile_app
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Login());
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            window.X = 1250;
            window.Y = 70;
            window.Width = 350;
            window.Height = 650;
            return window;
        }
    }
}
