namespace superTech.WinUI.Products
{
    partial class frmProducts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdcutName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitOfMeasure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pbProdImage = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbUom = new System.Windows.Forms.ComboBox();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.imgDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnClear = new System.Windows.Forms.Button();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnShowProducts = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.NumericUpDown();
            this.groupSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblNoProducts = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCodeSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNameSearch = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProdImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).BeginInit();
            this.groupSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.Code,
            this.ProdcutName,
            this.Category,
            this.UnitOfMeasure,
            this.Price,
            this.Description,
            this.Active,
            this.Rating});
            this.dgvProducts.Location = new System.Drawing.Point(839, 0);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersWidth = 62;
            this.dgvProducts.RowTemplate.Height = 28;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(1376, 1115);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProducts_CellFormatting);
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
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Šifra";
            this.Code.MinimumWidth = 8;
            this.Code.Name = "Code";
            this.Code.Width = 150;
            // 
            // ProdcutName
            // 
            this.ProdcutName.DataPropertyName = "Name";
            this.ProdcutName.HeaderText = "Naziv";
            this.ProdcutName.MinimumWidth = 8;
            this.ProdcutName.Name = "ProdcutName";
            this.ProdcutName.Width = 150;
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
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Cijena";
            this.Price.MinimumWidth = 8;
            this.Price.Name = "Price";
            this.Price.Width = 150;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Opis";
            this.Description.MinimumWidth = 8;
            this.Description.Name = "Description";
            this.Description.Width = 150;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Aktivan";
            this.Active.MinimumWidth = 8;
            this.Active.Name = "Active";
            this.Active.Width = 150;
            // 
            // Rating
            // 
            this.Rating.DataPropertyName = "Rating";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "/";
            this.Rating.DefaultCellStyle = dataGridViewCellStyle1;
            this.Rating.HeaderText = "Ocjena";
            this.Rating.MinimumWidth = 8;
            this.Rating.Name = "Rating";
            this.Rating.Width = 150;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(177, 295);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(643, 26);
            this.txtCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Šifra:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(177, 341);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(643, 26);
            this.txtName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Naziv:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(177, 387);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(643, 96);
            this.txtDesc.TabIndex = 7;
            this.txtDesc.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 390);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Opis:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(106, 511);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cijena:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(448, 511);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Jedinica mjere:";
            // 
            // pbProdImage
            // 
            this.pbProdImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbProdImage.Location = new System.Drawing.Point(332, 662);
            this.pbProdImage.Name = "pbProdImage";
            this.pbProdImage.Size = new System.Drawing.Size(488, 248);
            this.pbProdImage.TabIndex = 16;
            this.pbProdImage.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(110, 575);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Slika:";
            // 
            // txtImage
            // 
            this.txtImage.Location = new System.Drawing.Point(177, 564);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(448, 26);
            this.txtImage.TabIndex = 17;
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(642, 559);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(178, 36);
            this.btnAddImage.TabIndex = 19;
            this.btnAddImage.Text = "...";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(576, 966);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(230, 94);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Sačuvaj";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbUom
            // 
            this.cmbUom.FormattingEnabled = true;
            this.cmbUom.Location = new System.Drawing.Point(568, 503);
            this.cmbUom.Name = "cmbUom";
            this.cmbUom.Size = new System.Drawing.Size(252, 28);
            this.cmbUom.TabIndex = 21;
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbActive.Location = new System.Drawing.Point(110, 632);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(87, 24);
            this.cbActive.TabIndex = 23;
            this.cbActive.Text = "Aktivan";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // cmbCategories
            // 
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(177, 247);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(385, 28);
            this.cmbCategories.TabIndex = 26;
            this.cmbCategories.SelectedIndexChanged += new System.EventHandler(this.cmbCategories_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(79, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "Kategorija:";
            // 
            // imgDialog
            // 
            this.imgDialog.FileName = "openFileDialog1";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 966);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(148, 84);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Očisti";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // btnShowProducts
            // 
            this.btnShowProducts.Location = new System.Drawing.Point(618, 236);
            this.btnShowProducts.Name = "btnShowProducts";
            this.btnShowProducts.Size = new System.Drawing.Size(202, 49);
            this.btnShowProducts.TabIndex = 28;
            this.btnShowProducts.Text = "Prikazi";
            this.btnShowProducts.UseVisualStyleBackColor = true;
            this.btnShowProducts.Click += new System.EventHandler(this.btnShowProducts_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.DecimalPlaces = 2;
            this.txtPrice.Location = new System.Drawing.Point(177, 509);
            this.txtPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(265, 26);
            this.txtPrice.TabIndex = 29;
            // 
            // groupSearch
            // 
            this.groupSearch.Controls.Add(this.btnSearch);
            this.groupSearch.Controls.Add(this.lblNoProducts);
            this.groupSearch.Controls.Add(this.label9);
            this.groupSearch.Controls.Add(this.txtCodeSearch);
            this.groupSearch.Controls.Add(this.label1);
            this.groupSearch.Controls.Add(this.txtNameSearch);
            this.groupSearch.Location = new System.Drawing.Point(177, 40);
            this.groupSearch.Name = "groupSearch";
            this.groupSearch.Size = new System.Drawing.Size(643, 177);
            this.groupSearch.TabIndex = 30;
            this.groupSearch.TabStop = false;
            this.groupSearch.Text = "Pretraga";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(435, 64);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(202, 49);
            this.btnSearch.TabIndex = 31;
            this.btnSearch.Text = "Prikazi";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblNoProducts
            // 
            this.lblNoProducts.AutoSize = true;
            this.lblNoProducts.Location = new System.Drawing.Point(414, 135);
            this.lblNoProducts.Name = "lblNoProducts";
            this.lblNoProducts.Size = new System.Drawing.Size(0, 20);
            this.lblNoProducts.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "Šifra";
            // 
            // txtCodeSearch
            // 
            this.txtCodeSearch.Location = new System.Drawing.Point(7, 135);
            this.txtCodeSearch.Name = "txtCodeSearch";
            this.txtCodeSearch.Size = new System.Drawing.Size(362, 26);
            this.txtCodeSearch.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Naziv";
            // 
            // txtNameSearch
            // 
            this.txtNameSearch.Location = new System.Drawing.Point(7, 64);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(362, 26);
            this.txtNameSearch.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.Location = new System.Drawing.Point(332, 966);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(214, 94);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "Obriši";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2215, 1115);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupSearch);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnShowProducts);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.cmbUom);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtImage);
            this.Controls.Add(this.pbProdImage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.dgvProducts);
            this.Name = "frmProducts";
            this.Load += new System.EventHandler(this.frmProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProdImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).EndInit();
            this.groupSearch.ResumeLayout(false);
            this.groupSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pbProdImage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbUom;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog imgDialog;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdcutName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitOfMeasure;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rating;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.Button btnShowProducts;
        private System.Windows.Forms.NumericUpDown txtPrice;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCodeSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNameSearch;
        private System.Windows.Forms.Label lblNoProducts;
        private System.Windows.Forms.Button btnDelete;
    }
}