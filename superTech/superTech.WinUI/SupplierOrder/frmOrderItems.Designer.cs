namespace superTech.WinUI.SupplierOrder
{
    partial class frmOrderItems
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
            this.listViewOrderItems = new System.Windows.Forms.ListView();
            this.ProdIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProdName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewOrderItems
            // 
            this.listViewOrderItems.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listViewOrderItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProdIndex,
            this.ProdName,
            this.ProductCode,
            this.Quantity,
            this.Price});
            this.listViewOrderItems.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listViewOrderItems.GridLines = true;
            this.listViewOrderItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewOrderItems.HideSelection = false;
            this.listViewOrderItems.Location = new System.Drawing.Point(0, 56);
            this.listViewOrderItems.MultiSelect = false;
            this.listViewOrderItems.Name = "listViewOrderItems";
            this.listViewOrderItems.Size = new System.Drawing.Size(898, 412);
            this.listViewOrderItems.TabIndex = 0;
            this.listViewOrderItems.UseCompatibleStateImageBehavior = false;
            this.listViewOrderItems.View = System.Windows.Forms.View.Details;
            // 
            // ProdIndex
            // 
            this.ProdIndex.Text = "Redni broj";
            this.ProdIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ProdName
            // 
            this.ProdName.Text = "Proizvod";
            this.ProdName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ProdName.Width = 150;
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
            // Price
            // 
            this.Price.Text = "Ukupna cijena";
            this.Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Price.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Artikli";
            // 
            // frmOrderItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 468);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewOrderItems);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrderItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stavke narudžbe";
            this.Load += new System.EventHandler(this.frmOrderItems_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewOrderItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader ProductCode;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader ProdName;
        private System.Windows.Forms.ColumnHeader ProdIndex;
    }
}