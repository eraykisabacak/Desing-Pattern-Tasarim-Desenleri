using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta2Odev
{
    class Program
    {
        static void Main(string[] args)
        {
            Musteri.BilgisayarIstegi(Markalar.MONSTER, "T5 TULPAR", "GTX 1050", "PARMAK İZİ OKUYUCU");
            Musteri.BilgisayarIstegi(Markalar.Apple, "MACBOOK PRO", "AMD Ekran Kartı");

            Console.ReadLine();
        }
        enum Markalar
        {
            MONSTER, Apple
        }

        class Musteri
        {
            public static void BilgisayarIstegi(Markalar marka, string model,
                params string[] istek_parcalar)
            {
                Magaza magaza = new Magaza();
                switch (marka)
                {
                    case Markalar.MONSTER:
                        Monster a = magaza.MonsterTalebi(model, istek_parcalar);
                        Console.WriteLine(a.ToString());
                        break;

                    case Markalar.Apple:
                        Apple b = magaza.AppleTalebi(model, istek_parcalar);
                        Console.WriteLine(b.ToString());
                        break;
                }
            }
        }

        class Magaza
        {
            private Fabrika fabrika;

            public Monster MonsterTalebi(string model, string[] istek_parcalar)
            {
                fabrika = new MonsterFabrika();

                foreach (string istek in istek_parcalar)
                {
                    fabrika.ParcaEkle(istek);
                }

                return (Monster)fabrika.Uret(model);
            }

            public Apple AppleTalebi(string model, string[] istek_parcalar)
            {
                fabrika = new AppleFabrika();

                foreach (string istek in istek_parcalar)
                {
                    fabrika.ParcaEkle(istek);
                }
                return (Apple)fabrika.Uret(model);
            }
        }

        abstract class Fabrika
        {
            public abstract void ParcaEkle(string parca);
            public abstract Bilgisayar Uret(string model);
        }

        class MonsterFabrika : Fabrika
        {
            private Monster monster = new Monster();

            public override void ParcaEkle(string parca)
            {
                monster.OpsiyonelParcalar.Add(parca);
            }

            public override Bilgisayar Uret(string model)
            {
                monster.Model = model;
                return monster;
            }
        }

        class AppleFabrika : Fabrika
        {
            private Apple apple = new Apple();

            public override void ParcaEkle(string parca)
            {
                apple.OpsiyonelParcalar.Add(parca);
            }

            public override Bilgisayar Uret(string model)
            {
                apple.Model = model;
                return apple;
            }
        }

    }

    abstract class Bilgisayar
    {
        protected List<string> zorunlu_parcalar;
        private List<string> opsiyonel_parcalar;
        protected string model;

        public List<string> OpsiyonelParcalar
        {
            get
            {
                return opsiyonel_parcalar;
            }
            set
            {
                opsiyonel_parcalar = value;
            }
        }

        public Bilgisayar()
        {
            zorunlu_parcalar = new List<string>();
            zorunlu_parcalar.AddRange(new string[]{
                    "Anakart","Ram","Intel Ekran Kartı",
                    "HDD","İşlemci","Güç Kaynağı"
                });
            opsiyonel_parcalar = new List<string>();
        }
    }

    class Monster : Bilgisayar
    {
        public string Model
        {
            get
            {
                return base.model;
            }
            set
            {
                base.model = value;
            }
        }

        public Monster() : base()
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Monster {0} \n\r", model);

            for (int i = 0; i <= zorunlu_parcalar.Count - 1; i++)
            {
                sb.AppendLine(zorunlu_parcalar[i] + "\n\r");
            }

            for (int i = 0; i <= OpsiyonelParcalar.Count - 1; i++)
            {
                sb.AppendLine(OpsiyonelParcalar[i] + "\n\r");
            }
            return sb.ToString();
        }
    }

    class Apple : Bilgisayar
    {
        public string Model
        {
            get
            {
                return base.model;
            }
            set
            {
                base.model = value;
            }
        }

        public Apple() : base()
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Apple {0} \n\r", model);

            for (int i = 0; i <= zorunlu_parcalar.Count - 1; i++)
            {
                sb.AppendLine(zorunlu_parcalar[i] + "\n\r");
            }

            for (int i = 0; i <= OpsiyonelParcalar.Count - 1; i++)
            {
                sb.AppendLine(OpsiyonelParcalar[i] + "\n\r");
            }
            return sb.ToString();
        }
    }
}
