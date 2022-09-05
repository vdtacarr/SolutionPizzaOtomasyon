using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaOtomasyonuVarliklar;

namespace PizzaOtomasyonuVeriKatmani
{
    public class SatisVeriTabaniIslemleri
    {
        public int SatisiEkle(Satislar satis, SatisDetaylari sdetay, List<SatilanPizzaninMalzemeleri> smalzemeleriListesi)
        {
            int eklenenSatirSayisi = 0;
            SqlTransaction islem = null; //Transaction değişkenimizi tanımlıyoruz
            try
            {
                using (SqlConnection baglanti = VeriTabaniBaglantiIslemleri.SQLBaglanti)
                {
                    baglanti.Open();
                    islem = baglanti.BeginTransaction();//SQL bağlantımız için Transaction işlemini başlatıyoruz

                    SqlCommand komutSatis = new SqlCommand();
                    komutSatis.Connection = baglanti;
                    komutSatis.CommandType = System.Data.CommandType.Text;
                    komutSatis.CommandText = "INSERT INTO Satislar (Tarih ,MusteriID,ToplamTutar,ElemanTCNO,SilindiMi) VALUES(@tarih,@musteriID, @toplamtutar,@elemantc,@silindiMi)  select scope_identity()";
                    komutSatis.Parameters.AddWithValue("@tarih", satis.Tarih);
                    komutSatis.Parameters.AddWithValue("@musteriID", satis.MusteriID);
                    komutSatis.Parameters.AddWithValue("@toplamtutar", satis.ToplamTutar);
                    komutSatis.Parameters.AddWithValue("@elemantc", satis.ElemanTCNO);
                    komutSatis.Parameters.AddWithValue("@silindiMi", satis.SilindiMi);
                    komutSatis.Transaction = islem; // komuta transaction ata

                    //ExecuteScalar komutu ile son eklenen kaydın id numarasını aldık.
                    long satisid = Convert.ToInt64(komutSatis.ExecuteScalar());

                    SqlCommand komutSatisDetay = new SqlCommand();
                    komutSatisDetay.Connection = baglanti;
                    komutSatisDetay.CommandType = System.Data.CommandType.Text;
                    komutSatisDetay.CommandText = "INSERT INTO SatisDetaylari(SatisID   ,PizzaID   ,Adet   ,BirimFiyat   ,SilindiMi)VALUES(@satisId,@pizzaId,@adet,@birimFiyat, @silindiMi) select scope_identity()";
                    komutSatisDetay.Parameters.AddWithValue("@satisId", satisid);
                    komutSatisDetay.Parameters.AddWithValue("@pizzaId", sdetay.PizzaID);
                    komutSatisDetay.Parameters.AddWithValue("@adet", sdetay.Adet);
                    komutSatisDetay.Parameters.AddWithValue("@birimFiyat", sdetay.BirimFiyat);
                    komutSatisDetay.Parameters.AddWithValue("@silindiMi", sdetay.SilindiMi);
                    komutSatisDetay.Transaction = islem; // komuta transaction ata


                    //ExecuteScalar komutu ile son eklenen kaydın id numarasını aldık.
                    long satisdetayid = Convert.ToInt64(komutSatisDetay.ExecuteScalar());

                    SqlCommand komutSatilanPizzaMalz = new SqlCommand();
                    komutSatilanPizzaMalz.Connection = baglanti;
                    komutSatilanPizzaMalz.CommandType = System.Data.CommandType.Text;
                    for (int i = 0; i < smalzemeleriListesi.Count; i++)
                    {
                        komutSatilanPizzaMalz.Parameters.Clear();
                        komutSatilanPizzaMalz.CommandText = "INSERT INTO SatilanPizzaninMalzemeleri (PizzaID, MalzemeID, MusteriID, SatisDetayID, OlusturulmaTarihi) VALUES (@pizzaId, @malzemeId,@musteriId,@sdetayId,@tarih)";
                        komutSatilanPizzaMalz.Parameters.AddWithValue("@pizzaId", smalzemeleriListesi[i].PizzaID);
                        komutSatilanPizzaMalz.Parameters.AddWithValue("@malzemeId", smalzemeleriListesi[i].MalzemeID);
                        komutSatilanPizzaMalz.Parameters.AddWithValue("@musteriId", smalzemeleriListesi[i].MusteriID);
                        komutSatilanPizzaMalz.Parameters.AddWithValue("@sdetayId", satisdetayid);
                        komutSatilanPizzaMalz.Parameters.AddWithValue("@tarih", smalzemeleriListesi[i].OlusturulmaTarihi);

                        komutSatilanPizzaMalz.Transaction = islem; // komuta transaction ata

                        eklenenSatirSayisi += komutSatilanPizzaMalz.ExecuteNonQuery();

                    }

                    //tüm işlemlerde bir hata gerçekleşmez ise Transaction işlemini onaylıyoruz (commit)
                    islem.Commit();
                }
            }
            catch (Exception hatali)
            {
                eklenenSatirSayisi = 0; // sıfırla
                //Bu blok çalışırsa try bloğu içinde herhangi bir yerde hata oluşmuş demektir ki o zaman SQL'e yazılan verileri geri alıyoruz
                islem.Rollback();
                throw;
            }
            return eklenenSatirSayisi;
        }
    }
}
