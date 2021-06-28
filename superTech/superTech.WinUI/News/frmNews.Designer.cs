namespace superTech.WinUI.News
{
    partial class frmNews
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
            this.dgvNews = new System.Windows.Forms.DataGridView();
            this.NewsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfCreation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dpDoC = new System.Windows.Forms.DateTimePicker();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.btnFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNews)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNews
            // 
            this.dgvNews.AllowUserToAddRows = false;
            this.dgvNews.AllowUserToDeleteRows = false;
            this.dgvNews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNews.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NewsId,
            this.Title,
            this.Content,
            this.DateOfCreation,
            this.Active});
            this.dgvNews.Location = new System.Drawing.Point(1006, 12);
            this.dgvNews.Name = "dgvNews";
            this.dgvNews.ReadOnly = true;
            this.dgvNews.RowHeadersWidth = 62;
            this.dgvNews.RowTemplate.Height = 28;
            this.dgvNews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNews.Size = new System.Drawing.Size(1139, 1116);
            this.dgvNews.TabIndex = 0;
            this.dgvNews.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvNews_MouseDoubleClick);
            // 
            // NewsId
            // 
            this.NewsId.DataPropertyName = "NewsId";
            this.NewsId.HeaderText = "Id";
            this.NewsId.MinimumWidth = 8;
            this.NewsId.Name = "NewsId";
            this.NewsId.ReadOnly = true;
            this.NewsId.Visible = false;
            this.NewsId.Width = 150;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Naslov";
            this.Title.MinimumWidth = 8;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 150;
            // 
            // Content
            // 
            this.Content.DataPropertyName = "Content";
            this.Content.HeaderText = "Sadržaj";
            this.Content.MinimumWidth = 8;
            this.Content.Name = "Content";
            this.Content.ReadOnly = true;
            this.Content.Width = 150;
            // 
            // DateOfCreation
            // 
            this.DateOfCreation.DataPropertyName = "DateOfCreation";
            this.DateOfCreation.HeaderText = "Datum kreiranja";
            this.DateOfCreation.MinimumWidth = 8;
            this.DateOfCreation.Name = "DateOfCreation";
            this.DateOfCreation.ReadOnly = true;
            this.DateOfCreation.Width = 150;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Aktivna";
            this.Active.MinimumWidth = 8;
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            this.Active.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Naslov:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(135, 82);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(432, 26);
            this.txtTitle.TabIndex = 2;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(135, 245);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(832, 536);
            this.txtContent.TabIndex = 3;
            this.txtContent.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sadržaj:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Datum objave:";
            // 
            // dpDoC
            // 
            this.dpDoC.Location = new System.Drawing.Point(135, 137);
            this.dpDoC.Name = "dpDoC";
            this.dpDoC.Size = new System.Drawing.Size(432, 26);
            this.dpDoC.TabIndex = 7;
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(135, 192);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(91, 24);
            this.cbActive.TabIndex = 8;
            this.cbActive.Text = "Aktivna:";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(618, 128);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(202, 49);
            this.btnFilter.TabIndex = 9;
            this.btnFilter.Text = "button1";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // frmNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2157, 1140);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.dpDoC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvNews);
            this.Name = "frmNews";
            this.Text = "frmNews";
            this.Load += new System.EventHandler(this.frmNews_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNews)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNews;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.RichTextBox txtContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpDoC;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfCreation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
        private System.Windows.Forms.Button btnFilter;
    }
}