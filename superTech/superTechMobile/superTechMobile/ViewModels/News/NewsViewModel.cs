using superTech.Models.News;
using superTechMobile.Views.News;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace superTechMobile.ViewModels.News
{
    public class NewsViewModel : BaseViewModel
    {
        private readonly APIService.APIService _newsApiService = new APIService.APIService("news");

        public ObservableCollection<NewsModel> NewsList { get; set; } = new ObservableCollection<NewsModel>();
        public ICommand InitCommand { get; set; }
        private NewsModel _selectedItem;

        public NewsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }


        public async Task Init()
        {
            try
            {
                IsBusy = true;
                var list = await _newsApiService.Get<List<NewsModel>>(null);
                NewsList.Clear();
                foreach (var item in list)
                {
                    NewsList.Add(item);
                }
            }
            catch (Exception)
            {

                throw;
            }
            IsBusy = false;

        }


        public NewsModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

     public  async void OnItemSelected(NewsModel item)
        {
            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(NewsDetailsPage)}?{nameof(NewsDetailsViewModel.NewsId)}={item.NewsId}");

            await Application.Current.MainPage.Navigation.PushAsync(new NewsDetailsPage());

        }


    }
}
