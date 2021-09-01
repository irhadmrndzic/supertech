using superTech.Models.BuyerOrders;
using superTech.Models.BuyerOrders.BuyerOrderItems;
using superTechMobile.Global;
using superTechMobile.Views.Orders;
using superTechMobile.Views.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace superTechMobile.ViewModels.TempOrderDetails
{
    public class TempOrderDetailsViewModel:BaseViewModel
    {

        private readonly APIService.APIService _ordersApiService = new APIService.APIService("buyerorders");

        public DateTime _date;
        public bool _active;
        public bool _canceled;
        public bool _confirmed;
        public int _userId;
        public decimal _amount;
        public int _orderNumber;
        public ObservableCollection<TempOrderItems> _tempOrderItems = new ObservableCollection<TempOrderItems>();
        public DateTime Date { get => _date; set => SetProperty(ref _date, value); }
        public bool Active { get => _active; set => SetProperty(ref _active, value); }
        public bool Canceled { get => _canceled; set => SetProperty(ref _canceled, value); }
        public bool Confirmed { get => _confirmed; set => SetProperty(ref _confirmed, value); }
        public int UserId{ get => _userId; set => SetProperty(ref _userId, value); }
        public int OrderNumber{ get => _orderNumber; set => SetProperty(ref _orderNumber, value); }
        public decimal Amount{ get => _amount; set => SetProperty(ref _amount, value); }

        public ObservableCollection<TempOrderItems> AllOrderItems { get => _tempOrderItems; set => SetProperty(ref _tempOrderItems, value); }


        public TempOrderDetailsViewModel()
        {
        }

        public async Task Init()
        {
            Date = Global.Global.activeOrder.Date;
            Active = Global.Global.activeOrder.Active;
            Canceled = Global.Global.activeOrder.Canceled;
            Confirmed = (bool)Global.Global.activeOrder.Confirmed;
            UserId = (int)Global.Global.activeOrder.FkUserId;
            OrderNumber = (int)Global.Global.activeOrder.OrderNumber;
            foreach (var item in Global.Global.activeOrder.tempOrderItemsList)
            {
                AllOrderItems.Add(item);
            }

            foreach (var item in AllOrderItems)
            {
                Amount += (decimal)item.Amount;
            }
        }

        public async Task ConfirmOrder()
        {
            try
            {
                BuyerOrdersUpsertRequest request = new BuyerOrdersUpsertRequest
                {
                    Amount = Amount,
                    Active = true,
                    Canceled = false,
                    Confirmed = false,
                    Date = Date,
                    UserId = UserId,
                    OrderNumber = OrderNumber
                };


                request.BuyerOrderItems = new List<BuyerOrderItemsUpsertRequest>();

                foreach (var item in AllOrderItems)
                {
                    BuyerOrderItemsUpsertRequest itemsRequest = new BuyerOrderItemsUpsertRequest
                    {
                        Amount = item.Amount,
                        Quantity = item.Quantity,
                        FkProductId = item.FkProductId,
                        BuyerOrderId = 0
                    };

                    request.BuyerOrderItems.Add(itemsRequest);
                }
                await _ordersApiService.Insert<BuyerOrdersModel>(request);
                await Application.Current.MainPage.DisplayAlert("Info", "Narudžba zaprimljena !", "OK");
                await Application.Current.MainPage.Navigation.PushAsync(new OrdersPage());

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greška",ex.Message, "OK");
            }
        }

    }
}
