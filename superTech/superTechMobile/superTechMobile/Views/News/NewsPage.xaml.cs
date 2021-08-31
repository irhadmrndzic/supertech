using superTech.Models.News;
using superTechMobile.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views.News
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : ContentPage
    {
        private readonly NewsViewModel _model = null;
        public NewsPage()
        {
            InitializeComponent();
            BindingContext = new NewsViewModel();
            BindingContext = _model = new NewsViewModel();
        }

        protected async override void OnAppearing()
        {
            await _model.Init();
            base.OnAppearing();
        }



        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new NewsDetailsPage((NewsModel)e.SelectedItem));
        }
    }
}