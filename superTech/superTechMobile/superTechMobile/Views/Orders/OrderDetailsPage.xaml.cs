using superTech.Models.BuyerOrders;
using superTech.Models.BuyerOrders.BuyerOrderItems;
using superTech.Models.Ratings;
using superTechMobile.ViewModels.Orders;
using superTechMobile.Views.Ratings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views.Orders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetailsPage : ContentPage
    {
        private readonly OrderDetailsViewModel _model = null;

        public OrderDetailsPage(BuyerOrdersModel model)
        {
            InitializeComponent();
            this.BindingContext = new OrderDetailsViewModel();
            BindingContext = _model = new OrderDetailsViewModel();
            _model.OrderDetailId = model.BuyerOrderId;
            _model.Confirmed = model.Confirmed;
        }


        protected override void OnAppearing()
        {
            _model.loadOrdersDetails();
            base.OnAppearing();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new RateProductPage((BuyerOrderItemsModel)e.SelectedItem, _model.Confirmed));
        }
    }
}