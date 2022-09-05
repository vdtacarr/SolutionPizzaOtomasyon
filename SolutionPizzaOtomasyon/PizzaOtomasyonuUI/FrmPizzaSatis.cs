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
    public partial class FrmPizzaSatis : Form
    {
        //property
        public Musteriler SecilmisOlanMusteri { get; set; }

        public FrmPizzaSatis()
        {
            InitializeComponent();
            SecilmisOlanMusteri = null;
        }

        //Global Alan Değişkenleri
        PizzaIslemleri pizzaIslem = new PizzaIslemleri();
        List<PizzaVeMalzemeleri> comboboBoxIcineEklenenPizzalarListesi = new List<PizzaVeMalzemeleri>();
        MalzemeIslemleri malzemeIslemleri = new MalzemeIslemleri();
        MusterilerIslemleri musteriIslemim = new MusterilerIslemleri();
        decimal seciliPizzaFiyati = 0m;
        PizzaVeMalzemeleri seciliPizza = null;
        List<Siparis> Siparisler = new List<Siparis>();
        SatisIslemleri satisIslemim = new SatisIslemleri();

        private void müşteriİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMusteriler frmMusteriler = new FrmMusteriler();
            frmMusteriler.ShowDialog();
        }


        private void pizzaİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPizzalar frmPizzalar = new FrmPizzalar();
            frmPizzalar.ShowDialog();
        }

        private void radioButtonAnonim_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FrmPizzaSatis_Load(object sender, EventArgs e)
        {
            //context menu strip
            listBoxSiparis.ContextMenuStrip = contextMenuStrip1;


            //labelleri temizle
            lblSeciliPizzaTutarTL.Text = "0";
            lblToplamTutar.Text = "0";
            // tikleri temizlemek
            CheckedListBoxMalzemelerTikleriniTemizle();
            // tikleri temizlemek
            CheckedListBoxEkstraMalzemelerTikleriniTemizle();
            // enable ayarla
            checkBoxEkstraMalzemeIstiyorMu.Checked = false;
            checkedListBoxEkstraMalzemeler.Enabled = false;


            #region  combobBox_Doldur
            string hataMesaji = string.Empty;
            comboboBoxIcineEklenenPizzalarListesi = pizzaIslem.TumPizzalariMalzemeleriyleBeraberListele(out hataMesaji);

            if (hataMesaji.Length > 0)
            {
                MessageBox.Show("Beklenmedik hata oluştu!" + hataMesaji);
            }
            else
            {
                comboBoxPizzalar.ValueMember = "PizzaID";
                comboBoxPizzalar.DisplayMember = "PizzaBilgileri";
                comboBoxPizzalar.DataSource = comboboBoxIcineEklenenPizzalarListesi;
            }
            #endregion

            #region CheckBoxlari_Malzemeler_ile_Doldur
            CheckBoxlariMalzemelerleDoldur();
            #endregion

            #region Secili_Malzemelere_Tik_At

            //tik at
            SeciliPizzaninMalzemelerineTikAt();

            #endregion

            #region Fiyat_Hesapla
            CheckBoxlardakiSecimeGorePizzaBirinFiyatHesapla();
            #endregion
        }

        private void CheckBoxlardakiSecimeGorePizzaBirinFiyatHesapla()
        {
            // temizle
            seciliPizzaFiyati = 0m;

            string hataMesaji = string.Empty;
            //checkedListBoxMalzemeler 
            for (int i = 0; i < checkedListBoxMalzemeler.Items.Count; i++)
            {
                if (checkedListBoxMalzemeler.GetItemCheckState(i) == CheckState.Checked) //tikli mi?
                {
                    int tireninIndexi = checkedListBoxMalzemeler.Items[i].ToString().LastIndexOf(" - ");
                    string malzemeAdi = tireninIndexi > -1 ? checkedListBoxMalzemeler.Items[i].ToString().Substring(0, tireninIndexi) :
                         checkedListBoxMalzemeler.Items[i].ToString();
                    hataMesaji = string.Empty;
                    decimal malzemeninFiyat = malzemeIslemleri.MalzemeninAdinaGoreFiyatiniGetir(malzemeAdi, out hataMesaji);
                    if (hataMesaji.Length > 0)
                    {
                        seciliPizzaFiyati = 0;
                        MessageBox.Show("Beklenmedik hata oldu. HATA:" + hataMesaji);
                        break;
                    }
                    else
                    {
                        seciliPizzaFiyati += malzemeninFiyat;
                    }
                }
            }

            if (hataMesaji.Length == 0)
            {
                // ekstra malzemeler
                for (int i = 0; i < checkedListBoxEkstraMalzemeler.Items.Count; i++)
                {
                    if (checkedListBoxEkstraMalzemeler.GetItemCheckState(i) == CheckState.Checked) //tikli mi?
                    {
                        int tireninIndexi = checkedListBoxEkstraMalzemeler.Items[i].ToString().LastIndexOf(" - ");
                        string malzemeAdi = tireninIndexi > -1 ? checkedListBoxEkstraMalzemeler.Items[i].ToString().Substring(0, tireninIndexi) :
                             checkedListBoxMalzemeler.Items[i].ToString();
                        hataMesaji = string.Empty;
                        decimal malzemeninFiyat = malzemeIslemleri.MalzemeninAdinaGoreFiyatiniGetir(malzemeAdi, out hataMesaji);
                        if (hataMesaji.Length > 0)
                        {
                            seciliPizzaFiyati = 0;
                            MessageBox.Show("Beklenmedik hata oldu. HATA:" + hataMesaji);
                            break;
                        }
                        else
                        {
                            seciliPizzaFiyati += malzemeninFiyat;
                        }
                    }
                }

            }

            //labela yazdır
            lblSeciliPizzaTutarTL.Text = seciliPizzaFiyati.ToString("0.00");
        }

        private void SeciliPizzaninMalzemelerineTikAt()
        {
            if (comboBoxPizzalar.SelectedIndex > -1)
            {
                long pizzaid = (long)comboBoxPizzalar.SelectedValue;
                if (pizzaid > 0)
                {
                    seciliPizza = comboboBoxIcineEklenenPizzalarListesi.FirstOrDefault(eleman => eleman.Pizza.PizzaIDno == pizzaid);
                    if (seciliPizza.PizzaninMalzemeleri.Count > 0)
                    {
                        for (int i = 0; i < checkedListBoxMalzemeler.Items.Count; i++)
                        {
                            int tireninIndeksi = checkedListBoxMalzemeler.Items[i].ToString().LastIndexOf(" - ");
                            string malzemeninAdi = tireninIndeksi > -1 ? checkedListBoxMalzemeler.Items[i].ToString().Substring(0, tireninIndeksi) : checkedListBoxMalzemeler.Items[i].ToString();
                            if (seciliPizza.PizzaninMalzemeleri.Exists(x => x.MalzemeAdi == malzemeninAdi))
                            {
                                checkedListBoxMalzemeler.SetItemChecked(i, true);
                            }
                        }
                    }
                }
            }
        }

        private void CheckBoxlariMalzemelerleDoldur()
        {
            //bütün malzemeleri getir

            List<Malzemeler> tumMalzemeler = new List<Malzemeler>();
            string hataMesaji = string.Empty;
            tumMalzemeler = malzemeIslemleri.TumMalzemeleriSilinenHaricListele(out hataMesaji);
            if (hataMesaji.Length > 0)
            {
                MessageBox.Show("Beklenmedik hata oluştu!" + hataMesaji);
            }

            else
            {
                foreach (Malzemeler item in tumMalzemeler)
                {
                    checkedListBoxMalzemeler.Items.Add(item.MalzemeAdi + " - " + item.BirimFiyati.ToString("0.00"));
                    checkedListBoxEkstraMalzemeler.Items.Add(item.MalzemeAdi + " - " + item.BirimFiyati.ToString("0.00"));
                }
            }
        }

        private void comboBoxPizzalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //seciliPizzaFiyati temizle
            seciliPizzaFiyati = 0m;

            if (radioButtonAnonim.Checked == false && radioButtonKayitliMusteri.Checked == false)
            {
                //seçili kişiyi temizle
                SecilmisOlanMusteri = null;
            }

            //enable ayarla
            checkedListBoxEkstraMalzemeler.Enabled = false;
            checkedListBoxMalzemeler.Enabled = true;
            checkBoxEkstraMalzemeIstiyorMu.Enabled = true;
            checkBoxEkstraMalzemeIstiyorMu.Checked = false;

            // tikleri temizlemek
            CheckedListBoxMalzemelerTikleriniTemizle();
            // tikleri temizlemek
            CheckedListBoxEkstraMalzemelerTikleriniTemizle();

            //seçili olan değer değişince tekrar malzemelerine tik at
            SeciliPizzaninMalzemelerineTikAt();



            #region Fiyat_Hesapla
            CheckBoxlardakiSecimeGorePizzaBirinFiyatHesapla();
            #endregion
        }

        private void CheckedListBoxEkstraMalzemelerTikleriniTemizle()
        {
            for (int i = 0; i < checkedListBoxEkstraMalzemeler.Items.Count; i++)
            {
                checkedListBoxEkstraMalzemeler.SetItemChecked(i, false);
            }
        }

        private void CheckedListBoxMalzemelerTikleriniTemizle()
        {
            for (int i = 0; i < checkedListBoxMalzemeler.Items.Count; i++)
            {
                checkedListBoxMalzemeler.SetItemChecked(i, false);
            }
        }

        private void checkBoxEkstraMalzemeIstiyorMu_CheckedChanged(object sender, EventArgs e)
        {
            //temizleme
            CheckedListBoxEkstraMalzemelerTikleriniTemizle();
            if (checkBoxEkstraMalzemeIstiyorMu.Checked)
            {
                checkedListBoxEkstraMalzemeler.Enabled = true;
            }
            else
            {
                checkedListBoxEkstraMalzemeler.Enabled = false;

            }
            #region Fiyat_Hesapla
            CheckBoxlardakiSecimeGorePizzaBirinFiyatHesapla();
            #endregion
        }

        private void checkedListBoxMalzemeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            // items.count > 0 olmalıdır. yoksa uyarı mesajı versin 
            if (checkedListBoxMalzemeler.CheckedItems.Count == 0)
            {
                MessageBox.Show("Malzemeler listesinde malzeme seçilmelidir!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //enable ayarla
                checkBoxEkstraMalzemeIstiyorMu.Checked = false;

                // tikleri temizlemek
                CheckedListBoxMalzemelerTikleriniTemizle();
                // tikleri temizlemek
                CheckedListBoxEkstraMalzemelerTikleriniTemizle();
            }

            #region Fiyat_Hesapla
            CheckBoxlardakiSecimeGorePizzaBirinFiyatHesapla();
            #endregion
        }

        private void checkedListBoxEkstraMalzemeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Fiyat_Hesapla
            CheckBoxlardakiSecimeGorePizzaBirinFiyatHesapla();
            #endregion
        }

        private void radioButtonKayitliMusteri_Click(object sender, EventArgs e)
        {
            if (radioButtonKayitliMusteri.Checked)
            {
                FrmMusteriler frmMusteriler = new FrmMusteriler();
                frmMusteriler.ShowDialog();
            }

        }

        private void btnSiparisEkle_Click(object sender, EventArgs e)
        {

            Siparis yeniSiparis = null;

            // öncelikle müşteri var mı
            //müşteri yoksa sipariş eklemesin
            if (SecilmisOlanMusteri == null || SecilmisOlanMusteri.MusteriIDNo < 0)
            {
                MessageBox.Show("Müşteri seçmeden sipariş oluşturamazsınız! Lütfen müşteri seçiniz!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // checkedListBoxMalzemeler checkeditems count > 0
            else if (checkedListBoxMalzemeler.CheckedItems.Count == 0)
            {
                MessageBox.Show("Malzemesi olmayan pizzaya sipariş oluşturamazsınız! Lütfen pizzaya malzeme seçiniz!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // sipariş oluşturulacak
                // yandaki listeye eklenecek
                yeniSiparis = new Siparis()
                {
                    Adeti = 1,
                    BirimFiyati = seciliPizzaFiyati,
                    Musteri = SecilmisOlanMusteri,
                    Pizza = seciliPizza.Pizza,
                    EkstraMalzemeEklenmisMi = false,
                    PizzaninMalzemeleriListesi = new List<Malzemeler>(),
                    EkstraMalzemeleriListesi = new List<Malzemeler>(),
                    OlusturulmaTarihi = DateTime.Now
                };


                string hataMesaji = string.Empty;
                List<Malzemeler> tumMalzemeler = malzemeIslemleri.TumMalzemeleriSilinenHaricListele(out hataMesaji);

                if (hataMesaji.Length == 0)
                {
                    //malzemeleri al
                    for (int i = 0; i < checkedListBoxMalzemeler.Items.Count; i++)
                    {
                        if (checkedListBoxMalzemeler.GetItemCheckState(i) == CheckState.Checked) //tikli mi?
                        {
                            int tireninIndexi = checkedListBoxMalzemeler.Items[i].ToString().LastIndexOf(" - ");
                            string malzemeAdi = tireninIndexi > -1 ? checkedListBoxMalzemeler.Items[i].ToString().Substring(0, tireninIndexi) :
                                 checkedListBoxMalzemeler.Items[i].ToString();

                            //malzemenin adına göre listeden çek
                            Malzemeler m = tumMalzemeler.FirstOrDefault(x => x.MalzemeAdi.ToLower() == malzemeAdi.ToLower());
                            if (m != null)
                            {
                                yeniSiparis.PizzaninMalzemeleriListesi.Add(m);
                            }

                        }

                    }

                    //ekstra malzeme eklenmiş mi
                    if (checkBoxEkstraMalzemeIstiyorMu.Checked)
                    {
                        yeniSiparis.EkstraMalzemeEklenmisMi = true;

                        // ekstra malzemeler

                        for (int i = 0; i < checkedListBoxEkstraMalzemeler.Items.Count; i++)
                        {
                            if (checkedListBoxEkstraMalzemeler.GetItemCheckState(i) == CheckState.Checked) //tikli mi?
                            {
                                int tireninIndexi = checkedListBoxEkstraMalzemeler.Items[i].ToString().LastIndexOf(" - ");
                                string malzemeAdi = tireninIndexi > -1 ? checkedListBoxEkstraMalzemeler.Items[i].ToString().Substring(0, tireninIndexi) :
                                     checkedListBoxEkstraMalzemeler.Items[i].ToString();

                                //malzemenin adına göre listeden çek
                                Malzemeler m = tumMalzemeler.FirstOrDefault(x => x.MalzemeAdi.ToLower() == malzemeAdi.ToLower());
                                if (m != null)
                                {
                                    yeniSiparis.EkstraMalzemeleriListesi.Add(m);
                                }

                            }

                        }

                    }
                }
                else // hatamesajı alırsa
                {
                    yeniSiparis = null;
                    MessageBox.Show("Beklenmedik HATA: " + hataMesaji);
                }



            }

            //EĞER yeniSiparis null değilse listeye eklesin

            if (yeniSiparis != null)
            {
                Siparisler.Add(yeniSiparis);
                SiparisListesiniYenile();
                MessageBox.Show("Sipariş listeye eklendi! Satış yapabilirsiniz. ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //yenile
                comboBoxPizzalar.SelectedIndex = -1;
                checkedListBoxEkstraMalzemeler.Enabled = false;
                checkedListBoxMalzemeler.Enabled = false;
                checkBoxEkstraMalzemeIstiyorMu.Enabled = false;
                radioButtonAnonim.Checked = false;
                radioButtonKayitliMusteri.Checked = false;
                //seçili kişiyi temizle
                SecilmisOlanMusteri = null;


            }
            else
            {
                MessageBox.Show("SİPARİŞ EKLENMEDİ! OLUŞAN HATAYI SİSTEM YÖNETİCİSİNE BİLDİRİNİZ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SiparisListesiniYenile()
        {
            listBoxSiparis.DataSource = null;
            listBoxSiparis.ValueMember = "ID";
            listBoxSiparis.DisplayMember = "Bilgileri";
            listBoxSiparis.DataSource = Siparisler;
            decimal tutar = 0m;
            foreach (var item in Siparisler)
            {
                tutar += item.ToplamFiyat;
            }
            lblToplamTutar.Text = tutar.ToString("0.00");
        }

        private void hepsiniTemizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Siparis listesini tamamen silmek istediğinize emin misiniz?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (cevap == DialogResult.Yes)
            {
                Siparisler.Clear();
            }
            SiparisListesiniYenile();
        }

        private void adetArttirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // secçili olan siparişi bul
            var seciliDeger = listBoxSiparis.SelectedValue;
            var seciliSiparis = Siparisler.FirstOrDefault(x => x.ID == seciliDeger.ToString());
            if (seciliSiparis != null)
            {
                seciliSiparis.Adeti++;
            }
            SiparisListesiniYenile();

        }

        private void adetAzaltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // secçili olan siparişi bul
            var seciliDeger = listBoxSiparis.SelectedValue;
            var seciliSiparis = Siparisler.FirstOrDefault(x => x.ID == seciliDeger.ToString());
            if (seciliSiparis != null)
            {
                if (seciliSiparis.Adeti > 1)
                {

                    seciliSiparis.Adeti--;
                }
                else
                {
                    DialogResult cevap = MessageBox.Show("Sipariş 1 adettir. Siparişi silmek  istediğinize emin misiniz?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (cevap == DialogResult.Yes)
                    {
                        Siparisler.Remove(seciliSiparis);
                    }
                }
            }
            SiparisListesiniYenile();
        }

        private void radioButtonAnonim_Click(object sender, EventArgs e)
        {
            if (radioButtonAnonim.Checked)
            {
                //Musteriyi getir
                string hataMesaji = string.Empty;
                SecilmisOlanMusteri = musteriIslemim.AdveSoyadaGoreMusteriBul("Anonim", "Anonim", out hataMesaji);
                if (hataMesaji.Length > 0)
                {
                    SecilmisOlanMusteri = null;
                    MessageBox.Show("Beklenmedik hata: " + hataMesaji);
                }
            }
            else
            {
                SecilmisOlanMusteri = null;
            }
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            //satış yap :D 
            string hataMesaji = string.Empty;
            int eklenenSatir = 0;
            if (Siparisler.Count > 0)
            {

                eklenenSatir = satisIslemim.SatisEkle(out hataMesaji, Siparisler);
                if (hataMesaji.Length > 0)
                {
                    MessageBox.Show("SATIŞ İŞLEMİ BAŞARISIZDIR! HATA: " + hataMesaji);
                }
                else if (eklenenSatir > 0)
                {
                    MessageBox.Show("SATIŞ BAŞARILIDIR!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //yenileme
                    Siparisler.Clear();
                    SiparisListesiniYenile();
                    // 
                    //yenile
                    comboBoxPizzalar.SelectedIndex = -1;
                    checkedListBoxEkstraMalzemeler.Enabled = false;
                    checkedListBoxMalzemeler.Enabled = false;
                    checkBoxEkstraMalzemeIstiyorMu.Enabled = false;
                    radioButtonAnonim.Checked = false;
                    radioButtonKayitliMusteri.Checked = false;
                    //seçili kişiyi temizle
                    SecilmisOlanMusteri = null;
                    // 
                    seciliPizzaFiyati = 0m;
                }
            }
            else
            {
                MessageBox.Show("Satış yapmak için sipariş oluşturmalısınız!l", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
