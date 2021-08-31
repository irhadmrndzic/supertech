using superTech.Models.News;
using System;
using System.Threading.Tasks;

namespace superTechMobile.ViewModels.News
{
    public class NewsDetailsViewModel : BaseViewModel
    {
        private readonly APIService.APIService _newsApiService = new APIService.APIService("news");

        public string _title;
        public string _date;
        public string _content;


        public int NewsId { get; set; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }


        public async void loadNewsDetails()
        {
            try
            {
                var item = await _newsApiService.GetById<NewsModel>(NewsItemId);
                Title = item.Title;
                Date = item.DateOfCreation.ToShortDateString();
                Content = item.Content;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int NewsItemId
        {
            get
            {
                return NewsId;
            }
            set
            {
                NewsId = value;
                LoadNewsItem(value);
            }
        }


        public async Task LoadNewsItem(int newsItemId)
        {
            try
            {
                var item = await _newsApiService.GetById<NewsModel>(newsItemId);
                Title = item.Title;
                Content = item.Content;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
