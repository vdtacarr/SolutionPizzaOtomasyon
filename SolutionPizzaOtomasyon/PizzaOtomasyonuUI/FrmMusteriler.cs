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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }
        #region GlobalAlanDegiskenleri 
        MusterilerIslemleri musterilerIslemleri = new MusterilerIslemleri();
        string hataMesaji = string.Empty;

        #endregion

        #region GlobalProperty
        public long SatisEkraninaGonderilecekSeciliMusteriIDNo { get; set; }
        #endregion
        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            ProgramKayitlari.ProgramKayitlariDosyasinaYaz("###### frmMusteri formu açıldı #####");

            btnYeniMusteri.Enabled = true;
            btnSil.Enabled = false;
            btnGuncelle.Enabled = false;

            //context menu ayarı
            dataGridViewMusteri.ContextMenuStrip = contextMenuStrip1;

            //SatisEkraninaGonderilecekSeciliMusteriIDNo setle (atama yap)
            SatisEkraninaGonderilecekSeciliMusteriIDNo = -1;

            dataGridViewMusteri.ReadOnly = true;
            dataGridViewMusteri.AllowUserToAddRows = false;
            dataGridViewMusteri.AllowUserToDeleteRows = false;
            dataGridViewMusteri.MultiSelect = false;
            dataGridViewMusteri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewYeniMusteri.ReadOnly = true;
            dataGridViewYeniMusteri.AllowUserToAddRows = false;
            dataGridViewYeniMusteri.AllowUserToDeleteRows = false;
            dataGridViewYeniMusteri.MultiSelect = false;
            dataGridViewYeniMusteri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewMusteri.DataSource = null;
            dataGridViewYeniMusteri.DataSource = null;
            GridleriDoldur();

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string aranacakAd = textBoxAd.Text.Trim();
            string aranacakSoyad = textBoxSoyad.Text.Trim();

            dataGridViewMusteri.DataSource = null;
            string hataMesaji = string.Empty;
            DataTable tablo = new DataTable();
            tablo = musterilerIslemleri.AdveSoyadaGoreMusteriAra(aranacakAd, aranacakSoyad, out hataMesaji);
            if (hataMesaji.Length > 0)
            {
                MessageBox.Show("Beklenmedik hata oluştu! HATA: " + hataMesaji);
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("FrmMusteriler ekranında btnAra_Click  metodunda hata oldu. HATA:  " + hataMesaji);

            }
            else if (tablo.Rows.Count > 0)
            {
                dataGridViewMusteri.DataSource = tablo;
                MessageBox.Show(tablo.Rows.Count.ToString() + " adet kayıt bulundu.");
            }
            else
            {
                MessageBox.Show("Aradığınız kişi sistemde bulunmuyor!");
                GridleriDoldur();
            }

            AramaTextleriniTemizle();

        }

        private void GridleriDoldur()
        {
            hataMesaji = string.Empty;
            DataTable sanalTablo = musterilerIslemleri.MusterilerdenSilinmeyenHerkesiDataTableIcineYukle(out hataMesaji);
            if (sanalTablo == null && hataMesaji.Length > 0)
            {
                MessageBox.Show("Beklenmedik hata oluştu! HATA: " + hataMesaji);
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("FrmMusteriler_Load ekranında hata oldu. HATA:  " + hataMesaji);
            }
            else
            {
                dataGridViewMusteri.DataSource = sanalTablo;
                dataGridViewYeniMusteri.DataSource = sanalTablo;
            }
        }

        private void AramaTextleriniTemizle()
        {
            textBoxAd.Clear();
            textBoxSoyad.Clear();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            btnYeniMusteri.Enabled = true;
            btnSil.Enabled = false;
            btnGuncelle.Enabled = false;

        }
        private void YeniMusteriEklemeTabSayfasindakiTextleriniTemizle()
        {
            textBoxID.Clear();
            textBoxIsim.Clear();
            textBoxSoyIsim.Clear();
            maskedTextBoxTelefon1.Clear();
            maskedTextBoxTelefon2.Clear();
            maskedTextBoxTelefon3.Clear();
        }

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            string hataMesaji = string.Empty;
            // yeni kişi ekle
            int eklenenKayitSayisi = 0;
            //gelen değerlere göre yeni müşteri eklenecek
            //Eğer textbox isim ve soyisim boş ise eklemesin
            if (string.IsNullOrEmpty(textBoxIsim.Text.Trim()) || string.IsNullOrEmpty(textBoxSoyIsim.Text.Trim()))
            {
                MessageBox.Show("Yeni kişi eklemek için isim ve soyisim girilmelidir!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (musterilerIslemleri.AyniKisidenSistemdeVarMi(textBoxIsim.Text.Trim(), textBoxSoyIsim.Text.Trim(), maskedTextBoxTelefon1.Text.Trim(), maskedTextBoxTelefon2.Text.Trim(), maskedTextBoxTelefon3.Text.Trim(), out hataMesaji)) // aynısından varsa eklemesin!
            {
                if (hataMesaji.Length > 0)
                {
                    MessageBox.Show("Beklenmedik bir hata oluştu! HATA: " + hataMesaji, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Bu kişiden zaten sistemde bulunuyor! ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else // eklesin
            {
                eklenenKayitSayisi = musterilerIslemleri.YeniMusteriEklemekIcinGonder(textBoxIsim.Text.Trim(), textBoxSoyIsim.Text.Trim(), maskedTextBoxTelefon1.Text.Trim(), maskedTextBoxTelefon2.Text.Trim(), maskedTextBoxTelefon3.Text.Trim(), out hataMesaji);
                if (hataMesaji.Length > 0 && eklenenKayitSayisi == 0)
                {
                    MessageBox.Show("Kayıt EKLENEMEDİ! BEKLENMEDİK HATA OLUŞTU! HATA: " + hataMesaji, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ProgramKayitlari.ProgramKayitlariDosyasinaYaz("FrmMusteri ekranında btnYeniMusteri_Click metodunda hata oluştu. HATA:  " + hataMesaji);
                }
                else
                {
                    MessageBox.Show("Kayıt başarılı olarak eklendi");
                    //ekranı temizle
                    YeniMusteriEklemeTabSayfasindakiTextleriniTemizle();
                    //gridleri yeniden doldur
                    GridleriDoldur();

                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //güncelle işlemleri
            int guncellenenKayitSayisi = 0;
            string hataMesaji = string.Empty;
            if (textBoxID.Text.Length > 0)
            {
                guncellenenKayitSayisi = musterilerIslemleri.MusteriyiYeniBilgilerleGuncelle(textBoxIsim.Text.Trim(), textBoxSoyIsim.Text.Trim(), maskedTextBoxTelefon1.Text.Trim(), maskedTextBoxTelefon2.Text.Trim(), maskedTextBoxTelefon3.Text.Trim(), textBoxID.Text, out hataMesaji);
                if (guncellenenKayitSayisi == 0 && hataMesaji.Length > 0)
                {
                    MessageBox.Show("Kayıt GÜNCELLENMEDİ! BEKLENMEDİK HATA OLUŞTU! HATA: " + hataMesaji, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ProgramKayitlari.ProgramKayitlariDosyasinaYaz("FrmMusteri ekranında btnGuncelle_Click metodunda hata oluştu. HATA:  " + hataMesaji);
                }
                else
                {
                    MessageBox.Show("Kayıt başarılı olarak güncellendi");
                    //ekranı temizle
                    YeniMusteriEklemeTabSayfasindakiTextleriniTemizle();
                    //gridleri yeniden doldur
                    GridleriDoldur();
                    //btnler
                    btnYeniMusteri.Enabled = true;
                    btnGuncelle.Enabled = false;
                    btnSil.Enabled = false;

                }
            }

        }

        private void dataGridViewYeniMusteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //btnlerin aktifliklerini ayarla
            btnYeniMusteri.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;

            //datagridviewden select (seçilmiş) satırı al

            if (dataGridViewYeniMusteri.SelectedRows.Count > 0) // gridte bir satır seçiliyse işlem yapar.
            {
                int seciliOlanSatirinIndeksi = dataGridViewYeniMusteri.SelectedCells[0].RowIndex;
                if (seciliOlanSatirinIndeksi > -1)
                {
                    DataGridViewRow seciliSatir = dataGridViewYeniMusteri.Rows[seciliOlanSatirinIndeksi];
                    textBoxID.Text = seciliSatir.Cells["MusteriIDNo"].Value.ToString(); // isterseniz kolon adı verin
                    textBoxIsim.Text = seciliSatir.Cells[1].Value.ToString(); // isterseniz kolon index numarasını verin
                    textBoxSoyIsim.Text = seciliSatir.Cells["MusteriSoyadi"].Value.ToString();
                    maskedTextBoxTelefon1.Text = seciliSatir.Cells["Telefon1"].Value.ToString();
                    maskedTextBoxTelefon2.Text = seciliSatir.Cells["Telefon2"].Value.ToString();
                    maskedTextBoxTelefon3.Text = seciliSatir.Cells["Telefon3"].Value.ToString();

                }
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show(textBoxIsim.Text.ToUpper() + " " + textBoxSoyIsim.Text.ToUpper() + " isimli müşteriyi silmek istediğinize emin misiniz?", "SORU", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
                , MessageBoxDefaultButton.Button2);

            if (cevap == DialogResult.Yes)
            {
                //bu kişiyi sil --> silme işlemini FAKE yani sahte silme sanal silme (soft delete) şeklinde yapacağız. Yani SilindiMi= olacak
                int silinenKayitSayisi = 0;
                if (textBoxID.Text.Length > 0)
                {
                    silinenKayitSayisi = musterilerIslemleri.MusteriyiSil(textBoxID.Text, out hataMesaji);
                    if (silinenKayitSayisi == 0 && hataMesaji.Length > 0)
                    {
                        MessageBox.Show("Kayıt SİLİNEMEDİ! BEKLENMEDİK HATA OLUŞTU! HATA: " + hataMesaji, "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ProgramKayitlari.ProgramKayitlariDosyasinaYaz("FrmMusteri ekranında btnSil_Click metodunda hata oluştu. HATA:  " + hataMesaji);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt başarılı olarak silindi");
                        //ekranı temizle
                        YeniMusteriEklemeTabSayfasindakiTextleriniTemizle();
                        //gridleri yeniden doldur
                        GridleriDoldur();
                        //btnler
                        btnYeniMusteri.Enabled = true;
                        btnGuncelle.Enabled = false;
                        btnSil.Enabled = false;

                    }
                }

            }
            else if (cevap == DialogResult.No) // silmiyorum diye mesaj verebilirsiniz.
            {

            }
        }


        private void secilenMusteriyiGonderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //seçilen müşteriyi al7

            if (dataGridViewMusteri.SelectedRows.Count > 0)
            {
                SatisEkraninaGonderilecekSeciliMusteriIDNo = (long)dataGridViewMusteri.SelectedRows[0].Cells["MusteriIDNo"].Value;
            }
            else
            {
                SatisEkraninaGonderilecekSeciliMusteriIDNo = -1;
            }
        }

        private void secilenMusteriyiSatisEkranindanTemizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SatisEkraninaGonderilecekSeciliMusteriIDNo = -1;

        }

        private void FrmMusteriler_FormClosed(object sender, FormClosedEventArgs e)
        {
            var frm = Application.OpenForms.OfType<FrmPizzaSatis>().Where(x => x.Name == "FrmPizzaSatis").FirstOrDefault();
            string hataMesaji = string.Empty;

            //FrmPizzaSatis frm = Application.OpenForms.Cast<FrmPizzaSatis>().Where(x => x.Name == "FrmPizzaSatis").FirstOrDefault();
            if (frm != null && SatisEkraninaGonderilecekSeciliMusteriIDNo > -1)
            {
                frm.SecilmisOlanMusteri = musterilerIslemleri.IDyeGoreMusteriBul(SatisEkraninaGonderilecekSeciliMusteriIDNo, out hataMesaji);
                if (hataMesaji.Length > 0)
                {
                    frm.SecilmisOlanMusteri = null;
                    MessageBox.Show("Müşteri bulmada hata oldu: " + hataMesaji);
                }

            }
        }
    }
}
