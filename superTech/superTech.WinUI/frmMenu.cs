using System;
using System.Collections.Generic;
using System.Windows.Forms;
using superTech.Models.BuyerOrders;
using superTech.WinUI.Bills;
using superTech.WinUI.BuyerOrder;
using superTech.WinUI.News;
using superTech.WinUI.Offers;
using superTech.WinUI.Products;
using superTech.WinUI.SupplierOrder;
using superTech.WinUI.Users;

namespace superTech.WinUI
{
    public partial class frmMenu : Form
    {
        private int childFormNumber = 0;
        public readonly APIService.APIService _buyerOrderService = new APIService.APIService("buyerOrders");

        public frmMenu()
        {
            InitializeComponent();
            this.notificationIcon.Icon = this.Icon;
            txtUsername.Text = APIService.APIService.Username;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void pretragaKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers frmUsers = new frmUsers();
            frmUsers.MdiParent = this;
            frmUsers.WindowState = FormWindowState.Maximized;
            frmUsers.Show();
        }

        private void noviKorisnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails frmUserDetails = new frmUserDetails();
            frmUserDetails.Show();
        }

        private void pregledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducts frmProducts = new frmProducts();
            frmProducts.MdiParent = this;
            frmProducts.WindowState = FormWindowState.Maximized;
            frmProducts.Show();
        }

        private void pregledToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmNews frmNews = new frmNews();
            frmNews.MdiParent = this;
            frmNews.WindowState = FormWindowState.Maximized;
            frmNews.Show();
        }

        private void novaNabavkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierOrder frmSupplierOrder = new frmSupplierOrder();
            frmSupplierOrder.MdiParent = this;
            frmSupplierOrder.WindowState = FormWindowState.Maximized;
            frmSupplierOrder.Show();
        }

        private void pregledToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmOrders frmOrders = new frmOrders();
            frmOrders.MdiParent = this;
            frmOrders.WindowState = FormWindowState.Maximized;
            frmOrders.Show();
        }

        private void pregledToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmOffers frmOffers = new frmOffers();
            frmOffers.MdiParent = this;
            frmOffers.WindowState = FormWindowState.Maximized;
            frmOffers.Show();
        }

        private void novaPonudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddOffer frmAddOffer = new frmAddOffer();
            frmAddOffer.MdiParent = this;
            frmAddOffer.WindowState = FormWindowState.Maximized;
            frmAddOffer.Show();
        }


        private void pregledToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmBuyerOrders frmBuyerOrders = new frmBuyerOrders();
            frmBuyerOrders.MdiParent = this;
            frmBuyerOrders.WindowState = FormWindowState.Maximized;
            frmBuyerOrders.Show();
        }



        private void notificationIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            frmBuyerOrders frmBuyerOrders = new frmBuyerOrders();
            frmBuyerOrders.MdiParent = this;
            frmBuyerOrders.WindowState = FormWindowState.Maximized;
            frmBuyerOrders.Show();
        }

        private async void frmMenu_Load(object sender, EventArgs e)
        {
            BuyerOrdersSearchRequest searchRequest = new BuyerOrdersSearchRequest();
            searchRequest.Status = "Neprocesirana";

            var buyerOrdersList = await _buyerOrderService.Get<List<BuyerOrdersModel>>(searchRequest);

            if (buyerOrdersList.Count > 0)
            {
                notificationIcon.ShowBalloonTip(6000, "Neprocesirane narudžbe", "Broj narudžbi: " + buyerOrdersList.Count, ToolTipIcon.Info);
            }
        }

        private void pregledToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmBills frmBills = new frmBills();
            frmBills.MdiParent = this;
            frmBills.WindowState = FormWindowState.Maximized;
            frmBills.Show();
        }
    }
}
