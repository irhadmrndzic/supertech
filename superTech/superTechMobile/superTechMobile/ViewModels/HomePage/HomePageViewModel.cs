using superTechMobile.Models;
using System.Collections.Generic;

namespace superTechMobile.ViewModels.HomePage
{
    public class HomePageViewModel : BaseViewModel
    {

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
        }

        public List<Item> HomePageItems
        {
            get => _homePageItems;
            set => SetProperty(ref _homePageItems, value);
        }


    }
}
