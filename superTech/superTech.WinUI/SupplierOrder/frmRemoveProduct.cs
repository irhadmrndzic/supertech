using System;

using System.Windows.Forms;

namespace superTech.WinUI.SupplierOrder
{
    public partial class frmRemoveProduct : Form
    {
        public int productIndex;
        public frmRemoveProduct()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (validateProductIndex())
            {
                productIndex = int.Parse(txtNumber.Text);
                this.DialogResult = DialogResult.OK;
            }
       
        }

        bool validateProductIndex()
        {
            if (int.Parse(txtNumber.Text) == 0)
            {
                errProvider.SetError(txtNumber, "Molimo unesite ispravan redni broj !");
                return false;
            }
            else
            {
                errProvider.SetError(txtNumber, null);
                return true;
            }
        }
    }
}
