namespace AracKiralama
{
    partial class FrmMainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainPage));
            this.btnMusteri = new System.Windows.Forms.Button();
            this.btnArac = new System.Windows.Forms.Button();
            this.btnKira = new System.Windows.Forms.Button();
            this.panelMove = new System.Windows.Forms.Panel();
            this.labelSayfaBilgisi = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCikisYap = new System.Windows.Forms.Button();
            this.btnAyarlar = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMusteri
            // 
            this.btnMusteri.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btnMusteri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusteri.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMusteri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(223)))), ((int)(((byte)(71)))));
            this.btnMusteri.Location = new System.Drawing.Point(15, 12);
            this.btnMusteri.Name = "btnMusteri";
            this.btnMusteri.Size = new System.Drawing.Size(181, 55);
            this.btnMusteri.TabIndex = 1;
            this.btnMusteri.Text = "Müşteri İşlemleri";
            this.btnMusteri.UseVisualStyleBackColor = true;
            this.btnMusteri.Click += new System.EventHandler(this.btnMusteri_Click);
            // 
            // btnArac
            // 
            this.btnArac.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btnArac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArac.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnArac.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(223)))), ((int)(((byte)(71)))));
            this.btnArac.Location = new System.Drawing.Point(15, 83);
            this.btnArac.Name = "btnArac";
            this.btnArac.Size = new System.Drawing.Size(181, 55);
            this.btnArac.TabIndex = 4;
            this.btnArac.Text = "Araç İşlemleri";
            this.btnArac.UseVisualStyleBackColor = true;
            this.btnArac.Click += new System.EventHandler(this.btnArac_Click);
            // 
            // btnKira
            // 
            this.btnKira.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btnKira.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKira.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKira.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(223)))), ((int)(((byte)(71)))));
            this.btnKira.Location = new System.Drawing.Point(15, 153);
            this.btnKira.Name = "btnKira";
            this.btnKira.Size = new System.Drawing.Size(181, 55);
            this.btnKira.TabIndex = 5;
            this.btnKira.Text = "Kira İşlemleri";
            this.btnKira.UseVisualStyleBackColor = true;
            this.btnKira.Click += new System.EventHandler(this.btnKira_Click);
            // 
            // panelMove
            // 
            this.panelMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(41)))));
            this.panelMove.Controls.Add(this.labelSayfaBilgisi);
            this.panelMove.Controls.Add(this.btnMinimize);
            this.panelMove.Controls.Add(this.btnClose);
            this.panelMove.Controls.Add(this.pictureBox2);
            this.panelMove.Location = new System.Drawing.Point(0, 0);
            this.panelMove.Name = "panelMove";
            this.panelMove.Size = new System.Drawing.Size(1400, 75);
            this.panelMove.TabIndex = 10;
            this.panelMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMove_MouseDown);
            this.panelMove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMove_MouseMove);
            this.panelMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelMove_MouseUp);
            // 
            // labelSayfaBilgisi
            // 
            this.labelSayfaBilgisi.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSayfaBilgisi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(223)))), ((int)(((byte)(71)))));
            this.labelSayfaBilgisi.Location = new System.Drawing.Point(209, 23);
            this.labelSayfaBilgisi.Name = "labelSayfaBilgisi";
            this.labelSayfaBilgisi.Size = new System.Drawing.Size(290, 32);
            this.labelSayfaBilgisi.TabIndex = 15;
            this.labelSayfaBilgisi.Text = "Müşteri İşlemleri";
            this.labelSayfaBilgisi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackgroundImage = global::AracKiralama.Properties.Resources.minimize;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Location = new System.Drawing.Point(1309, 14);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(20, 20);
            this.btnMinimize.TabIndex = 14;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::AracKiralama.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1359, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 13;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::AracKiralama.Properties.Resources.LOGO;
            this.pictureBox2.Location = new System.Drawing.Point(14, -26);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(179, 168);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(41)))));
            this.panel1.Controls.Add(this.btnCikisYap);
            this.panel1.Controls.Add(this.btnAyarlar);
            this.panel1.Controls.Add(this.btnMusteri);
            this.panel1.Controls.Add(this.btnArac);
            this.panel1.Controls.Add(this.btnKira);
            this.panel1.Location = new System.Drawing.Point(0, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 668);
            this.panel1.TabIndex = 12;
            // 
            // btnCikisYap
            // 
            this.btnCikisYap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCikisYap.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btnCikisYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikisYap.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikisYap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(223)))), ((int)(((byte)(71)))));
            this.btnCikisYap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCikisYap.Location = new System.Drawing.Point(15, 586);
            this.btnCikisYap.Name = "btnCikisYap";
            this.btnCikisYap.Size = new System.Drawing.Size(181, 55);
            this.btnCikisYap.TabIndex = 8;
            this.btnCikisYap.Text = "Çıkış Yap";
            this.btnCikisYap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCikisYap.UseVisualStyleBackColor = true;
            this.btnCikisYap.Click += new System.EventHandler(this.btnCikisYap_Click);
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAyarlar.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.btnAyarlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyarlar.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAyarlar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(223)))), ((int)(((byte)(71)))));
            this.btnAyarlar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyarlar.Location = new System.Drawing.Point(15, 515);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(181, 55);
            this.btnAyarlar.TabIndex = 7;
            this.btnAyarlar.Text = "Ayarlar";
            this.btnAyarlar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAyarlar.UseVisualStyleBackColor = true;
            this.btnAyarlar.Click += new System.EventHandler(this.btnAyarlar_Click);
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Location = new System.Drawing.Point(209, 75);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1191, 668);
            this.panelMain.TabIndex = 12;
            // 
            // FrmMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1400, 742);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelMove);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmMainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Araç Kiralama";
            this.Load += new System.EventHandler(this.FrmMainPage_Load);
            this.panelMove.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMusteri;
        private System.Windows.Forms.Button btnArac;
        private System.Windows.Forms.Button btnKira;
        private System.Windows.Forms.Button btnAyarlar;
        private System.Windows.Forms.Panel panelMove;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labelSayfaBilgisi;
        private System.Windows.Forms.Button btnCikisYap;
    }
}