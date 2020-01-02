using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ICardReader cardReader = new XBankCardReader();
            cardReader.ReadCardData();
            Console.ReadLine();
        }
    }

    interface ICardReader
    {
        void ReadCardData();
    }

    class XBankasi
    {
        public void ReadFromCard()
        {
            Console.WriteLine("X Bankası: Kart Okundun");
        }
    }

    class XBankCardReader : ICardReader
    {
        public void ReadCardData()
        {
            XBankasi xBankasi = new XBankasi();
            xBankasi.ReadFromCard();
        }
    }
}
