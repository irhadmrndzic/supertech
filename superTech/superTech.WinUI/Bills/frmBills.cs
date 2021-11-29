using superTech.Models.Bills;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                cbClosed.Checked = entity.Closed;

                if (!entity.Closed)
                {
                    foreach (Control control in gbInfo.Controls)
                    {
                        if (control is Button)
                        {
                            if (control.Name != "btnBillItems")
                            {
                                gbInfo.Controls.Remove(control);
                            }
                        }
                    }

                    Button btnCloseBill = new Button();
                    btnCloseBill = generateButton("btnCloseBill", "Zatvori račun", 15, 82, 186, btnCloseBill_Click);
                }
                else
                {
                    foreach (Control control in gbInfo.Controls)
                    {
                        if (control is Button)
                        {
                            if (control.Name != "btnBillItems")
                            {
                                gbInfo.Controls.Remove(control);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Računi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCloseBill_Click(object sender, EventArgs e)
        {
            if (_billId.HasValue)
            {
                try
                {
                    BillsUpsertRequest request = new BillsUpsertRequest();
                    request.Closed = cbClosed.Checked;
                    await _billsService.Update<BillsModel>(_billId, request);

                    MessageBox.Show("Račun uspješno zatvoren! ", "Računi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await this.loadBills();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Računi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Molimo odaberite račun! ", "Računi", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void dgvBills_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex ==3)
            {
                if (e.Value is bool)
                {
                    bool value = (bool)e.Value;
                    e.Value = (value) ? "DA" : "NE";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
