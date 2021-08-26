using superTech.Models.Bills;
using System;
using System.Windows.Forms;

namespace superTech.WinUI.Bills
{
    public partial class frmBillItems : Form
    {
        public int? _billId = null;
        public readonly APIService.APIService _billsService = new APIService.APIService("bills");

        public frmBillItems(int? billId = null)
        {
            InitializeComponent();
            _billId = billId;
        }

        private async void frmBillItems_Load(object sender, EventArgs e)
        {
            if (_billId.HasValue)
            {
                var bill = await _billsService.GetById<BillsModel>(_billId);
                lblAmount.Text = bill.Amount.ToString();
                lblBillNumber.Text = bill.BillNumber.ToString();
                lblIssuingDate.Text = bill.IssuingDate.ToShortDateString();
                lblAmount.Text = bill.Amount.ToString();
                lblTax.Text = bill.Tax.ToString() + "%";  
                lblAmountWithTax.Text = bill.AmountWithTax.ToString();
                listViewOrderItems.Items.Clear();
                int i = 1;
                foreach (var billItem in bill.BillItems)
                {
                    var row = new string[] { i.ToString(), billItem.ProductString, billItem.Price.ToString() + "KM", billItem.Quantity.ToString(), billItem.Discount.HasValue && billItem.Discount > 1? billItem.Discount.ToString():"0",
                        (Math.Round(billItem.Quantity * decimal.Parse(billItem.Price.ToString()),2)).ToString() +"KM" };
                    var lvItem = new ListViewItem(row);
                    listViewOrderItems.Items.Add(lvItem);
                    i++;
                }
            }
        }
    }
}
