using superTech.Models.Bills;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace superTechMobile.ViewModels.Bills
{
    public class BillsViewModel : BaseViewModel
    {
        private readonly APIService.APIService _billsApiService = new APIService.APIService("bills");
        public ObservableCollection<BillsModel> BillsList { get; set; } = new ObservableCollection<BillsModel>();
        public ICommand InitCommand { get; set; }


        public BillsViewModel()
        {
            InitCommand = new Command(async () => await Init(false));

        }

        public async Task Init(bool all)
        {
            try
            {
                if (!all)
                {
                    BillsSearchRequest request = new BillsSearchRequest();

                    request.Username = APIService.APIService.Username;

                    IsBusy = true;
                    var list = await _billsApiService.Get<List<BillsModel>>(request);
                    BillsList.Clear();
                    foreach (var item in list)
                    {
                        BillsList.Add(item);
                    }
                }
                else
                {
                    IsBusy = true;
                    var list = await _billsApiService.Get<List<BillsModel>>(null);
                    BillsList.Clear();
                    foreach (var item in list)
                    {
                        BillsList.Add(item);
                    }
                }

            }
            catch (Exception)
            {
                IsBusy = false;
                throw;
            }
            IsBusy = false;

        }
    }
}
