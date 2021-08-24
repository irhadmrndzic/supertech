
namespace superTech.WinUI.BuyerOrder
{
    partial class frmBuyerOrders
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
            this.dgvBuyerOrders = new System.Windows.Forms.DataGridView();
            this.BuyerOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buyer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Search = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbOrderStatus = new System.Windows.Forms.ComboBox();
            this.btnFilterOrder = new System.Windows.Forms.Button();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.cbProcessed = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuyer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyerOrders)).BeginInit();
            this.Search.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBuyerOrders
            // 
            this.dgvBuyerOrders.AllowUserToAddRows = false;
            this.dgvBuyerOrders.AllowUserToDeleteRows = false;
            this.dgvBuyerOrders.AllowUserToResizeColumns = false;
            this.dgvBuyerOrders.AllowUserToResizeRows = false;
            this.dgvBuyerOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBuyerOrders.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBuyerOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuyerOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BuyerOrderId,
            this.OrderNumber,
            this.OrderDate,
            this.Buyer,
            this.Amount,
            this.Active});
            this.dgvBuyerOrders.Location = new System.Drawing.Point(543, 12);
            this.dgvBuyerOrders.Name = "dgvBuyerOrders";
            this.dgvBuyerOrders.RowHeadersWidth = 62;
            this.dgvBuyerOrders.RowTemplate.Height = 28;
            this.dgvBuyerOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBuyerOrders.Size = new System.Drawing.Size(1577, 1227);
            this.dgvBuyerOrders.TabIndex = 0;
            this.dgvBuyerOrders.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBuyerOrders_CellFormatting);
            this.dgvBuyerOrders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvBuyerOrders_MouseDoubleClick);
            // 
            // BuyerOrderId
            // 
            this.BuyerOrderId.DataPropertyName = "BuyerOrderId";
            this.BuyerOrderId.HeaderText = "BuyerOrderId";
            this.BuyerOrderId.MinimumWidth = 8;
            this.BuyerOrderId.Name = "BuyerOrderId";
            this.BuyerOrderId.Visible = false;
            this.BuyerOrderId.Width = 150;
            // 
            // OrderNumber
            // 
            this.OrderNumber.DataPropertyName = "OrderNumber";
            this.OrderNumber.HeaderText = "Broj narudžbe";
            this.OrderNumber.MinimumWidth = 8;
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.Width = 150;
            // 
            // OrderDate
            // 
            this.OrderDate.DataPropertyName = "Date";
            this.OrderDate.HeaderText = "Datum narudžbe ";
            this.OrderDate.MinimumWidth = 8;
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.Width = 150;
            // 
            // Buyer
            // 
            this.Buyer.DataPropertyName = "UserString";
            this.Buyer.HeaderText = "Kupac";
            this.Buyer.MinimumWidth = 8;
            this.Buyer.Name = "Buyer";
            this.Buyer.Width = 150;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Iznos";
            this.Amount.MinimumWidth = 8;
            this.Amount.Name = "Amount";
            this.Amount.Width = 150;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Procesirana";
            this.Active.MinimumWidth = 8;
            this.Active.Name = "Active";
            this.Active.Width = 150;
            // 
            // Search
            // 
            this.Search.Controls.Add(this.label2);
            this.Search.Controls.Add(this.cbOrderStatus);
            this.Search.Controls.Add(this.btnFilterOrder);
            this.Search.Location = new System.Drawing.Point(12, 12);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(460, 192);
            this.Search.TabIndex = 2;
            this.Search.TabStop = false;
            this.Search.Text = "Pretraga";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Status";
            // 
            // cbOrderStatus
            // 
            this.cbOrderStatus.FormattingEnabled = true;
            this.cbOrderStatus.Location = new System.Drawing.Point(30, 95);
            this.cbOrderStatus.Name = "cbOrderStatus";
            this.cbOrderStatus.Size = new System.Drawing.Size(233, 28);
            this.cbOrderStatus.TabIndex = 7;
            // 
            // btnFilterOrder
            // 
            this.btnFilterOrder.Location = new System.Drawing.Point(328, 82);
            this.btnFilterOrder.Name = "btnFilterOrder";
            this.btnFilterOrder.Size = new System.Drawing.Size(106, 52);
            this.btnFilterOrder.TabIndex = 1;
            this.btnFilterOrder.Text = "Filtriraj";
            this.btnFilterOrder.UseVisualStyleBackColor = true;
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.cbProcessed);
            this.gbInfo.Controls.Add(this.label5);
            this.gbInfo.Controls.Add(this.txtAmount);
            this.gbInfo.Controls.Add(this.label4);
            this.gbInfo.Controls.Add(this.txtBuyer);
            this.gbInfo.Controls.Add(this.label3);
            this.gbInfo.Controls.Add(this.txtDate);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.Controls.Add(this.txtOrderNumber);
            this.gbInfo.Location = new System.Drawing.Point(12, 236);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(460, 583);
            this.gbInfo.TabIndex = 3;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Informacije";
            // 
            // cbProcessed
            // 
            this.cbProcessed.AutoCheck = false;
            this.cbProcessed.AutoSize = true;
            this.cbProcessed.Location = new System.Drawing.Point(6, 403);
            this.cbProcessed.Name = "cbProcessed";
            this.cbProcessed.Size = new System.Drawing.Size(119, 24);
            this.cbProcessed.TabIndex = 13;
            this.cbProcessed.Text = "Procesirana";
            this.cbProcessed.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Iznos";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(6, 340);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(417, 26);
            this.txtAmount.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Kupac";
            // 
            // txtBuyer
            // 
            this.txtBuyer.Location = new System.Drawing.Point(6, 252);
            this.txtBuyer.Name = "txtBuyer";
            this.txtBuyer.ReadOnly = true;
            this.txtBuyer.Size = new System.Drawing.Size(417, 26);
            this.txtBuyer.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Datum";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(6, 164);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(417, 26);
            this.txtDate.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Broj narudžbe";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(6, 80);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.ReadOnly = true;
            this.txtOrderNumber.Size = new System.Drawing.Size(417, 26);
            this.txtOrderNumber.TabIndex = 5;
            // 
            // frmBuyerOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2132, 1251);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.dgvBuyerOrders);
            this.Name = "frmBuyerOrders";
            this.Text = "Narudžbe";
            this.Load += new System.EventHandler(this.frmBuyerOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyerOrders)).EndInit();
            this.Search.ResumeLayout(false);
            this.Search.PerformLayout();
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBuyerOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyerOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Buyer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
        private System.Windows.Forms.GroupBox Search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbOrderStatus;
        private System.Windows.Forms.Button btnFilterOrder;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.CheckBox cbProcessed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBuyer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrderNumber;
    }
}