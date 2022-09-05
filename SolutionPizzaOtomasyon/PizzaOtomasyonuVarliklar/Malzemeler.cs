using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyonuVarliklar
{
    public class Malzemeler
    {
        public long MalzemeId { get; set; }
        public string MalzemeAdi { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public decimal BirimFiyati { get; set; }
        public bool SilindiMi { get; set; }

    }
}
