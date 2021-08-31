using superTechMobile.ViewModels.UserDetails;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views.UserDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailsPage : ContentPage
    {
        private readonly UserDetailsViewModel _model;
        public UserDetailsPage()
        {
            InitializeComponent();
            BindingContext = new UserDetailsViewModel();
            BindingContext = _model = new UserDetailsViewModel();
        }


        protected async override void OnAppearing()
        {
            await _model.Init();
            base.OnAppearing();
        }

        private void Entry_TextChangedPhoneNumber(object sender, TextChangedEventArgs e)
        {
            
            if (e.OldTextValue != null)
            {
                if(e.NewTextValue != _model.OldPhoneNumber)
                {
                    _model.IsTextChangedPhoneNumber = true;
                    _model.PhoneNumber = e.NewTextValue;
                }
                else
                {
                    _model.IsTextChangedPhoneNumber = false;
                }
            }

            if(_model.IsTextChangedPhoneNumber || _model.IsTextChangedEmail)
            {
                _model.IsTextChanged = true;
            }
            else
            {
                _model.IsTextChanged = false;
            }
        }

        private void Entry_TextChangedEmail(object sender, TextChangedEventArgs e)
        {

            if (e.OldTextValue != null)
            {
                if(e.NewTextValue != _model.OldEmail)
                {
                    _model.IsTextChangedEmail = true;
                    _model.Email = e.NewTextValue;
                }
                else
                {
                    _model.IsTextChangedEmail = false;
                }
            }
            if (_model.IsTextChangedPhoneNumber || _model.IsTextChangedEmail)
            {
                _model.IsTextChanged = true;
            }
            else
            {
                _model.IsTextChanged = false;

            }
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
          await  _model.onSaveClicked();
        }
    }
}