using superTech.Models.Offers;
using superTech.Models.Offers.OfferItems;
using System;
using System.Collections.ObjectModel;

namespace superTechMobile.ViewModels.Offers
{
    public class OfferDetailsViewModel:BaseViewModel
    {
        private readonly APIService.APIService _offersApiService = new APIService.APIService("offers");
        public string _title;
        public DateTime _dateTo;
        public string _description;
        public ObservableCollection<OfferItemsModel> _allOfferItems = new ObservableCollection<OfferItemsModel>();

        public int OfferId { get; set; }

        public string Title { get => _title; set => SetProperty(ref _title, value); }
        public DateTime DateTO { get => _dateTo; set => SetProperty(ref _dateTo, value); }
        public string Description { get => _description; set => SetProperty(ref _description, value); }
        public ObservableCollection<OfferItemsModel> AllOfferItems { get => _allOfferItems; set => SetProperty(ref _allOfferItems, value); }

        public int OfferDetailId
        {
            get
            {
                return OfferId;
            }
            set
            {
                OfferId = value;
            }
        }

        public OfferDetailsViewModel()
        {
        }

        public async void loadOfferDetails()
        {
            try
            {
                var offer = await _offersApiService.GetById<OffersModel>(OfferDetailId);
                Title = offer.Title;
                DateTO = offer.DateTo;
                Description = offer.Description;
            
                AllOfferItems.Clear();

                foreach (var item in offer.OfferItems)
                {
                    AllOfferItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
