
namespace superTech.WinUI.Offers
{
    partial class frmRemoveOfferProduct
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
            this.btnCnt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtNumber = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCnt
            // 
            this.btnCnt.Location = new System.Drawing.Point(12, 110);
            this.btnCnt.Name = "btnCnt";
            this.btnCnt.Size = new System.Drawing.Size(209, 48);
            this.btnCnt.TabIndex = 5;
            this.btnCnt.Text = "Nastavi";
            this.btnCnt.UseVisualStyleBackColor = true;
            this.btnCnt.Click += new System.EventHandler(this.btnCnt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Unesite redni broj proizvoda:";
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(70, 64);
            this.txtNumber.Mask = "00000";
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(92, 26);
            this.txtNumber.TabIndex = 6;
            // 
            // frmRemoveOfferProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(235, 183);
            this.Controls.Add(this.btnCnt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumber);
            this.Name = "frmRemoveOfferProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRemoveOfferProduct";
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.MaskedTextBox txtNumber;
    }
}