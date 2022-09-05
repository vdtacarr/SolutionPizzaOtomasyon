using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaOtomasyonuVeriKatmani;

namespace PizzaOtomasyonIsKatmani
{
    public class ElemanIslemleri
    {
        public ElemanVeriTabaniIslemleri elemanVeriTabaniIslemim { get; set; } = new ElemanVeriTabaniIslemleri();

        public bool KullaniciAdiveSifreyeGoreElemaniBul(string kAdi, string sifresi, out string hataMesaji)
        {
            bool sonuc = false;
            hataMesaji = string.Empty;
            try
            {
                sonuc = elemanVeriTabaniIslemim.KullaniciAdiveSifresineGoreSilinmemisKisiyiSorgula(kAdi, sifresi);
            }
            catch (Exception hata)
            {
                hataMesaji = hata.Message;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: KullaniciAdiveSifreyeGoreElemaniBul metodunda hata oluştu. HATA:" + hata.ToString());
            }

            return sonuc;
        }
    }
}
