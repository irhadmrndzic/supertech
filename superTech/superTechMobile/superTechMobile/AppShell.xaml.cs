using superTechMobile.ViewModels;
using superTechMobile.Views;
using superTechMobile.Views.News;
using superTechMobile.Views.WelcomePage;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace superTechMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(NewsDetailsPage), typeof(NewsDetailsPage));
            Routing.RegisterRoute(nameof(NewsPage), typeof(NewsPage));
            Routing.RegisterRoute(nameof(WelcomePage), typeof(WelcomePage));
        }

        private  void onLogoutClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }
    }
}
