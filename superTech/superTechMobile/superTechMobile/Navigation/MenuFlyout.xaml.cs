using superTech.Models.User;
using superTechMobile.Views;
using superTechMobile.Views.Bills;
using superTechMobile.Views.DelivererBills;
using superTechMobile.Views.DelivererOrders;
using superTechMobile.Views.News;
using superTechMobile.Views.Offers;
using superTechMobile.Views.Orders;
using superTechMobile.Views.Products;
using superTechMobile.Views.TempOrderDetails;
using superTechMobile.Views.UserDetails;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuFlyout : ContentPage
    {
        private readonly APIService.APIService _usersApiService = new APIService.APIService("users");

        public ListView ListView;
        public MenuFlyout()
        {
            InitializeComponent();

            BindingContext = new MenuFlyoutViewModel();
            ListView = MenuItemsListView;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing(); 
        }


        class MenuFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MenuFlyoutMenuItem> MenuItems { get; set; }
            public MenuFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MenuFlyoutMenuItem>();
                MenuItems.Add(new MenuFlyoutMenuItem { Title = "Početna", Image = "home-page.png", TargetType = typeof(ProductsPage) });

                if (!APIService.APIService.cUser.RolesString.Contains("Dostavljac"))
                {
                    MenuItems.Add(new MenuFlyoutMenuItem { Title = "Korpa", Image = "cart.png", TargetType = typeof(TempOrderDetailsPage) });
                    
                    MenuItems.Add(new MenuFlyoutMenuItem { Title = "Ponude", Image = "find-product.png", TargetType = typeof(OffersPage) });
                    MenuItems.Add(new MenuFlyoutMenuItem { Title = "Moje narudžbe", Image = "orders.png", TargetType = typeof(OrdersPage) });
                    MenuItems.Add(new MenuFlyoutMenuItem { Title = "Moji računi", Image = "bills.png", TargetType = typeof(BillsPage) });
                    MenuItems.Add(new MenuFlyoutMenuItem { Title = "Novosti", Image = "news.png", TargetType = typeof(NewsPage) });
                    MenuItems.Add(new MenuFlyoutMenuItem { Title = "Profil", Image = "my-account.png", TargetType = typeof(UserDetailsPage) });
                }
                if (APIService.APIService.cUser.RolesString.Contains("Dostavljac"))
                {
                    MenuItems.Add(new MenuFlyoutMenuItem { Title = "Aktivne narudžbe", Image = "orders.png", TargetType = typeof(DelivererOrdersPage) });
                    MenuItems.Add(new MenuFlyoutMenuItem { Title = "Aktivni računi", Image = "bills.png", TargetType = typeof(DelivererBills) });
                }
                MenuItems.Add(new MenuFlyoutMenuItem { Title = "Odjava", Image = "logout.png", TargetType = typeof(LoginPage) });

            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}