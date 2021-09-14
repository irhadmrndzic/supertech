using superTech.Models.BuyerOrders;
using superTechMobile.ViewModels.Orders;
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
            if (APIService.APIService.cUser.RolesString.Contains("Dostavljac") || APIService.APIService.cUser.RolesString.Contains("Administrator"))
            {
                await _model.Init(true);
            }
            else
            {
                await _model.Init(false);

            }
            base.OnAppearing();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new OrderDetailsPage((BuyerOrdersModel)e.SelectedItem));
        }
    }
}