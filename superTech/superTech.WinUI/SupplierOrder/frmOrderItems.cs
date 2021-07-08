using superTech.Models.Orders;
using System;
using System.Windows.Forms;

namespace superTech.WinUI.SupplierOrder
{
    public partial class frmOrderItems : Form
    {
        private int? _orderId = null;
        private readonly APIService.APIService _ordersService = new APIService.APIService("orders");

        public frmOrderItems(int? orderId = null)
        {
            InitializeComponent();
            _orderId = orderId;
        }

        private async void frmOrderItems_Load(object sender, EventArgs e)
        {
            if (_orderId.HasValue)
            {
                var order = await _ordersService.GetById<OrdersModel>(_orderId);
                listViewOrderItems.Items.Clear();
                int i = 1;
                foreach (var orderItem in order.OrderItems)
                {
                    var row = new string[] { i.ToString(), orderItem.ProductName, orderItem.ProductCode, orderItem.Quantity.ToString(), orderItem.Amount.ToString() + " KM " };
                    var lvItem = new ListViewItem(row);
                    listViewOrderItems.Items.Add(lvItem);
                    i++;
                }
            }
        }
    }
}
