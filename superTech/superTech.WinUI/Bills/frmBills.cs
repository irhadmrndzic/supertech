using superTech.Models.Bills;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace superTech.WinUI.Bills
{
    public partial class frmBills : Form
    {
        public readonly APIService.APIService _billsService = new APIService.APIService("bills");
        private int? _billId = null;
        public frmBills()
        {
            InitializeComponent();
            dgvBills.AutoGenerateColumns = false;
        }


        private async void frmBills_Load(object sender, EventArgs e)
        {
            await loadBills();
        }


        public async Task loadBills()
        {
            try
            {
                var billsList = await _billsService.Get<List<BillsModel>>(null);
                dgvBills.DataSource = billsList;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Računi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async void dgvBills_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _billId = (int)dgvBills.SelectedRows[0].Cells[0].Value;


            try
            {
                var entity = await _billsService.GetById<BillsModel>(_billId);
                txtBillNumber.Text = entity.BillNumber.ToString();
                txtIssuingDate.Text = entity.IssuingDate.ToShortDateString();
                txtTax.Text = entity.Tax.ToString();
                txtAmount.Text = entity.Amount.ToString();
                txtAmountWithTax.Text = entity.AmountWithTax.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Računi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void btnBillItems_Click(object sender, EventArgs e)
        {
            if (_billId.HasValue)
            {
                frmBillItems frm = new frmBillItems(_billId);
                frm.ShowDialog();

                //if (frm.result == DialogResult.OK)
                //{
                //    await loadBuyerOrders();
                //}
            }
            else
            {
                MessageBox.Show("Molimo odaberite račun ! ");
            }
        }
    }
}
