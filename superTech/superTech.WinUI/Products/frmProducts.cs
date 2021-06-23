using superTech.Models.Category;
using superTech.Models.Product;
using superTech.Models.UnitsOfMeasures;
using superTech.WinUI.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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

        private async void dgvProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvProducts.SelectedRows[0].Cells[0].Value;

            var entity = await _productsService.GetById<ProductModel>(id);

            txtCode.Text = entity.Code;
            txtDesc.Text = entity.Description;
            txtName.Text = entity.Name;
            txtPrice.Text = entity.Price.ToString();
            cbActive.Checked = entity.Active;
            if (entity.Image.Length>0)
            {
                ImageConverter converter = new ImageConverter();
                pbProdImage.Image = (Image)converter.ConvertFrom(entity.Image);
                pbProdImage.SizeMode = PictureBoxSizeMode.StretchImage;

            }


         }

        ProductUpsertRequest req = new ProductUpsertRequest();
        private void button1_Click(object sender, EventArgs e)
        {
            var result = imgDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = imgDialog.FileName;

                var file = File.ReadAllBytes(fileName);

                req.Image = file;
                txtImage.Text = fileName;

                Image image = Image.FromFile(fileName);
                pbProdImage.Image = image;
                pbProdImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var categoryId = cmbCategories.SelectedValue;

            if (int.TryParse(categoryId.ToString(), out int catId))
            {
                req.CategoryId = catId;
            }

            var unitOfMeasure = cmbUom.SelectedValue;

            if (int.TryParse(unitOfMeasure.ToString(), out int uomId))
            {
                req.UnitOfMeasureId = uomId;
            }

            req.Name = txtName.Text;
            req.Code = txtCode.Text;
            req.Active = cbActive.Checked;
            req.Description = txtDesc.Text;
            req.Price = decimal.Parse(txtPrice.Text);

            await _productsService.Insert<ProductModel>(req);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            FormReset.ResetAllControls(this);
        }
    }
}
