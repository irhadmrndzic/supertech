using superTechMobile.ViewModels.TempOrderDetails;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views.TempOrderDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TempOrderDetailsPage : ContentPage
    {
        private readonly TempOrderDetailsViewModel _model = null;

        public TempOrderDetailsPage()
        {
            InitializeComponent();
            this.BindingContext = new TempOrderDetailsViewModel();
            BindingContext = _model = new TempOrderDetailsViewModel();
        }

        protected async override void OnAppearing()
        {
           await _model.Init();
            base.OnAppearing();
        }

        public async void confirmOrderBtn_Clicked(object sender, System.EventArgs e)
        {
           await  _model.ConfirmOrder();
        }

        private async void cancelOrder_Clicked(object sender, System.EventArgs e)
        {
            await Application.Current.MainPage.DisplayAlert("Info", "Narudžba otkazana !", "OK");
            Global.Global.activeOrder = null;
            Application.Current.MainPage = new Navigation.Menu();
        }
    }
}