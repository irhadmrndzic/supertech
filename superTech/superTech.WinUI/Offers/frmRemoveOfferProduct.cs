using System;
using System.Windows.Forms;

namespace superTech.WinUI.Offers
{
    public partial class frmRemoveOfferProduct : Form
    {
        public int productIndex;

        public frmRemoveOfferProduct()
        {
            InitializeComponent();
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

        private void btnCnt_Click(object sender, EventArgs e)
        {
            if (validateProductIndex())
            {
                productIndex = int.Parse(txtNumber.Text);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
