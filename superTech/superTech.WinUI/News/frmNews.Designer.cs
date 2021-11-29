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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvNews = new System.Windows.Forms.DataGridView();
            this.NewsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfCreation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dpDoC = new System.Windows.Forms.DateTimePicker();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.lblNoNews = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNews)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNews
            // 
            this.dgvNews.AllowUserToAddRows = false;
            this.dgvNews.AllowUserToDeleteRows = false;
            this.dgvNews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNews.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNews.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvNews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNews.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NewsId,
            this.Title,
            this.Content,
            this.DateOfCreation,
            this.Active});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNews.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvNews.Location = new System.Drawing.Point(1006, 12);
            this.dgvNews.Name = "dgvNews";
            this.dgvNews.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNews.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
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
            this.Active.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Active.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Naslov:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(144, 16);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(832, 26);
            this.txtTitle.TabIndex = 2;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(144, 179);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(832, 536);
            this.txtContent.TabIndex = 3;
            this.txtContent.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sadržaj:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Datum objave:";
            // 
            // dpDoC
            // 
            this.dpDoC.Location = new System.Drawing.Point(144, 71);
            this.dpDoC.Name = "dpDoC";
            this.dpDoC.Size = new System.Drawing.Size(432, 26);
            this.dpDoC.TabIndex = 7;
            this.dpDoC.ValueChanged += new System.EventHandler(this.dpDoC_ValueChanged);
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(144, 126);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(91, 24);
            this.cbActive.TabIndex = 8;
            this.cbActive.Text = "Aktivna:";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(82)))), ((int)(((byte)(186)))));
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(245)))), ((int)(((byte)(239)))));
            this.btnFilter.Location = new System.Drawing.Point(627, 62);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(154, 49);
            this.btnFilter.TabIndex = 9;
            this.btnFilter.Text = "Filtriraj";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(82)))), ((int)(((byte)(186)))));
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(245)))), ((int)(((byte)(239)))));
            this.btnShowAll.Location = new System.Drawing.Point(829, 62);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(154, 49);
            this.btnShowAll.TabIndex = 10;
            this.btnShowAll.Text = "Prikaži sve";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // lblNoNews
            // 
            this.lblNoNews.AutoSize = true;
            this.lblNoNews.Location = new System.Drawing.Point(623, 126);
            this.lblNoNews.Name = "lblNoNews";
            this.lblNoNews.Size = new System.Drawing.Size(0, 20);
            this.lblNoNews.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(102)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(245)))), ((int)(((byte)(239)))));
            this.btnSave.Location = new System.Drawing.Point(753, 816);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(230, 63);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Sačuvaj";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClearForm
            // 
            this.btnClearForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(245)))), ((int)(((byte)(239)))));
            this.btnClearForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearForm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClearForm.Location = new System.Drawing.Point(794, 734);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(148, 63);
            this.btnClearForm.TabIndex = 13;
            this.btnClearForm.Text = "Očisti";
            this.btnClearForm.UseVisualStyleBackColor = false;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // frmNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2157, 1140);
            this.Controls.Add(this.btnClearForm);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblNoNews);
            this.Controls.Add(this.btnShowAll);
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
            this.Text = "Novosti";
            this.Load += new System.EventHandler(this.frmNews_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNews)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
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
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label lblNoNews;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfCreation;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
    }
}