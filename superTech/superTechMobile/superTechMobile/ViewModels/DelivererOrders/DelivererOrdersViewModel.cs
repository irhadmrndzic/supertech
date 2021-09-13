using superTech.Models.BuyerOrders;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace superTechMobile.ViewModels.DelivererOrders
{
    public class DelivererOrdersViewModel:BaseViewModel
    {
        public readonly APIService.APIService _buyerOrderService = new APIService.APIService("buyerOrders");

        public ObservableCollection<BuyerOrdersModel> OrdersList { get; set; } = new ObservableCollection<BuyerOrdersModel>();
        public ICommand InitCommand { get; set; }

        public DelivererOrdersViewModel()
        {
            InitCommand = new Command(async () => await Init());

        }


        public async Task Init()
        {
            try
            {
                IsBusy = true;
                var list = await _buyerOrderService.Get<List<BuyerOrdersModel>>(null);
                OrdersList.Clear();
                foreach (var item in list)
                {
                    OrdersList.Add(item);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            IsBusy = false;

        }
    }
}
