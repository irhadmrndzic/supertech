
namespace superTech.WinUI.Bills
{
    partial class frmBills
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
            this.dgvBills = new System.Windows.Forms.DataGridView();
            this.BuyerOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buyer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountWithTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAmountWithTax = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cbClosed = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIssuingDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBillNumber = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.GroupBox();
            this.dpDoC = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFilterOrder = new System.Windows.Forms.Button();
            this.btnBillItems = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.gbInfo.SuspendLayout();
            this.Search.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBills
            // 
            this.dgvBills.AllowUserToAddRows = false;
            this.dgvBills.AllowUserToDeleteRows = false;
            this.dgvBills.AllowUserToResizeColumns = false;
            this.dgvBills.AllowUserToResizeRows = false;
            this.dgvBills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBills.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BuyerOrderId,
            this.OrderNumber,
            this.OrderDate,
            this.Buyer,
            this.Amount,
            this.Active,
            this.AmountWithTax});
            this.dgvBills.Location = new System.Drawing.Point(534, 12);
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.RowHeadersWidth = 62;
            this.dgvBills.RowTemplate.Height = 28;
            this.dgvBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBills.Size = new System.Drawing.Size(1586, 1227);
            this.dgvBills.TabIndex = 1;
            this.dgvBills.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvBills_MouseDoubleClick);
            // 
            // BuyerOrderId
            // 
            this.BuyerOrderId.DataPropertyName = "BillId";
            this.BuyerOrderId.HeaderText = "BillId";
            this.BuyerOrderId.MinimumWidth = 8;
            this.BuyerOrderId.Name = "BuyerOrderId";
            this.BuyerOrderId.Visible = false;
            this.BuyerOrderId.Width = 150;
            // 
            // OrderNumber
            // 
            this.OrderNumber.DataPropertyName = "BillNumber";
            this.OrderNumber.HeaderText = "Broj računa";
            this.OrderNumber.MinimumWidth = 8;
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.Width = 150;
            // 
            // OrderDate
            // 
            this.OrderDate.DataPropertyName = "IssuingDate";
            this.OrderDate.HeaderText = "Datum izdavanja";
            this.OrderDate.MinimumWidth = 8;
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.Width = 150;
            // 
            // Buyer
            // 
            this.Buyer.DataPropertyName = "Closed";
            this.Buyer.HeaderText = "Zatvoren";
            this.Buyer.MinimumWidth = 8;
            this.Buyer.Name = "Buyer";
            this.Buyer.Width = 150;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Tax";
            this.Amount.HeaderText = "Porez";
            this.Amount.MinimumWidth = 8;
            this.Amount.Name = "Amount";
            this.Amount.Width = 150;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Amount";
            this.Active.HeaderText = "Iznos";
            this.Active.MinimumWidth = 8;
            this.Active.Name = "Active";
            this.Active.Width = 150;
            // 
            // AmountWithTax
            // 
            this.AmountWithTax.DataPropertyName = "AmountWithTax";
            this.AmountWithTax.HeaderText = "Iznos s porezom";
            this.AmountWithTax.MinimumWidth = 8;
            this.AmountWithTax.Name = "AmountWithTax";
            this.AmountWithTax.Width = 150;
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.btnBillItems);
            this.gbInfo.Controls.Add(this.label7);
            this.gbInfo.Controls.Add(this.txtAmountWithTax);
            this.gbInfo.Controls.Add(this.label6);
            this.gbInfo.Controls.Add(this.txtAmount);
            this.gbInfo.Controls.Add(this.cbClosed);
            this.gbInfo.Controls.Add(this.label4);
            this.gbInfo.Controls.Add(this.txtTax);
            this.gbInfo.Controls.Add(this.label3);
            this.gbInfo.Controls.Add(this.txtIssuingDate);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.Controls.Add(this.txtBillNumber);
            this.gbInfo.Location = new System.Drawing.Point(12, 236);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(484, 651);
            this.gbInfo.TabIndex = 5;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Informacije";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 380);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Iznos s porezom";
            // 
            // txtAmountWithTax
            // 
            this.txtAmountWithTax.Location = new System.Drawing.Point(6, 413);
            this.txtAmountWithTax.Name = "txtAmountWithTax";
            this.txtAmountWithTax.ReadOnly = true;
            this.txtAmountWithTax.Size = new System.Drawing.Size(417, 26);
            this.txtAmountWithTax.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Iznos";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(6, 329);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(417, 26);
            this.txtAmount.TabIndex = 14;
            // 
            // cbClosed
            // 
            this.cbClosed.AutoSize = true;
            this.cbClosed.Location = new System.Drawing.Point(6, 468);
            this.cbClosed.Name = "cbClosed";
            this.cbClosed.Size = new System.Drawing.Size(98, 24);
            this.cbClosed.TabIndex = 13;
            this.cbClosed.Text = "Zatvoren";
            this.cbClosed.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Porez";
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(6, 248);
            this.txtTax.Name = "txtTax";
            this.txtTax.ReadOnly = true;
            this.txtTax.Size = new System.Drawing.Size(417, 26);
            this.txtTax.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Datum izdavanja";
            // 
            // txtIssuingDate
            // 
            this.txtIssuingDate.Location = new System.Drawing.Point(6, 164);
            this.txtIssuingDate.Name = "txtIssuingDate";
            this.txtIssuingDate.ReadOnly = true;
            this.txtIssuingDate.Size = new System.Drawing.Size(417, 26);
            this.txtIssuingDate.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Broj računa";
            // 
            // txtBillNumber
            // 
            this.txtBillNumber.Location = new System.Drawing.Point(6, 80);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.ReadOnly = true;
            this.txtBillNumber.Size = new System.Drawing.Size(417, 26);
            this.txtBillNumber.TabIndex = 5;
            // 
            // Search
            // 
            this.Search.Controls.Add(this.dpDoC);
            this.Search.Controls.Add(this.label2);
            this.Search.Controls.Add(this.btnFilterOrder);
            this.Search.Location = new System.Drawing.Point(12, 12);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(484, 192);
            this.Search.TabIndex = 4;
            this.Search.TabStop = false;
            this.Search.Text = "Pretraga";
            // 
            // dpDoC
            // 
            this.dpDoC.Location = new System.Drawing.Point(6, 93);
            this.dpDoC.Name = "dpDoC";
            this.dpDoC.Size = new System.Drawing.Size(316, 26);
            this.dpDoC.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Datum";
            // 
            // btnFilterOrder
            // 
            this.btnFilterOrder.Location = new System.Drawing.Point(356, 82);
            this.btnFilterOrder.Name = "btnFilterOrder";
            this.btnFilterOrder.Size = new System.Drawing.Size(106, 52);
            this.btnFilterOrder.TabIndex = 1;
            this.btnFilterOrder.Text = "Filtriraj";
            this.btnFilterOrder.UseVisualStyleBackColor = true;
            // 
            // btnBillItems
            // 
            this.btnBillItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBillItems.Location = new System.Drawing.Point(263, 482);
            this.btnBillItems.Name = "btnBillItems";
            this.btnBillItems.Size = new System.Drawing.Size(160, 46);
            this.btnBillItems.TabIndex = 6;
            this.btnBillItems.Text = "Artikli";
            this.btnBillItems.UseVisualStyleBackColor = true;
            this.btnBillItems.Click += new System.EventHandler(this.btnBillItems_Click);
            // 
            // frmBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2132, 1251);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.dgvBills);
            this.Name = "frmBills";
            this.Text = "frmBills";
            this.Load += new System.EventHandler(this.frmBills_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.Search.ResumeLayout(false);
            this.Search.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBills;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyerOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Buyer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountWithTax;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.CheckBox cbClosed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIssuingDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBillNumber;
        private System.Windows.Forms.GroupBox Search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFilterOrder;
        private System.Windows.Forms.DateTimePicker dpDoC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAmountWithTax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnBillItems;
    }
}