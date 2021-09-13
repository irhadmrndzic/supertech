namespace superTech.WinUI.Offers
{
    partial class frmOfferItems
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
            this.listViewOfferItems = new System.Windows.Forms.ListView();
            this.ProdIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProdName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Discount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PriceWithDiscount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewOfferItems
            // 
            this.listViewOfferItems.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listViewOfferItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProdIndex,
            this.ProdName,
            this.Discount,
            this.PriceWithDiscount});
            this.listViewOfferItems.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listViewOfferItems.GridLines = true;
            this.listViewOfferItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewOfferItems.HideSelection = false;
            this.listViewOfferItems.Location = new System.Drawing.Point(0, 38);
            this.listViewOfferItems.MultiSelect = false;
            this.listViewOfferItems.Name = "listViewOfferItems";
            this.listViewOfferItems.Size = new System.Drawing.Size(800, 412);
            this.listViewOfferItems.TabIndex = 1;
            this.listViewOfferItems.UseCompatibleStateImageBehavior = false;
            this.listViewOfferItems.View = System.Windows.Forms.View.Details;
            // 
            // ProdIndex
            // 
            this.ProdIndex.Text = "Redni broj";
            this.ProdIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ProdIndex.Width = 90;
            // 
            // ProdName
            // 
            this.ProdName.Text = "Proizvod";
            this.ProdName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ProdName.Width = 150;
            // 
            // Discount
            // 
            this.Discount.Text = "Popust";
            this.Discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Discount.Width = 150;
            // 
            // PriceWithDiscount
            // 
            this.PriceWithDiscount.Text = "Cijena s popustom";
            this.PriceWithDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PriceWithDiscount.Width = 155;
            // 
            // frmOfferItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listViewOfferItems);
            this.Name = "frmOfferItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stavke ponude";
            this.Load += new System.EventHandler(this.frmOfferItems_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewOfferItems;
        private System.Windows.Forms.ColumnHeader ProdIndex;
        private System.Windows.Forms.ColumnHeader ProdName;
        private System.Windows.Forms.ColumnHeader Discount;
        private System.Windows.Forms.ColumnHeader PriceWithDiscount;
    }
}