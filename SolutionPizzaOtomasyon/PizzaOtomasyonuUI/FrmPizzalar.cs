using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PizzaOtomasyonIsKatmani;
using PizzaOtomasyonuVarliklar;

namespace PizzaOtomasyonuUI
{
    public partial class FrmPizzalar : Form
    {
        public FrmPizzalar()
        {
            InitializeComponent();
        }
        List<Pizzalar> tumPizzalarListesi = new List<Pizzalar>();
        public PizzaIslemleri pizzaIslem = new PizzaIslemleri();

        private void btnPizzaAra_Click(object sender, EventArgs e)
        {
            // pizzayı arayacak
            //sizin yazmanızı istiyorum :D
        }

        private void FrmPizzalar_Load(object sender, EventArgs e)
        {
            GridlerinAyarlari();
            ButonlarinAktiflikleriniAyarla();
            TumPizzalariGridlereGetir();
            //comboboxa pizzalari getir
            ComboBoxaPizzalariGetir();

            //gride contextMenuStrip1 nesnesini ekledim
            dataGridViewPizzaMalzemeleri.ContextMenuStrip = contextMenuStrip1;
        }

        private void ComboBoxaPizzalariGetir()
        {
            string hataMesaji = string.Empty;
            tumPizzalarListesi = pizzaIslem.TumPizzalarListesiniGetir(out hataMesaji);
            if (hataMesaji.Length > 0)
            {
                MessageBox.Show("Beklenmedik hata oluştu. Sistem yöneticisine danışınıız. HATA: " + hataMesaji);
            }
            else
            {
                comboBoxPizzalar.DisplayMember = "PizzaAdi"; //combobox'ın görünen değeri
                comboBoxPizzalar.ValueMember = "PizzaIDno"; //combobox'ın arka planda tutacağı değeri
                // genellikle id verilir. Çünkü veri işlemlerinde kullanılır

                comboBoxPizzalar.DataSource = tumPizzalarListesi;

            }
        }

        private void TumPizzalariGridlereGetir()
        {
            DataTable tablo = new DataTable();
            string hataMesaji = string.Empty;
            tablo = pizzaIslem.TumPizzalariDataSeteGetir(out hataMesaji);
            if (hataMesaji.Length > 0)
            {
                MessageBox.Show("Beklenmedik hata oluştu. Sistem yöneticisine danışınıız. HATA: " + hataMesaji);
            }
            else
            {
                dataGridViewPizzalar.DataSource = tablo;
                dataGridViewYeniPizza.DataSource = tablo;
            }

            DataGridViewPizzalarGenisliginiAyarla();
        }

        private void DataGridViewPizzalarGenisliginiAyarla()
        {
            //dataGridViewPizzalar içindeki tüm kolonları gezer Tek tek dolaşır (DÖNGÜ)
            foreach (DataGridViewColumn sutun in dataGridViewPizzalar.Columns)
            {
                sutun.Width = 195; // her kolonun genişliği 195 olsun
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            ButonlarinAktiflikleriniAyarla();
        }
        private void ButonlarinAktiflikleriniAyarla()
        {
            btnYeniPizza.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            btnPizzayaMalzemeEkle.Enabled = false;
        }
        private void GridlerinAyarlari()
        {
            dataGridViewPizzalar.AllowUserToAddRows = false;
            dataGridViewPizzalar.AllowUserToDeleteRows = false;
            dataGridViewPizzalar.MultiSelect = false;
            dataGridViewPizzalar.ReadOnly = true;
            dataGridViewPizzalar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            dataGridViewPizzaMalzemeleri.AllowUserToAddRows = false;
            dataGridViewPizzaMalzemeleri.AllowUserToDeleteRows = false;
            dataGridViewPizzaMalzemeleri.MultiSelect = false;
            dataGridViewPizzaMalzemeleri.ReadOnly = true;
            dataGridViewPizzaMalzemeleri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            dataGridViewYeniPizza.AllowUserToAddRows = false;
            dataGridViewYeniPizza.AllowUserToDeleteRows = false;
            dataGridViewYeniPizza.MultiSelect = false;
            dataGridViewYeniPizza.ReadOnly = true;
            dataGridViewYeniPizza.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            dataGridViewPizzadaOlmayanMalzemeler.AllowUserToAddRows = false;
            dataGridViewPizzadaOlmayanMalzemeler.AllowUserToDeleteRows = false;
            dataGridViewPizzadaOlmayanMalzemeler.MultiSelect = true; //multiselect true olsun
            dataGridViewPizzadaOlmayanMalzemeler.ReadOnly = true;
            dataGridViewPizzadaOlmayanMalzemeler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewPizzaMalzemeleri.Enabled = false;
            dataGridViewPizzadaOlmayanMalzemeler.Enabled = false;

        }

        private void dataGridViewYeniPizza_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnYeniPizza.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;

            //

            //datagridviewden select (seçilmiş) satırı al

            if (dataGridViewYeniPizza.SelectedRows.Count > 0) // gridte bir satır seçiliyse işlem yapar.
            {
                int seciliOlanSatirinIndeksi = dataGridViewYeniPizza.SelectedCells[0].RowIndex;
                if (seciliOlanSatirinIndeksi > -1)
                {
                    DataGridViewRow seciliSatir = dataGridViewYeniPizza.Rows[seciliOlanSatirinIndeksi];
                    textBoxID.Text = seciliSatir.Cells["PizzaIDNo"].Value.ToString(); // isterseniz kolon adı verin
                    textBoxIsim.Text = seciliSatir.Cells["PizzaAdi"].Value.ToString();
                    numericUpDown1.Value = (decimal)seciliSatir.Cells["PizzaBirimFiyati"].Value;
                    dateTimePicker1.Value = (DateTime)seciliSatir.Cells["OlusturmaTarihi"].Value;
                }
            }


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string hataMesaji = string.Empty;
            int silinenKayitSayisi = 0;
            bool pizzaninMalzemeleriVarMi = false;

            if (textBoxID.Text.Length > 0)
            {
                //seçilen pizzanın malzemeleri var mı
                //eğer malzemesi varsa silmeyecek uyarı verecek --> Önce malzemelerini sil sonra pizzayı silebilirsin
                //eğer malzemesi yoksa soru soracak silmek ister misin --> evet derse silecek

                pizzaninMalzemeleriVarMi = pizzaIslem.SeciliPizzaninMalzemeleriVarMi(textBoxID.Text, out hataMesaji);

                if (pizzaninMalzemeleriVarMi)
                {
                    MessageBox.Show("DİKKAT! " + textBoxIsim.Text.ToUpper() + " adlı pizzanın malzemeleri var. Önce malzemelerini silmeniz gerekir! Sonra pizzayı bu ekrandan silebilirsiniz", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (pizzaninMalzemeleriVarMi == false && hataMesaji.Length == 0)
                {
                    DialogResult cevap = MessageBox.Show(textBoxIsim.Text.ToUpper() + " adlı pizzayı sistemden silmek istediğinize emin misiniz?", "SORU", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                    if (cevap == DialogResult.Yes)
                    {
                        silinenKayitSayisi = pizzaIslem.SeciliPizzayiSil(textBoxID.Text, out hataMesaji); // iş katmanından sil
                        if (silinenKayitSayisi == 0 && hataMesaji.Length > 0)
                        {
                            MessageBox.Show("Kayıt SİLİNEMEDİ! BEKLENMEDİK HATA OLUŞTU! HATA: " + hataMesaji, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ProgramKayitlari.ProgramKayitlariDosyasinaYaz("FrmPizzalare ekranında btnSil_Click metodunda hata oluştu. HATA:  " + hataMesaji);

                        }
                        else
                        {
                            MessageBox.Show("Silme işlemi başarılıdır.");
                            //gridleri yenile
                            TumPizzalariGridlereGetir();
                            // butonları aktif ayarla
                            ButonlarinAktiflikleriniAyarla();
                        }
                    }
                }
                else if (hataMesaji.Length > 0)
                {
                    MessageBox.Show("Beklenmedik hata oluştu. HATA: " + hataMesaji);
                }
            }

        }

        private void comboBoxPizzalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewPizzadaOlmayanMalzemeler.Enabled = true;

            //gride pizzada olmayan malzemeler eklenecek
            string hataMesaji = string.Empty;
            long seciliPizzaIDNo = -1;

            //hangi pizza seçili?
            if (comboBoxPizzalar.SelectedIndex > -1)
            {
                seciliPizzaIDNo = (long)comboBoxPizzalar.SelectedValue;
                SeciliPizzadaBulunmayanMalzemeleriDataGrideYukle(seciliPizzaIDNo);
            }

        }

        private void SeciliPizzadaBulunmayanMalzemeleriDataGrideYukle(long seciliPizzaIDNo)
        {
            DataTable tablo = new DataTable();
            string hataMesaji = string.Empty;

            //gride pizzada olmayan malzemeleri getir
            tablo = pizzaIslem.SeciliPizzadaOlmayanMalzemeleriGetir(seciliPizzaIDNo, out hataMesaji);
            if (hataMesaji.Length > 0)
            {
                MessageBox.Show("Beklenmedik hata: " + hataMesaji);
            }
            else
            {
                dataGridViewPizzadaOlmayanMalzemeler.DataSource = tablo;
                foreach (DataGridViewColumn item in dataGridViewPizzadaOlmayanMalzemeler.Columns)
                {
                    item.Width = 195;
                }
            }
        }

        private void dataGridViewPizzadaOlmayanMalzemeler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //btnyi ayarla
            btnPizzayaMalzemeEkle.Enabled = true;

        }

        private void btnPizzayaMalzemeEkle_Click(object sender, EventArgs e)
        {
            long seciliPizzaIDNo = (long)comboBoxPizzalar.SelectedValue;
            string hataMesaji = string.Empty;

            //dataGridView nesnesindeki seçilenleri al
            List<long> eklenecekMalzemelerinIDleri = new List<long>();
            int eklenenSatirSayisi = 0;
            if (dataGridViewPizzadaOlmayanMalzemeler.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dataGridViewPizzadaOlmayanMalzemeler.SelectedRows.Count; i++)
                {
                    DataGridViewRow satir = dataGridViewPizzadaOlmayanMalzemeler.SelectedRows[i];
                    long malzemeid = (long)satir.Cells["MalzemeId"].Value;
                    //bu malzeme id yi ekleyeceğiz
                    eklenecekMalzemelerinIDleri.Add(malzemeid);
                }
                if (eklenecekMalzemelerinIDleri.Count > 0)
                {
                    eklenenSatirSayisi = pizzaIslem.PizzayaYeniMalzemeEkle(eklenecekMalzemelerinIDleri, seciliPizzaIDNo, out hataMesaji);

                    if (hataMesaji.Length > 0)
                    {
                        MessageBox.Show("Beklenmedik hata: " + hataMesaji);
                    }
                    else
                    {
                        MessageBox.Show(eklenenSatirSayisi.ToString() + " adet malzeme eklendi");

                        //yenile
                        btnPizzayaMalzemeEkle.Enabled = false;
                        SeciliPizzadaBulunmayanMalzemeleriDataGrideYukle(seciliPizzaIDNo);
                        //gridi false ayarla
                        dataGridViewPizzaMalzemeleri.DataSource = null;
                        dataGridViewPizzaMalzemeleri.Enabled = false;
                    }
                }
            }
        }

        private void dataGridViewPizzalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //seçili pizzanın tüm malzemeleri gelsin
            long seciliPizzaId = (long)dataGridViewPizzalar.SelectedRows[0].Cells["PizzaIDno"].Value;


            //malzemeler varsa gelsin
            string hataMesaji = string.Empty;
            bool malzemesiVarMi = pizzaIslem.SeciliPizzaninMalzemeleriVarMi(seciliPizzaId.ToString(), out hataMesaji);

            if (hataMesaji.Length == 0 && malzemesiVarMi)
            {
                //gride getir
                hataMesaji = string.Empty;
                DataTable malzemeTablo = new DataTable();
                malzemeTablo = pizzaIslem.SeciliPizzadaBulunanMalzemeleriGetir(seciliPizzaId, out hataMesaji);
                if (hataMesaji.Length > 0)
                {
                    MessageBox.Show("Beklenmedik hata: " + hataMesaji);

                }
                else
                {
                    dataGridViewPizzaMalzemeleri.Enabled = true;
                    dataGridViewPizzaMalzemeleri.DataSource = malzemeTablo;
                    foreach (DataGridViewColumn item in dataGridViewPizzaMalzemeleri.Columns)
                    {
                        item.Width = 195;
                    }

                }

            }
            else if (hataMesaji.Length == 0 && malzemesiVarMi == false)
            {
                MessageBox.Show("Bu pizzaya ait malzeme hiç yoktur. Malzeme Ekleme ekranından ekleyiniz!");
                dataGridViewPizzaMalzemeleri.Enabled = false;
                dataGridViewPizzaMalzemeleri.DataSource = null;

            }
            else
            {
                MessageBox.Show("Beklenmedik hata: " + hataMesaji);
                dataGridViewPizzaMalzemeleri.Enabled = false;
                dataGridViewPizzaMalzemeleri.DataSource = null;

            }

        }

        private void seçiliOlanMalzemeyiPizzadanSilToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //secili pizza id 
            long seciliPizzaId = -1;
            if (dataGridViewPizzalar.SelectedRows.Count > 0)
            {
                seciliPizzaId = (long)dataGridViewPizzalar.SelectedRows[0].Cells["PizzaIDno"].Value;
            }

            long seciliMalzemeID = -1;
            string seciliMalzemeninAdi = string.Empty;
            string hataMesaji = String.Empty;

            //seçili malzemeyi bul

            if (dataGridViewPizzaMalzemeleri.SelectedRows.Count > 0) // gridte bir satır seçiliyse işlem yapar.
            {
                int seciliOlanSatirinIndeksi = dataGridViewPizzaMalzemeleri.SelectedCells[0].RowIndex;
                if (seciliOlanSatirinIndeksi > -1)
                {
                    DataGridViewRow seciliSatir = dataGridViewPizzaMalzemeleri.Rows[seciliOlanSatirinIndeksi];

                    seciliMalzemeID = (long)seciliSatir.Cells["MalzemeId"].Value;
                    seciliMalzemeninAdi = seciliSatir.Cells["MalzemeAdi"].Value.ToString();
                    seciliMalzemeninAdi = seciliSatir.Cells["MalzemeAdi"].Value.ToString();

                    DialogResult cevap = MessageBox.Show(seciliMalzemeninAdi + " adlı malzemeyi bu pizzadan silmek istediğinize emin misiniz?", "SORU", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                    if (cevap == DialogResult.Yes)
                    {
                        int silinen = pizzaIslem.SeciliOlanMalzemeyiSeciliOlanPizzadanSil(seciliPizzaId, seciliMalzemeID, out hataMesaji);
                        if (hataMesaji.Length > 0)
                        {
                            MessageBox.Show("Beklenmedik hata: " + hataMesaji);

                        }
                        else if (silinen > 0)
                        {
                            MessageBox.Show("Malzeme pizzadan silinmiştir!");
                            //yenile
                            dataGridViewPizzaMalzemeleri.Enabled = false;
                            dataGridViewPizzaMalzemeleri.DataSource = null;
                            // Ekle sayfasındaki veriler de yenilensin

                            //hangi pizza seçili?
                            if (comboBoxPizzalar.SelectedIndex > -1)
                            {
                                SeciliPizzadaBulunmayanMalzemeleriDataGrideYukle((long)comboBoxPizzalar.SelectedValue);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Malzeme pizzadan silinme işlemi başarısız!");
                            //yenile
                            dataGridViewPizzaMalzemeleri.Enabled = false;
                            dataGridViewPizzaMalzemeleri.DataSource = null;
                        }
                    }


                }
            }

        }
    }
}
