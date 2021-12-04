using superTech.Models.BuyerOrders;
using superTech.Models.BuyerOrders.BuyerOrderItems;
using System;
using System.Collections.ObjectModel;

namespace superTechMobile.ViewModels.Orders
{
    public class OrderDetailsViewModel : BaseViewModel
    {
        private readonly APIService.APIService _ordersApiService = new APIService.APIService("buyerorders");
        public string _orderNumber;
        public DateTime _date;
        public bool _confirmed;
        public string _amount;
        public string _amountWithTax;

        public ObservableCollection<BuyerOrderItemsModel> _allOrderItems = new ObservableCollection<BuyerOrderItemsModel>();

        public int OrderId { get; set; }

        public OrderDetailsViewModel()
        {

        }

        public string OrderNumber { get => _orderNumber; set => SetProperty(ref _orderNumber, value); }
        public DateTime Date { get => _date; set => SetProperty(ref _date, value); }
        public bool Confirmed { get => _confirmed; set => SetProperty(ref _confirmed, value); }
        public string Amount { get => _amount; set => SetProperty(ref _amount, value); }
        public string AmountWithTaxStr { get => _amountWithTax; set => SetProperty(ref _amountWithTax, value); }

        public ObservableCollection<BuyerOrderItemsModel> AllOrderItems { get => _allOrderItems; set => SetProperty(ref _allOrderItems, value); }

        public int OrderDetailId
        {
            get
            {
                return OrderId;
            }
            set
            {
                OrderId = value;
                loadOrders(value);
            }
        }
        public async void loadOrders(int id)
        {
            try
            {
                var order = await _ordersApiService.GetById<BuyerOrdersModel>(OrderDetailId);
                OrderNumber = order.OrderNumber.ToString();
                Confirmed = order.Confirmed;
                Date = order.Date;
                Amount = order.Amount.ToString() + " KM";
                AmountWithTaxStr = (Math.Round(((decimal)order.Amount + ((decimal)order.Amount * (decimal)0.17)), 2)).ToString() + " KM ";

                AllOrderItems.Clear();
                foreach (var item in order.BuyerOrderItems)
                {
                    AllOrderItems.Add(item);
                }

                foreach (var item in AllOrderItems)
                {
                    item.ProductPriceString = item.ProductPrice.ToString() + " KM";
                    item.AmountString = item.Amount.ToString() + " KM ";

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public async void loadOrdersDetails()
        {
            try
            {
                var order = await _ordersApiService.GetById<BuyerOrdersModel>(OrderDetailId);
                OrderNumber = order.OrderNumber.ToString();
                Confirmed = order.Confirmed;
                Date = order.Date;
                Amount = order.Amount.ToString() + " KM";
                AmountWithTaxStr = (Math.Round(((decimal)order.Amount + ((decimal)order.Amount * (decimal)0.17)), 2)).ToString() + " KM ";
                AllOrderItems.Clear();

                foreach (var item in order.BuyerOrderItems)
                {
                    AllOrderItems.Add(item);

                }
                foreach (var item in AllOrderItems)
                {
                    item.ProductPriceString = item.ProductPrice.ToString() + " KM";
                    item.AmountString = item.Amount.ToString() + " KM ";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
