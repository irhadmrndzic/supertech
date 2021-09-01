using superTech.Models.Offers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace superTechMobile.ViewModels.Offers
{
    public class OffersViewModel:BaseViewModel
    {
        private readonly APIService.APIService _offersApiService = new APIService.APIService("offers");
        public ObservableCollection<OffersModel> OffersList { get; set; } = new ObservableCollection<OffersModel>();
        public ICommand InitCommand { get; set; }


        public OffersViewModel()
        {
            InitCommand = new Command(async () => await Init());

        }

        public async Task Init()
        {

            try
            {
                IsBusy = true;
                var list = await _offersApiService.Get<List<OffersModel>>(null);
                OffersList.Clear();
                foreach (var item in list)
                {
                    OffersList.Add(item);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            IsBusy = false;

        }
    }
}
