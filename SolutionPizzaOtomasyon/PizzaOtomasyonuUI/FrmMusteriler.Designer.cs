namespace PizzaOtomasyonuUI
{
    partial class FrmMusteriler
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
            this.dataGridViewYeniMusteri = new System.Windows.Forms.DataGridView();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnYeniMusteri = new System.Windows.Forms.Button();
            this.maskedTextBoxTelefon3 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxTelefon2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxTelefon1 = new System.Windows.Forms.MaskedTextBox();
            this.textBoxSoyIsim = new System.Windows.Forms.TextBox();
            this.textBoxIsim = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblTelefon3 = new System.Windows.Forms.Label();
            this.lblTelefon2 = new System.Windows.Forms.Label();
            this.lblTelefon1 = new System.Windows.Forms.Label();
            this.lblSoyisim = new System.Windows.Forms.Label();
            this.lblısim = new System.Windows.Forms.Label();
            this.dataGridViewMusteri = new System.Windows.Forms.DataGridView();
            this.btnAra = new System.Windows.Forms.Button();
            this.textBoxSoyad = new System.Windows.Forms.TextBox();
            this.textBoxAd = new System.Windows.Forms.TextBox();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.lblAd = new System.Windows.Forms.Label();
            this.tabPageMusteriBul = new System.Windows.Forms.TabPage();
            this.tabPageMusteriEkle = new System.Windows.Forms.TabPage();
            this.tabControlMusteri = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.secilenMusteriyiGonderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secilenMusteriyiSatisEkranindanTemizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYeniMusteri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMusteri)).BeginInit();
            this.tabPageMusteriBul.SuspendLayout();
            this.tabPageMusteriEkle.SuspendLayout();
            this.tabControlMusteri.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewYeniMusteri
            // 
            this.dataGridViewYeniMusteri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewYeniMusteri.Location = new System.Drawing.Point(332, 13);
            this.dataGridViewYeniMusteri.Name = "dataGridViewYeniMusteri";
            this.dataGridViewYeniMusteri.Size = new System.Drawing.Size(421, 344);
            this.dataGridViewYeniMusteri.TabIndex = 29;
            this.dataGridViewYeniMusteri.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewYeniMusteri_CellClick);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Location = new System.Drawing.Point(9, 328);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(295, 29);
            this.btnTemizle.TabIndex = 26;
            this.btnTemizle.Text = "EKRANI TEMİZLE";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.Location = new System.Drawing.Point(9, 293);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(295, 29);
            this.btnSil.TabIndex = 26;
            this.btnSil.Text = "MÜŞTERİYİ SİL";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Location = new System.Drawing.Point(9, 257);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(295, 29);
            this.btnGuncelle.TabIndex = 27;
            this.btnGuncelle.Text = "MÜŞTERİYİ GÜNCELLE";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnYeniMusteri
            // 
            this.btnYeniMusteri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYeniMusteri.Location = new System.Drawing.Point(9, 217);
            this.btnYeniMusteri.Name = "btnYeniMusteri";
            this.btnYeniMusteri.Size = new System.Drawing.Size(295, 29);
            this.btnYeniMusteri.TabIndex = 28;
            this.btnYeniMusteri.Text = "YENİ MÜŞTERİ EKLE";
            this.btnYeniMusteri.UseVisualStyleBackColor = true;
            this.btnYeniMusteri.Click += new System.EventHandler(this.btnYeniMusteri_Click);
            // 
            // maskedTextBoxTelefon3
            // 
            this.maskedTextBoxTelefon3.Location = new System.Drawing.Point(106, 181);
            this.maskedTextBoxTelefon3.Mask = "(999) 000-0000";
            this.maskedTextBoxTelefon3.Name = "maskedTextBoxTelefon3";
            this.maskedTextBoxTelefon3.Size = new System.Drawing.Size(198, 20);
            this.maskedTextBoxTelefon3.TabIndex = 25;
            // 
            // maskedTextBoxTelefon2
            // 
            this.maskedTextBoxTelefon2.Location = new System.Drawing.Point(106, 148);
            this.maskedTextBoxTelefon2.Mask = "(999) 000-0000";
            this.maskedTextBoxTelefon2.Name = "maskedTextBoxTelefon2";
            this.maskedTextBoxTelefon2.Size = new System.Drawing.Size(198, 20);
            this.maskedTextBoxTelefon2.TabIndex = 23;
            // 
            // maskedTextBoxTelefon1
            // 
            this.maskedTextBoxTelefon1.Location = new System.Drawing.Point(106, 115);
            this.maskedTextBoxTelefon1.Mask = "(999) 000-0000";
            this.maskedTextBoxTelefon1.Name = "maskedTextBoxTelefon1";
            this.maskedTextBoxTelefon1.Size = new System.Drawing.Size(198, 20);
            this.maskedTextBoxTelefon1.TabIndex = 21;
            // 
            // textBoxSoyIsim
            // 
            this.textBoxSoyIsim.Location = new System.Drawing.Point(106, 77);
            this.textBoxSoyIsim.Name = "textBoxSoyIsim";
            this.textBoxSoyIsim.Size = new System.Drawing.Size(198, 20);
            this.textBoxSoyIsim.TabIndex = 19;
            // 
            // textBoxIsim
            // 
            this.textBoxIsim.Location = new System.Drawing.Point(106, 45);
            this.textBoxIsim.Name = "textBoxIsim";
            this.textBoxIsim.Size = new System.Drawing.Size(198, 20);
            this.textBoxIsim.TabIndex = 17;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(106, 13);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(198, 20);
            this.textBoxID.TabIndex = 15;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblID.Location = new System.Drawing.Point(6, 13);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(27, 16);
            this.lblID.TabIndex = 14;
            this.lblID.Text = "ID:";
            // 
            // lblTelefon3
            // 
            this.lblTelefon3.AutoSize = true;
            this.lblTelefon3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTelefon3.Location = new System.Drawing.Point(6, 185);
            this.lblTelefon3.Name = "lblTelefon3";
            this.lblTelefon3.Size = new System.Drawing.Size(93, 16);
            this.lblTelefon3.TabIndex = 24;
            this.lblTelefon3.Text = "TELEFON 3:";
            // 
            // lblTelefon2
            // 
            this.lblTelefon2.AutoSize = true;
            this.lblTelefon2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTelefon2.Location = new System.Drawing.Point(6, 152);
            this.lblTelefon2.Name = "lblTelefon2";
            this.lblTelefon2.Size = new System.Drawing.Size(93, 16);
            this.lblTelefon2.TabIndex = 22;
            this.lblTelefon2.Text = "TELEFON 2:";
            // 
            // lblTelefon1
            // 
            this.lblTelefon1.AutoSize = true;
            this.lblTelefon1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTelefon1.Location = new System.Drawing.Point(6, 119);
            this.lblTelefon1.Name = "lblTelefon1";
            this.lblTelefon1.Size = new System.Drawing.Size(93, 16);
            this.lblTelefon1.TabIndex = 20;
            this.lblTelefon1.Text = "TELEFON 1:";
            // 
            // lblSoyisim
            // 
            this.lblSoyisim.AutoSize = true;
            this.lblSoyisim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSoyisim.Location = new System.Drawing.Point(6, 81);
            this.lblSoyisim.Name = "lblSoyisim";
            this.lblSoyisim.Size = new System.Drawing.Size(73, 16);
            this.lblSoyisim.TabIndex = 18;
            this.lblSoyisim.Text = "SOYİSİM:";
            // 
            // lblısim
            // 
            this.lblısim.AutoSize = true;
            this.lblısim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblısim.Location = new System.Drawing.Point(6, 45);
            this.lblısim.Name = "lblısim";
            this.lblısim.Size = new System.Drawing.Size(42, 16);
            this.lblısim.TabIndex = 16;
            this.lblısim.Text = "İSİM:";
            // 
            // dataGridViewMusteri
            // 
            this.dataGridViewMusteri.AllowUserToAddRows = false;
            this.dataGridViewMusteri.AllowUserToDeleteRows = false;
            this.dataGridViewMusteri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMusteri.Location = new System.Drawing.Point(11, 87);
            this.dataGridViewMusteri.MultiSelect = false;
            this.dataGridViewMusteri.Name = "dataGridViewMusteri";
            this.dataGridViewMusteri.ReadOnly = true;
            this.dataGridViewMusteri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMusteri.Size = new System.Drawing.Size(742, 244);
            this.dataGridViewMusteri.TabIndex = 3;
            // 
            // btnAra
            // 
            this.btnAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAra.Location = new System.Drawing.Point(307, 18);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(75, 53);
            this.btnAra.TabIndex = 2;
            this.btnAra.Text = "ARA";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // textBoxSoyad
            // 
            this.textBoxSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxSoyad.Location = new System.Drawing.Point(71, 49);
            this.textBoxSoyad.Name = "textBoxSoyad";
            this.textBoxSoyad.Size = new System.Drawing.Size(220, 22);
            this.textBoxSoyad.TabIndex = 1;
            // 
            // textBoxAd
            // 
            this.textBoxAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxAd.Location = new System.Drawing.Point(71, 19);
            this.textBoxAd.Name = "textBoxAd";
            this.textBoxAd.Size = new System.Drawing.Size(220, 22);
            this.textBoxAd.TabIndex = 1;
            // 
            // lblSoyad
            // 
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSoyad.Location = new System.Drawing.Point(8, 52);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(57, 16);
            this.lblSoyad.TabIndex = 0;
            this.lblSoyad.Text = "Soyad:";
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAd.Location = new System.Drawing.Point(8, 22);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(33, 16);
            this.lblAd.TabIndex = 0;
            this.lblAd.Text = "AD:";
            // 
            // tabPageMusteriBul
            // 
            this.tabPageMusteriBul.Controls.Add(this.dataGridViewMusteri);
            this.tabPageMusteriBul.Controls.Add(this.btnAra);
            this.tabPageMusteriBul.Controls.Add(this.textBoxSoyad);
            this.tabPageMusteriBul.Controls.Add(this.textBoxAd);
            this.tabPageMusteriBul.Controls.Add(this.lblSoyad);
            this.tabPageMusteriBul.Controls.Add(this.lblAd);
            this.tabPageMusteriBul.Location = new System.Drawing.Point(4, 22);
            this.tabPageMusteriBul.Name = "tabPageMusteriBul";
            this.tabPageMusteriBul.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMusteriBul.Size = new System.Drawing.Size(759, 363);
            this.tabPageMusteriBul.TabIndex = 0;
            this.tabPageMusteriBul.Text = "Müşteri Ara";
            this.tabPageMusteriBul.UseVisualStyleBackColor = true;
            // 
            // tabPageMusteriEkle
            // 
            this.tabPageMusteriEkle.Controls.Add(this.dataGridViewYeniMusteri);
            this.tabPageMusteriEkle.Controls.Add(this.btnTemizle);
            this.tabPageMusteriEkle.Controls.Add(this.btnSil);
            this.tabPageMusteriEkle.Controls.Add(this.btnGuncelle);
            this.tabPageMusteriEkle.Controls.Add(this.btnYeniMusteri);
            this.tabPageMusteriEkle.Controls.Add(this.maskedTextBoxTelefon3);
            this.tabPageMusteriEkle.Controls.Add(this.maskedTextBoxTelefon2);
            this.tabPageMusteriEkle.Controls.Add(this.maskedTextBoxTelefon1);
            this.tabPageMusteriEkle.Controls.Add(this.textBoxSoyIsim);
            this.tabPageMusteriEkle.Controls.Add(this.textBoxIsim);
            this.tabPageMusteriEkle.Controls.Add(this.textBoxID);
            this.tabPageMusteriEkle.Controls.Add(this.lblID);
            this.tabPageMusteriEkle.Controls.Add(this.lblTelefon3);
            this.tabPageMusteriEkle.Controls.Add(this.lblTelefon2);
            this.tabPageMusteriEkle.Controls.Add(this.lblTelefon1);
            this.tabPageMusteriEkle.Controls.Add(this.lblSoyisim);
            this.tabPageMusteriEkle.Controls.Add(this.lblısim);
            this.tabPageMusteriEkle.Location = new System.Drawing.Point(4, 22);
            this.tabPageMusteriEkle.Name = "tabPageMusteriEkle";
            this.tabPageMusteriEkle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMusteriEkle.Size = new System.Drawing.Size(759, 363);
            this.tabPageMusteriEkle.TabIndex = 1;
            this.tabPageMusteriEkle.Text = "Yeni Ekle";
            this.tabPageMusteriEkle.UseVisualStyleBackColor = true;
            // 
            // tabControlMusteri
            // 
            this.tabControlMusteri.Controls.Add(this.tabPageMusteriBul);
            this.tabControlMusteri.Controls.Add(this.tabPageMusteriEkle);
            this.tabControlMusteri.Location = new System.Drawing.Point(8, 12);
            this.tabControlMusteri.Name = "tabControlMusteri";
            this.tabControlMusteri.SelectedIndex = 0;
            this.tabControlMusteri.Size = new System.Drawing.Size(767, 389);
            this.tabControlMusteri.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.secilenMusteriyiGonderToolStripMenuItem,
            this.secilenMusteriyiSatisEkranindanTemizleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(293, 48);
            // 
            // secilenMusteriyiGonderToolStripMenuItem
            // 
            this.secilenMusteriyiGonderToolStripMenuItem.Name = "secilenMusteriyiGonderToolStripMenuItem";
            this.secilenMusteriyiGonderToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.secilenMusteriyiGonderToolStripMenuItem.Text = "Seçilen müşteriyi satış ekranına gönder";
            this.secilenMusteriyiGonderToolStripMenuItem.Click += new System.EventHandler(this.secilenMusteriyiGonderToolStripMenuItem_Click);
            // 
            // secilenMusteriyiSatisEkranindanTemizleToolStripMenuItem
            // 
            this.secilenMusteriyiSatisEkranindanTemizleToolStripMenuItem.Name = "secilenMusteriyiSatisEkranindanTemizleToolStripMenuItem";
            this.secilenMusteriyiSatisEkranindanTemizleToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.secilenMusteriyiSatisEkranindanTemizleToolStripMenuItem.Text = "Seçilen müşteriyi satış ekranından temizle";
            this.secilenMusteriyiSatisEkranindanTemizleToolStripMenuItem.Click += new System.EventHandler(this.secilenMusteriyiSatisEkranindanTemizleToolStripMenuItem_Click);
            // 
            // FrmMusteriler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(782, 406);
            this.Controls.Add(this.tabControlMusteri);
            this.MaximizeBox = false;
            this.Name = "FrmMusteriler";
            this.Text = "FrmMusteriler";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMusteriler_FormClosed);
            this.Load += new System.EventHandler(this.FrmMusteriler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYeniMusteri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMusteri)).EndInit();
            this.tabPageMusteriBul.ResumeLayout(false);
            this.tabPageMusteriBul.PerformLayout();
            this.tabPageMusteriEkle.ResumeLayout(false);
            this.tabPageMusteriEkle.PerformLayout();
            this.tabControlMusteri.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewYeniMusteri;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnYeniMusteri;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelefon3;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelefon2;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelefon1;
        private System.Windows.Forms.TextBox textBoxSoyIsim;
        private System.Windows.Forms.TextBox textBoxIsim;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblTelefon3;
        private System.Windows.Forms.Label lblTelefon2;
        private System.Windows.Forms.Label lblTelefon1;
        private System.Windows.Forms.Label lblSoyisim;
        private System.Windows.Forms.Label lblısim;
        private System.Windows.Forms.DataGridView dataGridViewMusteri;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.TextBox textBoxSoyad;
        private System.Windows.Forms.TextBox textBoxAd;
        private System.Windows.Forms.Label lblSoyad;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.TabPage tabPageMusteriBul;
        private System.Windows.Forms.TabPage tabPageMusteriEkle;
        private System.Windows.Forms.TabControl tabControlMusteri;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem secilenMusteriyiGonderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secilenMusteriyiSatisEkranindanTemizleToolStripMenuItem;
    }
}