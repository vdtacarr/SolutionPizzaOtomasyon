using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaOtomasyonuVeriKatmani;
using PizzaOtomasyonuVarliklar;

namespace PizzaOtomasyonIsKatmani
{
    public class SatisIslemleri
    {
        public SatisVeriTabaniIslemleri SatisVeriTabaniIslemim = new SatisVeriTabaniIslemleri();
        public int SatisEkle(out string hataMesaji, List<Siparis> Siparisler)
        {
            hataMesaji = string.Empty;
            int eklenenSatir = 0;
            try
            {
                // işlemler
                for (int i = 0; i < Siparisler.Count; i++) // müşteri farklı olabilir
                {
                    Satislar satis = new Satislar()
                    {
                        ElemanTCNO = ProgramKayitlari.SistemeGirisYapmisEleman != null ? ProgramKayitlari.SistemeGirisYapmisEleman.ElemanTCNO : string.Empty,
                        MusteriID = Siparisler[0].Musteri.MusteriIDNo,
                        SilindiMi = false,
                        Tarih = DateTime.Now,
                        ToplamTutar = Siparisler[i].ToplamFiyat

                    };
                    SatisDetaylari sdetay = new SatisDetaylari()
                    {
                        Adet = Siparisler[i].Adeti,
                        BirimFiyat = Siparisler[i].BirimFiyati,
                        PizzaID = Siparisler[i].Pizza.PizzaIDno,
                        SilindiMi = false,
                        SatisID = satis.SatisId
                    };

                    List<Malzemeler> pizzamalzeleri = Siparisler[i].PizzaninMalzemeleriListesi;
                    if (Siparisler[i].EkstraMalzemeleriListesi.Count > 0)
                    {
                        Siparisler[i].EkstraMalzemeleriListesi.ForEach(x =>
                        {
                            if (!pizzamalzeleri.Exists(p => p.MalzemeId == x.MalzemeId))
                            {
                                pizzamalzeleri.Add(x);
                            }


                        });
                    }

                    List<SatilanPizzaninMalzemeleri> SatilanPizzaninMalzemeleriListesi = new List<SatilanPizzaninMalzemeleri>();
                    for (int k = 0; k < pizzamalzeleri.Count; k++)
                    {
                        SatilanPizzaninMalzemeleri satilan_p_malzemesi = new SatilanPizzaninMalzemeleri()
                        {
                            MusteriID = Siparisler[i].Musteri.MusteriIDNo,
                            PizzaID = Siparisler[i].Pizza.PizzaIDno,
                            SatisDetayID = sdetay.SatisDetayID,
                            OlusturulmaTarihi = DateTime.Now,
                            MalzemeID = pizzamalzeleri[k].MalzemeId
                        };
                        SatilanPizzaninMalzemeleriListesi.Add(satilan_p_malzemesi);
                    }

                    eklenenSatir= SatisVeriTabaniIslemim.SatisiEkle(satis, sdetay, SatilanPizzaninMalzemeleriListesi);
                }

            }
            catch (Exception hata)
            {
                hataMesaji = hata.Message;
                eklenenSatir = 0;
                //programkayıtlarına ekle 
                ProgramKayitlari.ProgramKayitlariDosyasinaYaz("HATA: SatisEkle metodunda hata oluştu. HATA:" + hata.ToString());
            }

            return eklenenSatir;

        }
    }
}
