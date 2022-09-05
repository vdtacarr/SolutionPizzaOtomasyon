namespace PizzaOtomasyonuUI
{
    partial class FrmPizzalar
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
            this.tabControlPizza = new System.Windows.Forms.TabControl();
            this.TumPizzalar = new System.Windows.Forms.TabPage();
            this.btnPizzaAra = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblPizzaAra = new System.Windows.Forms.Label();
            this.dataGridViewPizzaMalzemeleri = new System.Windows.Forms.DataGridView();
            this.lblSeciliPizzaMalzeme = new System.Windows.Forms.Label();
            this.dataGridViewPizzalar = new System.Windows.Forms.DataGridView();
            this.lblPizzalar = new System.Windows.Forms.Label();
            this.tabPagePizzaEkle = new System.Windows.Forms.TabPage();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewYeniPizza = new System.Windows.Forms.DataGridView();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.lblısim = new System.Windows.Forms.Label();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.btnYeniPizza = new System.Windows.Forms.Button();
            this.textBoxIsim = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTelefon2 = new System.Windows.Forms.Label();
            this.tabPagePizzaMalzemeEkle = new System.Windows.Forms.TabPage();
            this.btnPizzayaMalzemeEkle = new System.Windows.Forms.Button();
            this.dataGridViewPizzadaOlmayanMalzemeler = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxPizzalar = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seçiliOlanMalzemeyiPizzadanSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlPizza.SuspendLayout();
            this.TumPizzalar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPizzaMalzemeleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPizzalar)).BeginInit();
            this.tabPagePizzaEkle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYeniPizza)).BeginInit();
            this.tabPagePizzaMalzemeEkle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPizzadaOlmayanMalzemeler)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlPizza
            // 
            this.tabControlPizza.Controls.Add(this.TumPizzalar);
            this.tabControlPizza.Controls.Add(this.tabPagePizzaEkle);
            this.tabControlPizza.Controls.Add(this.tabPagePizzaMalzemeEkle);
            this.tabControlPizza.Location = new System.Drawing.Point(0, 0);
            this.tabControlPizza.Name = "tabControlPizza";
            this.tabControlPizza.SelectedIndex = 0;
            this.tabControlPizza.Size = new System.Drawing.Size(1011, 452);
            this.tabControlPizza.TabIndex = 0;
            // 
            // TumPizzalar
            // 
            this.TumPizzalar.Controls.Add(this.btnPizzaAra);
            this.TumPizzalar.Controls.Add(this.textBox1);
            this.TumPizzalar.Controls.Add(this.lblPizzaAra);
            this.TumPizzalar.Controls.Add(this.dataGridViewPizzaMalzemeleri);
            this.TumPizzalar.Controls.Add(this.lblSeciliPizzaMalzeme);
            this.TumPizzalar.Controls.Add(this.dataGridViewPizzalar);
            this.TumPizzalar.Controls.Add(this.lblPizzalar);
            this.TumPizzalar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TumPizzalar.Location = new System.Drawing.Point(4, 22);
            this.TumPizzalar.Name = "TumPizzalar";
            this.TumPizzalar.Padding = new System.Windows.Forms.Padding(3);
            this.TumPizzalar.Size = new System.Drawing.Size(1003, 426);
            this.TumPizzalar.TabIndex = 0;
            this.TumPizzalar.Text = "Tüm Pizzalar";
            this.TumPizzalar.UseVisualStyleBackColor = true;
            // 
            // btnPizzaAra
            // 
            this.btnPizzaAra.Location = new System.Drawing.Point(709, 29);
            this.btnPizzaAra.Name = "btnPizzaAra";
            this.btnPizzaAra.Size = new System.Drawing.Size(75, 23);
            this.btnPizzaAra.TabIndex = 13;
            this.btnPizzaAra.Text = "ARA";
            this.btnPizzaAra.UseVisualStyleBackColor = true;
            this.btnPizzaAra.Click += new System.EventHandler(this.btnPizzaAra_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(592, 20);
            this.textBox1.TabIndex = 12;
            // 
            // lblPizzaAra
            // 
            this.lblPizzaAra.AutoSize = true;
            this.lblPizzaAra.Location = new System.Drawing.Point(17, 36);
            this.lblPizzaAra.Name = "lblPizzaAra";
            this.lblPizzaAra.Size = new System.Drawing.Size(63, 13);
            this.lblPizzaAra.TabIndex = 11;
            this.lblPizzaAra.Text = "Pizza Adı:";
            // 
            // dataGridViewPizzaMalzemeleri
            // 
            this.dataGridViewPizzaMalzemeleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPizzaMalzemeleri.Location = new System.Drawing.Point(13, 252);
            this.dataGridViewPizzaMalzemeleri.Name = "dataGridViewPizzaMalzemeleri";
            this.dataGridViewPizzaMalzemeleri.Size = new System.Drawing.Size(771, 164);
            this.dataGridViewPizzaMalzemeleri.TabIndex = 10;
            // 
            // lblSeciliPizzaMalzeme
            // 
            this.lblSeciliPizzaMalzeme.AutoSize = true;
            this.lblSeciliPizzaMalzeme.Location = new System.Drawing.Point(10, 236);
            this.lblSeciliPizzaMalzeme.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSeciliPizzaMalzeme.Name = "lblSeciliPizzaMalzeme";
            this.lblSeciliPizzaMalzeme.Size = new System.Drawing.Size(124, 13);
            this.lblSeciliPizzaMalzeme.TabIndex = 9;
            this.lblSeciliPizzaMalzeme.Text = "Pizzanın Malzemeleri";
            // 
            // dataGridViewPizzalar
            // 
            this.dataGridViewPizzalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPizzalar.Location = new System.Drawing.Point(13, 64);
            this.dataGridViewPizzalar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridViewPizzalar.Name = "dataGridViewPizzalar";
            this.dataGridViewPizzalar.Size = new System.Drawing.Size(774, 156);
            this.dataGridViewPizzalar.TabIndex = 8;
            this.dataGridViewPizzalar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPizzalar_CellClick);
            // 
            // lblPizzalar
            // 
            this.lblPizzalar.AutoSize = true;
            this.lblPizzalar.Location = new System.Drawing.Point(3, 6);
            this.lblPizzalar.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblPizzalar.Name = "lblPizzalar";
            this.lblPizzalar.Size = new System.Drawing.Size(79, 13);
            this.lblPizzalar.TabIndex = 7;
            this.lblPizzalar.Text = "Tüm Pizzalar";
            // 
            // tabPagePizzaEkle
            // 
            this.tabPagePizzaEkle.Controls.Add(this.numericUpDown1);
            this.tabPagePizzaEkle.Controls.Add(this.dateTimePicker1);
            this.tabPagePizzaEkle.Controls.Add(this.dataGridViewYeniPizza);
            this.tabPagePizzaEkle.Controls.Add(this.btnTemizle);
            this.tabPagePizzaEkle.Controls.Add(this.lblID);
            this.tabPagePizzaEkle.Controls.Add(this.btnSil);
            this.tabPagePizzaEkle.Controls.Add(this.lblısim);
            this.tabPagePizzaEkle.Controls.Add(this.btnGuncelle);
            this.tabPagePizzaEkle.Controls.Add(this.textBoxID);
            this.tabPagePizzaEkle.Controls.Add(this.btnYeniPizza);
            this.tabPagePizzaEkle.Controls.Add(this.textBoxIsim);
            this.tabPagePizzaEkle.Controls.Add(this.label2);
            this.tabPagePizzaEkle.Controls.Add(this.label1);
            this.tabPagePizzaEkle.Controls.Add(this.lblTelefon2);
            this.tabPagePizzaEkle.Location = new System.Drawing.Point(4, 22);
            this.tabPagePizzaEkle.Name = "tabPagePizzaEkle";
            this.tabPagePizzaEkle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePizzaEkle.Size = new System.Drawing.Size(1003, 426);
            this.tabPagePizzaEkle.TabIndex = 1;
            this.tabPagePizzaEkle.Text = "Pizza Ekle";
            this.tabPagePizzaEkle.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(160, 115);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(157, 20);
            this.numericUpDown1.TabIndex = 31;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(160, 142);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(157, 20);
            this.dateTimePicker1.TabIndex = 30;
            // 
            // dataGridViewYeniPizza
            // 
            this.dataGridViewYeniPizza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewYeniPizza.Location = new System.Drawing.Point(333, 28);
            this.dataGridViewYeniPizza.Name = "dataGridViewYeniPizza";
            this.dataGridViewYeniPizza.Size = new System.Drawing.Size(664, 388);
            this.dataGridViewYeniPizza.TabIndex = 29;
            this.dataGridViewYeniPizza.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewYeniPizza_CellClick);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Location = new System.Drawing.Point(22, 335);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(249, 29);
            this.btnTemizle.TabIndex = 26;
            this.btnTemizle.Text = "EKRANI TEMİZLE";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblID.Location = new System.Drawing.Point(19, 54);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(92, 16);
            this.lblID.TabIndex = 14;
            this.lblID.Text = "Pizza ID No:";
            // 
            // btnSil
            // 
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.Location = new System.Drawing.Point(22, 298);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(249, 29);
            this.btnSil.TabIndex = 26;
            this.btnSil.Text = "PİZZA SİL";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // lblısim
            // 
            this.lblısim.AutoSize = true;
            this.lblısim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblısim.Location = new System.Drawing.Point(19, 86);
            this.lblısim.Name = "lblısim";
            this.lblısim.Size = new System.Drawing.Size(76, 16);
            this.lblısim.TabIndex = 16;
            this.lblısim.Text = "Pizza Adı:";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Location = new System.Drawing.Point(22, 260);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(249, 29);
            this.btnGuncelle.TabIndex = 27;
            this.btnGuncelle.Text = "PİZZA GÜNCELLE";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(160, 54);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(157, 20);
            this.textBoxID.TabIndex = 15;
            // 
            // btnYeniPizza
            // 
            this.btnYeniPizza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYeniPizza.Location = new System.Drawing.Point(22, 215);
            this.btnYeniPizza.Name = "btnYeniPizza";
            this.btnYeniPizza.Size = new System.Drawing.Size(249, 29);
            this.btnYeniPizza.TabIndex = 28;
            this.btnYeniPizza.Text = "YENİ PİZZA EKLE";
            this.btnYeniPizza.UseVisualStyleBackColor = true;
            // 
            // textBoxIsim
            // 
            this.textBoxIsim.Location = new System.Drawing.Point(160, 86);
            this.textBoxIsim.Name = "textBoxIsim";
            this.textBoxIsim.Size = new System.Drawing.Size(157, 20);
            this.textBoxIsim.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(-193, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "TELEFON 1:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(19, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Birim Fiyat:";
            // 
            // lblTelefon2
            // 
            this.lblTelefon2.AutoSize = true;
            this.lblTelefon2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTelefon2.Location = new System.Drawing.Point(17, 146);
            this.lblTelefon2.Name = "lblTelefon2";
            this.lblTelefon2.Size = new System.Drawing.Size(137, 16);
            this.lblTelefon2.TabIndex = 22;
            this.lblTelefon2.Text = "Oluşturulma Tarihi:";
            this.lblTelefon2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPagePizzaMalzemeEkle
            // 
            this.tabPagePizzaMalzemeEkle.Controls.Add(this.btnPizzayaMalzemeEkle);
            this.tabPagePizzaMalzemeEkle.Controls.Add(this.dataGridViewPizzadaOlmayanMalzemeler);
            this.tabPagePizzaMalzemeEkle.Controls.Add(this.label3);
            this.tabPagePizzaMalzemeEkle.Controls.Add(this.comboBoxPizzalar);
            this.tabPagePizzaMalzemeEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabPagePizzaMalzemeEkle.Location = new System.Drawing.Point(4, 22);
            this.tabPagePizzaMalzemeEkle.Name = "tabPagePizzaMalzemeEkle";
            this.tabPagePizzaMalzemeEkle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePizzaMalzemeEkle.Size = new System.Drawing.Size(1003, 426);
            this.tabPagePizzaMalzemeEkle.TabIndex = 2;
            this.tabPagePizzaMalzemeEkle.Text = "Malzeme Ekle";
            this.tabPagePizzaMalzemeEkle.UseVisualStyleBackColor = true;
            // 
            // btnPizzayaMalzemeEkle
            // 
            this.btnPizzayaMalzemeEkle.Location = new System.Drawing.Point(20, 343);
            this.btnPizzayaMalzemeEkle.Name = "btnPizzayaMalzemeEkle";
            this.btnPizzayaMalzemeEkle.Size = new System.Drawing.Size(952, 42);
            this.btnPizzayaMalzemeEkle.TabIndex = 12;
            this.btnPizzayaMalzemeEkle.Text = "SEÇİLİ MALZEMELERİ EKLE";
            this.btnPizzayaMalzemeEkle.UseVisualStyleBackColor = true;
            this.btnPizzayaMalzemeEkle.Click += new System.EventHandler(this.btnPizzayaMalzemeEkle_Click);
            // 
            // dataGridViewPizzadaOlmayanMalzemeler
            // 
            this.dataGridViewPizzadaOlmayanMalzemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPizzadaOlmayanMalzemeler.Location = new System.Drawing.Point(20, 82);
            this.dataGridViewPizzadaOlmayanMalzemeler.Name = "dataGridViewPizzadaOlmayanMalzemeler";
            this.dataGridViewPizzadaOlmayanMalzemeler.Size = new System.Drawing.Size(952, 242);
            this.dataGridViewPizzadaOlmayanMalzemeler.TabIndex = 11;
            this.dataGridViewPizzadaOlmayanMalzemeler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPizzadaOlmayanMalzemeler_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "PİZZA SEÇ:";
            // 
            // comboBoxPizzalar
            // 
            this.comboBoxPizzalar.FormattingEnabled = true;
            this.comboBoxPizzalar.Location = new System.Drawing.Point(101, 34);
            this.comboBoxPizzalar.Name = "comboBoxPizzalar";
            this.comboBoxPizzalar.Size = new System.Drawing.Size(871, 21);
            this.comboBoxPizzalar.TabIndex = 0;
            this.comboBoxPizzalar.SelectedIndexChanged += new System.EventHandler(this.comboBoxPizzalar_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seçiliOlanMalzemeyiPizzadanSilToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(254, 48);
            // 
            // seçiliOlanMalzemeyiPizzadanSilToolStripMenuItem
            // 
            this.seçiliOlanMalzemeyiPizzadanSilToolStripMenuItem.Name = "seçiliOlanMalzemeyiPizzadanSilToolStripMenuItem";
            this.seçiliOlanMalzemeyiPizzadanSilToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.seçiliOlanMalzemeyiPizzadanSilToolStripMenuItem.Text = "Seçili Olan Malzemeyi Pizzadan Sil";
            this.seçiliOlanMalzemeyiPizzadanSilToolStripMenuItem.Click += new System.EventHandler(this.seçiliOlanMalzemeyiPizzadanSilToolStripMenuItem_Click);
            // 
            // FrmPizzalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1023, 450);
            this.Controls.Add(this.tabControlPizza);
            this.MaximizeBox = false;
            this.Name = "FrmPizzalar";
            this.Text = "FrmPizzalar";
            this.Load += new System.EventHandler(this.FrmPizzalar_Load);
            this.tabControlPizza.ResumeLayout(false);
            this.TumPizzalar.ResumeLayout(false);
            this.TumPizzalar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPizzaMalzemeleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPizzalar)).EndInit();
            this.tabPagePizzaEkle.ResumeLayout(false);
            this.tabPagePizzaEkle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYeniPizza)).EndInit();
            this.tabPagePizzaMalzemeEkle.ResumeLayout(false);
            this.tabPagePizzaMalzemeEkle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPizzadaOlmayanMalzemeler)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPizza;
        private System.Windows.Forms.TabPage TumPizzalar;
        private System.Windows.Forms.Button btnPizzaAra;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblPizzaAra;
        private System.Windows.Forms.DataGridView dataGridViewPizzaMalzemeleri;
        private System.Windows.Forms.Label lblSeciliPizzaMalzeme;
        private System.Windows.Forms.DataGridView dataGridViewPizzalar;
        private System.Windows.Forms.Label lblPizzalar;
        private System.Windows.Forms.TabPage tabPagePizzaEkle;
        private System.Windows.Forms.TabPage tabPagePizzaMalzemeEkle;
        private System.Windows.Forms.DataGridView dataGridViewYeniPizza;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnYeniPizza;
        private System.Windows.Forms.Label lblTelefon2;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblısim;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxIsim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnPizzayaMalzemeEkle;
        private System.Windows.Forms.DataGridView dataGridViewPizzadaOlmayanMalzemeler;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxPizzalar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem seçiliOlanMalzemeyiPizzadanSilToolStripMenuItem;
    }
}