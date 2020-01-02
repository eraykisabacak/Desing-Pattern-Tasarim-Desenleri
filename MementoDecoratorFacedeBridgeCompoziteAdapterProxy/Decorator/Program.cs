using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var kisiselArac = new KisiselArac
            {
                Make = "BMW",
                Model = "3.20",
                HirePrice = 2200
            };

            OzelTeklif ozelteklif = new OzelTeklif(kisiselArac);

            ozelteklif.DiscountPercentage = 10;
            Console.WriteLine("Concrete Car: {0}", kisiselArac.HirePrice);
            Console.WriteLine("Special Offer: {0}", ozelteklif.HirePrice);

            Console.ReadLine();
        }
    }

    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class KisiselArac : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class TicariArac : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }


    // Decorator

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class OzelTeklif : CarDecoratorBase
    {
        public int DiscountPercentage { get; set; }
        private readonly CarBase _carBase;

        public OzelTeklif(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice
        {
            get
            {
                return _carBase.HirePrice - (_carBase.HirePrice * DiscountPercentage/100);
            }
            set
            {

            }
        }
    }
}
