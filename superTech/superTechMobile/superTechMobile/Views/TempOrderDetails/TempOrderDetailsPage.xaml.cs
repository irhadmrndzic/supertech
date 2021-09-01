using superTechMobile.ViewModels.TempOrderDetails;
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
    }
}