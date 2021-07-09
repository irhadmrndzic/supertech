namespace superTech.WinUI.SupplierOrder
{
    partial class frmOrders
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
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Confirmed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Search = new System.Windows.Forms.GroupBox();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lblNoOrders = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFilterOrder = new System.Windows.Forms.Button();
            this.dpOrder = new System.Windows.Forms.DateTimePicker();
            this.Edit = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.cbConfirmOrder = new System.Windows.Forms.CheckBox();
            this.btnOrderItems = new System.Windows.Forms.Button();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrderNumberSearch = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.Search.SuspendLayout();
            this.Edit.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToResizeColumns = false;
            this.dgvOrders.AllowUserToResizeRows = false;
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderId,
            this.OrderNumber,
            this.Date,
            this.Amount,
            this.UserString,
            this.SupplierString,
            this.Active,
            this.Confirmed});
            this.dgvOrders.Location = new System.Drawing.Point(988, 12);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 62;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1292, 1262);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOrders_CellFormatting);
            this.dgvOrders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvOrders_MouseDoubleClick);
            // 
            // OrderId
            // 
            this.OrderId.DataPropertyName = "OrderId";
            this.OrderId.HeaderText = "OrderId";
            this.OrderId.MinimumWidth = 8;
            this.OrderId.Name = "OrderId";
            this.OrderId.Visible = false;
            this.OrderId.Width = 150;
            // 
            // OrderNumber
            // 
            this.OrderNumber.DataPropertyName = "OrderNumber";
            this.OrderNumber.HeaderText = "Broj narudžbe";
            this.OrderNumber.MinimumWidth = 8;
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.Width = 150;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Datum";
            this.Date.MinimumWidth = 8;
            this.Date.Name = "Date";
            this.Date.Width = 150;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Iznos";
            this.Amount.MinimumWidth = 8;
            this.Amount.Name = "Amount";
            this.Amount.Width = 150;
            // 
            // UserString
            // 
            this.UserString.DataPropertyName = "UserString";
            this.UserString.HeaderText = "Zaposlenik";
            this.UserString.MinimumWidth = 8;
            this.UserString.Name = "UserString";
            this.UserString.Width = 150;
            // 
            // SupplierString
            // 
            this.SupplierString.DataPropertyName = "SupplierString";
            this.SupplierString.HeaderText = "Dobavljač";
            this.SupplierString.MinimumWidth = 8;
            this.SupplierString.Name = "SupplierString";
            this.SupplierString.Width = 150;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Aktivna";
            this.Active.MinimumWidth = 8;
            this.Active.Name = "Active";
            this.Active.Width = 150;
            // 
            // Confirmed
            // 
            this.Confirmed.DataPropertyName = "Confirmed";
            this.Confirmed.HeaderText = "Potvrđena";
            this.Confirmed.MinimumWidth = 8;
            this.Confirmed.Name = "Confirmed";
            this.Confirmed.Width = 150;
            // 
            // Search
            // 
            this.Search.Controls.Add(this.txtOrderNumberSearch);
            this.Search.Controls.Add(this.btnShowAll);
            this.Search.Controls.Add(this.lblNoOrders);
            this.Search.Controls.Add(this.label2);
            this.Search.Controls.Add(this.btnFilterOrder);
            this.Search.Controls.Add(this.dpOrder);
            this.Search.Location = new System.Drawing.Point(13, 13);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(753, 192);
            this.Search.TabIndex = 1;
            this.Search.TabStop = false;
            this.Search.Text = "Pretraga";
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(595, 70);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(106, 52);
            this.btnShowAll.TabIndex = 7;
            this.btnShowAll.Text = "Prikaži sve";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // lblNoOrders
            // 
            this.lblNoOrders.AutoSize = true;
            this.lblNoOrders.Location = new System.Drawing.Point(397, 138);
            this.lblNoOrders.Name = "lblNoOrders";
            this.lblNoOrders.Size = new System.Drawing.Size(0, 20);
            this.lblNoOrders.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Broj narudžbe";
            // 
            // btnFilterOrder
            // 
            this.btnFilterOrder.Location = new System.Drawing.Point(416, 70);
            this.btnFilterOrder.Name = "btnFilterOrder";
            this.btnFilterOrder.Size = new System.Drawing.Size(106, 52);
            this.btnFilterOrder.TabIndex = 1;
            this.btnFilterOrder.Text = "Filtriraj";
            this.btnFilterOrder.UseVisualStyleBackColor = true;
            this.btnFilterOrder.Click += new System.EventHandler(this.btnFilterOrder_Click);
            // 
            // dpOrder
            // 
            this.dpOrder.Location = new System.Drawing.Point(7, 42);
            this.dpOrder.Name = "dpOrder";
            this.dpOrder.Size = new System.Drawing.Size(338, 26);
            this.dpOrder.TabIndex = 0;
            this.dpOrder.ValueChanged += new System.EventHandler(this.dpOrder_ValueChanged);
            // 
            // Edit
            // 
            this.Edit.Controls.Add(this.btnSave);
            this.Edit.Controls.Add(this.cbActive);
            this.Edit.Controls.Add(this.cbConfirmOrder);
            this.Edit.Location = new System.Drawing.Point(13, 334);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(547, 178);
            this.Edit.TabIndex = 2;
            this.Edit.TabStop = false;
            this.Edit.Text = "Potvrda prijema  robe";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(416, 76);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 52);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Sačuvaj";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbActive
            // 
            this.cbActive.AutoCheck = false;
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(7, 104);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(87, 24);
            this.cbActive.TabIndex = 1;
            this.cbActive.Text = "Aktivna";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // cbConfirmOrder
            // 
            this.cbConfirmOrder.AutoSize = true;
            this.cbConfirmOrder.Location = new System.Drawing.Point(7, 48);
            this.cbConfirmOrder.Name = "cbConfirmOrder";
            this.cbConfirmOrder.Size = new System.Drawing.Size(107, 24);
            this.cbConfirmOrder.TabIndex = 0;
            this.cbConfirmOrder.Text = "Potrvđena";
            this.cbConfirmOrder.UseVisualStyleBackColor = true;
            // 
            // btnOrderItems
            // 
            this.btnOrderItems.Location = new System.Drawing.Point(429, 268);
            this.btnOrderItems.Name = "btnOrderItems";
            this.btnOrderItems.Size = new System.Drawing.Size(106, 45);
            this.btnOrderItems.TabIndex = 4;
            this.btnOrderItems.Text = "Artikli";
            this.btnOrderItems.UseVisualStyleBackColor = true;
            this.btnOrderItems.Click += new System.EventHandler(this.btnOrderItems_Click);
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(16, 277);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.ReadOnly = true;
            this.txtOrderNumber.Size = new System.Drawing.Size(338, 26);
            this.txtOrderNumber.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Broj narudžbe";
            // 
            // txtOrderNumberSearch
            // 
            this.txtOrderNumberSearch.Location = new System.Drawing.Point(7, 138);
            this.txtOrderNumberSearch.Mask = "0000000000";
            this.txtOrderNumberSearch.Name = "txtOrderNumberSearch";
            this.txtOrderNumberSearch.Size = new System.Drawing.Size(338, 26);
            this.txtOrderNumberSearch.TabIndex = 5;
            // 
            // frmOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2292, 1286);
            this.Controls.Add(this.btnOrderItems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOrderNumber);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.dgvOrders);
            this.Name = "frmOrders";
            this.Text = "Narudžbe";
            this.Load += new System.EventHandler(this.frmOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.Search.ResumeLayout(false);
            this.Search.PerformLayout();
            this.Edit.ResumeLayout(false);
            this.Edit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.GroupBox Search;
        private System.Windows.Forms.Button btnFilterOrder;
        private System.Windows.Forms.DateTimePicker dpOrder;
        private System.Windows.Forms.GroupBox Edit;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.CheckBox cbConfirmOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserString;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierString;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn Confirmed;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOrderItems;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNoOrders;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.MaskedTextBox txtOrderNumberSearch;
    }
}