using superTech.Models.Bills;
using superTechMobile.ViewModels.DelivererBIlls;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views.DelivererBills
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DelivererBills : ContentPage
    {
        private readonly DelivererBillsViewModel _model = null;

        public DelivererBills()
        {
            InitializeComponent();
            BindingContext = new DelivererBillsViewModel();
            BindingContext = _model = new DelivererBillsViewModel();
        }

        protected async override void OnAppearing()
        {
            await _model.Init();
            base.OnAppearing();
        }
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new DelivererBillsDetailsPage((BillsModel)e.SelectedItem));
        }
    }

}