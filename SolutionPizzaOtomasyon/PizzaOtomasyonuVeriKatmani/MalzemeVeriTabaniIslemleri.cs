using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaOtomasyonuVarliklar;
using System.Data.SqlClient;

namespace PizzaOtomasyonuVeriKatmani
{
    public class MalzemeVeriTabaniIslemleri
    {
        public List<Malzemeler> TumMazlemeriSilinenlerHaricGetir()
        {
            List<Malzemeler> liste = new List<Malzemeler>();
            using (SqlConnection bag = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                string sorgu = "select * from Malzemeler where SilindiMi=0";
                SqlCommand komut = new SqlCommand(sorgu, bag);
                bag.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.HasRows)
                {
                    while (okuyucu.Read())
                    {
                        if (!liste.Exists(eleman => eleman.MalzemeId == (long)okuyucu["MalzemeId"]))
                        {
                            liste.Add(new Malzemeler()
                            {
                                MalzemeId = (long)okuyucu["MalzemeId"],
                                BirimFiyati = (decimal)okuyucu["BirimFiyati"],
                                MalzemeAdi = okuyucu["MalzemeAdi"].ToString(),
                                OlusturulmaTarihi = (DateTime)okuyucu["OlusturulmaTarihi"],
                                SilindiMi = (bool)okuyucu["SilindiMi"]
                            });
                        }
                    }
                }
            }
            return liste;
        }
        public decimal MalzemeninBirimFiyatiniAdinaGoreSorgula(string malzemeAdi)
        {
            decimal sonuc = 0m;
            using (SqlConnection bag = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                string sorgu = "select * from Malzemeler where MalzemeAdi=@m_adi";
                SqlCommand komut = new SqlCommand(sorgu, bag);
                komut.Parameters.AddWithValue("@m_adi", malzemeAdi);
                bag.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();

                if (okuyucu.HasRows)
                {
                    while (okuyucu.Read())
                    {
                        if (okuyucu["MalzemeAdi"].ToString().ToLower() == malzemeAdi.ToLower())
                        {
                            sonuc = (decimal)okuyucu["BirimFiyati"];
                        }
                    }
                }

            }
            return sonuc;
        }

    }
}
