using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaOtomasyonuVarliklar;
using PizzaOtomasyonuVeriKatmani;

namespace PizzaOtomasyonIsKatmani
{
    public class MalzemeIslemleri
    {
        public MalzemeVeriTabaniIslemleri malzemeVeriTabaniIslemim = new MalzemeVeriTabaniIslemleri();
        public List<Malzemeler> TumMalzemeleriSilinenHaricListele(out string hataMesaji)
        {
            hataMesaji = string.Empty;
            List<Malzemeler> sonucListe = new List<Malzemeler>();
            try
            {
                sonucListe = malzemeVeriTabaniIslemim.TumMazlemeriSilinenlerHaricGetir();
            }
            catch (Exception hata)
            {
                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("TumMalzemeleriSilinenHaricListele metot hata oluştu. HATA:" + hata.ToString());
            }
            return sonucListe;
        }

        public decimal MalzemeninAdinaGoreFiyatiniGetir(string malzemeAdi, out string hataMesaji)
        {
            decimal sonuc = 0m;
            hataMesaji = String.Empty;

            try
            {
                sonuc = malzemeVeriTabaniIslemim.MalzemeninBirimFiyatiniAdinaGoreSorgula(malzemeAdi);
            }
            catch (Exception hata)
            {
                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("TumMalzemeleriSilinenHaricListele metot hata oluştu. HATA:" + hata.ToString());
            }
            return sonuc;
        }
    }
}
