using superTechMobile.ViewModels.Registration;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views.RegistrationVIew
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {

        private readonly RegistrationViewModel _model = null;
        public RegistrationPage()
        {
            InitializeComponent();
                this.BindingContext = new RegistrationViewModel();
                BindingContext = _model = new RegistrationViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _model.Init();
        }
    }
}