using superTechMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace superTechMobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}