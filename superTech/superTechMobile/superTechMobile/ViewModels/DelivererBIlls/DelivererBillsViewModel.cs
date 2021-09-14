using superTech.Models.Bills;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace superTechMobile.ViewModels.DelivererBIlls
{
   public class DelivererBillsViewModel:BaseViewModel
    {
        private readonly APIService.APIService _billsApiService = new APIService.APIService("bills");
        public ObservableCollection<BillsModel> BillsList { get; set; } = new ObservableCollection<BillsModel>();
        public ICommand InitCommand { get; set; }


        public DelivererBillsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public async Task Init()
        {

            try
            {
                BillsSearchRequest request = new BillsSearchRequest();
                request.Status = false;
                IsBusy = true;
                var list = await _billsApiService.Get<List<BillsModel>>(request);
                BillsList.Clear();
                foreach (var item in list)
                {
                    BillsList.Add(item);
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                throw;
            }
            IsBusy = false;

        }
    }
}
