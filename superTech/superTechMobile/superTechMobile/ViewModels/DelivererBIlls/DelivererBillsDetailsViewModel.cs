using superTech.Models.Bills;
using superTech.Models.Bills.BillItems;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace superTechMobile.ViewModels.DelivererBIlls
{
    public class DelivererBillsDetailsViewModel:BaseViewModel
    {
        private readonly APIService.APIService _billsApiService = new APIService.APIService("bills");

        public string _billNumber;
        public DateTime _issuingDate;
        public bool _closed;
        public string _tax;
        public string _amount;
        public string _amountWithTax;
        public string _shippingAddress;
        public string _userString;
        public string _orderNumber;

        public int BillId { get; set; }

        public ObservableCollection<BillItemsModel> _allBillItems = new ObservableCollection<BillItemsModel>();


        public string BillNumber { get => _billNumber; set => SetProperty(ref _billNumber, value); }
        public DateTime IssuingDate { get => _issuingDate; set => SetProperty(ref _issuingDate, value); }
        public bool Closed { get => _closed; set => SetProperty(ref _closed, value); }
        public string Amount { get => _amount; set => SetProperty(ref _amount, value); }

        public string UserString { get => _userString; set => SetProperty(ref _userString, value); }
        public string ShippingAddress { get => _shippingAddress; set => SetProperty(ref _shippingAddress, value); }

        public string Tax { get => _tax; set => SetProperty(ref _tax, value); }
        public string AmountWithTax { get => _amountWithTax; set => SetProperty(ref _amountWithTax, value); }
        public string OrderNumber { get => _orderNumber; set => SetProperty(ref _orderNumber, value); }

        public ObservableCollection<BillItemsModel> AllBillItems { get => _allBillItems; set => SetProperty(ref _allBillItems, value); }



        public int BillDetailId
        {
            get
            {
                return BillId;
            }
            set
            {
                BillId = value;
                loadBills(value);
            }
        }

        public async void loadBills(int id)
        {
            try
            {
                var bill = await _billsApiService.GetById<BillsModel>(BillDetailId);
                BillNumber = bill.BillNumber.ToString();
                Closed = bill.Closed;
                IssuingDate = bill.IssuingDate;
                Amount = bill.Amount.ToString() + "KM";
                Tax = bill.Tax.ToString() + "%";
                AmountWithTax = bill.AmountWithTax.ToString() + "KM";
                UserString = bill.UserString;
                ShippingAddress = bill.ShippingAddress;
                OrderNumber = bill.OrderNumber;

                AllBillItems.Clear();
                foreach (var item in bill.BillItems)
                {
                    AllBillItems.Add(item);
                }
                foreach (var item in AllBillItems)
                {
                    item.AmountSum += item.Quantity * item.Price;
                    item.AmountSumString = item.AmountSum.ToString() + " KM ";
                    item.PriceString = item.Price.ToString() + " KM ";
                    item.DiscountString = item.Discount.ToString() + " % ";
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public async void loadBillDetails()
        {
            try
            {
                var bill = await _billsApiService.GetById<BillsModel>(BillDetailId);
                BillNumber = bill.BillNumber.ToString();
                Closed = bill.Closed;
                IssuingDate = bill.IssuingDate;
                Amount = bill.Amount.ToString() + "KM";
                Tax = bill.Tax.ToString() + "%";
                AmountWithTax = bill.AmountWithTax.ToString() + "KM";
                UserString = bill.UserString;
                ShippingAddress = bill.ShippingAddress;
                OrderNumber = bill.OrderNumber;

                AllBillItems.Clear();
                foreach (var item in bill.BillItems)
                {
                    AllBillItems.Add(item);
                }
                foreach (var item in AllBillItems)
                {
                    item.AmountSum += item.Quantity * item.Price;
                    item.AmountSumString = item.AmountSum + " KM ";
                    item.PriceString = item.Price.ToString() + " KM ";
                    item.DiscountString = item.Discount.ToString() + " % ";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task CloseBill()
        {
            try
            {
                BillsUpsertRequest request = new BillsUpsertRequest();
                request.Closed = true;
                await _billsApiService.Update<BillsModel>(BillDetailId, request);

                await Application.Current.MainPage.DisplayAlert("Info", "Račun zatvoren !", "OK");


            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Račun nije moguće zatvoriti! ", "OK");
            }
        }

    }
}
