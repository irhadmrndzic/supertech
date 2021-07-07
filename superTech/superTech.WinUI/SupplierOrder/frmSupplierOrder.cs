using superTech.Models.Category;
using superTech.Models.Orders;
using superTech.Models.Orders.OrderItems;
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
        private readonly APIService.APIService _orderService = new APIService.APIService("orders");
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

            dpOrderDate.CustomFormat = " ";
            dpOrderDate.Format = DateTimePickerFormat.Custom;

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
                SuppliersSearchRequest suppliersSearchRequest = new SuppliersSearchRequest();
                suppliersSearchRequest.Name = txtSupplierSearch.Text;
                var suppliers = await _suppliersService.Get<List<SuppliersModel>>(suppliersSearchRequest);
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

            try
            {
                var request = await _suppliersService.GetById<SuppliersModel>(_supplierId);

                txtSupplierName.Text = request.Name;
                txtSupplierEmail.Text = request.Email;
                txtSupplierBankAcc.Text = request.BankAccount;
                txtSupplierWebAddress.Text = request.WebAddress;
                txtSupplierPhone.Text = request.PhoneNumber;
                txtSupplierDesc.Text = request.Description;

                errProvider.Clear();
                errProvider.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Dobavljači", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

            txtUnitOfMeasure.Text = entity.FkUnitOfMeasureString;
            txtProductCode.Text = entity.Code;
            txtPrice.Text = entity.Price.ToString();
            txtUnitOfMeasure.Text = entity.FkUnitOfMeasureString;
            selectedProduct = entity;



        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {

            if (validateProductForm())
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
                        if (prod.Name == entity.Name)
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

             
                txtBillAmount.Text = getSum(dgvProductOrder).ToString();

                selectedProduct = null;

                setRowNumber(dgvProductOrder);

            }
        }

        private decimal getSum(DataGridView dgv)
        {
            decimal sum = 0;
            for (int i = 0; i < dgv.Rows.Count; ++i)
            {
                sum += Convert.ToDecimal(dgvProductOrder.Rows[i].Cells[3].Value);
            }
            return sum;
        }
        private void setRowNumber(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells[1].Value = (i + 1).ToString();
            }
        }


        bool validateProductCode()
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


        bool validateProductPrice()
        {

            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                errProvider.SetError(txtPrice, Properties.Resources.Validate_Input);
                return false;
            }
            else
            {
                errProvider.SetError(txtPrice, null);
                return true;
            }
        }

        bool validateProductUom()
        {

            if (string.IsNullOrWhiteSpace(txtUnitOfMeasure.Text))
            {
                errProvider.SetError(txtUnitOfMeasure, Properties.Resources.Validate_Input);
                return false;
            }
            else
            {
                errProvider.SetError(txtUnitOfMeasure, null);
                return true;
            }
        }

        bool validateProductQuantity()
        {
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                errProvider.SetError(txtQuantity, Properties.Resources.Validate_Input);
                return false;
            }
            else
            {
                errProvider.SetError(txtQuantity, null);
                return true;
            }
        }

        bool validateProductForm()
        {
            if (!validateProductQuantity() || !validateProductCode() || !validateProductPrice() || !validateProductUom())
                return false;
            return true;
        }

        bool validateSupplierName()
        {
            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                errProvider.SetError(txtSupplierName, Properties.Resources.Validate_Input);
                return false;
            }
            else
            {
                errProvider.SetError(txtSupplierName, null);
                return true;
            }
        }

        bool validateSupplierForm()
        {
            if (!validateSupplierName())
                return false;
            return true;
        }

        bool validateOrderNumber()
        {
            if (string.IsNullOrEmpty(txtOrderNumber.Text))
            {
                errProvider.SetError(txtOrderNumber, Properties.Resources.Validate_Input);
                return false;
            }
            else if (txtOrderNumber.Text.Length > 10)
            {
                errProvider.SetError(txtOrderNumber, "Polje mora sadržavati manje od 10 karaktera ! ");
                return false;
            }
            else
            {
                errProvider.SetError(txtOrderNumber, null);
                return true;
            }
        }

        private void dpOrderDate_ValueChanged(object sender, EventArgs e)
        {
            dpOrderDate.CustomFormat = "dd/MM/yyyy";

        }

        bool validateOrderDate()
        {
            if (dpOrderDate.Text == " ")
            {
                errProvider.SetError(dpOrderDate, "Molimo unesite datum objave !");
                return false;
            }
            else
            {
                errProvider.SetError(dpOrderDate, null);
                return true;
            }
        }

        bool validateOrderForm()
        {
            if (!validateOrderNumber() || !validateOrderDate())
                return false;
            return true;
        }


        private async void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (validateSupplierForm() && validateProductForm() && validateOrderForm() && orderList.Count > 0)
            {
                try
                {
                    string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    OrdersUpsertRequest order = new OrdersUpsertRequest();
                    int amount = 0;
                    for (int i = 0; i < dgvProductOrder.Rows.Count; ++i)
                    {
                        amount += Convert.ToInt32(dgvProductOrder.Rows[i].Cells[3].Value);
                    }
                    order.Amount = amount;
                    order.Date = DateTime.Now;
                    order.OrderNumber = int.Parse(txtOrderNumber.Text);
                    order.SupplierId = _supplierId;
                    order.UserId = 47;
                    order.Active = true;

                    order.OrderItems = new List<OrderItemsUpsertRequest>();


                    for (int i = 0; i < orderList.Count; i++)
                    {

                        OrderItemsUpsertRequest oi = new OrderItemsUpsertRequest
                        {
                            FkProductId = _productId,
                            Quantity = (int)dgvProductOrder.Rows[i].Cells[4].Value,
                            Amount = (decimal)dgvProductOrder.Rows[i].Cells[3].Value,
                        };

                        order.OrderItems.Add(oi);
                    }
                    await _orderService.Insert<OrdersModel>(order);
                    MessageBox.Show("Uspješno ste dodali narudžbu !");

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Narudžba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if(orderList.Count == 0)
            {
                MessageBox.Show("Molimo dodajte proizvode u listu !");
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

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            int productIndex;
            frmRemoveProduct frmRemoveProduct = new frmRemoveProduct();
            if (frmRemoveProduct.ShowDialog() == DialogResult.OK)
            {

                productIndex = frmRemoveProduct.productIndex;
                if (productIndex <= orderList.Count)
                {
                    orderList.RemoveAt(productIndex - 1);
                    dgvProductOrder.DataSource = orderList.ToList();
                    setRowNumber(dgvProductOrder);

                    dgvProductOrder.Refresh();
                    dgvProductOrder.Update();

                    txtBillAmount.Text = getSum(dgvProductOrder).ToString();
                }
                else
                {
                    MessageBox.Show("Unesite ispravan redni broj! ");
                }
              
            }

        }
    }
}
