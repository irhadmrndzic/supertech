
namespace superTech.WinUI.BuyerOrder
{
    partial class frmProcessedBuyerOrderItems
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
            this.gbItems = new System.Windows.Forms.GroupBox();
            this.listViewOrderItems = new System.Windows.Forms.ListView();
            this.ProdIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAmount = new System.Windows.Forms.Label();
            this.Iznos = new System.Windows.Forms.Label();
            this.lblBuyer = new System.Windows.Forms.Label();
            this.Kupac = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.Datum = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbItems
            // 
            this.gbItems.Controls.Add(this.listViewOrderItems);
            this.gbItems.Location = new System.Drawing.Point(12, 155);
            this.gbItems.Name = "gbItems";
            this.gbItems.Size = new System.Drawing.Size(1133, 567);
            this.gbItems.TabIndex = 0;
            this.gbItems.TabStop = false;
            this.gbItems.Text = "Artikli";
            // 
            // listViewOrderItems
            // 
            this.listViewOrderItems.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listViewOrderItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProdIndex,
            this.ProductName,
            this.ProductCode,
            this.Quantity,
            this.ProductPrice,
            this.ProductAmount});
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
            // 
            // ProductName
            // 
            this.ProductName.Text = "Proizvod";
            this.ProductName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ProductName.Width = 150;
            // 
            // ProductCode
            // 
            this.ProductCode.Text = "Šifra";
            this.ProductCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ProductCode.Width = 150;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Količina";
            this.Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Quantity.Width = 125;
            // 
            // ProductPrice
            // 
            this.ProductPrice.Text = "Cijena";
            this.ProductPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ProductPrice.Width = 125;
            // 
            // ProductAmount
            // 
            this.ProductAmount.Text = "Iznos";
            this.ProductAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ProductAmount.Width = 125;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblAmount.Location = new System.Drawing.Point(423, 86);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(0, 22);
            this.lblAmount.TabIndex = 15;
            // 
            // Iznos
            // 
            this.Iznos.AutoSize = true;
            this.Iznos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Iznos.Location = new System.Drawing.Point(330, 86);
            this.Iznos.Name = "Iznos";
            this.Iznos.Size = new System.Drawing.Size(56, 22);
            this.Iznos.TabIndex = 14;
            this.Iznos.Text = "Iznos:";
            // 
            // lblBuyer
            // 
            this.lblBuyer.AutoSize = true;
            this.lblBuyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblBuyer.Location = new System.Drawing.Point(423, 30);
            this.lblBuyer.Name = "lblBuyer";
            this.lblBuyer.Size = new System.Drawing.Size(0, 22);
            this.lblBuyer.TabIndex = 13;
            // 
            // Kupac
            // 
            this.Kupac.AutoSize = true;
            this.Kupac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Kupac.Location = new System.Drawing.Point(330, 30);
            this.Kupac.Name = "Kupac";
            this.Kupac.Size = new System.Drawing.Size(66, 22);
            this.Kupac.TabIndex = 12;
            this.Kupac.Text = "Kupac:";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblOrderDate.Location = new System.Drawing.Point(155, 86);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(0, 22);
            this.lblOrderDate.TabIndex = 11;
            // 
            // Datum
            // 
            this.Datum.AutoSize = true;
            this.Datum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Datum.Location = new System.Drawing.Point(12, 86);
            this.Datum.Name = "Datum";
            this.Datum.Size = new System.Drawing.Size(67, 22);
            this.Datum.TabIndex = 10;
            this.Datum.Text = "Datum:";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblOrderNumber.Location = new System.Drawing.Point(155, 30);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(0, 22);
            this.lblOrderNumber.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "Broj narudžbe:";
            // 
            // frmProcessedBuyerOrderItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 735);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.Iznos);
            this.Controls.Add(this.lblBuyer);
            this.Controls.Add(this.Kupac);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.Datum);
            this.Controls.Add(this.lblOrderNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbItems);
            this.MaximizeBox = false;
            this.Name = "frmProcessedBuyerOrderItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProcessedBuyerOrderItems";
            this.Load += new System.EventHandler(this.frmProcessedBuyerOrderItems_Load);
            this.gbItems.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbItems;
        private System.Windows.Forms.ListView listViewOrderItems;
        private System.Windows.Forms.ColumnHeader ProdIndex;
        private System.Windows.Forms.ColumnHeader ProductName;
        private System.Windows.Forms.ColumnHeader ProductCode;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader ProductPrice;
        private System.Windows.Forms.ColumnHeader ProductAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label Iznos;
        private System.Windows.Forms.Label lblBuyer;
        private System.Windows.Forms.Label Kupac;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label Datum;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label label1;
    }
}