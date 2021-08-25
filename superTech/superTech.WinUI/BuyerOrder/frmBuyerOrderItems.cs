using superTech.Models.BuyerOrders;
using System;
using System.Windows.Forms;

namespace superTech.WinUI.BuyerOrder
{
    public partial class frmBuyerOrderItems : Form
    {
        private int? _orderId = null;
        public readonly APIService.APIService _buyerOrderService = new APIService.APIService("buyerOrders");

        public DialogResult result;
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
                txtInfo.Text = order.Confirmed ? "Procesirana" : "Neprocesirana";

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

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            BuyerOrdersUpsertRequest req = new BuyerOrdersUpsertRequest();

            req.Confirmed = true;
            req.Active = false;
            req.Canceled = false;
            if (_orderId.HasValue)
            {
                await _buyerOrderService.Update<BuyerOrdersModel>(_orderId, req);

                DialogResult result = MessageBox.Show("Uspješno ste potvrdili narudžbu!", "Narudžbe", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    this.result = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            BuyerOrdersUpsertRequest req = new BuyerOrdersUpsertRequest();

            req.Confirmed = false;
            req.Active = false;
            req.Canceled = true;

            if (_orderId.HasValue)
            {
                await _buyerOrderService.Update<BuyerOrdersModel>(_orderId, req);

                DialogResult result = MessageBox.Show("Uspješno ste otkazali narudžbu!", "Narudžbe", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    this.result = DialogResult.OK;
                    this.Close();
                }

            }
        }

        private void frmBuyerOrderItems_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
