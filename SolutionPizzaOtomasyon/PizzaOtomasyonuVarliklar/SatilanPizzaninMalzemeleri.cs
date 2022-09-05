using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyonuVarliklar
{
    public class SatilanPizzaninMalzemeleri
    {

        public long ID { get; set; }
        public long PizzaID { get; set; }
        public long MalzemeID { get; set; }
        public long MusteriID { get; set; }
        public long SatisDetayID { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }

    }
}
