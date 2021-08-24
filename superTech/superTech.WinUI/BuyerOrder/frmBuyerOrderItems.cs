using superTech.Models.BuyerOrders;
using System;

using System.Windows.Forms;

namespace superTech.WinUI.BuyerOrder
{
    public partial class frmBuyerOrderItems : Form
    {
        private int? _orderId = null;
        public readonly APIService.APIService _buyerOrderService = new APIService.APIService("buyerOrders");

        public frmBuyerOrderItems(int? orderId = null)
        {
            InitializeComponent();
            _orderId = orderId;

        }

        private async void frmBuyerOrderItems_Load(object sender, EventArgs e)
        {
            if (_orderId.HasValue)
            {
                var order = await _buyerOrderService.GetById<BuyerOrdersModel>(_orderId);
                lblAmount.Text = order.Amount.ToString();
                lblBuyer.Text = order.UserString;
                lblOrderDate.Text = order.Date.ToShortDateString();
                lblOrderNumber.Text = order.OrderNumber.ToString();

                listViewOrderItems.Items.Clear();
                int i = 1;
                foreach (var orderItem in order.BuyerOrderItems)
                {
                    var row = new string[] { i.ToString(), orderItem.ProductName, orderItem.ProductCode, orderItem.Quantity.ToString(), orderItem.ProductPrice.ToString() + " KM ",
                        (orderItem.Quantity * orderItem.ProductPrice).ToString() +"KM" };
                    var lvItem = new ListViewItem(row);
                    listViewOrderItems.Items.Add(lvItem);
                    i++;
                }
            }
        }
    }
}
