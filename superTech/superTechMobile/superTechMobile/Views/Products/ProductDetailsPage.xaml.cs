using superTech.Models.BuyerOrders;
using superTech.Models.Product;
using superTechMobile.Global;
using superTechMobile.ViewModels.Products;
using superTechMobile.Views.TempOrderDetails;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace superTechMobile.Views.Products
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailsPage : ContentPage
    {
        private readonly ProductDetailsViewModel _model = null;
        private readonly ProductModel tempModel = null;
        private readonly APIService.APIService _ordersApiService = new APIService.APIService("buyerorders");

        public ProductDetailsPage(ProductModel model)
        {
            InitializeComponent();

            this.BindingContext = new ProductDetailsViewModel();
            BindingContext = _model = new ProductDetailsViewModel();
            _model.ProductId = model.ProductId;
            tempModel = model;
        }

        protected override void OnAppearing()
        {
            _model.loadProductDetails();
            _model.loadRecommendedProducts(_model.ProductId);
            if (Global.Global.activeOrder != null)
            {
                if (Global.Global.activeOrder.tempOrderItemsList != null)
                {
                    if (Global.Global.activeOrder.tempOrderItemsList.Count > 0)
                    {
                        ConfirmOrder.IsVisible = true;

                    }
                    else
                    {
                        ConfirmOrder.IsVisible = false;
                    }

                }
                else
                {
                    ConfirmOrder.IsVisible = false;
                }
            }
            else
            {
                ConfirmOrder.IsVisible = false;

            }
            base.OnAppearing();
        }

        private async void Button_AddToCart_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (qty.Text =="")
                {
                    throw new Exception("Unesite validnu količinu! ");
                }
                int number = 0;
                if (Global.Global.activeOrder == null)
                {

                    var ordersList = await _ordersApiService.Get<List<BuyerOrdersModel>>(null);
                    if (ordersList.Count > 0)
                    {
                        number = ordersList.Count;
                    }
                    else
                    {
                        number = 0;
                    }

                    Global.Global.activeOrder = new Global.TempOrder();
                    Global.Global.activeOrder.Active = true;
                    Global.Global.activeOrder.FkUserId = APIService.APIService.userId;
                    Global.Global.activeOrder.Confirmed = false;
                    Global.Global.activeOrder.Canceled = false;
                    Global.Global.activeOrder.OrderNumber = number++;
                    Global.Global.activeOrder.Date = DateTime.Now;
                }

                bool isProductAdded = false;

                foreach (var item in Global.Global.activeOrder.tempOrderItemsList)
                {
                    if (_model.ProductId == item.FkProductId)
                    {
                        item.Quantity += _model.Quantity;

                        isProductAdded = true;
                        await Application.Current.MainPage.DisplayAlert("Info", "Količina proizvoda izmijenjena !", "OK");

                        break;
                    }
                }
                if (!isProductAdded)
                {
                    TempOrderItems tempOrderItemsList = new TempOrderItems();
                    tempOrderItemsList.FkProductId = _model.ProductDetailsId;
                    tempOrderItemsList.Quantity = _model.Quantity;
                    tempOrderItemsList.FkProduct = tempModel;
                    tempOrderItemsList.FkProduct.Image = null;
                    tempOrderItemsList.FkProduct.ImageThumb = null;
                    tempOrderItemsList.Amount = tempModel.Price * int.Parse(qty.Text);

                    Global.Global.activeOrder.tempOrderItemsList.Add(tempOrderItemsList);
                    await Application.Current.MainPage.DisplayAlert("Info", "Proizvod dodan u korpu!", "OK");
                }



                if (Global.Global.activeOrder.tempOrderItemsList.Count == 1)
                {
                    CartInfo.Text = "U korpi se nalazi 1 proizvod! ";
                }
                else
                {
                    CartInfo.Text = "U korpi se nalazi: " + Global.Global.activeOrder.tempOrderItemsList.Count + " proizvoda! ";
                }
                ConfirmOrder.IsVisible = true;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");

            }

        }

        private async void Button_Confirm_Order_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TempOrderDetailsPage());
        }
    }
}