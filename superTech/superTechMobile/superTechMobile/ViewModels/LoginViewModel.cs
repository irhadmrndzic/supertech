using superTech.Models.User;
using superTechMobile.APIService;
using superTechMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using superTechMobile.ViewModels.Registration;

namespace superTechMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService.APIService _usersApiService = new APIService.APIService("users");
        public ICommand LoginCommand { get; }

        string _username = string.Empty;
        string _password = string.Empty;

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);

            }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await OnLoginClicked());
        }

        private async Task OnLoginClicked()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");

            IsBusy = true;

            APIService.APIService.Username = Username;
            APIService.APIService.Password = Password;

            try
            {
                await _usersApiService.Get<object>(null);

                Application.Current.MainPage = new AppShell();

            }
            catch (Exception exception)
            {
                await Application.Current.MainPage.DisplayAlert("Login", exception.Message, "OK");
            }
        }
     
    }
}
