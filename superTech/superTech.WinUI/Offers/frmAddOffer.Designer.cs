
namespace superTech.WinUI.Offers
{
    partial class frmAddOffer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dpDateTo = new System.Windows.Forms.DateTimePicker();
            this.gbAddProduct = new System.Windows.Forms.GroupBox();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.txtPriceDiscount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.MaskedTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtUnitOfMeasure = new System.Windows.Forms.TextBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.groupSearch = new System.Windows.Forms.GroupBox();
            this.lblNoProducts = new System.Windows.Forms.Label();
            this.btnShowProducts = new System.Windows.Forms.Button();
            this.cmbProductCategories = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProductCodeSearch = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Popust = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitOfMeasure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProductOrder = new System.Windows.Forms.DataGridView();
            this.SelectedProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectedProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectedProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectedProductQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbAddProduct.SuspendLayout();
            this.groupSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naslov";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(12, 68);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(721, 26);
            this.txtTitle.TabIndex = 1;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(17, 157);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(724, 297);
            this.txtDesc.TabIndex = 2;
            this.txtDesc.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Opis";
            // 
            // dpDateFrom
            // 
            this.dpDateFrom.Location = new System.Drawing.Point(17, 531);
            this.dpDateFrom.Name = "dpDateFrom";
            this.dpDateFrom.Size = new System.Drawing.Size(378, 26);
            this.dpDateFrom.TabIndex = 4;
            this.dpDateFrom.ValueChanged += new System.EventHandler(this.dpDateFrom_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 494);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Datum važenja od";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 583);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Datum važenja do";
            // 
            // dpDateTo
            // 
            this.dpDateTo.Location = new System.Drawing.Point(17, 620);
            this.dpDateTo.Name = "dpDateTo";
            this.dpDateTo.Size = new System.Drawing.Size(378, 26);
            this.dpDateTo.TabIndex = 5;
            this.dpDateTo.ValueChanged += new System.EventHandler(this.dpDateTo_ValueChanged);
            // 
            // gbAddProduct
            // 
            this.gbAddProduct.Controls.Add(this.btnAddOrder);
            this.gbAddProduct.Controls.Add(this.btnRemoveProduct);
            this.gbAddProduct.Controls.Add(this.txtPriceDiscount);
            this.gbAddProduct.Controls.Add(this.label5);
            this.gbAddProduct.Controls.Add(this.txtDiscount);
            this.gbAddProduct.Controls.Add(this.label18);
            this.gbAddProduct.Controls.Add(this.txtUnitOfMeasure);
            this.gbAddProduct.Controls.Add(this.btnAddProduct);
            this.gbAddProduct.Controls.Add(this.groupSearch);
            this.gbAddProduct.Controls.Add(this.txtPrice);
            this.gbAddProduct.Controls.Add(this.label10);
            this.gbAddProduct.Controls.Add(this.Popust);
            this.gbAddProduct.Controls.Add(this.txtProductCode);
            this.gbAddProduct.Controls.Add(this.label8);
            this.gbAddProduct.Location = new System.Drawing.Point(12, 693);
            this.gbAddProduct.Name = "gbAddProduct";
            this.gbAddProduct.Size = new System.Drawing.Size(721, 697);
            this.gbAddProduct.TabIndex = 9;
            this.gbAddProduct.TabStop = false;
            this.gbAddProduct.Text = "Proizvodi";
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(516, 588);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(184, 84);
            this.btnAddOrder.TabIndex = 40;
            this.btnAddOrder.Text = "Zaključi";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.BackColor = System.Drawing.Color.IndianRed;
            this.btnRemoveProduct.Location = new System.Drawing.Point(545, 302);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(137, 54);
            this.btnRemoveProduct.TabIndex = 37;
            this.btnRemoveProduct.Text = "Ukloni proizvod";
            this.btnRemoveProduct.UseVisualStyleBackColor = false;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // txtPriceDiscount
            // 
            this.txtPriceDiscount.Location = new System.Drawing.Point(11, 434);
            this.txtPriceDiscount.Name = "txtPriceDiscount";
            this.txtPriceDiscount.ReadOnly = true;
            this.txtPriceDiscount.Size = new System.Drawing.Size(281, 26);
            this.txtPriceDiscount.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 20);
            this.label5.TabIndex = 38;
            this.label5.Text = "Cijena s popustom";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(348, 354);
            this.txtDiscount.Mask = "000000";
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(134, 26);
            this.txtDiscount.TabIndex = 37;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(344, 245);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(110, 20);
            this.label18.TabIndex = 36;
            this.label18.Text = "Jedinica mjere";
            // 
            // txtUnitOfMeasure
            // 
            this.txtUnitOfMeasure.Location = new System.Drawing.Point(344, 280);
            this.txtUnitOfMeasure.Name = "txtUnitOfMeasure";
            this.txtUnitOfMeasure.ReadOnly = true;
            this.txtUnitOfMeasure.Size = new System.Drawing.Size(138, 26);
            this.txtUnitOfMeasure.TabIndex = 35;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(344, 423);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(202, 49);
            this.btnAddProduct.TabIndex = 34;
            this.btnAddProduct.Text = "Dodaj na listu";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // groupSearch
            // 
            this.groupSearch.Controls.Add(this.lblNoProducts);
            this.groupSearch.Controls.Add(this.btnShowProducts);
            this.groupSearch.Controls.Add(this.cmbProductCategories);
            this.groupSearch.Controls.Add(this.label11);
            this.groupSearch.Controls.Add(this.txtProductCodeSearch);
            this.groupSearch.Controls.Add(this.label13);
            this.groupSearch.Location = new System.Drawing.Point(10, 48);
            this.groupSearch.Name = "groupSearch";
            this.groupSearch.Size = new System.Drawing.Size(672, 180);
            this.groupSearch.TabIndex = 34;
            this.groupSearch.TabStop = false;
            this.groupSearch.Text = "Pretraga";
            // 
            // lblNoProducts
            // 
            this.lblNoProducts.AutoSize = true;
            this.lblNoProducts.Location = new System.Drawing.Point(418, 56);
            this.lblNoProducts.Name = "lblNoProducts";
            this.lblNoProducts.Size = new System.Drawing.Size(0, 20);
            this.lblNoProducts.TabIndex = 32;
            // 
            // btnShowProducts
            // 
            this.btnShowProducts.Location = new System.Drawing.Point(424, 70);
            this.btnShowProducts.Name = "btnShowProducts";
            this.btnShowProducts.Size = new System.Drawing.Size(202, 49);
            this.btnShowProducts.TabIndex = 33;
            this.btnShowProducts.Text = "Prikazi";
            this.btnShowProducts.UseVisualStyleBackColor = true;
            this.btnShowProducts.Click += new System.EventHandler(this.btnShowProducts_Click);
            // 
            // cmbProductCategories
            // 
            this.cmbProductCategories.FormattingEnabled = true;
            this.cmbProductCategories.Location = new System.Drawing.Point(10, 132);
            this.cmbProductCategories.Name = "cmbProductCategories";
            this.cmbProductCategories.Size = new System.Drawing.Size(363, 28);
            this.cmbProductCategories.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 20);
            this.label11.TabIndex = 3;
            this.label11.Text = "Šifra";
            // 
            // txtProductCodeSearch
            // 
            this.txtProductCodeSearch.Location = new System.Drawing.Point(11, 56);
            this.txtProductCodeSearch.Name = "txtProductCodeSearch";
            this.txtProductCodeSearch.Size = new System.Drawing.Size(362, 26);
            this.txtProductCodeSearch.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 20);
            this.label13.TabIndex = 31;
            this.label13.Text = "Kategorija:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(11, 354);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(281, 26);
            this.txtPrice.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 319);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 20);
            this.label10.TabIndex = 13;
            this.label10.Text = "Cijena";
            // 
            // Popust
            // 
            this.Popust.AutoSize = true;
            this.Popust.Location = new System.Drawing.Point(344, 319);
            this.Popust.Name = "Popust";
            this.Popust.Size = new System.Drawing.Size(72, 20);
            this.Popust.TabIndex = 11;
            this.Popust.Text = "Discount";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(11, 280);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            this.txtProductCode.Size = new System.Drawing.Size(281, 26);
            this.txtProductCode.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Šifra";
            // 
            // dgvProducts
            // 
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.ProductName,
            this.Code,
            this.Price,
            this.Category,
            this.UnitOfMeasure,
            this.Inventory,
            this.ProductDescription});
            this.dgvProducts.Location = new System.Drawing.Point(848, 68);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersWidth = 62;
            this.dgvProducts.RowTemplate.Height = 28;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(1130, 578);
            this.dgvProducts.TabIndex = 9;
            this.dgvProducts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvProducts_MouseDoubleClick);
            // 
            // ProductId
            // 
            this.ProductId.DataPropertyName = "ProductId";
            this.ProductId.HeaderText = "ProductId";
            this.ProductId.MinimumWidth = 8;
            this.ProductId.Name = "ProductId";
            this.ProductId.Visible = false;
            this.ProductId.Width = 150;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "Name";
            this.ProductName.HeaderText = "Naziv";
            this.ProductName.MinimumWidth = 8;
            this.ProductName.Name = "ProductName";
            this.ProductName.Width = 150;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Šifra";
            this.Code.MinimumWidth = 8;
            this.Code.Name = "Code";
            this.Code.Width = 150;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Cijena";
            this.Price.MinimumWidth = 8;
            this.Price.Name = "Price";
            this.Price.Width = 150;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "CategoryString";
            this.Category.HeaderText = "Kategorija";
            this.Category.MinimumWidth = 8;
            this.Category.Name = "Category";
            this.Category.Width = 150;
            // 
            // UnitOfMeasure
            // 
            this.UnitOfMeasure.DataPropertyName = "FkUnitOfMeasureString";
            this.UnitOfMeasure.HeaderText = "Jedinica mjere";
            this.UnitOfMeasure.MinimumWidth = 8;
            this.UnitOfMeasure.Name = "UnitOfMeasure";
            this.UnitOfMeasure.Width = 150;
            // 
            // Inventory
            // 
            this.Inventory.DataPropertyName = "Inventory";
            this.Inventory.HeaderText = "Stanje na skladištu";
            this.Inventory.MinimumWidth = 8;
            this.Inventory.Name = "Inventory";
            this.Inventory.Width = 150;
            // 
            // ProductDescription
            // 
            this.ProductDescription.DataPropertyName = "Description";
            this.ProductDescription.HeaderText = "Opis";
            this.ProductDescription.MinimumWidth = 8;
            this.ProductDescription.Name = "ProductDescription";
            this.ProductDescription.Width = 150;
            // 
            // dgvProductOrder
            // 
            this.dgvProductOrder.AllowUserToAddRows = false;
            this.dgvProductOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductOrder.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvProductOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectedProductId,
            this.ProductIndex,
            this.SelectedProductName,
            this.SelectedProductPrice,
            this.SelectedProductQuantity,
            this.PriceDiscount});
            this.dgvProductOrder.Location = new System.Drawing.Point(848, 696);
            this.dgvProductOrder.Name = "dgvProductOrder";
            this.dgvProductOrder.RowHeadersWidth = 62;
            this.dgvProductOrder.RowTemplate.Height = 28;
            this.dgvProductOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductOrder.Size = new System.Drawing.Size(1130, 578);
            this.dgvProductOrder.TabIndex = 16;
            // 
            // SelectedProductId
            // 
            this.SelectedProductId.DataPropertyName = "ProductId";
            this.SelectedProductId.HeaderText = "ProductId";
            this.SelectedProductId.MinimumWidth = 8;
            this.SelectedProductId.Name = "SelectedProductId";
            this.SelectedProductId.Visible = false;
            this.SelectedProductId.Width = 150;
            // 
            // ProductIndex
            // 
            this.ProductIndex.HeaderText = "Redni broj";
            this.ProductIndex.MinimumWidth = 8;
            this.ProductIndex.Name = "ProductIndex";
            this.ProductIndex.Width = 150;
            // 
            // SelectedProductName
            // 
            this.SelectedProductName.DataPropertyName = "Name";
            this.SelectedProductName.HeaderText = "Naziv";
            this.SelectedProductName.MinimumWidth = 8;
            this.SelectedProductName.Name = "SelectedProductName";
            this.SelectedProductName.Width = 150;
            // 
            // SelectedProductPrice
            // 
            this.SelectedProductPrice.DataPropertyName = "Price";
            this.SelectedProductPrice.HeaderText = "Cijena";
            this.SelectedProductPrice.MinimumWidth = 8;
            this.SelectedProductPrice.Name = "SelectedProductPrice";
            this.SelectedProductPrice.Width = 150;
            // 
            // SelectedProductQuantity
            // 
            this.SelectedProductQuantity.DataPropertyName = "Discount";
            this.SelectedProductQuantity.HeaderText = "Popust";
            this.SelectedProductQuantity.MinimumWidth = 8;
            this.SelectedProductQuantity.Name = "SelectedProductQuantity";
            this.SelectedProductQuantity.Width = 150;
            // 
            // PriceDiscount
            // 
            this.PriceDiscount.DataPropertyName = "PriceWithDiscount";
            this.PriceDiscount.HeaderText = "Cijena s popustom";
            this.PriceDiscount.MinimumWidth = 8;
            this.PriceDiscount.Name = "PriceDiscount";
            this.PriceDiscount.Width = 150;
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // frmAddOffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1990, 1729);
            this.Controls.Add(this.dgvProductOrder);
            this.Controls.Add(this.gbAddProduct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dpDateTo);
            this.Controls.Add(this.dpDateFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProducts);
            this.Name = "frmAddOffer";
            this.Text = "frmAddOffer";
            this.Load += new System.EventHandler(this.frmAddOffer_Load);
            this.gbAddProduct.ResumeLayout(false);
            this.gbAddProduct.PerformLayout();
            this.groupSearch.ResumeLayout(false);
            this.groupSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.RichTextBox txtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpDateFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dpDateTo;
        private System.Windows.Forms.GroupBox gbAddProduct;
        private System.Windows.Forms.MaskedTextBox txtDiscount;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtUnitOfMeasure;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.GroupBox groupSearch;
        private System.Windows.Forms.Label lblNoProducts;
        private System.Windows.Forms.Button btnShowProducts;
        private System.Windows.Forms.ComboBox cmbProductCategories;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProductCodeSearch;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label Popust;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitOfMeasure;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductDescription;
        private System.Windows.Forms.TextBox txtPriceDiscount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvProductOrder;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectedProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectedProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectedProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectedProductQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceDiscount;
    }
}