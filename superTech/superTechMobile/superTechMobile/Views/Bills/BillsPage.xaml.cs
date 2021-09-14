using superTech.Models.Bills;
using superTechMobile.ViewModels.Bills;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views.Bills
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BillsPage : ContentPage
    {
        private readonly BillsViewModel _model = null;

        public BillsPage()
        {
            InitializeComponent();
            BindingContext = new BillsViewModel();
            BindingContext = _model = new BillsViewModel();
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
            await Navigation.PushAsync(new BillsDetailsPage((BillsModel)e.SelectedItem));
        }
    }
}