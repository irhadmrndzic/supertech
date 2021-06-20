using superTech.Models.Category;
using superTech.Models.Product;
using superTech.Models.UnitsOfMeasures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace superTech.WinUI.Products
{
    public partial class frmProducts : Form
    {
        private readonly APIService.APIService _categoriesService = new APIService.APIService("categories");
        private readonly APIService.APIService _uomService = new APIService.APIService("unitsofmeasures");
        private readonly APIService.APIService _productsService = new APIService.APIService("products");



        public frmProducts()
        {
            InitializeComponent();
        }

        private async void frmProducts_Load(object sender, EventArgs e)
        {
            cmbCategories.SelectedValue = 0;

         await  loadUnitsOfMeasures();
         await  loadCategories();
         await  loadProducts(0);


        }



        private async Task loadUnitsOfMeasures()
        {
            List<UnitsOfMeasuresModel> uom = await _uomService.Get<List<UnitsOfMeasuresModel>>(null);
            cmbUom.DataSource = uom;
            uom.Insert(0, new UnitsOfMeasuresModel());
            cmbUom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUom.DisplayMember = "Name";
            cmbUom.ValueMember = "UnitOfMeasureId";
        }

        private async Task loadCategories()
        {
            List<CategoryModel> categories = await _categoriesService.Get<List<CategoryModel>>(null);
            categories.Insert(0, new CategoryModel());

            cmbCategories.SelectedIndex = cmbCategories.SelectionStart;
            cmbCategories.DataSource = categories;
            cmbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategories.DisplayMember = "Name";
            cmbCategories.ValueMember = "CategoryId";


        }

        private async Task loadProducts(int? categoryId)
        {
            var products = await _productsService.Get<List<ProductModel>>(new ProductsSearchRequest() { 
                CategoryId = categoryId
            });

            if (products.Count > 0)
            {
                Cursor.Current = Cursor.Current;
                dgvProducts.AutoGenerateColumns = false;
                dgvProducts.DataSource = products;
            }
        }

        private async void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = cmbCategories.SelectedValue;
            if (value == null)
            {
                value = 0;
            }
            if(int.TryParse(value.ToString(), out int id))
            {
                 await  loadProducts(id);
            }
        }
    }
}
