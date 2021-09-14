using superTech.Models.Bills;
using superTechMobile.ViewModels.DelivererBIlls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views.DelivererBills
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DelivererBillsDetailsPage : ContentPage
    {
        private readonly DelivererBillsDetailsViewModel _model = null;

        public DelivererBillsDetailsPage(BillsModel model)
        {
            InitializeComponent();
            this.BindingContext = new DelivererBillsDetailsViewModel();
            BindingContext = _model = new DelivererBillsDetailsViewModel();
            _model.BillDetailId = model.BillId;
        }

        protected override void OnAppearing()
        {
            _model.loadBillDetails();
            base.OnAppearing();
        }

        private async void closeBillBtn_Clicked(object sender, EventArgs e)
        {
            await _model.CloseBill();
        }
    }
}