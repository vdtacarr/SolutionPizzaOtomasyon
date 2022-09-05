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

namespace PizzaOtomasyonuUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region GlobalAlanDegiskenleri
        string kullaniciAdi = string.Empty;
        string sifre = string.Empty;
        bool bulduMu = false;
        ElemanIslemleri elemanIslemim = new ElemanIslemleri();
        string hataMesaji = string.Empty;
        #endregion  
        private void Form1_Load(object sender, EventArgs e)
        {
            //program çalıştı 
            ProgramKayitlari.ProgramKayitlariDosyasinaYaz("##### PROGRAM BAŞLADI #####");
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {

            // gİRİŞ YAPILACAK
            if (string.IsNullOrEmpty(txtKullanici.Text.Trim()) || string.IsNullOrEmpty(txtSifre.Text.Trim()))
            {
                MessageBox.Show("Lütfen bilgilerinizi giriniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else // değerler varsa kontrol edilecek
            {
                kullaniciAdi = txtKullanici.Text.Trim();
                sifre = txtSifre.Text.Trim();
                // işlem
                bulduMu = elemanIslemim.KullaniciAdiveSifreyeGoreElemaniBul(kullaniciAdi, sifre, out hataMesaji);

                if (bulduMu) // kişi vardır sisteme girebilir
                {
                    MessageBox.Show("Hoşgeldiniz sayın " + kullaniciAdi.ToUpper(), "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ProgramKayitlari.ProgramKayitlariDosyasinaYaz(kullaniciAdi + " adlı eleman sisteme giriş yaptı.");
                    FrmPizzaSatis frmPizzaSatis = new FrmPizzaSatis();
                    this.Hide();
                    frmPizzaSatis.Show();

                }
                else if (bulduMu == false && hataMesaji.Length == 0) // sisteme giremez
                {
                    MessageBox.Show("Kullanıcı adı veya parola hatalı!");
                }
                else
                {
                    MessageBox.Show("Beklenmedik bir hata oluştu! Tekrar deneyiniz. Hata: " + hataMesaji);
                    ProgramKayitlari.ProgramKayitlariDosyasinaYaz("frmGiris ekranında btnGiris_Click metodunda hata oldu. HATA:" + hataMesaji);
                }
            }


        }


        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                //GİRİŞ YAPILACAK
                if (string.IsNullOrEmpty(txtKullanici.Text.Trim()) || string.IsNullOrEmpty(txtSifre.Text.Trim()))
                {
                    MessageBox.Show("Lütfen bilgilerinizi giriniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // değerler varsa kontrol edilecek
                {
                    kullaniciAdi = txtKullanici.Text.Trim();
                    sifre = txtSifre.Text.Trim();
                    // işlem
                    bulduMu = elemanIslemim.KullaniciAdiveSifreyeGoreElemaniBul(kullaniciAdi, sifre, out hataMesaji);

                    if (bulduMu) // kişi vardır sisteme girebilir
                    {
                        MessageBox.Show("Hoşgeldiniz sayın " + kullaniciAdi.ToUpper(), "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ProgramKayitlari.ProgramKayitlariDosyasinaYaz(kullaniciAdi + " adlı eleman sisteme giriş yaptı.");
                        FrmPizzaSatis frmPizzaSatis = new FrmPizzaSatis();
                        this.Hide();
                        frmPizzaSatis.Show();
                    }
                    else if (bulduMu == false && hataMesaji.Length == 0) // sisteme giremez
                    {
                        MessageBox.Show("Kullanıcı adı veya parola hatalı!");
                    }
                    else
                    {
                        MessageBox.Show("Beklenmedik bir hata oluştu! Tekrar deneyiniz. Hata: " + hataMesaji);
                        ProgramKayitlari.ProgramKayitlariDosyasinaYaz("frmGiris ekranında btnGiris_Click metodunda hata oldu. HATA:" + hataMesaji);
                    }
                }

            }

        }
    }
}
