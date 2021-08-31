using superTech.Models.Ratings;
using superTech.Models.User;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System;

namespace superTechMobile.ViewModels.Rating
{
    public class RatingsViewModel : BaseViewModel
    {
        private readonly APIService.APIService _ratingsApiService = new APIService.APIService("ratings");
        private readonly APIService.APIService _usersApiService = new APIService.APIService("users");

        public int _rating;
        public int _productId;
        public bool _enableButton;
        public bool _enableLabel;
        public bool _orderConfirmed;
        public bool _ratingPermission;
        List<RatingsModel> userRatings = new List<RatingsModel>();
        public string _username = APIService.APIService.Username;
        public event PropertyChangedEventHandler PropertyChanged;
        public RatingsViewModel()
        {
        }

        public async void GetUserRatings()
        {
            try
            {
                RatingsSearchRequest request = new RatingsSearchRequest();
                request.ProductId = Product;
                request.UserId = APIService.APIService.userId;
                 userRatings = await _ratingsApiService.Get<List<RatingsModel>>(request);
                if (userRatings.Count > 0)
                {
                    EnableButton = false;
                    EnableLabel = true;
                }
                else if (!OrderConfirmed )
                {
                    EnableButton = false;
                    EnableLabel = true;

                }
                else if (OrderConfirmed && userRatings.Count <= 0)
                {
                    EnableButton = true;
                    EnableLabel = false;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public bool EnableButton
        {
            get => _enableButton; 
            set
            {
                SetProperty(ref _enableButton, value);
                OnPropertyChanged();
            }
        }

        public bool EnableLabel
        {
            get => _enableLabel; 
            set
            {
                SetProperty(ref _enableLabel, value);
                OnPropertyChanged();
            }
        }


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public List<RatingsModel> UR
        {
            get => userRatings; set => SetProperty(ref userRatings, value);
        }

        public int Rating
        {
            get => _rating; set => SetProperty(ref _rating, value);
        }
        public bool OrderConfirmed
        {
            get => _orderConfirmed; set => SetProperty(ref _orderConfirmed, value);
        }
        public int Product
        {
            get => _productId; set => SetProperty(ref _productId, value);
        }

        public async Task RateProduct()
        {
            try
            {
                RatingsUpsertRequest request = new RatingsUpsertRequest();

                request.FkProductId = Product;
                request.FkUserId = APIService.APIService.userId;
                if(Rating>0 && Rating < 6)
                {
                    request.Rating1 = Rating;
                }
                else
                {
                    throw new Exception("Unesite vrijednost izmedju 1 i 5!");
                }
                await _ratingsApiService.Insert<RatingsModel>(request);
            }
            catch (System.Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
            }
        }
    }
}
