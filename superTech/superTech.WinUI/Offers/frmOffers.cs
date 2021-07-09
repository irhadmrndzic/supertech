using superTech.Models.Offers;
using superTech.WinUI.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace superTech.WinUI.Offers
{
    public partial class frmOffers : Form
    {
        private readonly APIService.APIService _offerService = new APIService.APIService("offers");
        private int? _offerId = null;

        public frmOffers()
        {
            InitializeComponent();
            SetDatesEmpty();
        }

        public void SetDatesEmpty()
        {
            dpDFSearch.CustomFormat = " ";
            dpDFSearch.Format = DateTimePickerFormat.Custom;
            dpDTSearch.CustomFormat = " ";
            dpDTSearch.Format = DateTimePickerFormat.Custom;


            dpDateFrom.CustomFormat = " ";
            dpDateFrom.Format = DateTimePickerFormat.Custom;
            dpDateTo.CustomFormat = " ";
            dpDateTo.Format = DateTimePickerFormat.Custom;
        }

        private void frmOffers_Load(object sender, EventArgs e)
        {
            dgvOffers.AutoGenerateColumns = false;
            LoadOffers();
        }

        public  async Task LoadOffers()
        {
            try
            {
                var offers = await _offerService.Get<List<OffersModel>>(null);
                dgvOffers.DataSource = offers;
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Ponude", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task selectOffer()
        {
            try
            {
                _offerId = (int)dgvOffers.SelectedRows[0].Cells[0].Value;

                var entity = await _offerService.GetById<OffersModel>(_offerId);

                txtTitle.Text = entity.Title;
                txtDescription.Text = entity.Description;
                dpDateFrom.Value = entity.DateFrom;
                dpDateTo.Value = entity.DateTo;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ponude", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvOffers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            selectOffer();
        }

        private void btnOfferItems_Click(object sender, EventArgs e)
        {
            if (_offerId.HasValue)
            {
                frmOfferItems frmOfferItems = new frmOfferItems(_offerId);
                frmOfferItems.Show();
            }
            else
            {
                MessageBox.Show("Molimo odaberite ponudu ! ");
            }

        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            OffersSearchRequest request = new OffersSearchRequest();

            if (dpDFSearch.Text != " ")
            {
                request.DateFrom = dpDFSearch.Value;
            }
            else
            {
                MessageBox.Show("Molimo odaberite datum od ! ");

            }
            if (dpDTSearch.Text!=" ")
            {
                request.DateTo = dpDTSearch.Value;
            }
            else
            {
                MessageBox.Show("Molimo odaberite datum do ! ");

            }
            try
            {
              var res =  await _offerService.Get<List<OffersModel>>(request);
                if (res.Count > 0)
                {
                    dgvOffers.DataSource = res;
                    clearForm();
                }
                else
                {
                    lblNoOffers.Text = "Nema pronađenih ponuda ! ";
                    lblNoOffers.Show();
                }
                dgvOffers.DataSource = res;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ponude", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        void clearForm()
        {
            _offerId = null;
            lblNoOffers.Hide();
            FormReset.ResetAllControls(this);
            SetDatesEmpty();
        }

        private void dpDFSearch_ValueChanged(object sender, EventArgs e)
        {
            lblNoOffers.Hide();
            dpDFSearch.CustomFormat = "dd/MM/yyyy";
        }

        private void dpDTSearch_ValueChanged(object sender, EventArgs e)
        {
            lblNoOffers.Hide();
            dpDTSearch.CustomFormat = "dd/MM/yyyy";

        }

        private void dpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            lblNoOffers.Hide();
            dpDateFrom.CustomFormat = "dd/MM/yyyy";
        }

        private void dpDateTo_ValueChanged(object sender, EventArgs e)
        {
            lblNoOffers.Hide();
            dpDateTo.CustomFormat = "dd/MM/yyyy";
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            clearForm();
            LoadOffers();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_offerId.HasValue)
            {
                try
                {
                    await _offerService.Delete<OffersModel>(_offerId);
                    MessageBox.Show("Uspješno ste obrisali ponudu ! ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ponude", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Molimo odaberite ponudu ! ");
            }
        
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            OffersUpsertRequest offersUpsertRequest = new OffersUpsertRequest();

            if (_offerId.HasValue)
            {
                try
                {
                    offersUpsertRequest.DateFrom = dpDateFrom.Value;
                    offersUpsertRequest.DateTo = dpDateTo.Value;
                    offersUpsertRequest.Title = txtTitle.Text;
                    offersUpsertRequest.Description = txtDescription.Text;

                    await _offerService.Update<OffersModel>(_offerId, offersUpsertRequest);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ponude", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }    
        }
    }
}
