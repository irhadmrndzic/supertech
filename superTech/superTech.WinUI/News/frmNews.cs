using superTech.Models.News;
using superTech.WinUI.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace superTech.WinUI.News
{
    public partial class frmNews : Form
    {
        private readonly APIService.APIService _newsService = new APIService.APIService("news");
        private int? _id = null;

        public frmNews()
        {
            InitializeComponent();
        }

        private async void frmNews_Load(object sender, EventArgs e)
        {
            lblNoNews.Hide();
            await loadNews();
            dpDoC.CustomFormat = " ";
            dpDoC.Format = DateTimePickerFormat.Custom;
        }

        private async Task loadNews()
        {
            var news = await _newsService.Get<List<NewsModel>>(null);
            dgvNews.AutoGenerateColumns = false;

            if (news.Count > 0)
            {
                dgvNews.DataSource = news;
            }
        }

        private void dgvNews_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            errProvider.Clear();
            errProvider.Dispose();
            onNewsClicked();
        }

        private async void onNewsClicked()
        {
            _id = (int)dgvNews.SelectedRows[0].Cells[0].Value;

            var entity = await _newsService.GetById<NewsModel>(_id);

            txtTitle.Text = entity.Title;
            txtContent.Text = entity.Content;
            dpDoC.Value = Convert.ToDateTime(entity.DateOfCreation);
            cbActive.Checked = entity.Active;
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            lblNoNews.Hide();
            if (dpDoC.Text != " ")
            {
                NewsSearchRequest request = new NewsSearchRequest();

                request.DateOfCreation = dpDoC.Value;
                var news = await _newsService.Get<List<NewsModel>>(request);
                dgvNews.DataSource = news;

                if (news.Count == 0)
                {
                    lblNoNews.Text = "Nema pronađenih novosti za odabrani datum !";
                    lblNoNews.Show();
                }
            }
            else
            {
                lblNoNews.Text = "Molimo unesite datum za pretragu! ";
                lblNoNews.Show();
            }

        }

        private async void btnShowAll_Click(object sender, EventArgs e)
        {
            lblNoNews.Hide();

            await loadNews();
            dpDoC.CustomFormat = " ";
            dpDoC.Format = DateTimePickerFormat.Custom;
        }

        private void dpDoC_ValueChanged(object sender, EventArgs e)
        {
            lblNoNews.Hide();
            dpDoC.CustomFormat = "dd/MM/yyyy";
        }

        NewsUpsertRequest upsertRequest = new NewsUpsertRequest();
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                try
                {
                    upsertRequest.Active = cbActive.Checked;
                    upsertRequest.Title = txtTitle.Text.ToString();
                    upsertRequest.Content = txtContent.Text;
                    upsertRequest.DateOfCreation = dpDoC.Value;

                    if (_id.HasValue)
                    {
                        await _newsService.Update<NewsModel>(_id, upsertRequest);
                        MessageBox.Show("Uspješno ste uredili novost !");
                    }
                    else
                    {
                        await _newsService.Insert<NewsModel>(upsertRequest);
                        MessageBox.Show("Uspješno ste sačuvali novost !");

                    }

                    FormReset.ResetAllControls(this);
                    _id = null;
                    dpDoC.CustomFormat = " ";
                    dpDoC.Format = DateTimePickerFormat.Custom;

                    await this.loadNews();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Novosti", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            errProvider.Clear();
            errProvider.Dispose();
            FormReset.ResetAllControls(this);
            _id = null;
            dpDoC.CustomFormat = " ";
            dpDoC.Format = DateTimePickerFormat.Custom;
        }


        bool validateForm()
        {
            if (!validateTitle() || !validateDate() || !validateContent())
                return false;
            return true;
        }

        bool validateTitle()
        {
            if (txtTitle.Text == "" || txtTitle.Text.Length == 0)
            {
                errProvider.SetError(txtTitle, "Molimo unesite naslov novosti !");
                return false;

            }
            else if (txtTitle.Text.Length > 100)
            {
                errProvider.SetError(txtTitle, "Maksimalna dužina naslova je 100 karaktera !");
                return false;
            }
            else
            {
                errProvider.SetError(txtTitle, null);
                return true;
            }
        }

        bool validateContent()
        {
            if (txtContent.Text == "" || txtContent.Text.Length == 0)
            {
                errProvider.SetError(txtContent, "Molimo sadržaj novosti !");
                return false;

            }
            else if (txtContent.Text.Length > 1000)
            {
                errProvider.SetError(txtContent, "Maksimalna dužina sadržaja je 1000 karaktera !");
                return false;
            }
            else
            {
                errProvider.SetError(txtContent, null);
                return true;
            }
        }

        bool validateDate()
        {
            if (dpDoC.Text == " ")
            {
                errProvider.SetError(dpDoC, "Molimo unesite datum objave !");
                return false;
            }
            else if (dpDoC.Value.Date > DateTime.Now.Date)
            {
                errProvider.SetError(dpDoC, "Datum ne može biti veći od današnjeg !");
                return false;
            }
            else
            {
                errProvider.SetError(dpDoC, null);
                return true;
            }
        }

    }
}
