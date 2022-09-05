using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PizzaOtomasyonuVeriKatmani
{
    public static class VeriTabaniBaglantiIslemleri
    {
        //SqlBaglantiCumlesi: buradaki server ismini kendi bilgisayarınızdaki sql management stuido üzerinden kopyalayınız.
        public static string SqlBaglantiCumlesi { get; set; } = "Server=DESKTOP-51MCHBG\\SQLEXPRESS;Database=PIZZAOTOMASYON;Trusted_Connection=True";

        public static SqlConnection _sqlBaglanti;
        public static SqlConnection SQLBaglanti
        {
            get
            {
                if (!string.IsNullOrEmpty(SqlBaglantiCumlesi)) // Eğer bağlantı cümlesi null değilse bağlantı nesnesine bu cümleyi ata.
                {
                    _sqlBaglanti = new SqlConnection(SqlBaglantiCumlesi);
                    return _sqlBaglanti;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _sqlBaglanti = value;
            }

        }
    }
}
