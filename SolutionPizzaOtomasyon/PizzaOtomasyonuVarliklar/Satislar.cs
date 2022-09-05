using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyonuVarliklar
{
    public class Satislar
    {

        public long SatisId { get; set; }
        public DateTime Tarih { get; set; }
        public long MusteriID { get; set; }
        public decimal ToplamTutar { get; set; }
        public string ElemanTCNO { get; set; }
        public bool SilindiMi { get; set; }

    }
}
