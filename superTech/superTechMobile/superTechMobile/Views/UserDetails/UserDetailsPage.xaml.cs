using Plugin.Media;
using Plugin.Media.Abstractions;
using superTechMobile.ViewModels.UserDetails;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views.UserDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailsPage : ContentPage
    {
        private readonly UserDetailsViewModel _model;
        private MediaFile _mediaFile;

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

            if(_model.IsTextChangedPhoneNumber || _model.IsTextChangedEmail || _model.IsImageChanged)
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
            if (_model.IsTextChangedPhoneNumber || _model.IsTextChangedEmail || _model.IsImageChanged)
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

        private async void pickPhotoBtn_Clicked(object sender, System.EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Nije moguće odabrati sliku", "OK");
                return;

            }

            _mediaFile = await CrossMedia.Current.PickPhotoAsync();

            if (_mediaFile == null)
            {
                return;
            }


            FileImage.Source = ImageSource.FromStream(() =>
            {
                return _mediaFile.GetStream();
            });


            _model.Content = new MultipartFormDataContent();

            _model.Content.Add(new StreamContent(_mediaFile.GetStream()),"\"file\"",$"\"{_mediaFile.Path}\"");
            _model.MediaFile = _mediaFile;
            _model.IsImageChanged = true;
            _model.IsTextChanged = true;

        }

    }
}