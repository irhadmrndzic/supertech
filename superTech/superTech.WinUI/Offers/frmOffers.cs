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
            dgvOffers.Columns[0].Width = 350;
            dgvOffers.Columns[1].Width = 350;
            LoadOffers();
        }

        public async Task LoadOffers()
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
                cbActive.Checked = entity.Active;
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
            if (dpDTSearch.Text != " ")
            {
                request.DateTo = dpDTSearch.Value;
            }
            else
            {
                MessageBox.Show("Molimo odaberite datum do ! ");

            }
            try
            {
                var res = await _offerService.Get<List<OffersModel>>(request);
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

        private async void btnSaveOffer_Click(object sender, EventArgs e)
        {
            OffersUpsertRequest offersUpsertRequest = new OffersUpsertRequest();

            if (_offerId.HasValue)
            {
                if (validateForm())
                {
                    try
                    {
                        offersUpsertRequest.DateFrom = dpDateFrom.Value;
                        offersUpsertRequest.DateTo = dpDateTo.Value;
                        offersUpsertRequest.Title = txtTitle.Text;
                        offersUpsertRequest.Description = txtDescription.Text;
                        offersUpsertRequest.Active = cbActive.Checked;

                        await _offerService.Update<OffersModel>(_offerId, offersUpsertRequest);
                        MessageBox.Show("Uspješno ste uredili ponudu ! ", "Ponude", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ponude", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            else
            {
                MessageBox.Show("Molimo odaberite ponudu ! ", "Ponude", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        bool validateForm()
        {
            if (!validateTitle() || !validateDescription() || !validateOrderDateFrom() || !validateOrderDateTo() || !validatePeriod())
                return false;
            return true;
        }

        bool validateTitle()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errProvider.SetError(txtTitle, Properties.Resources.Validate_Input);
                return false;
            }
            if (txtTitle.Text.Length >= 101)
            {
                errProvider.SetError(txtTitle, "Naslov ne smije sadržavati više od 100 karaktera");
                return false;
            }
            else
            {
                errProvider.SetError(txtTitle, null);
                return true;
            }
        }


        bool validateDescription()
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                errProvider.SetError(txtDescription, Properties.Resources.Validate_Input);
                return false;
            }
            if (txtDescription.Text.Length >= 1001)
            {
                errProvider.SetError(txtDescription, "Naslov ne smije sadržavati više od 100 karaktera");
                return false;
            }
            else
            {
                errProvider.SetError(txtDescription, null);
                return true;
            }
        }

        bool validateOrderDateFrom()
        {
            if (dpDateFrom.Text == " ")
            {
                errProvider.SetError(dpDateFrom, "Molimo unesite važenja od !");
                return false;
            }
            else
            {
                errProvider.SetError(dpDateFrom, null);
                return true;
            }
        }

        bool validateOrderDateTo()
        {
            if (dpDateTo.Text == " ")
            {
                errProvider.SetError(dpDateTo, "Molimo unesite važenja do !");
                return false;
            }
            else
            {
                errProvider.SetError(dpDateTo, null);
                return true;
            }
        }

        bool validatePeriod()
        {

            if (dpDateTo.Value < dpDateFrom.Value)
            {
                errProvider.SetError(dpDateTo, "Molimo unesite validan period !");
                return false;
            }

            else
            {
                errProvider.SetError(dpDateTo, null);
                return true;
            }
        }

        private void dgvOffers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
    }
}
