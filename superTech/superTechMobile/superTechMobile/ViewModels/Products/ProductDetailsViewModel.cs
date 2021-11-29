using superTech.Models.Offers;
using superTech.Models.Product;
using superTechMobile.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace superTechMobile.ViewModels.Products
{
    public class ProductDetailsViewModel : BaseViewModel
    {
        private readonly APIService.APIService _productsApiService = new APIService.APIService("products");
        private readonly APIService.APIService _offersApiService = new APIService.APIService("offers");

        public string _productName;
        public string _productCode;
        public string _productDescription;
        public string _productPrice;
        public string _productRating;
        public string _productInventory;
        public int _productInventoryInt;
        public string _productBrand;
        public string _proiductCategory;
        public int _quantity;
        public decimal _productPriceDecimal;
        public bool _hasAccess;


        public bool HasAccess { get => _hasAccess; set { SetProperty(ref _hasAccess, value); } }

        public ObservableCollection<ProductModel> ProductsList { get; set; } = new ObservableCollection<ProductModel>();

        public byte[] _image;


        public int ProductId { get; set; }


        public int ProductDetailsId
        {
            get
            {
                return ProductId;
            }
            set
            {
                ProductId = value;
            }
        }
  

        public string ProductName { get => _productName; set { SetProperty(ref _productName, value); } }
        public byte[] Image{ get => _image; set { SetProperty(ref _image, value); } }
        public string ProductCode { get => _productCode; set { SetProperty(ref _productCode, value); } }
        public string ProductPrice { get => _productPrice; set { SetProperty(ref _productPrice, value); } }
        public decimal ProductPriceDecimal { get => _productPriceDecimal; set { SetProperty(ref _productPriceDecimal, value); } }
        public string ProductDescription { get => _productDescription; set { SetProperty(ref _productDescription, value); } }
        public string ProductRating { get => _productRating; set { SetProperty(ref _productRating, value); } }
        public string Inventory { get => _productInventory; set { SetProperty(ref _productInventory, value); } }
        public int ProductInventory { get => _productInventoryInt; set { SetProperty(ref _productInventoryInt, value); } }
        public string ProductBrand { get => _productBrand; set { SetProperty(ref _productBrand, value); } }
        public string ProductCategory { get => _proiductCategory; set { SetProperty(ref _proiductCategory, value); } }

        public int Quantity
        {
            get => _quantity; set => SetProperty(ref _quantity, value);
        }

        public ProductDetailsViewModel()
        {

        }

        public async void loadProductDetails()
        {
            if (APIService.APIService.cUser.RolesString.Contains("Kupac"))
            {
                HasAccess = true;
            }
            else
            {
                HasAccess = false;
            }

                try
            {
                ProductModel product = await _productsApiService.GetById<ProductModel>(ProductId);
                var offers = await _offersApiService.Get<List<OffersModel>>(null);

                if(offers.Count() > 0)
                {
                    foreach (var offer in offers)
                    {
                        foreach (var item in offer.OfferItems)
                        {

                            if (product.ProductId == item.FkProductId)
                            {
                                ProductPrice = item.PriceWithDiscount.ToString();
                                ProductPriceDecimal = (decimal)item.PriceWithDiscount;
                            }
                            else
                            {
                                ProductPriceDecimal = product.Price;
                                ProductPrice = product.PriceString;
                            }
                        }
                    }
                }
                else
                {
                    ProductPrice = product.PriceString;
                }
                
         
                ProductName = product.Name;
                ProductCode = product.Code;
                ProductDescription = product.Description;
                ProductInventory = product.Inventory;
                Image = product.Image;
                if (product.Inventory > 0)
                {
                    Inventory = "Dostupno !";
                }
                else
                {
                    Inventory = "Nema na stanju !";
                }
                ProductBrand = product.Brand;
                ProductCategory = product.CategoryString;
                ProductRating = product.Rating.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async void loadRecommendedProducts(int id)
        {
            try
            {
                List<ProductModel> products = await _productsApiService.GetRecommended<List<ProductModel>>(id);
                var offers = await _offersApiService.Get<List<OffersModel>>(null);

                ProductsList.Clear();

                foreach (var item in products)
                {
                    ProductsList.Add(item);
                }
                foreach (var offer in offers)
                {
                    foreach (var item in offer.OfferItems)
                    {
                        foreach (var prod in ProductsList)
                        {
                            if (prod.ProductId == item.FkProductId)
                            {
                                ProductsList.Where(x => x.ProductId == item.FkProductId && offer.Active == true).SetValue(q => q.Price = (decimal)item.PriceWithDiscount);
                                ProductsList.Where(x => x.ProductId == item.FkProductId && offer.Active == true).SetValue(q => q.PriceString = item.PriceWithDiscount.ToString() + " KM");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
