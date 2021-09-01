using superTech.Models.Offers;
using superTechMobile.ViewModels.Offers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views.Offers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OfferDetailsPage : ContentPage
    {
        private readonly OfferDetailsViewModel _model = null;

        public OfferDetailsPage(OffersModel model)
        {
            InitializeComponent();
            this.BindingContext = new OfferDetailsViewModel();
            BindingContext = _model = new OfferDetailsViewModel();
            _model.OfferDetailId = model.OfferId;
        }

        protected override void OnAppearing()
        {
            _model.loadOfferDetails();
            base.OnAppearing();
        }
    }
}