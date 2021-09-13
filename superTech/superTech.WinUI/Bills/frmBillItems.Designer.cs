
namespace superTech.WinUI.Bills
{
    partial class frmBillItems
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
            this.lblAmount = new System.Windows.Forms.Label();
            this.Iznos = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.Porez = new System.Windows.Forms.Label();
            this.lblIssuingDate = new System.Windows.Forms.Label();
            this.Datum = new System.Windows.Forms.Label();
            this.lblBillNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbItems = new System.Windows.Forms.GroupBox();
            this.listViewOrderItems = new System.Windows.Forms.ListView();
            this.ProdIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductString = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Discount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAmountWithTax = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblAmount.Location = new System.Drawing.Point(423, 82);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(0, 22);
            this.lblAmount.TabIndex = 25;
            // 
            // Iznos
            // 
            this.Iznos.AutoSize = true;
            this.Iznos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Iznos.Location = new System.Drawing.Point(330, 82);
            this.Iznos.Name = "Iznos";
            this.Iznos.Size = new System.Drawing.Size(56, 22);
            this.Iznos.TabIndex = 24;
            this.Iznos.Text = "Iznos:";
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblTax.Location = new System.Drawing.Point(423, 36);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(0, 22);
            this.lblTax.TabIndex = 23;
            // 
            // Porez
            // 
            this.Porez.AutoSize = true;
            this.Porez.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Porez.Location = new System.Drawing.Point(330, 36);
            this.Porez.Name = "Porez";
            this.Porez.Size = new System.Drawing.Size(61, 22);
            this.Porez.TabIndex = 22;
            this.Porez.Text = "Porez:";
            // 
            // lblIssuingDate
            // 
            this.lblIssuingDate.AutoSize = true;
            this.lblIssuingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblIssuingDate.Location = new System.Drawing.Point(184, 73);
            this.lblIssuingDate.Name = "lblIssuingDate";
            this.lblIssuingDate.Size = new System.Drawing.Size(0, 22);
            this.lblIssuingDate.TabIndex = 21;
            // 
            // Datum
            // 
            this.Datum.AutoSize = true;
            this.Datum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Datum.Location = new System.Drawing.Point(12, 73);
            this.Datum.Name = "Datum";
            this.Datum.Size = new System.Drawing.Size(147, 22);
            this.Datum.TabIndex = 20;
            this.Datum.Text = "Datum izdavanja:";
            // 
            // lblBillNumber
            // 
            this.lblBillNumber.AutoSize = true;
            this.lblBillNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblBillNumber.Location = new System.Drawing.Point(184, 36);
            this.lblBillNumber.Name = "lblBillNumber";
            this.lblBillNumber.Size = new System.Drawing.Size(0, 22);
            this.lblBillNumber.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 22);
            this.label1.TabIndex = 18;
            this.label1.Text = "Broj računa:";
            // 
            // gbItems
            // 
            this.gbItems.Controls.Add(this.listViewOrderItems);
            this.gbItems.Location = new System.Drawing.Point(12, 161);
            this.gbItems.Name = "gbItems";
            this.gbItems.Size = new System.Drawing.Size(1133, 567);
            this.gbItems.TabIndex = 17;
            this.gbItems.TabStop = false;
            this.gbItems.Text = "Artikli";
            // 
            // listViewOrderItems
            // 
            this.listViewOrderItems.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listViewOrderItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProdIndex,
            this.ProductString,
            this.Price,
            this.Quantity,
            this.Discount,
            this.Total});
            this.listViewOrderItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewOrderItems.GridLines = true;
            this.listViewOrderItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewOrderItems.HideSelection = false;
            this.listViewOrderItems.Location = new System.Drawing.Point(3, 22);
            this.listViewOrderItems.MultiSelect = false;
            this.listViewOrderItems.Name = "listViewOrderItems";
            this.listViewOrderItems.Size = new System.Drawing.Size(1127, 542);
            this.listViewOrderItems.TabIndex = 10;
            this.listViewOrderItems.UseCompatibleStateImageBehavior = false;
            this.listViewOrderItems.View = System.Windows.Forms.View.Details;
            // 
            // ProdIndex
            // 
            this.ProdIndex.Text = "Redni broj";
            this.ProdIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ProdIndex.Width = 91;
            // 
            // ProductString
            // 
            this.ProductString.Text = "Proizvod";
            this.ProductString.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ProductString.Width = 150;
            // 
            // Price
            // 
            this.Price.Text = "Cijena";
            this.Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Price.Width = 150;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Količina";
            this.Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Quantity.Width = 125;
            // 
            // Discount
            // 
            this.Discount.Text = "Popust";
            this.Discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Discount.Width = 125;
            // 
            // Total
            // 
            this.Total.Text = "Ukupno";
            this.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Total.Width = 125;
            // 
            // lblAmountWithTax
            // 
            this.lblAmountWithTax.AutoSize = true;
            this.lblAmountWithTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblAmountWithTax.Location = new System.Drawing.Point(184, 116);
            this.lblAmountWithTax.Name = "lblAmountWithTax";
            this.lblAmountWithTax.Size = new System.Drawing.Size(0, 22);
            this.lblAmountWithTax.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 22);
            this.label3.TabIndex = 26;
            this.label3.Text = "Iznos s porezom:";
            // 
            // frmBillItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1164, 749);
            this.Controls.Add(this.lblAmountWithTax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.Iznos);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.Porez);
            this.Controls.Add(this.lblIssuingDate);
            this.Controls.Add(this.Datum);
            this.Controls.Add(this.lblBillNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbItems);
            this.MaximizeBox = false;
            this.Name = "frmBillItems";
            this.Text = "Stavke računa";
            this.Load += new System.EventHandler(this.frmBillItems_Load);
            this.gbItems.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label Iznos;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label Porez;
        private System.Windows.Forms.Label lblIssuingDate;
        private System.Windows.Forms.Label Datum;
        private System.Windows.Forms.Label lblBillNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbItems;
        private System.Windows.Forms.ListView listViewOrderItems;
        private System.Windows.Forms.ColumnHeader ProdIndex;
        private System.Windows.Forms.ColumnHeader ProductString;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Discount;
        private System.Windows.Forms.Label lblAmountWithTax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader Total;
    }
}