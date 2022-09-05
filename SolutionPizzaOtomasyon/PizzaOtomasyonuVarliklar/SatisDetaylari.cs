using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyonuVarliklar
{
    public class SatisDetaylari
    {
        public long SatisDetayID { get; set; }
        public long SatisID { get; set; }
        public long PizzaID { get; set; }
        public int Adet { get; set; }
        public decimal BirimFiyat { get; set; }
        public bool SilindiMi { get; set; }
    }
}
