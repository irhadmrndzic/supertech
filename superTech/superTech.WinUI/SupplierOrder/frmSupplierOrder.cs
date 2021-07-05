﻿using superTech.Models.Category;
using superTech.Models.Product;
using superTech.Models.Suppliers;
using superTech.WinUI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace superTech.WinUI.SupplierOrder
{
    public partial class frmSupplierOrder : Form
    {
        private readonly APIService.APIService _suppliersService = new APIService.APIService("suppliers");
        private readonly APIService.APIService _productsService = new APIService.APIService("products");
        private readonly APIService.APIService _categoriesService = new APIService.APIService("categories");
        public int? _supplierId = null;
        public int? _productId = null;
        public frmSupplierOrder()
        {
            InitializeComponent();
            this.AutoScroll = true;

        }

        private async void frmSupplierOrder_Load(object sender, EventArgs e)
        {
            dgvSuppliers.AutoGenerateColumns = false;
            dgvProductOrder.AutoGenerateColumns = false;

            cmbProductCategories.SelectedValue = 0;
            lblNoSuppliers.Hide();
            LoadSuppliers();

            //await loadUnitsOfMeasures();
            await loadCategories();
            await loadProducts(0);

        }

        public async void LoadSuppliers()
        {
            try
            {
                var suppliers = await _suppliersService.Get<List<SuppliersModel>>(null);
                dgvSuppliers.DataSource = suppliers;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Dobavljači", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dgvSuppliers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _supplierId = (int)dgvSuppliers.SelectedRows[0].Cells[0].Value;

            var request = await _suppliersService.GetById<SuppliersModel>(_supplierId);

            txtSupplierName.Text = request.Name;
            txtSupplierEmail.Text = request.Email;
            txtSupplierBankAcc.Text = request.BankAccount;
            txtSupplierWebAddress.Text = request.WebAddress;
            txtSupplierPhone.Text = request.PhoneNumber;
            txtSupplierDesc.Text = request.Description;
        }

        private void btnShowSuppliers_Click(object sender, EventArgs e)
        {
            filterSuppliers();
        }

        public async void filterSuppliers()
        {
            lblNoSuppliers.Hide();
            SuppliersSearchRequest request = new SuppliersSearchRequest();
            request.Name = txtSupplierSearch.Text;

            try
            {
                var suppliers = await _suppliersService.Get<List<SuppliersModel>>(request);

                dgvSuppliers.DataSource = suppliers;

                if (suppliers.Count == 0)
                {
                    lblNoSuppliers.Text = "Nema pronađenih dobavljača ! ";
                    lblNoSuppliers.Show();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Dobavljači", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bntClearSuppliers_Click(object sender, EventArgs e)
        {
            clearSuppliers();
        }

        void clearSuppliers()
        {
            _supplierId = null;
            txtSupplierSearch.Text = "";
            FormReset.ResetAllControls(this);
        }


        private async Task loadProducts(int? categoryId)
        {
            try
            {
                var products = await _productsService.Get<List<ProductModel>>(new ProductsSearchRequest()
                {
                    Name = txtProductNameSearch.Text,
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
                MessageBox.Show(exception.Message, "Categories", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            onProductClicked();

        }

        ProductModel selectedProduct = new ProductModel();
        ProductModel entity = new ProductModel();
        List<ProductModel> orderList = new List<ProductModel>();

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

            //var castedUOMs = cmbUom.Items.Cast<UnitsOfMeasuresModel>().Select(x => x.UnitOfMeasureId).ToList();

            //for (int i = 0; i < castedUOMs.Count; i++)
            //{
            //    if (castedUOMs[i] == entity.UnitOfMeasureId)
            //    {
            //        cmbUom.SelectedIndex = i;
            //    }
            //}

            txtProductCode.Text = entity.Code;
            txtPrice.Text = entity.Price.ToString();
            selectedProduct = entity;

  

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (orderList.Count == 0)
            {
                selectedProduct.Quantity = int.Parse(txtQuantity.Text);
                selectedProduct.Price = decimal.Parse(txtPrice.Text) * int.Parse(txtQuantity.Text);
                orderList.Add(selectedProduct);
                selectedProduct = null;
            }
            else
            {
                foreach (var prod in orderList.ToList())
                {
                    if  (prod.Name == entity.Name)
                    {
                        prod.Quantity += int.Parse(txtQuantity.Text);
                        prod.Price = decimal.Parse(txtPrice.Text) * prod.Quantity;
                    }
                }

                if (!orderList.Where(x => x.Name == entity.Name).Any())
                {
                    selectedProduct.Quantity = int.Parse(txtQuantity.Text);
                    selectedProduct.Price = entity.Price * int.Parse(txtQuantity.Text);
                    orderList.Add(selectedProduct);
                }
            }

            dgvProductOrder.DataSource = orderList.ToList();
            dgvProductOrder.Refresh();
            dgvProductOrder.Update();
            selectedProduct = null;
        }
    }
}
