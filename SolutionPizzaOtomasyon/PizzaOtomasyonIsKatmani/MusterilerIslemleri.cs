using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaOtomasyonuVeriKatmani;
using PizzaOtomasyonuVarliklar;

namespace PizzaOtomasyonIsKatmani
{
    public class MusterilerIslemleri
    {
        public MusteriVeriTabaniIslemleri musteriVeriTabaniIslemleri = new MusteriVeriTabaniIslemleri();

        public DataTable MusterilerdenSilinmeyenHerkesiDataTableIcineYukle(out string hataMesaji)
        {
            DataTable sanalTablo = new DataTable();
            hataMesaji = string.Empty;
            try
            {
                sanalTablo = musteriVeriTabaniIslemleri.MusterilerdenSilinmeyenHerkesiGetir();
            }
            catch (Exception hata)
            {
                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: MusterilerdenSilinmeyenHerkesiDataGrideYukle metodunda hata oluştu. HATA:" + hata.ToString());
            }

            return sanalTablo;
        }


        public DataTable AdveSoyadaGoreMusteriAra(string ad, string soyad, out string hataMesaji)
        {
            DataTable sanalTablo = new DataTable();
            hataMesaji = string.Empty;
            try
            {
                sanalTablo = musteriVeriTabaniIslemleri.AdveSoyadaGoreSilinmemisOlanMusteriyiGetir(ad, soyad);
            }
            catch (Exception hata)
            {

                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: AdveSoyadaGoreMusteriAra metodunda hata oluştu. HATA:" + hata.ToString());
            }

            return sanalTablo;
        }

        public int YeniMusteriEklemekIcinGonder(string isim, string soyisim, string telefon1, string telefon2, string telefon3, out string hataMesaji)
        {
            int eklenenSatirSayisi = 0;
            hataMesaji = string.Empty;
            try
            {
                eklenenSatirSayisi = musteriVeriTabaniIslemleri.YeniMusteriEkle(isim, soyisim, telefon1, telefon2, telefon3);
            }
            catch (Exception hata)
            {

                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: YeniMusteriEklemekIcinGonder metodunda hata oluştu. HATA:" + hata.ToString());
            }

            return eklenenSatirSayisi;

        }

        public bool AyniKisidenSistemdeVarMi(string isim, string soyisim, string telefon1, string telefon2, string telefon3, out string hataMesaji)
        {
            bool sonuc = false;
            hataMesaji = string.Empty;
            try
            {
                sonuc = musteriVeriTabaniIslemleri.MusterininAynisindanMusteriTablosundaVarMi(isim, soyisim, telefon1, telefon2, telefon3);
            }
            catch (Exception hata)
            {
                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: AyniKisidenSistemdeVarMi metodunda hata oluştu. HATA:" + hata.ToString());
            }

            return sonuc;

        }

        public int MusteriyiYeniBilgilerleGuncelle(string isim, string soyisim, string telefon1, string telefon2, string telefon3, string id, out string hataMesaji)
        {
            int guncellenenKayitSayisi = 0;
            hataMesaji = string.Empty;
            try
            {
                guncellenenKayitSayisi = musteriVeriTabaniIslemleri.MusteriyiGuncelle(isim, soyisim, telefon1, telefon2, telefon3, id);
            }
            catch (Exception hata)
            {

                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: MusteriyiYeniBilgilerleGuncelle metodunda hata oluştu. HATA:" + hata.ToString());
            }
            return guncellenenKayitSayisi;
        }


        public int MusteriyiSil(string id, out string hataMesaji)
        {
            int silinenKayitSayisi = 0;
            hataMesaji = string.Empty;
            try
            {
                silinenKayitSayisi = musteriVeriTabaniIslemleri.MusteriyiSofDeleteIleSil(id);
            }
            catch (Exception hata)
            {

                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: MusteriyiYeniBilgilerleGuncelle metodunda hata oluştu. HATA:" + hata.ToString());
            }
            return silinenKayitSayisi;
        }

        public Musteriler AdveSoyadaGoreMusteriBul(string ad, string soyad, out string hataMesaji)
        {
            Musteriler musteri = null;
            hataMesaji = string.Empty;
            try
            {
                musteri = musteriVeriTabaniIslemleri.AdveSoyadaGoreSilinmemisOlanMusteriGetir(ad, soyad);
            }
            catch (Exception hata)
            {

                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: AdveSoyadaGoreMusteriGetir metodunda hata oluştu. HATA:" + hata.ToString());
            }

            return musteri;
        }

        public Musteriler IDyeGoreMusteriBul(long id, out string hataMesaji)
        {
            hataMesaji = string.Empty;
            Musteriler m = null;
            try
            {
                m = musteriVeriTabaniIslemleri.IDBilgisineGoreSilinmemisOlanMusteriGetir(id);
            }
            catch (Exception hata)
            {
                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: IDyeGoreMusteriBul metodunda hata oluştu. HATA:" + hata.ToString());
            }
            return m;

        }
    }
}
