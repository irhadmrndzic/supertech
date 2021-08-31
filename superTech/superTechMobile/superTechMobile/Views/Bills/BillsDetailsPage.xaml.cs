using superTech.Models.Bills;
using superTechMobile.ViewModels.Bills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views.Bills
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BillsDetailsPage : ContentPage
    {
        private readonly BillsDetailsViewModel _model = null;

        public BillsDetailsPage(BillsModel model)
        {
            InitializeComponent();
            this.BindingContext = new BillsDetailsViewModel();
            BindingContext = _model = new BillsDetailsViewModel();
            _model.BillDetailId = model.BillId;
        }

        protected  override void OnAppearing()
        {
            _model.loadBillDetails();
            base.OnAppearing();
        }
    }
}