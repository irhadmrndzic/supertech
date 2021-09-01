using superTech.Models.Offers;
using superTechMobile.ViewModels.Offers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views.Offers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OffersPage : ContentPage
    {
        private readonly OffersViewModel _model = null;

        public OffersPage()
        {
            InitializeComponent();
            BindingContext = new OffersViewModel();
            BindingContext = _model = new OffersViewModel();
        }

        protected async override void OnAppearing()
        {
            await _model.Init();
            base.OnAppearing();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new OfferDetailsPage((OffersModel)e.SelectedItem));

        }
    }
}