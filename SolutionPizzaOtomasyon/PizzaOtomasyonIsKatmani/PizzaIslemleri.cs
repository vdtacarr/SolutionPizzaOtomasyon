using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PizzaOtomasyonuVeriKatmani;
using PizzaOtomasyonuVarliklar;

namespace PizzaOtomasyonIsKatmani
{

    public class PizzaIslemleri
    {
        public PizzaVeriTabaniIslemleri pizzaVeriTabaniIslemi = new PizzaVeriTabaniIslemleri();


        public DataTable TumPizzalariDataSeteGetir(out string hataMesaji)
        {
            DataTable sanalTablo = new DataTable();
            hataMesaji = string.Empty;
            try
            {
                sanalTablo = pizzaVeriTabaniIslemi.TumPizzalariSilinenlerHaricGetir();
            }
            catch (Exception hata)
            {
                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: TumPizzalariDataSeteGetir metodunda hata oluştu. HATA:" + hata.ToString());

            }

            return sanalTablo;

        }

        public bool SeciliPizzaninMalzemeleriVarMi(string id, out string hataMesaji)
        {
            hataMesaji = string.Empty;
            bool sonuc = false;
            try
            {
                sonuc = pizzaVeriTabaniIslemi.SeciliPizzaninMalzemeleriVarMiKontrolEt(id);
            }
            catch (Exception hata)
            {
                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: SeciliPizzaninMalzemeleriVarMi metodunda hata oluştu. HATA:" + hata.ToString());
            }
            return sonuc;
        }

        public int SeciliPizzayiSil(string id, out string hataMesaji)
        {
            int silinenKayitSayisi = 0;
            hataMesaji = string.Empty;
            try
            {
                silinenKayitSayisi = pizzaVeriTabaniIslemi.SeciliPizzayiSofDeleteIleSil(id);
            }
            catch (Exception hata)
            {

                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: SeciliPizzayiSil metodunda hata oluştu. HATA:" + hata.ToString());
            }
            return silinenKayitSayisi;
        }

        public List<Pizzalar> TumPizzalarListesiniGetir(out string hataMesaji)
        {
            List<Pizzalar> pizzalar = new List<Pizzalar>();
            hataMesaji = string.Empty;
            try
            {
                pizzalar = pizzaVeriTabaniIslemi.TumPizzalarListesiniSilinenlerHaricGetir();
            }
            catch (Exception hata)
            {
                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: TumPizzalariDataSeteGetir metodunda hata oluştu. HATA:" + hata.ToString());

            }

            return pizzalar;

        }

        public DataTable SeciliPizzadaOlmayanMalzemeleriGetir(long id, out string hataMesaji)
        {
            hataMesaji = string.Empty;
            DataTable tablo = new DataTable();
            try
            {
                tablo = pizzaVeriTabaniIslemi.SeciliPizzadaOlmayanMalzemeleriGetir(id);
            }
            catch (Exception hata)
            {
                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: SeciliPizzadaOlmayanMalzemeleriGetir metodunda hata oluştu. HATA:" + hata.ToString());
            }
            return tablo;
        }

        public int PizzayaYeniMalzemeEkle(List<long> malzemeidler, long pizzaID, out string hataMesaji)
        {
            int eklenen = 0;
            hataMesaji = string.Empty;
            try
            {
                eklenen = pizzaVeriTabaniIslemi.PizzayaYeniMalzemeleriniEkle(malzemeidler, pizzaID);
            }
            catch (Exception hata)
            {

                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: PizzayaYeniMalzemeEkle metodunda hata oluştu. HATA:" + hata.ToString());
            }

            return eklenen;
        }


        public DataTable SeciliPizzadaBulunanMalzemeleriGetir(long id, out string hataMesaji)
        {
            hataMesaji = string.Empty;
            DataTable tablo = new DataTable();
            try
            {
                tablo = pizzaVeriTabaniIslemi.SeciliPizzadaBulananMalzemeleriGetir(id);
            }
            catch (Exception hata)
            {
                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: SeciliPizzadaOlmayanMalzemeleriGetir metodunda hata oluştu. HATA:" + hata.ToString());
            }
            return tablo;
        }
        public int SeciliOlanMalzemeyiSeciliOlanPizzadanSil(long pizzaIdsi, long malzemeninIdsi, out string hataMesaji)
        {
            int silinen = 0;
            hataMesaji = string.Empty;

            try
            {
                silinen = pizzaVeriTabaniIslemi.SeciliPizzadanSeciliMalzemeyiSil(pizzaIdsi, malzemeninIdsi);
            }
            catch (Exception hata)
            {

                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: SeciliOlanMalzemeyiSeciliOlanPizzadanSil metodunda hata oluştu. HATA:" + hata.ToString());
            }
            return silinen;
        }

        public List<PizzaVeMalzemeleri> TumPizzalariMalzemeleriyleBeraberListele(out string hataMesaji)
        {
            hataMesaji = string.Empty;
            List<PizzaVeMalzemeleri> liste = new List<PizzaVeMalzemeleri>();
            try
            {
                liste = pizzaVeriTabaniIslemi.TumPizzalariMalzemeleriyleBeraberGetir();
            }
            catch (Exception hata)
            {
                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: TumPizzalariMalzemeleriyleBeraberListele metodunda hata oluştu. HATA:" + hata.ToString());

            }
            return liste;
        }

    }
}
