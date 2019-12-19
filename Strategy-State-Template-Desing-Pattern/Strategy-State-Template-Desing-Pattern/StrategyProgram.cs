using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_State_Template_Desing_Pattern
{
    class StrategyProgram
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();

            customerManager.krediHesaplama = new EskiMusteri();
            customerManager.SaveCredit();

            customerManager.krediHesaplama = new YeniMusteri();
            customerManager.SaveCredit();

            Console.ReadLine();
        }
    }

    interface KrediHesaplama
    {
        void Kredi();
    }

    class EskiMusteri : KrediHesaplama
    {
        public void Kredi()
        {
            Console.WriteLine("Eski Müşteri için Kredi Hesaplandı Kredi Faiz Oranı : " + 0.99);
        }
    }

    class YeniMusteri : KrediHesaplama
    {
        public void Kredi()
        {
            Console.WriteLine("Yeni Müşteri için Kredi Hesaplandı Kredi Faiz Oranı : " + 1.10);
        }
    }

    class CustomerManager
    {
        public KrediHesaplama krediHesaplama { get; set; }
        public void SaveCredit()
        {
            krediHesaplama.Kredi();
        }
    }
}
