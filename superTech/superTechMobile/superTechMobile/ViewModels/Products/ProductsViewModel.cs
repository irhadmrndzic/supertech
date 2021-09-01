using superTech.Models.Brands;
using superTech.Models.Category;
using superTech.Models.Offers;
using superTech.Models.Product;
using superTechMobile.Extensions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace superTechMobile.ViewModels.Products
{
    public class ProductsViewModel : BaseViewModel
    {
        private readonly APIService.APIService _productsApiService = new APIService.APIService("products");
        private readonly APIService.APIService _categoriesApiService = new APIService.APIService("categories");
        private readonly APIService.APIService _offersApiService = new APIService.APIService("offers");

        public string _productName;
        public string _productCode;
        public string _productDescription;
        public decimal _productPrice;
        public string _productRating;
        public int _productInventory;
        public string _productBrand;
        public string _proiductCategory;

        public ICommand InitCommand { get; }

        public string ProductName { get => _productName; set { SetProperty(ref _productName, value); } }
        public string ProductCode { get => _productCode; set { SetProperty(ref _productCode, value); } }
        public string ProductDescription { get => _productDescription; set { SetProperty(ref _productDescription, value); } }
        public string ProductRating { get => _productRating; set { SetProperty(ref _productRating, value); } }
        public int Inventory { get => _productInventory; set { SetProperty(ref _productInventory, value); } }
        public string ProductBrand { get => _productBrand; set { SetProperty(ref _productBrand, value); } }
        public string ProductCategory { get => _proiductCategory; set { SetProperty(ref _proiductCategory, value); } }
        public decimal ProductPrice { get => _productPrice; set { SetProperty(ref _productPrice, value); } }

        public CategoryModel _selectedCategory = null;
        public CategoryModel SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                SetProperty(ref _selectedCategory, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }


        public ObservableCollection<ProductModel> ProductsList { get; set; } = new ObservableCollection<ProductModel>();
        public ObservableCollection<ProductModel> AlteredProductList { get; set; } = new ObservableCollection<ProductModel>();
        public ObservableCollection<CategoryModel> CategoriesList { get; set; } = new ObservableCollection<CategoryModel>();
        public ObservableCollection<BrandsModel> BrandsList { get; set; } = new ObservableCollection<BrandsModel>();

        public ProductsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }


        public  void Reset()
        {
            SelectedCategory = null;
            InitCommand.Execute(null);
        }
        public async Task Init()
        {
            try
            {
                var offers = await _offersApiService.Get<List<OffersModel>>(null);
            
                IsBusy = true;
                if (CategoriesList.Count == 0)
                {
                    var categoriesList = await _categoriesApiService.Get<List<CategoryModel>>(null);
                    CategoriesList.Clear();
                    foreach (var item in categoriesList)
                    {
                        CategoriesList.Add(item);
                    }
                }

                if (SelectedCategory != null)
                {
                    ProductsSearchRequest request = new ProductsSearchRequest();
                    request.CategoryId = SelectedCategory.CategoryId;
                    var list = await _productsApiService.Get<List<ProductModel>>(request);
                    ProductsList.Clear();
                    foreach (var item in list)
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
                                    ProductsList.Where(x => x.ProductId == item.FkProductId).SetValue(q => q.Price = (decimal)item.PriceWithDiscount);
                                }
                            }
                        }
                    }

                }

                if (SelectedCategory == null)
                {
                    var list = await _productsApiService.Get<List<ProductModel>>(null);
                    ProductsList.Clear();
                    foreach (var item in list)
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
                                    ProductsList.Where(x => x.ProductId == item.FkProductId && offer.Active==true).SetValue(q => q.Price = (decimal)item.PriceWithDiscount);
                                    ProductsList.Where(x => x.ProductId == item.FkProductId && offer.Active==true).SetValue(q => q.PriceString = item.PriceWithDiscount.ToString()+ " KM");
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                IsBusy = false;
                throw;
            }
            IsBusy = false;

        }
    }
}
