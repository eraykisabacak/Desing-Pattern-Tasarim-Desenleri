using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorTasarimDeseni
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleContainer sc = new SampleContainer();

            foreach (Urun item in sc)
            {
                Console.WriteLine(item.UrunAdi);
                Console.WriteLine(item.UrunFiyat);
            }

            SampleIterator iter = (SampleIterator)sc.GetEnumerator();
            while (iter.MoveNext())
            {
                Console.WriteLine(((Urun)iter.Current).UrunAdi);
                Console.WriteLine(((Urun)iter.Current).UrunFiyat);
            }

            Console.ReadLine();
        }
    }

    class Urun
    {
        private string urunAdi;
        private int urunFiyat;

        public string UrunAdi
        {
            get { return urunAdi; }
            set { urunAdi = value;  }
        }

        public int UrunFiyat
        {
            get { return urunFiyat; }
            set { urunFiyat = value; }
        }
    }

    class SampleContainer : IEnumerable
    {
        private Urun[] urunObjects;

        internal Urun[] Items
        {
            get { return urunObjects; }
        }

        public SampleContainer()
        {
            urunObjects = new Urun[4];
            urunObjects[0] = new Urun() { UrunAdi="Telefon", UrunFiyat = 3000 };
            urunObjects[1] = new Urun() { UrunAdi = "Televizyon", UrunFiyat = 5000 };
            urunObjects[2] = new Urun() { UrunAdi = "Bulaşık Makinesi", UrunFiyat = 3250 };
            urunObjects[3] = new Urun() { UrunAdi = "Buzdolabı", UrunFiyat = 4000 };
        }

        public IEnumerator GetEnumerator()
        {
            return new SampleIterator(this);
        }
    }

    class SampleIterator : IEnumerator
    {
        private int p = -1;
        private SampleContainer container;

        public SampleIterator(SampleContainer sc)
        {
            container = sc;
        }


        public object Current
        {
            get { return container.Items[p]; }
        }

        public bool MoveNext()
        {
            if (p < container.Items.Length- 1)
            {
                ++p;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }

        public void Reset()
        {
            p = 0;
        }
    }
}
