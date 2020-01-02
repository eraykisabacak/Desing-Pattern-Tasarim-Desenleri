using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoDecoratorFacedeBridgeCompoziteAdapterProxy
{
    class Memento
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                Numarasi = "123456",
                Baslik = "Sefiller",
                Yazar = "Victor Hugo"
            };
            book.ShowBook();
            CareTaker history = new CareTaker();
            history.Mementom = book.CreateUndo();

            book.Numarasi = "987654";
            book.Baslik = "SEFİLLER";

            book.ShowBook();

            book.RestoreFromUndo(history.Mementom);

            book.ShowBook();

            Console.ReadLine();
        }
    }

    class Book
    {
        private string _baslik;
        private string _yazar;
        private string _numarasi;
        DateTime _sonGuncelleme;

        public string Baslik
        {
            get{ return _baslik; }
            set
            {
                _baslik = value;
                SetSonGuncelleme();
            }
        }

        public string Yazar
        {
            get{ return _yazar; }
            set
            {
                _yazar = value;
                SetSonGuncelleme();
            }
        }

        public string Numarasi
        {
            get { return _numarasi; }
            set
            {
                _numarasi = value;
                SetSonGuncelleme();
            }
        }
        

        private void SetSonGuncelleme()
        {
            _sonGuncelleme = DateTime.UtcNow;
        }

        public Mementom CreateUndo()
        {
            return new Mementom(_baslik, _yazar, _numarasi, _sonGuncelleme);
        }

        public void RestoreFromUndo(Mementom mementom)
        {
            _baslik = mementom.baslik;
            _yazar = mementom.yazar;
            _numarasi = mementom.numarasi;
            _sonGuncelleme = mementom.sonGuncelleme;
        }

        public void ShowBook()
        {
            Console.WriteLine("{0} numaralı {1} kitap {2} yazarı, son güncelleme {3}", _numarasi, _baslik, _yazar, _sonGuncelleme);
        }
    }

    class Mementom
    {
        public string baslik { get; set; }
        public string yazar { get; set; }
        public string numarasi { get; set; }
        public DateTime sonGuncelleme { get; set; }

        public Mementom(string baslik,
                       string yazar,
                       string numarasi,
                       DateTime sonGuncelleme)
        {
            this.baslik = baslik;
            this.yazar = yazar;
            this.numarasi = numarasi;
            this.sonGuncelleme = sonGuncelleme;
        }
    }

    class CareTaker
    {
        public Mementom Mementom { get; set; }
    }
}
 