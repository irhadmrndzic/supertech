namespace superTech.WinUI
{
    partial class frmMenu
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.korisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaKorisnikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviKorisnikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proizvodiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nabavkaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.novaNabavkaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ponudeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.novaPonudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(245)))), ((int)(((byte)(239)))));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisniciToolStripMenuItem,
            this.proizvodiToolStripMenuItem,
            this.newsToolStripMenuItem,
            this.nabavkaToolStripMenuItem,
            this.ponudeToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(2072, 33);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // korisniciToolStripMenuItem
            // 
            this.korisniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaKorisnikaToolStripMenuItem,
            this.noviKorisnikToolStripMenuItem});
            this.korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            this.korisniciToolStripMenuItem.Size = new System.Drawing.Size(93, 29);
            this.korisniciToolStripMenuItem.Text = "Korisnici";
            // 
            // pretragaKorisnikaToolStripMenuItem
            // 
            this.pretragaKorisnikaToolStripMenuItem.Name = "pretragaKorisnikaToolStripMenuItem";
            this.pretragaKorisnikaToolStripMenuItem.Size = new System.Drawing.Size(256, 34);
            this.pretragaKorisnikaToolStripMenuItem.Text = "Pretraga Korisnika";
            this.pretragaKorisnikaToolStripMenuItem.Click += new System.EventHandler(this.pretragaKorisnikaToolStripMenuItem_Click);
            // 
            // noviKorisnikToolStripMenuItem
            // 
            this.noviKorisnikToolStripMenuItem.Name = "noviKorisnikToolStripMenuItem";
            this.noviKorisnikToolStripMenuItem.Size = new System.Drawing.Size(256, 34);
            this.noviKorisnikToolStripMenuItem.Text = "Novi korisnik";
            this.noviKorisnikToolStripMenuItem.Click += new System.EventHandler(this.noviKorisnikToolStripMenuItem_Click);
            // 
            // proizvodiToolStripMenuItem
            // 
            this.proizvodiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledToolStripMenuItem});
            this.proizvodiToolStripMenuItem.Name = "proizvodiToolStripMenuItem";
            this.proizvodiToolStripMenuItem.Size = new System.Drawing.Size(102, 29);
            this.proizvodiToolStripMenuItem.Text = "Proizvodi";
            // 
            // pregledToolStripMenuItem
            // 
            this.pregledToolStripMenuItem.Name = "pregledToolStripMenuItem";
            this.pregledToolStripMenuItem.Size = new System.Drawing.Size(174, 34);
            this.pregledToolStripMenuItem.Text = "Pregled";
            this.pregledToolStripMenuItem.Click += new System.EventHandler(this.pregledToolStripMenuItem_Click);
            // 
            // newsToolStripMenuItem
            // 
            this.newsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledToolStripMenuItem1});
            this.newsToolStripMenuItem.Name = "newsToolStripMenuItem";
            this.newsToolStripMenuItem.Size = new System.Drawing.Size(71, 29);
            this.newsToolStripMenuItem.Text = "News";
            // 
            // pregledToolStripMenuItem1
            // 
            this.pregledToolStripMenuItem1.Name = "pregledToolStripMenuItem1";
            this.pregledToolStripMenuItem1.Size = new System.Drawing.Size(174, 34);
            this.pregledToolStripMenuItem1.Text = "Pregled";
            this.pregledToolStripMenuItem1.Click += new System.EventHandler(this.pregledToolStripMenuItem1_Click);
            // 
            // nabavkaToolStripMenuItem
            // 
            this.nabavkaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledToolStripMenuItem2,
            this.novaNabavkaToolStripMenuItem});
            this.nabavkaToolStripMenuItem.Name = "nabavkaToolStripMenuItem";
            this.nabavkaToolStripMenuItem.Size = new System.Drawing.Size(97, 29);
            this.nabavkaToolStripMenuItem.Text = "Nabavka";
            // 
            // pregledToolStripMenuItem2
            // 
            this.pregledToolStripMenuItem2.Name = "pregledToolStripMenuItem2";
            this.pregledToolStripMenuItem2.Size = new System.Drawing.Size(227, 34);
            this.pregledToolStripMenuItem2.Text = "Pregled";
            this.pregledToolStripMenuItem2.Click += new System.EventHandler(this.pregledToolStripMenuItem2_Click);
            // 
            // novaNabavkaToolStripMenuItem
            // 
            this.novaNabavkaToolStripMenuItem.Name = "novaNabavkaToolStripMenuItem";
            this.novaNabavkaToolStripMenuItem.Size = new System.Drawing.Size(227, 34);
            this.novaNabavkaToolStripMenuItem.Text = "Nova nabavka";
            this.novaNabavkaToolStripMenuItem.Click += new System.EventHandler(this.novaNabavkaToolStripMenuItem_Click);
            // 
            // ponudeToolStripMenuItem
            // 
            this.ponudeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledToolStripMenuItem3,
            this.novaPonudaToolStripMenuItem});
            this.ponudeToolStripMenuItem.Name = "ponudeToolStripMenuItem";
            this.ponudeToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.ponudeToolStripMenuItem.Text = "Ponude";
            // 
            // pregledToolStripMenuItem3
            // 
            this.pregledToolStripMenuItem3.Name = "pregledToolStripMenuItem3";
            this.pregledToolStripMenuItem3.Size = new System.Drawing.Size(223, 34);
            this.pregledToolStripMenuItem3.Text = "Pregled";
            this.pregledToolStripMenuItem3.Click += new System.EventHandler(this.pregledToolStripMenuItem3_Click);
            // 
            // novaPonudaToolStripMenuItem
            // 
            this.novaPonudaToolStripMenuItem.Name = "novaPonudaToolStripMenuItem";
            this.novaPonudaToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.novaPonudaToolStripMenuItem.Text = "Nova ponuda";
            this.novaPonudaToolStripMenuItem.Click += new System.EventHandler(this.novaPonudaToolStripMenuItem_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.CausesValidation = false;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.No;
            this.txtUsername.Enabled = false;
            this.txtUsername.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtUsername.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtUsername.Location = new System.Drawing.Point(1718, 0);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(199, 30);
            this.txtUsername.TabIndex = 4;
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2072, 1159);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMenu";
            this.Text = "SUPERTECH";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem korisniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaKorisnikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviKorisnikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proizvodiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nabavkaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem novaNabavkaToolStripMenuItem;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.ToolStripMenuItem ponudeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem novaPonudaToolStripMenuItem;
    }
}



