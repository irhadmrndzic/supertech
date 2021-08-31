﻿using superTech.Models.BuyerOrders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace superTechMobile.ViewModels.Orders
{
    public class OrdersViewModel : BaseViewModel
    {
        private readonly APIService.APIService _ordersApiService = new APIService.APIService("buyerorders");
        public ObservableCollection<BuyerOrdersModel> OrdersList { get; set; } = new ObservableCollection<BuyerOrdersModel>();
        public ICommand InitCommand { get; set; }

        public OrdersViewModel()
        {
            InitCommand = new Command(async () => await Init());

        }

        public async Task Init()
        {
            BuyerOrdersSearchRequest request = new BuyerOrdersSearchRequest();

            request.Username = APIService.APIService.Username;
            try
            {
                IsBusy = true;
                var list = await _ordersApiService.Get<List<BuyerOrdersModel>>(request);
                OrdersList.Clear();
                foreach (var item in list)
                {
                    OrdersList.Add(item);
                }
            }
            catch (Exception)
            {

                throw;
            }
            IsBusy = false;

        }

    }
}
