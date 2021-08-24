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

            cbOrderStatus.DataSource = this.orderStatus;
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
               var buyerOrdersList =  await _buyerOrderService.Get<List<BuyerOrdersModel>>(null);
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
                    e.Value = (value) ? "Da" : "Ne";
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
                //Point newLoc = new Point(7, 491);
                _orderId = (int)dgvBuyerOrders.SelectedRows[0].Cells[0].Value;

                var entity = await _buyerOrderService.GetById<BuyerOrdersModel>(_orderId);

                txtOrderNumber.Text = entity.OrderNumber.ToString();
                txtDate.Text = entity.Date.ToString();
                txtBuyer.Text = entity.UserString;
                txtAmount.Text = entity.Amount.ToString();
                cbProcessed.Checked = entity.Active;

                if (!entity.Active)
                {
                    bool buttonCounter = false;
                    foreach (Control control in gbInfo.Controls)
                    {
                        if (control is Button)
                        {
                            buttonCounter = true;
                        }
                    }

                    if(buttonCounter == false)
                    {
                        Button btnProcess = new Button();

                        btnProcess.Text = "Procesiraj";
                        btnProcess.Name = "btnProcess";
                        btnProcess.BackColor = Color.FromArgb(15, 82, 186);
                        btnProcess.Parent = gbInfo;
                        btnProcess.Dock = DockStyle.Bottom;
                        gbInfo.Controls.Add(btnProcess);
                        btnProcess.ForeColor = Color.White;
                        btnProcess.Height =63;
                        btnProcess.Width = 230;

                        btnProcess.Click += new EventHandler(btnProcess_Click);
                    }

                }
                else
                {
                    foreach (Control control in gbInfo.Controls)
                    {
                        if(control is Button)
                        {
                            gbInfo.Controls.Remove(control);
                        }
                    }

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Narudžbe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (_orderId.HasValue)
            {
                frmBuyerOrderItems frm = new frmBuyerOrderItems(_orderId);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Molimo odaberite narudžbu ! ");
            }
        }

    }
}
