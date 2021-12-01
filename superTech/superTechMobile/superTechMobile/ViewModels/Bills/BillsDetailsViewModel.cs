using superTech.Models.Bills;
using superTech.Models.Bills.BillItems;
using System;
using System.Collections.ObjectModel;

namespace superTechMobile.ViewModels.Bills
{
    public class BillsDetailsViewModel : BaseViewModel
    {
        private readonly APIService.APIService _billsApiService = new APIService.APIService("bills");

        public string _billNumber;
        public DateTime _issuingDate;
        public bool _closed;
        public string _tax;
        public string _amount;
        public string _amountWithTax;
        public string _amountSumString;
        public int BillId { get; set; }

        public ObservableCollection<BillItemsModel> _allBillItems = new ObservableCollection<BillItemsModel>();


        public string BillNumber { get => _billNumber; set => SetProperty(ref _billNumber, value); }
        public DateTime IssuingDate { get => _issuingDate; set => SetProperty(ref _issuingDate, value); }
        public bool Closed { get => _closed; set => SetProperty(ref _closed, value); }
        public string Amount { get => _amount; set => SetProperty(ref _amount, value); }
        public string Tax { get => _tax; set => SetProperty(ref _tax, value); }
        public string AmountWithTax { get => _amountWithTax; set => SetProperty(ref _amountWithTax, value); }
        public string AmountSumString { get => _amountSumString; set => SetProperty(ref _amountSumString, value); }
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
                
                AllBillItems.Clear();
                foreach (var item in bill.BillItems)
                {
                    AllBillItems.Add(item);
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
                AllBillItems.Clear();
                foreach (var item in bill.BillItems)
                {
                   item.AmountSum += item.Quantity * item.Price;
                    item.PriceString = item.Price.ToString() + " KM ";
                    item.DiscountString = item.Discount.ToString() + " % ";
                    item.AmountSumString = item.AmountSum.ToString() + " KM ";
                        
                    AllBillItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
