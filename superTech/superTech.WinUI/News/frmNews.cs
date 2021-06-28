using superTech.Models.News;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace superTech.WinUI.News
{
    public partial class frmNews : Form
    {
        private readonly APIService.APIService _newsService = new APIService.APIService("news");
        private readonly int? _id = null;
        public frmNews()
        {
            InitializeComponent();
        }

        private async void frmNews_Load(object sender, EventArgs e)
        {
         await loadNews();
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

        private   void dgvNews_MouseDoubleClick(object sender, MouseEventArgs e)
        {
             onNewsClicked();
        }

        private async void onNewsClicked()
        {
            var _id = (int)dgvNews.SelectedRows[0].Cells[0].Value;

            var entity = await _newsService.GetById<NewsModel>(_id);

            txtTitle.Text = entity.Title;
            txtContent.Text = entity.Content;
            dpDoC.Value = Convert.ToDateTime(entity.DateOfCreation);
            cbActive.Checked = entity.Active;
        }
    }
}
