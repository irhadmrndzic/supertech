using superTechMobile.Models;
using System.Collections.Generic;

namespace superTechMobile.ViewModels.HomePage
{
    public class HomePageViewModel : BaseViewModel
    {
        public string _username;
        public string Username { get => _username; set { SetProperty(ref _username, value); } }


        public List<Item> _homePageItems;

        public HomePageViewModel()
        {
            _homePageItems = new List<Item>()
            {
                new Item { Title="Proizvodi" },
                new Item { Title="Ponude" },
                new Item { Title="Novosti" },
                new Item { Title="Narudžbe" },
                new Item { Title="Računi" }
            };
            Username = APIService.APIService.Username;
        }

        public List<Item> HomePageItems
        {
            get => _homePageItems;
            set => SetProperty(ref _homePageItems, value);
        }


    }
}
