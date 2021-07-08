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

        private int? _id = null;

        public frmProducts()
        {
            this.AutoValidate = AutoValidate.Disable;
            InitializeComponent();
        }

        private async void frmProducts_Load(object sender, EventArgs e)
        {
            cmbCategories.SelectedValue = 0;

            await loadUnitsOfMeasures();
            await loadCategories();
            await loadProducts(0);
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
            lblNoProducts.Hide();

            var products = await _productsService.Get<List<ProductModel>>(new ProductsSearchRequest()
            {
                Name = txtNameSearch.Text,
                Code = txtCodeSearch.Text,
                CategoryId = categoryId
            });

            if (products.Count > 0)
            {
                Cursor.Current = Cursor.Current;
                dgvProducts.AutoGenerateColumns = false;

                    dgvProducts.DataSource = products;
            }

            if (products.Count == 0)
            {
                lblNoProducts.Text = Properties.Resources.No_Products;
                lblNoProducts.Show();
            }
        }

        private  void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = cmbCategories.SelectedValue;
            if (value == null)
            {
                value = 0;
            }
        }

        private async void onProductClicked()
        {
            _id = (int)dgvProducts.SelectedRows[0].Cells[0].Value;

            var entity = await _productsService.GetById<ProductModel>(_id);

            var castedCategories = cmbCategories.Items.Cast<CategoryModel>().Select(x => x.CategoryId).ToList();


            for (int i = 0; i < castedCategories.Count; i++)
            {
                if (castedCategories[i] == entity.CategoryId)
                {
                    cmbCategories.SelectedIndex = i;
                }
            }

            var castedUOMs = cmbUom.Items.Cast<UnitsOfMeasuresModel>().Select(x => x.UnitOfMeasureId).ToList();

            for (int i = 0; i < castedUOMs.Count; i++)
            {
                if (castedUOMs[i] == entity.UnitOfMeasureId)
                {
                    cmbUom.SelectedIndex = i;
                }
            }

            txtCode.Text = entity.Code;
            txtDesc.Text = entity.Description;
            txtName.Text = entity.Name;
            txtPrice.Text = entity.Price.ToString();
            cbActive.Checked = entity.Active;
            if (entity.Image.Length > 0)
            {
                ImageConverter converter = new ImageConverter();
                pbProdImage.Image = (Image)converter.ConvertFrom(entity.Image);
                pbProdImage.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }

        private  void dgvProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            errProvider.Clear();
            errProvider.Dispose();

            onProductClicked();
        }

        ProductUpsertRequest req = new ProductUpsertRequest();
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (validateForm())
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

                if (!_id.HasValue)
                {
                    await _productsService.Insert<ProductModel>(req);
                }
                else
                {
                    await _productsService.Update<ProductModel>(_id, req);
                }
            }
        }

        void clearForm()
        {
            errProvider.Clear();
            errProvider.Dispose();
            FormReset.ResetAllControls(this);
            _id = null;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
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

        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (e.Value is bool)
                {
                    bool value = (bool)e.Value;
                    e.Value = (value) ? "DA" : "NE";
                    e.FormattingApplied = true;
                }
            }
        }


        bool validateForm()
        {
            if (!validateCategories() || !validateProductName() || !validateProductDescription() || !validatePrice() || !validateUOMs() || !validateProductCode() || !validateImage())
                return false;
            return true;
        }

        bool validateCategories()
        {
            if (cmbCategories.SelectedIndex == 0)
            {
                errProvider.SetError(cmbCategories, Properties.Resources.Validate_Input);
                return false;

            }
            else
            {
                errProvider.SetError(cmbCategories, null);
                return true;
            }

        }

        bool validateUOMs()
        {
            if (cmbUom.SelectedIndex == 0)
            {
                errProvider.SetError(cmbUom, Properties.Resources.Validate_Input);
                return false;

            }
            else
            {
                errProvider.SetError(cmbUom, null);
                return true;
            }

        }

        bool validateProductName()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errProvider.SetError(txtName, Properties.Resources.Validate_Input);
                return false;
            }
            else
            {
                if (txtName.TextLength >= 50)
                {
                    errProvider.SetError(txtName, Properties.Resources.Validate_Input_Length + " 50 !");
                    return false;
                }
                else
                {
                    errProvider.SetError(txtName, null);
                    return true;
                }
            }
        }

        bool validateProductCode()
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                errProvider.SetError(txtCode, Properties.Resources.Validate_Input);
                return false;
            }
            else
            {
                if (txtCode.TextLength >= 30)
                {
                    errProvider.SetError(txtCode, Properties.Resources.Validate_Input_Length + " 30 !");
                    return false;
                }
                else
                {
                    errProvider.SetError(txtCode, null);
                    return true;
                }
            }
        }

        bool validateProductDescription()
        {
            if (string.IsNullOrWhiteSpace(txtDesc.Text))
            {
                errProvider.SetError(txtDesc, Properties.Resources.Validate_Input);
                return false;
            }
            else
            {
                if (txtCode.TextLength >= 100)
                {
                    errProvider.SetError(txtDesc, Properties.Resources.Validate_Input_Length + " 100 !");
                    return false;
                }
                else
                {
                    errProvider.SetError(txtDesc, null);
                    return true;
                }
            }
        }

        bool validatePrice()
        {
            if (txtPrice.Value <= 0)
            {
                errProvider.SetError(txtPrice, Properties.Resources.ValidatePrice);
                return false;
            }
            else
            {
                errProvider.SetError(txtPrice, null);
                return true;
            }
        }

        bool validateImage()
        {
            if (pbProdImage == null || pbProdImage.Image == null)
            {
                errProvider.SetError(pbProdImage, Properties.Resources.Validate_Image);

                return false;
            }
            else
            {
                errProvider.SetError(pbProdImage, null);
                return true;
            }
        }

       private async void onGetProductsClicked()
        {

            var value = cmbCategories.SelectedValue;
            if (value == null)
            {
                value = 0;
            }
            if (int.TryParse(value.ToString(), out int id))
            {
                errProvider.SetError(cmbCategories, null);

                await loadProducts(id);
            }
        }
        private  void btnShowProducts_Click(object sender, EventArgs e)
        {
            clearForm();
            onGetProductsClicked();
        }

        private  void btnSearch_Click(object sender, EventArgs e)
        {
            clearForm();
            onGetProductsClicked();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {

            if (_id.HasValue)
            {
            await _productsService.Delete<ProductModel>(_id);
            }

        }
    }
}
