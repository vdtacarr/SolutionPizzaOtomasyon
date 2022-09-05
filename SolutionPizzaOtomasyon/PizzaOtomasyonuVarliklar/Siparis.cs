using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyonuVarliklar
{
    public class Siparis
    {
        private string _id = string.Empty;
        public string ID
        {
            get
            {

                _id = OlusturulmaTarihi.ToString("yyMMddHHmmssfff");
                return _id;
            }
        }

        private string _bilgileri = string.Empty;
        public string Bilgileri
        {
            get
            {
                _bilgileri = " Müşteri: " + Musteri.MusteriAdi + " " + Musteri.MusteriSoyadi + " ";
                _bilgileri += " / Pizza: " + Pizza.PizzaAdi + " ";
                _bilgileri += " / Adet : " + Adeti.ToString() + " / Tutar:" + ToplamFiyat.ToString("0.00") + " TL ";

                return _bilgileri;

            }
            set
            {

                _bilgileri = value;
            }
        }

        public Musteriler Musteri { get; set; }
        public Pizzalar Pizza { get; set; }
        public List<Malzemeler> PizzaninMalzemeleriListesi { get; set; } = new List<Malzemeler>();
        public bool EkstraMalzemeEklenmisMi { get; set; }
        public List<Malzemeler> EkstraMalzemeleriListesi { get; set; } = new List<Malzemeler>();
        public decimal BirimFiyati { get; set; }
        public int Adeti { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        private decimal _toplamFiyat = 0m;
        public decimal ToplamFiyat
        {
            get
            {
                _toplamFiyat = BirimFiyati * Adeti;
                return _toplamFiyat;
            }
        }

        public override string ToString()
        {
            string sonuc = string.Empty;
            sonuc = " Müşteri: " + Musteri.MusteriAdi + " " + Musteri.MusteriSoyadi + " ";
            sonuc += " / Pizza: " + Pizza.PizzaAdi + " ";
            sonuc += " 7 Tutar:" + ToplamFiyat.ToString("0.00") + " TL ";

            return sonuc;
        }
    }
}
