using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesing
{
    class Program
    {
        static void Main(string[] args)
        {
            Bilgisayar bilgisayar = new Bilgisayar();
            bilgisayar.ac();

            Console.ReadLine();
        }
    }

    class Bellek
    {
        public void yukle()
        {
            Console.WriteLine("Bilgiler Yüklendi");
        }
    }

    class Islemci
    {
        public void acil()
        {
            Console.WriteLine("Bilgisayar açıldı");
        }
        public void calis()
        {
            Console.WriteLine("Bilgisayar çalıştı");
        }
    }

    class Bilgisayar
    {
        public void ac()
        {
            Islemci islemci = new Islemci();
            Bellek bellek = new Bellek();

            islemci.acil();
            islemci.calis();
            bellek.yukle();
        }
    }


}
