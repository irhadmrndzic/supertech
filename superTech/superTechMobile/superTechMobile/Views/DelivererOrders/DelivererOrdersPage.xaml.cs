using superTech.Models.BuyerOrders;
using superTechMobile.ViewModels.DelivererOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views.DelivererOrders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DelivererOrdersPage : ContentPage
    {
        private readonly DelivererOrdersViewModel _model = null;

        public DelivererOrdersPage()
        {
            InitializeComponent();
            BindingContext = new DelivererOrdersViewModel();
            BindingContext = _model = new DelivererOrdersViewModel();
        }

        protected async override void OnAppearing()
        {
            await _model.Init();
            base.OnAppearing();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new DelivererOrderDetailsPage((BuyerOrdersModel)e.SelectedItem));
        }
    }
}