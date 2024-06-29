namespace AracKiralama
{
    partial class FrmArac
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAracBilgileri = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAracAra = new System.Windows.Forms.TextBox();
            this.btnaracEkle = new System.Windows.Forms.Button();
            this.dataGridViewTumAraclar = new System.Windows.Forms.DataGridView();
            this.araclarBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.arcDataSet1 = new AracKiralama.arcDataSet();
            this.araclarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnaracSil = new System.Windows.Forms.Button();
            this.btnaracDuzenle = new System.Windows.Forms.Button();
            this.araclarBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.araclarTableAdapter1 = new AracKiralama.arcDataSetTableAdapters.araclarTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTumAraclar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.araclarBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.araclarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.araclarBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAracBilgileri
            // 
            this.btnAracBilgileri.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(223)))), ((int)(((byte)(71)))));
            this.btnAracBilgileri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAracBilgileri.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAracBilgileri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(223)))), ((int)(((byte)(71)))));
            this.btnAracBilgileri.Location = new System.Drawing.Point(1063, 62);
            this.btnAracBilgileri.Name = "btnAracBilgileri";
            this.btnAracBilgileri.Size = new System.Drawing.Size(114, 54);
            this.btnAracBilgileri.TabIndex = 38;
            this.btnAracBilgileri.Text = "Araç Bilgileri";
            this.btnAracBilgileri.UseVisualStyleBackColor = true;
            this.btnAracBilgileri.Click += new System.EventHandler(this.btnAracBilgileri_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(33, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 21);
            this.label12.TabIndex = 37;
            this.label12.Text = "Ara:";
            // 
            // txtAracAra
            // 
            this.txtAracAra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.txtAracAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAracAra.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAracAra.Location = new System.Drawing.Point(76, 22);
            this.txtAracAra.Name = "txtAracAra";
            this.txtAracAra.Size = new System.Drawing.Size(174, 29);
            this.txtAracAra.TabIndex = 36;
            this.txtAracAra.TextChanged += new System.EventHandler(this.txtAracAra_TextChanged);
            // 
            // btnaracEkle
            // 
            this.btnaracEkle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(223)))), ((int)(((byte)(71)))));
            this.btnaracEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaracEkle.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnaracEkle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(223)))), ((int)(((byte)(71)))));
            this.btnaracEkle.Location = new System.Drawing.Point(1063, 122);
            this.btnaracEkle.Name = "btnaracEkle";
            this.btnaracEkle.Size = new System.Drawing.Size(114, 54);
            this.btnaracEkle.TabIndex = 39;
            this.btnaracEkle.Text = "Araç Ekle";
            this.btnaracEkle.UseVisualStyleBackColor = true;
            this.btnaracEkle.Click += new System.EventHandler(this.btnaracEkle_Click);
            // 
            // dataGridViewTumAraclar
            // 
            this.dataGridViewTumAraclar.AllowUserToAddRows = false;
            this.dataGridViewTumAraclar.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(75)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(223)))), ((int)(((byte)(71)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTumAraclar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTumAraclar.AutoGenerateColumns = false;
            this.dataGridViewTumAraclar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(75)))), ((int)(((byte)(79)))));
            this.dataGridViewTumAraclar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTumAraclar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(223)))), ((int)(((byte)(71)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTumAraclar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTumAraclar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTumAraclar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            this.dataGridViewTumAraclar.DataSource = this.araclarBindingSource2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(75)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(223)))), ((int)(((byte)(71)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTumAraclar.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTumAraclar.EnableHeadersVisualStyles = false;
            this.dataGridViewTumAraclar.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewTumAraclar.Location = new System.Drawing.Point(12, 62);
            this.dataGridViewTumAraclar.MultiSelect = false;
            this.dataGridViewTumAraclar.Name = "dataGridViewTumAraclar";
            this.dataGridViewTumAraclar.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(75)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(223)))), ((int)(((byte)(71)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTumAraclar.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTumAraclar.RowHeadersWidth = 30;
            this.dataGridViewTumAraclar.RowTemplate.Height = 30;
            this.dataGridViewTumAraclar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTumAraclar.Size = new System.Drawing.Size(1035, 594);
            this.dataGridViewTumAraclar.TabIndex = 35;
            // 
            // araclarBindingSource2
            // 
            this.araclarBindingSource2.DataMember = "araclar";
            this.araclarBindingSource2.DataSource = this.arcDataSet1;
            // 
            // arcDataSet1
            // 
            this.arcDataSet1.DataSetName = "arcDataSet";
            this.arcDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // araclarBindingSource
            // 
            this.araclarBindingSource.DataMember = "araclar";
            // 
            // btnaracSil
            // 
            this.btnaracSil.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(223)))), ((int)(((byte)(71)))));
            this.btnaracSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaracSil.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnaracSil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(223)))), ((int)(((byte)(71)))));
            this.btnaracSil.Location = new System.Drawing.Point(1063, 242);
            this.btnaracSil.Name = "btnaracSil";
            this.btnaracSil.Size = new System.Drawing.Size(114, 54);
            this.btnaracSil.TabIndex = 41;
            this.btnaracSil.Text = "Aracı Sil";
            this.btnaracSil.UseVisualStyleBackColor = true;
            this.btnaracSil.Click += new System.EventHandler(this.btnaracSil_Click);
            // 
            // btnaracDuzenle
            // 
            this.btnaracDuzenle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(223)))), ((int)(((byte)(71)))));
            this.btnaracDuzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaracDuzenle.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnaracDuzenle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(223)))), ((int)(((byte)(71)))));
            this.btnaracDuzenle.Location = new System.Drawing.Point(1063, 182);
            this.btnaracDuzenle.Name = "btnaracDuzenle";
            this.btnaracDuzenle.Size = new System.Drawing.Size(114, 54);
            this.btnaracDuzenle.TabIndex = 40;
            this.btnaracDuzenle.Text = "Aracı Düzenle";
            this.btnaracDuzenle.UseVisualStyleBackColor = true;
            this.btnaracDuzenle.Click += new System.EventHandler(this.btnaracDuzenle_Click);
            // 
            // araclarBindingSource1
            // 
            this.araclarBindingSource1.DataMember = "araclar";
            // 
            // araclarTableAdapter1
            // 
            this.araclarTableAdapter1.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "plaka";
            this.dataGridViewTextBoxColumn1.HeaderText = "Plaka";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "marka";
            this.dataGridViewTextBoxColumn2.HeaderText = "Marka";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "model";
            this.dataGridViewTextBoxColumn3.HeaderText = "Model";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "yil";
            this.dataGridViewTextBoxColumn4.HeaderText = "Yıl";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "yakit";
            this.dataGridViewTextBoxColumn5.HeaderText = "Yakıt";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "vites";
            this.dataGridViewTextBoxColumn6.HeaderText = "Vites";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "kilometre";
            this.dataGridViewTextBoxColumn7.HeaderText = "KM";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "motor_gucu";
            this.dataGridViewTextBoxColumn8.HeaderText = "Motor Gücü";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "kasa_tipi";
            this.dataGridViewTextBoxColumn9.HeaderText = "Kasa Tipi";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "renk";
            this.dataGridViewTextBoxColumn10.HeaderText = "Renk";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "hasar";
            this.dataGridViewTextBoxColumn11.HeaderText = "Hasar Kaydı";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // FrmArac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(1191, 668);
            this.Controls.Add(this.btnAracBilgileri);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtAracAra);
            this.Controls.Add(this.btnaracEkle);
            this.Controls.Add(this.dataGridViewTumAraclar);
            this.Controls.Add(this.btnaracSil);
            this.Controls.Add(this.btnaracDuzenle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmArac";
            this.Text = "FrmArac";
            this.Load += new System.EventHandler(this.FrmArac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTumAraclar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.araclarBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.araclarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.araclarBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAracBilgileri;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAracAra;
        private System.Windows.Forms.Button btnaracEkle;
        public System.Windows.Forms.DataGridView dataGridViewTumAraclar;
        private System.Windows.Forms.Button btnaracSil;
        private System.Windows.Forms.Button btnaracDuzenle;
        private arcDataSet arcDataSet;
        private System.Windows.Forms.BindingSource araclarBindingSource;
        private arcDataSetTableAdapters.araclarTableAdapter araclarTableAdapter;
        private System.Windows.Forms.BindingSource araclarBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn plakaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn markaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yakitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vitesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kilometreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn motorgucuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kasatipiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn renkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hasarDataGridViewTextBoxColumn;
        private arcDataSet arcDataSet1;
        private System.Windows.Forms.BindingSource araclarBindingSource2;
        private arcDataSetTableAdapters.araclarTableAdapter araclarTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
    }
}