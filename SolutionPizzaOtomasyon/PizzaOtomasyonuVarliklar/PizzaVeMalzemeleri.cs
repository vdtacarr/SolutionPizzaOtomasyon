using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyonuVarliklar
{
    public class PizzaVeMalzemeleri
    {
        private long _pizzaID = -1;
        public long PizzaID // comboboxlarda  valuemember olarak kullanılsın
        {
            get
            {
                if (Pizza != null)
                {
                    _pizzaID = Pizza.PizzaIDno;
                }
                else
                {
                    _pizzaID = -1;
                }
                return _pizzaID;
            }
            set
            {
                _pizzaID = value;
            }
        }

        public string PizzaBilgileri //comboboc display member için kullanılsın
        {
            get
            {
                string sonuc = string.Empty;
                sonuc = Pizza.PizzaAdi + " ";
                sonuc += PizzaninMalzemeleri.Count >  0 ? " (" : "";

                foreach (Malzemeler item in PizzaninMalzemeleri)
                {
                    sonuc += " " + item.MalzemeAdi + ",";

                }

                int sonVirgulIndeksi = Array.LastIndexOf(sonuc.ToArray(), ',');
                sonuc = sonVirgulIndeksi > -1 ? sonuc.Remove(sonVirgulIndeksi, 1) : sonuc;

                sonuc += PizzaninMalzemeleri.Count > 0 ? " )" : "";
                return sonuc;
            }

        }
        public Pizzalar Pizza { get; set; }
        public List<Malzemeler> PizzaninMalzemeleri { get; set; } = new List<Malzemeler>();


    }
}
