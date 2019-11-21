using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOf_Command_Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Kisi Kisi = new Kisi();
            BirkacKisi birkacKisi = new BirkacKisi();
            ButunAile butunAile = new ButunAile();

            Kisi.Sonraki(birkacKisi);
            birkacKisi.Sonraki(butunAile);

            Urun urun = new Urun { Fiyat=50 };
            Urun urun2 = new Urun { Fiyat = 2500 };
            Urun urun3 = new Urun { Fiyat = 50000 };

            Kisi.Degerlendirme(urun);
            Kisi.Degerlendirme(urun2);
            Kisi.Degerlendirme(urun3);

            Console.ReadLine();
        }
    }

    class Urun
    {
        public decimal Fiyat { get; set; }
    }

    abstract class Aile
    {
        public abstract void Degerlendirme(Urun urun);

        protected Aile sonraki_aile;
        
        public void Sonraki(Aile sonraki_aile)
        {
            this.sonraki_aile = sonraki_aile;
        }
    }

    class Kisi : Aile
    {
        public override void Degerlendirme(Urun urun)
        {
            if(urun.Fiyat > 0 && urun.Fiyat <= 1000)
            {
                Console.WriteLine("Kişi'nin onayı ile satın alındı");
            }
            else if(sonraki_aile != null)
            {
                sonraki_aile.Degerlendirme(urun);
            }
        }
    }

    class BirkacKisi : Aile
    {
        public override void Degerlendirme(Urun urun)
        {
            if (urun.Fiyat > 1000 && urun.Fiyat <= 10000)
            {
                Console.WriteLine("BirkacKisi'nin onayı ile satın alındı");
            }
            else if (sonraki_aile != null)
            {
                sonraki_aile.Degerlendirme(urun);
            }
        }

    }

    class ButunAile : Aile
    {
        public override void Degerlendirme(Urun urun)
        {
            if (urun.Fiyat > 10000)
            {
                Console.WriteLine("ButunAile'nin onayı ile satın alındı");
            }
            else if (sonraki_aile != null)
            {
                sonraki_aile.Degerlendirme(urun);
            }
        }
    }
}
