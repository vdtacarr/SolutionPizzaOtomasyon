using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PizzaOtomasyonuVarliklar;

namespace PizzaOtomasyonuVeriKatmani
{
    public class ElemanVeriTabaniIslemleri
    {
        public bool KullaniciAdiveSifresineGoreSilinmemisKisiyiSorgula(string kAdi, string sifre)
        {
            bool sonuc = false;

            // veri tabanı işlemleri
            using (SqlConnection baglantim = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                string sorgu = "select * from Elemanlar where ElemanKullaniciAdi=@elemanKullaniciAdi and ElemanKullaniciSifresi=@elemanKullaniciSifresi and SilindiMi=0";
                //1. yol
                // SqlCommand komut = new SqlCommand(sorgu, baglantim);
                //2.yol
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglantim;
                komut.CommandType = System.Data.CommandType.Text;
                komut.CommandText = sorgu;
                komut.Parameters.AddWithValue("elemanKullaniciAdi", kAdi);
                komut.Parameters.AddWithValue("elemanKullaniciSifresi", sifre);
                baglantim.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.HasRows)
                {
                    while (okuyucu.Read())
                    {
                        if (okuyucu["ElemanKullaniciAdi"].ToString().Trim().ToLower() == kAdi.ToLower() && okuyucu["ElemanKullaniciSifresi"].ToString().Trim().ToLower() == sifre.ToLower() && (bool)okuyucu["SilindiMi"] == false)
                        {
                            sonuc = true;
                            SistemeGirisYapmisEleman = new Elemanlar()
                            {
                                ElemanAdi = okuyucu["ElemanAdi"].ToString(),
                                ElemanKullaniciAdi = okuyucu["ElemanKullaniciAdi"].ToString(),
                                ElemanKullaniciSifresi = okuyucu["ElemanKullaniciSifresi"].ToString(),
                                ElemanSoyadi = okuyucu["ElemanSoyadi"].ToString(),
                                ElemanTCNO = okuyucu["ElemanTCNO"].ToString(),
                                ElemanTelefon = okuyucu["ElemanTelefon"].ToString(),
                                ElemanTelefon2 = okuyucu["ElemanTelefon2"].ToString(),
                                OlusturulmaTarihi = (DateTime)okuyucu["OlusturulmaTarihi"],
                                SilindiMi = (bool)okuyucu["SilindiMi"]
                            };
                            break;
                        }
                    }
                }
            }
            return sonuc;
        }

        public static Elemanlar SistemeGirisYapmisEleman { get; set; }
    }
}
