using superTech.Models.Orders;
using superTech.WinUI.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace superTech.WinUI.SupplierOrder
{
    public partial class frmOrders : Form
    {
        private readonly APIService.APIService _ordersService = new APIService.APIService("orders");
        private int? _orderId = null;
        public frmOrders()
        {
            InitializeComponent();
            dgvOrders.AutoGenerateColumns = false;

            dgvOrders.AllowUserToResizeColumns = false;
            dgvOrders.AllowUserToResizeRows = false;
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            lblNoOrders.Hide();
            loadOrders();

            dpOrder.CustomFormat = " ";
            dpOrder.Format = DateTimePickerFormat.Custom;
        }


        public async Task loadOrders()
        {
            try
            {
                Cursor.Current = Cursor.Current;
                var orders = await _ordersService.Get<List<OrdersModel>>(null);
                dgvOrders.DataSource = orders;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Nabavka", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void dgvOrders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            selectOrder();
        }

        public async Task selectOrder()
        {
            try
            {
                _orderId = (int)dgvOrders.SelectedRows[0].Cells[0].Value;

                var entity = await _ordersService.GetById<OrdersModel>(_orderId);

                cbActive.Checked = entity.Active;
                cbConfirmOrder.Checked = entity.Confirmed;
                cbCanceled.Checked = entity.Canceled; // NA FORM RESETU PONISIT DISABLED CBOXE
                txtOrderNumber.Text = entity.OrderNumber.ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Narudžbe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnOrderItems_Click(object sender, EventArgs e)
        {

            if (_orderId.HasValue)
            {
                frmOrderItems frmOrderItems = new frmOrderItems(_orderId);
                frmOrderItems.Show();
            }
            else
            {
                MessageBox.Show("Molimo odaberite narudžbu ! ");
            }


        }

        private void dgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 || e.ColumnIndex == 7)
            {
                if (e.Value is bool)
                {
                    bool value = (bool)e.Value;
                    e.Value = (value) ? "Da" : "Ne";
                    e.FormattingApplied = true;
                }
            }
        }

        private async void btnFilterOrder_Click(object sender, EventArgs e)
        {
            try
            {
                OrdersSearchRequest request = new OrdersSearchRequest();

                if (txtOrderNumberSearch.Text != "")
                {
                    request.OrderNumber = Convert.ToInt32(txtOrderNumberSearch.Text);
                }

                if (dpOrder.Text != " ")
                {
                    request.Date = dpOrder.Value;
                }

                var res = await _ordersService.Get<List<OrdersModel>>(request);

                if (res.Count > 0)
                {
                    dgvOrders.DataSource = res;
                    clearForm();
                }
                else
                {
                    lblNoOrders.Text = "Nema pronađenih narudžbi ! ";
                    lblNoOrders.Show();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Narudžbe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dpOrder_ValueChanged(object sender, EventArgs e)
        {
            lblNoOrders.Hide();
            dpOrder.CustomFormat = "dd/MM/yyyy";
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            dpOrder.CustomFormat = " ";
            dpOrder.Format = DateTimePickerFormat.Custom;
            txtOrderNumberSearch.Text = "";
            lblNoOrders.Hide();
            loadOrders();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {

                try
                {
                    if (_orderId.HasValue)
                    {
                        OrdersUpsertRequest request = new OrdersUpsertRequest();

                        request.Confirmed = cbConfirmOrder.Checked;
                        if (cbConfirmOrder.Checked)
                        {
                            cbCanceled.Enabled = false;
                            cbCanceled.Checked = false;
                            request.Canceled = false;
                            request.Active = false;
                        }
                        else if (!cbConfirmOrder.Checked)
                        {
                            cbCanceled.Enabled = true;

                            if (cbCanceled.Checked)
                            {
                                request.Confirmed = false;
                                request.Canceled = true;
                                request.Active = false;
                            }

                        }

                        await _ordersService.Update<OrdersModel>(_orderId, request);

                        DialogResult result = MessageBox.Show("Uspješno ste uredili narudžbu : " + txtOrderNumber.Text + " !", "Uredi narudžbu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (result == DialogResult.OK)
                        {
                            clearForm();
                            loadOrders();
                            this.cbCanceled.Enabled = true;
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Narudžbe", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        void clearForm()
        {
            _orderId = null;
            txtOrderNumberSearch.Text = "";
            FormReset.ResetAllControls(this);
            dpOrder.CustomFormat = " ";
            dpOrder.Format = DateTimePickerFormat.Custom;
            cbActive.Enabled = true;
            cbConfirmOrder.Enabled = true;
            cbCanceled.Enabled = true;
            errProvider.Clear();
            errProvider.Dispose();
        }
        bool validateForm()
        {
            if (!validateCheckBoxes())
            {
                return false;
            }
            return true;
        }


        bool validateCheckBoxes()
        {
            if (cbConfirmOrder.Checked == true && cbCanceled.Checked == true)
            {
                errProvider.SetError(EditOrder, "Narudžba ne može biti potvrđena i otkazana u isto vrijeme ! ");
                return false;
            }
            return true;
        }


        /*
           if (string.IsNullOrWhiteSpace(txtProductCode.Text))
            {
                errProvider.SetError(txtProductCode, Properties.Resources.Validate_Input);
                return false;
            }
            else
            {
                errProvider.SetError(txtProductCode, null);
                return true;
            }
         
         
         */
    }
}
