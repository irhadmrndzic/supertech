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
    public partial class DelivererOrderDetailsPage : ContentPage
    {
        private readonly DelivererOrderDetailsViewModel _model = null;
        public DelivererOrderDetailsPage(BuyerOrdersModel model)
        {
            InitializeComponent();
            this.BindingContext = new DelivererOrderDetailsViewModel();
            BindingContext = _model = new DelivererOrderDetailsViewModel();
            _model.OrderDetailId = model.BuyerOrderId;
            _model.Confirmed = model.Confirmed;
        }

        protected override void OnAppearing()
        {
            _model.loadOrdersDetails();
            base.OnAppearing();
        }

        private async void orderConfirmBtn_Clicked(object sender, EventArgs e)
        {
            await _model.confirmOrderDelivery();
        }
    }
}