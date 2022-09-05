using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaOtomasyonuVarliklar;
using PizzaOtomasyonuVeriKatmani;

namespace PizzaOtomasyonIsKatmani
{
    public class ProgramKayitlari
    {
        public static string DosyaAdi = "ProgramKayitlari_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
        public static string DosyaYolu = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), DosyaAdi);

        public static void ProgramKayitlariDosyasinaYaz(string mesaj)
        {
            //İşlem yapacağımız dosyanın yolunu belirtiyoruz.
            //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
            //2.parametre dosya varsa açılacağını yoksa oluşturulacağını belirtir,
            //3.parametre dosyaya erişimin veri yazmak için olacağını gösterir.
            FileStream dosyaYazici = null;
            if (!File.Exists(DosyaYolu))
            {
                dosyaYazici = new FileStream(DosyaYolu, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter yazici = new StreamWriter(dosyaYazici);
                yazici.WriteLine($"{DateTime.Now.ToString()} - {mesaj}");
                //Dosyaya ekleyeceğimiz yazıyı WriteLine() metodu ile yazacağız.
                yazici.WriteLine();
                //Veriyi tampon bölgeden dosyaya aktardık. 
                yazici.Flush();
                yazici.Close();
            }
            else
            {
                dosyaYazici = new FileStream(DosyaYolu, FileMode.Append, FileAccess.Write);
                using (dosyaYazici)
                {
                    //Yazma işlemi için bir StreamWriter nesnesi oluşturduk.
                    StreamWriter yazici = new StreamWriter(dosyaYazici);
                    yazici.WriteLine($"{DateTime.Now.ToString()} - {mesaj}");
                    //Dosyaya ekleyeceğimiz yazıyı WriteLine() metodu ile yazacağız.
                    yazici.WriteLine();
                    //Veriyi tampon bölgeden dosyaya aktardık. 
                    yazici.Flush();
                }
            }
        }

        private static Elemanlar _elemanlar = null;
        public static Elemanlar SistemeGirisYapmisEleman
        {
            get
            {
                if (ElemanVeriTabaniIslemleri.SistemeGirisYapmisEleman != null)
                {
                    _elemanlar = ElemanVeriTabaniIslemleri.SistemeGirisYapmisEleman;
                }
                return _elemanlar;
            }
            set
            {
                _elemanlar = value;
            }
        }
    }
}
