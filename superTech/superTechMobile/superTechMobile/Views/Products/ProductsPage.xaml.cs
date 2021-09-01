using superTech.Models.Product;
using superTechMobile.ViewModels.Products;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views.Products
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        private readonly ProductsViewModel _model = null;

        public ProductsPage()
        {
            InitializeComponent(); 
            BindingContext = new ProductsViewModel();
            BindingContext = _model = new ProductsViewModel();
        }

        protected async override void OnAppearing()
        {
           await _model.Init();
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            _model.SelectedCategory = null;
            base.OnDisappearing();
        }
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ProductDetailsPage((ProductModel)e.SelectedItem));
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            _model.Reset();
        }
    }
}