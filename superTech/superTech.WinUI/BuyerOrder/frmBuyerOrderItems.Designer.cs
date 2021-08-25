
namespace superTech.WinUI.BuyerOrder
{
    partial class frmBuyerOrderItems
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.Datum = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.Iznos = new System.Windows.Forms.Label();
            this.lblBuyer = new System.Windows.Forms.Label();
            this.Kupac = new System.Windows.Forms.Label();
            this.listViewOrderItems = new System.Windows.Forms.ListView();
            this.ProdIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Broj narudžbe:";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblOrderNumber.Location = new System.Drawing.Point(155, 28);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(0, 22);
            this.lblOrderNumber.TabIndex = 1;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblOrderDate.Location = new System.Drawing.Point(155, 72);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(0, 22);
            this.lblOrderDate.TabIndex = 3;
            // 
            // Datum
            // 
            this.Datum.AutoSize = true;
            this.Datum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Datum.Location = new System.Drawing.Point(12, 72);
            this.Datum.Name = "Datum";
            this.Datum.Size = new System.Drawing.Size(67, 22);
            this.Datum.TabIndex = 2;
            this.Datum.Text = "Datum:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblAmount.Location = new System.Drawing.Point(423, 72);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(0, 22);
            this.lblAmount.TabIndex = 7;
            // 
            // Iznos
            // 
            this.Iznos.AutoSize = true;
            this.Iznos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Iznos.Location = new System.Drawing.Point(330, 72);
            this.Iznos.Name = "Iznos";
            this.Iznos.Size = new System.Drawing.Size(56, 22);
            this.Iznos.TabIndex = 6;
            this.Iznos.Text = "Iznos:";
            // 
            // lblBuyer
            // 
            this.lblBuyer.AutoSize = true;
            this.lblBuyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblBuyer.Location = new System.Drawing.Point(423, 28);
            this.lblBuyer.Name = "lblBuyer";
            this.lblBuyer.Size = new System.Drawing.Size(0, 22);
            this.lblBuyer.TabIndex = 5;
            // 
            // Kupac
            // 
            this.Kupac.AutoSize = true;
            this.Kupac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Kupac.Location = new System.Drawing.Point(330, 28);
            this.Kupac.Name = "Kupac";
            this.Kupac.Size = new System.Drawing.Size(66, 22);
            this.Kupac.TabIndex = 4;
            this.Kupac.Text = "Kupac:";
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
            this.listViewOrderItems.TabIndex = 8;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewOrderItems);
            this.groupBox1.Location = new System.Drawing.Point(12, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1133, 567);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Artikli";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(245)))), ((int)(((byte)(239)))));
            this.btnCancel.Location = new System.Drawing.Point(680, 735);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(199, 63);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Otkaži";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(102)))));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(245)))), ((int)(((byte)(239)))));
            this.btnConfirm.Location = new System.Drawing.Point(943, 735);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(199, 63);
            this.btnConfirm.TabIndex = 11;
            this.btnConfirm.Text = "Potvrdi";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.SystemColors.Info;
            this.txtInfo.Location = new System.Drawing.Point(16, 108);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(220, 26);
            this.txtInfo.TabIndex = 17;
            this.txtInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmBuyerOrderItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 810);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.Iznos);
            this.Controls.Add(this.lblBuyer);
            this.Controls.Add(this.Kupac);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.Datum);
            this.Controls.Add(this.lblOrderNumber);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmBuyerOrderItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalji narudžbe ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBuyerOrderItems_FormClosed);
            this.Load += new System.EventHandler(this.frmBuyerOrderItems_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label Datum;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label Iznos;
        private System.Windows.Forms.Label lblBuyer;
        private System.Windows.Forms.Label Kupac;
        private System.Windows.Forms.ListView listViewOrderItems;
        private System.Windows.Forms.ColumnHeader ProdIndex;
        private System.Windows.Forms.ColumnHeader ProductName;
        private System.Windows.Forms.ColumnHeader ProductCode;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader ProductPrice;
        private System.Windows.Forms.ColumnHeader ProductAmount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtInfo;
    }
}