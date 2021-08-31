using superTech.Models.BuyerOrders;
using superTechMobile.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views.Orders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersPage : ContentPage
    {
        private readonly OrdersViewModel _model = null;

        public OrdersPage()
        {
            InitializeComponent();
            BindingContext = new OrdersViewModel();
            BindingContext = _model = new OrdersViewModel();
        }

        protected async override void OnAppearing()
        {
            await _model.Init();
            base.OnAppearing();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new OrderDetailsPage((BuyerOrdersModel)e.SelectedItem));
        }
    }
}