

using superTech.Models.BuyerOrders.BuyerOrderItems;
using superTechMobile.ViewModels.Rating;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views.Ratings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RateProductPage : ContentPage
    {
        private readonly RatingsViewModel _model = null;
        public RateProductPage(BuyerOrderItemsModel model, bool Confirmed)
        {
            InitializeComponent();
            BindingContext = new RatingsViewModel();
            BindingContext = _model = new RatingsViewModel();
            _model.Product = (int)model.FkProductId;
            _model.OrderConfirmed = Confirmed;
        }

        protected override void OnAppearing()
        {
            _model.GetUserRatings();

            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await _model.RateProduct();
        }
    }
}