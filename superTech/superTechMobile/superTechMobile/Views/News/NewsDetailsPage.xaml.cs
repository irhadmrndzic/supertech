
using superTech.Models.News;
using superTechMobile.ViewModels.News;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views.News
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsDetailsPage : ContentPage
    {
        private readonly NewsDetailsViewModel _model = null;

        public NewsDetailsPage()
        {

        }
        public NewsDetailsPage(NewsModel model)
        {
            InitializeComponent();
            this.BindingContext = new NewsDetailsViewModel();
            BindingContext = _model = new NewsDetailsViewModel();
            _model.NewsId = model.NewsId;
        }

        protected override void OnAppearing()
        {
            _model.loadNewsDetails();
            base.OnAppearing();
        }

    }
}