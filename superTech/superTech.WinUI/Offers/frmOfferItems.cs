
using superTech.Models.Offers;
using System.Windows.Forms;

namespace superTech.WinUI.Offers
{
    public partial class frmOfferItems : Form
    {
        private int? _offerId = null;
        private readonly APIService.APIService _offersService = new APIService.APIService("offers");

        public frmOfferItems(int? offerId = null)
        {
            InitializeComponent();
            _offerId = offerId;
        }
        private async void frmOfferItems_Load(object sender, System.EventArgs e)
        {
            if (_offerId.HasValue)
            {
                var offer = await _offersService.GetById<OffersModel>(_offerId);
                listViewOfferItems.Items.Clear();
                int i = 1;
                foreach (var orderItem in offer.OfferItems)
                {
                    var row = new string[] { i.ToString(), orderItem.ProductName, orderItem.Discount.ToString() + " %", orderItem.PriceWithDiscount.ToString() + " KM " };
                    var lvItem = new ListViewItem(row);
                    listViewOfferItems.Items.Add(lvItem);
                    i++;
                }
            }
        }
    }
}
