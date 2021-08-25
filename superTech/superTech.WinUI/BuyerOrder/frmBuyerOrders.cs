using superTech.Models.BuyerOrders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace superTech.WinUI.BuyerOrder
{
    public partial class frmBuyerOrders : Form
    {
        public readonly APIService.APIService _buyerOrderService = new APIService.APIService("buyerOrders");
        private int? _orderId = null;



        string[] orderStatus = new string[3];
        public frmBuyerOrders()
        {
            InitializeComponent();
            this.orderStatus[0] = "";
            this.orderStatus[1] = "Neprocesirana";
            this.orderStatus[2] = "Procesirana";

            cmbOrderStatus.DataSource = this.orderStatus;
            dgvBuyerOrders.AutoGenerateColumns = false;
        }

        private async void frmBuyerOrders_Load(object sender, EventArgs e)
        {
            await loadBuyerOrders();
        }


        public async Task loadBuyerOrders()
        {
            try
            {
                var buyerOrdersList = await _buyerOrderService.Get<List<BuyerOrdersModel>>(null);
                Cursor.Current = Cursor.Current;
                dgvBuyerOrders.DataSource = buyerOrdersList;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Narudžbe", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dgvBuyerOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (e.Value is bool)
                {
                    bool value = (bool)e.Value;
                    e.Value = (value) ? "Ne" : "Da";
                    e.FormattingApplied = true;
                }
            }
        }

        private void dgvBuyerOrders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            selectOrder();
        }

        public async Task selectOrder()
        {

            try
            {
                _orderId = (int)dgvBuyerOrders.SelectedRows[0].Cells[0].Value;

                var entity = await _buyerOrderService.GetById<BuyerOrdersModel>(_orderId);

                txtOrderNumber.Text = entity.OrderNumber.ToString();
                txtDate.Text = entity.Date.ToString();
                txtBuyer.Text = entity.UserString;
                txtAmount.Text = entity.Amount.ToString();
                cbProcessed.Checked = !entity.Active; //Procesirana je ako nije aktivna

                if (entity.Active)
                {
                    foreach (Control control in gbInfo.Controls)
                    {
                        if (control is Button)
                        {
                            gbInfo.Controls.Remove(control);
                        }
                    }


                    Button btnProcess = new Button();
                    btnProcess = generateButton("btnProcess", "Procesiraj", 15, 82, 186, btnProcess_Click);

                }
                else
                {
                    foreach (Control control in gbInfo.Controls)
                    {
                        if (control is Button)
                        {
                            gbInfo.Controls.Remove(control);
                        }
                    }
                    Button btnProcessedOrderItems = new Button();
                    btnProcessedOrderItems = generateButton("btnProcessedOrderItems", "Artikli", 153, 179, 190, btnProcessedOrderItems_Click);

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Narudžbe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async void btnProcess_Click(object sender, EventArgs e)
        {
            if (_orderId.HasValue)
            {
                frmBuyerOrderItems frm = new frmBuyerOrderItems(_orderId);
                frm.ShowDialog();

                if(frm.result == DialogResult.OK)
                {
                   await loadBuyerOrders();
                }
            }
            else
            {
                MessageBox.Show("Molimo odaberite narudžbu ! ");
            }
        }

        private void btnProcessedOrderItems_Click(object sender, EventArgs e)
        {
            if (_orderId.HasValue)
            {
                frmProcessedBuyerOrderItems frm = new frmProcessedBuyerOrderItems(_orderId);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Molimo odaberite narudžbu ! ");
            }
        }

        public Button generateButton(string name, string text, int r, int g, int b, EventHandler handler)
        {
            Button btn = new Button();

            btn.Text = text;
            btn.Name = name;
            btn.BackColor = Color.FromArgb(r, g, b);
            btn.Parent = gbInfo;
            btn.Dock = DockStyle.Bottom;
            gbInfo.Controls.Add(btn);
            btn.ForeColor = Color.White;
            btn.Height = 63;
            btn.Width = 230;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Click += new EventHandler(handler);

            return btn;

        }

        private async void btnFilterOrder_Click(object sender, EventArgs e)
        {
            var value = cmbOrderStatus.SelectedValue;
            BuyerOrdersSearchRequest req = new BuyerOrdersSearchRequest();

            if (value == "")
            {
                await loadBuyerOrders();
            }
            else if (value == "Neprocesirana")
            {
                req.Status = "Neprocesirana";
                var buyerOrdersList = await _buyerOrderService.Get<List<BuyerOrdersModel>>(req);
                Cursor.Current = Cursor.Current;
                dgvBuyerOrders.DataSource = buyerOrdersList;
            }
            else
            {
                req.Status = "Procesirana";
                var buyerOrdersList = await _buyerOrderService.Get<List<BuyerOrdersModel>>(req);
                Cursor.Current = Cursor.Current;
                dgvBuyerOrders.DataSource = buyerOrdersList;
            }



        }
    }
}
