using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using PizzaOtomasyonuVarliklar;

namespace PizzaOtomasyonuVeriKatmani
{
    public class PizzaVeriTabaniIslemleri
    {
        public DataTable TumPizzalariSilinenlerHaricGetir()
        {
            DataTable tablo = new DataTable();

            using (SqlConnection bag = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                string sorgu = " Select * from Pizzalar where SilindiMi=0";
                SqlCommand komut = new SqlCommand(sorgu, bag);
                bag.Open();
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                adaptor.Fill(tablo);
            }

            return tablo;
        }

        public bool SeciliPizzaninMalzemeleriVarMiKontrolEt(string id)
        {
            bool sonuc = false;

            using (SqlConnection bag = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                string sorgu = "select * from PizzaninMalzemeleri where PizzaID=@id";
                SqlCommand komut = new SqlCommand(sorgu, bag);
                komut.Parameters.AddWithValue("@id", id);
                bag.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.HasRows)
                {
                    while (okuyucu.Read())
                    {
                        if (okuyucu["PizzaID"].ToString() == id)
                        {
                            sonuc = true;
                            break;
                        }
                    }
                }

            }
            return sonuc;
        }

        public int SeciliPizzayiSofDeleteIleSil(string id)
        {
            int sonuc = 0;

            using (SqlConnection baglantim = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                string guncellemeSorgusu = "update Pizzalar set SilindiMi=1 WHERE PizzaIDno=@id";

                SqlCommand komut = new SqlCommand(guncellemeSorgusu, baglantim);
                komut.Parameters.Add("@id", SqlDbType.BigInt).Value = id;

                baglantim.Open();
                sonuc = komut.ExecuteNonQuery(); // ExecuteNonQuery= insert update ve delete sorgularında komutu çalıştıran ve etkilenen satır sayısı veren metot
            }

            return sonuc;

        }

        public List<Pizzalar> TumPizzalarListesiniSilinenlerHaricGetir()
        {
            List<Pizzalar> liste = new List<Pizzalar>();

            using (SqlConnection bag = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                string sorgu = " Select * from Pizzalar where SilindiMi=0";
                SqlCommand komut = new SqlCommand(sorgu, bag);
                bag.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.HasRows)
                {
                    while (okuyucu.Read())
                    {
                        Pizzalar p = new Pizzalar()
                        {
                            OlusturmaTarihi = (DateTime)okuyucu["OlusturmaTarihi"],
                            PizzaAdi = okuyucu["PizzaAdi"].ToString(),
                            PizzaBirimFiyati = (decimal)okuyucu["PizzaBirimFiyati"],
                            PizzaIDno = (long)okuyucu["PizzaIDno"],
                            SilindiMi = (bool)okuyucu["SilindiMi"]
                        };
                        liste.Add(p);
                    }
                }
            }

            return liste;
        }



        public DataTable SeciliPizzadaOlmayanMalzemeleriGetir(long id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection bag = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                string sorgu = "select * from Malzemeler where  MalzemeId not in  (select MalzemeID from PizzaninMalzemeleri where PizzaID=@id)";
                SqlCommand komut = new SqlCommand(sorgu, bag);
                komut.Parameters.AddWithValue("@id", id);
                bag.Open();
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                adaptor.Fill(dt);
            }
            return dt;
        }

        public int PizzayaYeniMalzemeleriniEkle(List<long> malzemeler, long pizzaID)
        {
            int eklendi = 0;
            using (SqlConnection bag = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                SqlCommand komut = new SqlCommand();
                komut.Parameters.Clear();
                komut.Connection = bag;
                komut.CommandType = CommandType.Text;
                bag.Open();
                for (int i = 0; i < malzemeler.Count; i++)
                {
                    komut.Parameters.Clear();
                    string sorgu = "INSERT INTO PizzaninMalzemeleri (PizzaID, MalzemeID, OlusturulmaTarihi) VALUES(@pizzaid,@malzemeid,@tarih)";
                    komut.CommandText = sorgu;
                    komut.Parameters.AddWithValue("@pizzaid", pizzaID);
                    komut.Parameters.AddWithValue("@malzemeid", malzemeler[i]);
                    komut.Parameters.AddWithValue("@tarih", DateTime.Now);
                    eklendi += komut.ExecuteNonQuery();
                }
            }

            return eklendi;
        }

        //
        public DataTable SeciliPizzadaBulananMalzemeleriGetir(long id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection bag = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                string sorgu = "select * from Malzemeler where  MalzemeId in  (select MalzemeID from PizzaninMalzemeleri where PizzaID=@id)";
                SqlCommand komut = new SqlCommand(sorgu, bag);
                komut.Parameters.AddWithValue("@id", id);
                bag.Open();
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                adaptor.Fill(dt);
            }
            return dt;
        }

        public int SeciliPizzadanSeciliMalzemeyiSil(long pizzaID, long malzemeID)
        {
            int sonuc = 0;
            using (SqlConnection bag = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                using (SqlConnection baglantim = VeriTabaniBaglantiIslemleri.SQLBaglanti)
                {
                    string guncellemeSorgusu = "delete from PizzaninMalzemeleri where PizzaID = @pizzaid and MalzemeID = @malzemeid";

                    SqlCommand komut = new SqlCommand(guncellemeSorgusu, baglantim);
                    komut.Parameters.Add("@pizzaid", SqlDbType.BigInt).Value = pizzaID;
                    komut.Parameters.Add("@malzemeid", SqlDbType.BigInt).Value = malzemeID;

                    baglantim.Open();
                    sonuc = komut.ExecuteNonQuery(); // ExecuteNonQuery= insert update ve delete sorgularında komutu çalıştıran ve etkilenen satır sayısı veren metot
                }

            }

            return sonuc;
        }

        public List<PizzaVeMalzemeleri> TumPizzalariMalzemeleriyleBeraberGetir()
        {
            List<PizzaVeMalzemeleri> liste = new List<PizzaVeMalzemeleri>();
            using (var con = VeriTabaniBaglantiIslemleri.SQLBaglanti)
            {
                string sorgu = "select * from ViewPizzalarinMalzemeleri";
                SqlCommand komut = new SqlCommand(sorgu, con);
                komut.CommandType = CommandType.Text;

                con.Open();

                SqlDataReader okuyucu = komut.ExecuteReader();

                if (okuyucu.HasRows)
                {
                    while (okuyucu.Read())
                    {
                        // eğer sonuc listesinde bu pizza yoksa ekleyecek. Varsa o pizzanın malzemesini ekleyecek.

                        if (!liste.Exists(eleman => eleman.Pizza.PizzaIDno == (long)okuyucu["PizzaIDno"]))
                        {
                            //pizza yok ise ekle listeye
                            PizzaVeMalzemeleri yeniPizza = new PizzaVeMalzemeleri()
                            {
                                Pizza = new Pizzalar()
                                {
                                    PizzaIDno = (long)okuyucu["PizzaIDno"],
                                    PizzaAdi = okuyucu["PizzaAdi"].ToString(),
                                    PizzaBirimFiyati = (decimal)okuyucu["PizzaBirimFiyati"],
                                    OlusturmaTarihi = (DateTime)okuyucu["OlusturmaTarihi"]
                                },
                                PizzaninMalzemeleri = new List<Malzemeler>()
                            };
                            if (!yeniPizza.PizzaninMalzemeleri.Exists(eleman => eleman.MalzemeId == (long)okuyucu["MalzemeId"]) && yeniPizza.Pizza.PizzaIDno != 3)
                            {
                                yeniPizza.PizzaninMalzemeleri.Add(new Malzemeler()
                                {
                                    MalzemeAdi = okuyucu["MalzemeAdi"].ToString(),
                                    MalzemeId = (long)okuyucu["MalzemeId"],
                                    OlusturulmaTarihi = (DateTime)okuyucu["OlusturmaTarihi"]
                                });
                            }
                            liste.Add(yeniPizza);

                        }
                        else
                        {
                            //pizza varsa Sadece o pizzaya malzeme eklenecek

                            PizzaVeMalzemeleri p = liste.Find(x => x.Pizza.PizzaIDno == (long)okuyucu["PizzaIDno"]);
                            if (p != null)
                            {
                                if (!p.PizzaninMalzemeleri.Exists(x => x.MalzemeId == (long)okuyucu["MalzemeId"]) && p.Pizza.PizzaIDno != 3)
                                {
                                    p.PizzaninMalzemeleri.Add(new Malzemeler()
                                    {
                                        MalzemeAdi = okuyucu["MalzemeAdi"].ToString(),
                                        MalzemeId = (long)okuyucu["MalzemeId"],
                                        OlusturulmaTarihi = (DateTime)okuyucu["OlusturmaTarihi"]
                                    });
                                }
                            }

                        }
                    }
                }
            }

            return liste;
        }
    }


}
