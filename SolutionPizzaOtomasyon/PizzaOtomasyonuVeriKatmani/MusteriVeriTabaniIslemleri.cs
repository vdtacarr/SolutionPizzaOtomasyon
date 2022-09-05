using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PizzaOtomasyonuVarliklar;

namespace PizzaOtomasyonuVeriKatmani
{
    public class MusteriVeriTabaniIslemleri
    {

        public DataTable MusterilerdenSilinmeyenHerkesiGetir()
        {
            DataTable sanalTablo = new DataTable();
            using (SqlConnection baglanti = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                string sorgu = "select * from Musteriler where SilindiMi=0";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                baglanti.Open();
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                adaptor.Fill(sanalTablo);
            }

            return sanalTablo;
        }


        public DataTable AdveSoyadaGoreSilinmemisOlanMusteriyiGetir(string ad, string soyad)
        {
            DataTable sanalTablo = new DataTable();
            string sorgu = string.Empty;

            if (string.IsNullOrEmpty(ad.Trim()) && string.IsNullOrEmpty(soyad.Trim()))
            {
                sorgu = "select * from Musteriler"; //herkes
            }
            else
            {
                //gelen değerlere göre SQL'deki LIKE isimli komutla alacağız. Yani içerisinde bu değerleri içeren kayıtları alacağız.
                sorgu = "select * from Musteriler where SilindiMi=0 and MusteriAdi like '%" + ad.Trim().ToLower() + "%' and MusteriSoyadi like '%" + soyad.Trim().ToLower() + "%' ";
            }

            using (SqlConnection baglanti = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                baglanti.Open();
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                adaptor.Fill(sanalTablo);
            }

            return sanalTablo;
        }

        public int YeniMusteriEkle(string isim, string soyisim, string telefon1, string telefon2, string telefon3)
        {
            int sonuc = 0;
            string tel1 = telefon1.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string tel2 = telefon2.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string tel3 = telefon3.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

            using (SqlConnection baglantim = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                string insertSorgusu = "insert into Musteriler (MusteriAdi, MusteriSoyadi, Telefon1, Telefon2, Telefon3) VALUES (@adi, @soyadi,@tel1, @tel2, @tel3)";

                SqlCommand komut = new SqlCommand(insertSorgusu, baglantim);
                komut.Parameters.Add("@adi", SqlDbType.NVarChar, 50).Value = isim.Trim();
                komut.Parameters.Add("@soyadi", SqlDbType.NVarChar, 50).Value = soyisim.Trim();
                komut.Parameters.Add("@tel1", SqlDbType.Char, 10).Value = tel1.Trim();
                komut.Parameters.Add("@tel2", SqlDbType.Char, 10).Value = tel2.Trim();
                komut.Parameters.Add("@tel3", SqlDbType.Char, 10).Value = tel3.Trim();

                baglantim.Open();
                sonuc = komut.ExecuteNonQuery(); // ExecuteNonQuery= insert update ve delete sorgularında komutu çalıştıran ve etkilenen satır sayısı veren metot
            }

            return sonuc;

        }

        public bool MusterininAynisindanMusteriTablosundaVarMi(string isim, string soyisim, string telefon1, string telefon2, string telefon3)
        {
            bool varMi = false;
            //maskedtextboxtan gelen maskeli yapıyı replace ile düzelttik
            string tel1 = telefon1.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string tel2 = telefon2.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string tel3 = telefon3.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            using (SqlConnection baglanti = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                string sorgu = " select * from Musteriler ";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.HasRows)
                {
                    while (okuyucu.Read())
                    {
                        if (okuyucu["MusteriAdi"].ToString().Trim().ToLower() == isim.Trim().ToLower()
                            && okuyucu["MusteriSoyadi"].ToString().Trim().ToLower() == soyisim.Trim().ToLower()
                            && okuyucu["Telefon1"].ToString().Trim().ToLower() == tel1
                            && okuyucu["Telefon2"].ToString().Trim().ToLower() == tel2
                            && okuyucu["Telefon3"].ToString().Trim().ToLower() == tel3)
                        {
                            varMi = true;
                            break;
                        }
                    }

                }

            }


            return varMi;
        }

        public int MusteriyiGuncelle(string isim, string soyisim, string telefon1, string telefon2, string telefon3, string id)
        {
            int sonuc = 0;
            string tel1 = telefon1.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string tel2 = telefon2.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string tel3 = telefon3.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

            using (SqlConnection baglantim = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                string guncellemeSorgusu = "update Musteriler set MusteriAdi=@adi, MusteriSoyadi=@soyadi, Telefon1=@tel1, Telefon2=@tel2, Telefon3=@tel3 WHERE MusteriIDNo=@id";

                SqlCommand komut = new SqlCommand(guncellemeSorgusu, baglantim);
                komut.Parameters.Add("@adi", SqlDbType.NVarChar, 50).Value = isim.Trim();
                komut.Parameters.Add("@soyadi", SqlDbType.NVarChar, 50).Value = soyisim.Trim();
                komut.Parameters.Add("@tel1", SqlDbType.Char, 10).Value = tel1.Trim();
                komut.Parameters.Add("@tel2", SqlDbType.Char, 10).Value = tel2.Trim();
                komut.Parameters.Add("@tel3", SqlDbType.Char, 10).Value = tel3.Trim();
                komut.Parameters.Add("@id", SqlDbType.BigInt).Value = id;

                baglantim.Open();
                sonuc = komut.ExecuteNonQuery(); // ExecuteNonQuery= insert update ve delete sorgularında komutu çalıştıran ve etkilenen satır sayısı veren metot
            }

            return sonuc;

        }



        public int MusteriyiSofDeleteIleSil(string id)
        {
            int sonuc = 0;

            using (SqlConnection baglantim = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                string guncellemeSorgusu = "update Musteriler set SilindiMi=1 WHERE MusteriIDNo=@id";

                SqlCommand komut = new SqlCommand(guncellemeSorgusu, baglantim);
                komut.Parameters.Add("@id", SqlDbType.BigInt).Value = id;

                baglantim.Open();
                sonuc = komut.ExecuteNonQuery(); // ExecuteNonQuery= insert update ve delete sorgularında komutu çalıştıran ve etkilenen satır sayısı veren metot
            }

            return sonuc;

        }

        public Musteriler AdveSoyadaGoreSilinmemisOlanMusteriGetir(string ad, string soyad)
        {
            Musteriler musteri = new Musteriler();
            string sorgu = string.Empty;

            sorgu = "select * from Musteriler where SilindiMi=0 and MusteriAdi =@adi and MusteriSoyadi =@soyadi";
            using (SqlConnection baglanti = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@adi", ad);
                komut.Parameters.AddWithValue("@soyadi", soyad);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.HasRows)
                {
                    while (okuyucu.Read())
                    {
                        if (okuyucu["MusteriAdi"].ToString().ToLower() == ad.ToLower() && okuyucu["MusteriSoyadi"].ToString().ToLower() == soyad.ToLower() && (bool)okuyucu["SilindiMi"] == false)
                        {
                            musteri = new Musteriler()
                            {
                                MusteriAdi = okuyucu["MusteriAdi"].ToString(),
                                MusteriSoyadi = okuyucu["MusteriSoyadi"].ToString(),
                                MusteriIDNo = (long)okuyucu["MusteriIDNo"],
                                SilindiMi = (bool)okuyucu["SilindiMi"],
                                Telefon1 = okuyucu["Telefon1"].ToString(),
                                Telefon2 = okuyucu["Telefon2"].ToString(),
                                Telefon3 = okuyucu["Telefon3"].ToString(),
                            };
                        }
                    }

                }
            }
            return musteri;
        }


        public Musteriler IDBilgisineGoreSilinmemisOlanMusteriGetir(long id)
        {
            Musteriler musteri = new Musteriler();
            string sorgu = string.Empty;


           sorgu = "select * from Musteriler where SilindiMi=0 and MusteriIDNo =@id ";
            using (SqlConnection baglanti = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.HasRows)
                {
                    while (okuyucu.Read())
                    {
                        if ((long)okuyucu["MusteriIDNo"] == id)
                        {
                            musteri = new Musteriler()
                            {
                                MusteriAdi = okuyucu["MusteriAdi"].ToString(),
                                MusteriSoyadi = okuyucu["MusteriSoyadi"].ToString(),
                                MusteriIDNo = (long)okuyucu["MusteriIDNo"],
                                SilindiMi = (bool)okuyucu["SilindiMi"],
                                Telefon1 = okuyucu["Telefon1"].ToString(),
                                Telefon2 = okuyucu["Telefon2"].ToString(),
                                Telefon3 = okuyucu["Telefon3"].ToString(),
                            };
                        }
                    }

                }
            }
            return musteri;
        }


    }
}
