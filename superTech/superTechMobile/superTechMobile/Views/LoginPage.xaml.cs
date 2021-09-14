using superTechMobile.ViewModels;
using superTechMobile.Views.RegistrationVIew;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            Global.Global.activeOrder = null;
            await Application.Current.MainPage.Navigation.PushAsync(new RegistrationPage());
        }
    }
}