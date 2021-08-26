namespace superTech.WinUI.Offers
{
    partial class frmOffers
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
            this.dgvOffers = new System.Windows.Forms.DataGridView();
            this.OfferId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNoOffers = new System.Windows.Forms.Label();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dpDTSearch = new System.Windows.Forms.DateTimePicker();
            this.dpDFSearch = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dpDateTo = new System.Windows.Forms.DateTimePicker();
            this.btnOfferItems = new System.Windows.Forms.Button();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSaveOffer = new System.Windows.Forms.Button();
            this.cbActive = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOffers)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOffers
            // 
            this.dgvOffers.AllowUserToAddRows = false;
            this.dgvOffers.AllowUserToDeleteRows = false;
            this.dgvOffers.AllowUserToOrderColumns = true;
            this.dgvOffers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOffers.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvOffers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOffers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OfferId,
            this.Title,
            this.Description,
            this.DateFrom,
            this.DateTo,
            this.Active});
            this.dgvOffers.Location = new System.Drawing.Point(749, 12);
            this.dgvOffers.Name = "dgvOffers";
            this.dgvOffers.RowHeadersWidth = 62;
            this.dgvOffers.RowTemplate.Height = 28;
            this.dgvOffers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOffers.Size = new System.Drawing.Size(853, 963);
            this.dgvOffers.TabIndex = 0;
            this.dgvOffers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOffers_CellFormatting);
            this.dgvOffers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvOffers_MouseDoubleClick);
            // 
            // OfferId
            // 
            this.OfferId.DataPropertyName = "OfferId";
            this.OfferId.HeaderText = "OfferId";
            this.OfferId.MinimumWidth = 8;
            this.OfferId.Name = "OfferId";
            this.OfferId.Visible = false;
            this.OfferId.Width = 150;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Naslov";
            this.Title.MinimumWidth = 8;
            this.Title.Name = "Title";
            this.Title.Width = 150;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Opis";
            this.Description.MinimumWidth = 8;
            this.Description.Name = "Description";
            this.Description.Width = 150;
            // 
            // DateFrom
            // 
            this.DateFrom.DataPropertyName = "DateFrom";
            this.DateFrom.HeaderText = "Datum Od";
            this.DateFrom.MinimumWidth = 8;
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Width = 150;
            // 
            // DateTo
            // 
            this.DateTo.DataPropertyName = "DateTo";
            this.DateTo.HeaderText = "Datum do";
            this.DateTo.MinimumWidth = 8;
            this.DateTo.Name = "DateTo";
            this.DateTo.Width = 150;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Aktivna";
            this.Active.MinimumWidth = 8;
            this.Active.Name = "Active";
            this.Active.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Active.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNoOffers);
            this.groupBox1.Controls.Add(this.btnShowAll);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Controls.Add(this.dpDTSearch);
            this.groupBox1.Controls.Add(this.dpDFSearch);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(19, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(698, 232);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pretraga";
            // 
            // lblNoOffers
            // 
            this.lblNoOffers.AutoSize = true;
            this.lblNoOffers.Location = new System.Drawing.Point(411, 194);
            this.lblNoOffers.Name = "lblNoOffers";
            this.lblNoOffers.Size = new System.Drawing.Size(0, 20);
            this.lblNoOffers.TabIndex = 18;
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(82)))), ((int)(((byte)(186)))));
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.ForeColor = System.Drawing.Color.White;
            this.btnShowAll.Location = new System.Drawing.Point(554, 111);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(106, 55);
            this.btnShowAll.TabIndex = 17;
            this.btnShowAll.Text = "Prikaži sve";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(82)))), ((int)(((byte)(186)))));
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(397, 111);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(106, 55);
            this.btnFilter.TabIndex = 13;
            this.btnFilter.Text = "Filtriraj";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dpDTSearch
            // 
            this.dpDTSearch.Location = new System.Drawing.Point(19, 168);
            this.dpDTSearch.Name = "dpDTSearch";
            this.dpDTSearch.Size = new System.Drawing.Size(355, 26);
            this.dpDTSearch.TabIndex = 16;
            this.dpDTSearch.ValueChanged += new System.EventHandler(this.dpDTSearch_ValueChanged);
            // 
            // dpDFSearch
            // 
            this.dpDFSearch.Location = new System.Drawing.Point(19, 84);
            this.dpDFSearch.Name = "dpDFSearch";
            this.dpDFSearch.Size = new System.Drawing.Size(362, 26);
            this.dpDFSearch.TabIndex = 15;
            this.dpDFSearch.ValueChanged += new System.EventHandler(this.dpDFSearch_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Datum Od:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Datum do:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Naslov";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(34, 363);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(579, 26);
            this.txtTitle.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Opis:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(34, 444);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(579, 161);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 642);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Datum Od:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 726);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Datum Do:";
            // 
            // dpDateFrom
            // 
            this.dpDateFrom.Location = new System.Drawing.Point(34, 679);
            this.dpDateFrom.Name = "dpDateFrom";
            this.dpDateFrom.Size = new System.Drawing.Size(362, 26);
            this.dpDateFrom.TabIndex = 9;
            this.dpDateFrom.ValueChanged += new System.EventHandler(this.dpDateFrom_ValueChanged);
            // 
            // dpDateTo
            // 
            this.dpDateTo.Location = new System.Drawing.Point(34, 763);
            this.dpDateTo.Name = "dpDateTo";
            this.dpDateTo.Size = new System.Drawing.Size(355, 26);
            this.dpDateTo.TabIndex = 10;
            this.dpDateTo.ValueChanged += new System.EventHandler(this.dpDateTo_ValueChanged);
            // 
            // btnOfferItems
            // 
            this.btnOfferItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOfferItems.Location = new System.Drawing.Point(434, 709);
            this.btnOfferItems.Name = "btnOfferItems";
            this.btnOfferItems.Size = new System.Drawing.Size(106, 55);
            this.btnOfferItems.TabIndex = 12;
            this.btnOfferItems.Text = "Proizvodi";
            this.btnOfferItems.UseVisualStyleBackColor = true;
            this.btnOfferItems.Click += new System.EventHandler(this.btnOfferItems_Click);
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // btnSaveOffer
            // 
            this.btnSaveOffer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(102)))));
            this.btnSaveOffer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveOffer.ForeColor = System.Drawing.Color.White;
            this.btnSaveOffer.Location = new System.Drawing.Point(356, 885);
            this.btnSaveOffer.Name = "btnSaveOffer";
            this.btnSaveOffer.Size = new System.Drawing.Size(257, 58);
            this.btnSaveOffer.TabIndex = 15;
            this.btnSaveOffer.Text = "Sačuvaj";
            this.btnSaveOffer.UseVisualStyleBackColor = false;
            this.btnSaveOffer.Click += new System.EventHandler(this.btnSaveOffer_Click);
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(34, 820);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(91, 24);
            this.cbActive.TabIndex = 16;
            this.cbActive.Text = "Aktivna:";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // frmOffers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1614, 987);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.btnSaveOffer);
            this.Controls.Add(this.btnOfferItems);
            this.Controls.Add(this.dpDateTo);
            this.Controls.Add(this.dpDateFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvOffers);
            this.Name = "frmOffers";
            this.Text = "Ponude";
            this.Load += new System.EventHandler(this.frmOffers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOffers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOffers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpDateFrom;
        private System.Windows.Forms.DateTimePicker dpDateTo;
        private System.Windows.Forms.Button btnOfferItems;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DateTimePicker dpDTSearch;
        private System.Windows.Forms.DateTimePicker dpDFSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNoOffers;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.Button btnSaveOffer;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn OfferId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
    }
}