using superTech.Models.Category;
using superTech.Models.Offers;
using superTech.Models.Offers.OfferItems;
using superTech.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace superTech.WinUI.Offers
{
    public partial class frmAddOffer : Form
    {
        private readonly APIService.APIService _productsService = new APIService.APIService("products");
        private readonly APIService.APIService _categoriesService = new APIService.APIService("categories");
        private readonly APIService.APIService _offerService = new APIService.APIService("offers");

        public int? _productId = null;

        public frmAddOffer()
        {
            InitializeComponent();
        }

        private async void frmAddOffer_Load(object sender, EventArgs e)
        {
            dgvProductOrder.AutoGenerateColumns = false;
            dgvProductOrder.AllowUserToResizeColumns = false;
            dgvProductOrder.AllowUserToResizeRows = false;

            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AllowUserToResizeRows = false;
            dgvProducts.AllowUserToResizeColumns = false;
            SetDatesEmpty();


            await loadCategories();
            await loadProducts(0);
        }

        public void SetDatesEmpty()
        {
            dpDateFrom.CustomFormat = " ";
            dpDateFrom.Format = DateTimePickerFormat.Custom;
            dpDateTo.CustomFormat = " ";
            dpDateTo.Format = DateTimePickerFormat.Custom;
        }
        private async Task loadCategories()
        {
            try
            {
                List<CategoryModel> categories = await _categoriesService.Get<List<CategoryModel>>(null);
                categories.Insert(0, new CategoryModel());

                cmbProductCategories.DataSource = categories;
                cmbProductCategories.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbProductCategories.DisplayMember = "Name";
                cmbProductCategories.ValueMember = "CategoryId";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Kategorije", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async Task loadProducts(int? categoryId)
        {

            lblNoProducts.Hide();
            try
            {
                var products = await _productsService.Get<List<ProductModel>>(new ProductsSearchRequest()
                {
                    Code = txtProductCodeSearch.Text,
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
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Proizvodi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowProducts_Click(object sender, EventArgs e)
        {
            onFilterProducts();
        }

        public async void onFilterProducts()
        {
            var value = cmbProductCategories.SelectedValue;
            if (value == null)
            {
                value = 0;
            }
            if (int.TryParse(value.ToString(), out int id))
            {
                errProvider.SetError(cmbProductCategories, null);
                await loadProducts(id);
            }
        }
        ProductModel entity = new ProductModel();
        List<ProductOfferModel> orderList = new List<ProductOfferModel>();
        public async void onProductClicked()
        {
            _productId = (int)dgvProducts.SelectedRows[0].Cells[0].Value;

            entity = await _productsService.GetById<ProductModel>(_productId);

            var castedCategories = cmbProductCategories.Items.Cast<CategoryModel>().Select(x => x.CategoryId).ToList();


            for (int i = 0; i < castedCategories.Count; i++)
            {
                if (castedCategories[i] == entity.CategoryId)
                {
                    cmbProductCategories.SelectedIndex = i;
                }
            }


            txtUnitOfMeasure.Text = entity.FkUnitOfMeasureString;
            txtProductCode.Text = entity.Code;
            txtPrice.Text = entity.Price.ToString();
            txtUnitOfMeasure.Text = entity.FkUnitOfMeasureString;

        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            int productIndex;
            frmRemoveOfferProduct frmRemoveOfferProduct = new frmRemoveOfferProduct();
            if (frmRemoveOfferProduct.ShowDialog() == DialogResult.OK)
            {

                productIndex = frmRemoveOfferProduct.productIndex;
                if (productIndex <= orderList.Count)
                {
                    orderList.RemoveAt(productIndex - 1);
                    dgvProductOrder.DataSource = orderList.ToList();
                    setRowNumber(dgvProductOrder);

                    dgvProductOrder.Refresh();
                    dgvProductOrder.Update();
                }
                else
                {
                    MessageBox.Show("Unesite ispravan redni broj ! ", "Ukloni proizvod", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void setRowNumber(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }


        public void setEntities(ProductModel entity)
        {
            ProductOfferModel pom = new ProductOfferModel();

            pom.Name = entity.Name;
            pom.ProductId = entity.ProductId;
            pom.Price = entity.Price;
            pom.Code = entity.Code;

            var dp = (entity.Price - (entity.Price * (decimal.Parse(txtDiscount.Text) / 100)));
            dp = Math.Round(dp, 2);
            pom.PriceWithDiscount = dp;
            pom.Discount = decimal.Parse(txtDiscount.Text);
            txtPriceDiscount.Text = dp.ToString();

            orderList.Add(pom);

            dgvProductOrder.DataSource = orderList.ToList();

            dgvProductOrder.Refresh();
            dgvProductOrder.Update();

            setRowNumber(dgvProductOrder);
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {

            if (validateForm())
            {
                ProductOfferModel pom = new ProductOfferModel();
                if (orderList.Count == 0)
                {
                    setEntities(entity);
                    errProvider.SetError(gbAddProduct, null);
                    return;
                }

                if (orderList.Count > 0)
                {
                    if (!orderList.Where(x => x.Code == entity.Code).Any())
                    {
                        errProvider.SetError(gbAddProduct, null);
                        setEntities(entity);
                    }
                    else
                    {
                        MessageBox.Show("Molimo odaberite novi proizvod ! ", "Ponuda", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }

        }

        private void dgvProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            onProductClicked();

        }

        private async void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (validateForm() && validateProductList())
            {
                try
                {
                    OffersUpsertRequest request = new OffersUpsertRequest();

                    request.DateFrom = dpDateFrom.Value;
                    request.DateTo = dpDateTo.Value;
                    request.Title = txtTitle.Text;
                    request.Description = txtDesc.Text;
                    request.Active = cbActive.Checked;

                    request.OfferItems = new List<OfferItemsUpsertRequest>();

                    for (int i = 0; i < orderList.Count; i++)
                    {
                        OfferItemsUpsertRequest oi = new OfferItemsUpsertRequest
                        {
                            Discount = orderList[i].Discount,
                            PriceWithDiscount = orderList[i].PriceWithDiscount,
                            FkProductId = orderList[i].ProductId
                        };
                        request.OfferItems.Add(oi);
                    }

                    await _offerService.Insert<OffersModel>(request);
                    MessageBox.Show("Uspješno ste dodali ponudu ! ", "Ponuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errProvider.Clear();
                    errProvider.Dispose();

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Ponude", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void dpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            dpDateFrom.CustomFormat = "dd/MM/yyyy";

        }

        private void dpDateTo_ValueChanged(object sender, EventArgs e)
        {
            dpDateTo.CustomFormat = "dd/MM/yyyy";
        }

        bool validateForm()
        {
            if (!validateTitle() || !validateDescription() || !validateOrderDateFrom() || !validateOrderDateTo() || !validatePeriod() || !validateProduct() || !validateDiscount() )
                return false;
            return true;
        }

        bool validateTitle()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errProvider.SetError(txtTitle, Properties.Resources.Validate_Input);
                return false;
            }
            if (txtTitle.Text.Length >= 101)
            {
                errProvider.SetError(txtTitle, "Naslov ne smije sadržavati više od 100 karaktera");
                return false;
            }
            else
            {
                errProvider.SetError(txtTitle, null);
                return true;
            }
        }


        bool validateDescription()
        {
            if (string.IsNullOrWhiteSpace(txtDesc.Text))
            {
                errProvider.SetError(txtDesc, Properties.Resources.Validate_Input);
                return false;
            }
            if (txtDesc.Text.Length >= 1001)
            {
                errProvider.SetError(txtDesc, "Naslov ne smije sadržavati više od 100 karaktera");
                return false;
            }
            else
            {
                errProvider.SetError(txtDesc, null);
                return true;
            }
        }

        bool validateOrderDateFrom()
        {
            if (dpDateFrom.Text == " ")
            {
                errProvider.SetError(dpDateFrom, "Molimo unesite važenja od !");
                return false;
            }
            else
            {
                errProvider.SetError(dpDateFrom, null);
                return true;
            }
        }

        bool validateOrderDateTo()
        {
            if (dpDateTo.Text == " ")
            {
                errProvider.SetError(dpDateTo, "Molimo unesite važenja do !");
                return false;
            }
            else
            {
                errProvider.SetError(dpDateTo, null);
                return true;
            }
        }

        bool validatePeriod()
        {

            if (dpDateTo.Value < dpDateFrom.Value)
            {
                errProvider.SetError(dpDateTo, "Molimo unesite validan period !");
                return false;
            }

            else
            {
                errProvider.SetError(dpDateTo, null);
                return true;
            }
        }

        bool validateDiscount()
        {
            if (string.IsNullOrWhiteSpace(txtDiscount.Text))
            {
                errProvider.SetError(txtDiscount, Properties.Resources.Validate_Input);
                return false;
            }
            else
            {
                errProvider.SetError(txtDiscount, null);
                return true;
            }
        }

        bool validateProduct()
        {
            if (string.IsNullOrWhiteSpace(txtProductCode.Text))
            {
                errProvider.SetError(txtProductCode, Properties.Resources.Validate_Input);
                return false;
            }
            else
            {
                errProvider.SetError(txtProductCode, null);
                return true;
            }
        }

        bool validateProductList()
        {
            if (orderList.Count == 0)
            {
                errProvider.SetError(gbAddProduct, "Molimo dodajte proizvod u listu !");
                return false;
            }
            else
            {
                errProvider.SetError(gbAddProduct, null);
                return true;
            }
        }


        
    }
}
