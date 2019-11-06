using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ITelevision television = FactoryUtil.GetFactory("LedTV");
            Console.WriteLine(television.CreateScreen().GetScreenSize());
            Console.WriteLine(television.CreateTechnology().GetTechnology());

            television = FactoryUtil.GetFactory("OLEDTV");
            Console.WriteLine(television.CreateScreen().GetScreenSize());
            Console.WriteLine(television.CreateTechnology().GetTechnology());

            Console.ReadLine();
        }

        public class FactoryUtil
        {
            public static ITelevision GetFactory(string name)
            {
                if (name == "LedTV")
                {
                    return new TelevisionFactory();
                }

                if (name == "OLEDTV")
                {
                    return new TelevisionFactory2();
                }
                throw new Exception("error");
            }
        }


        public abstract class ITelevision
        {
            public abstract IScreen CreateScreen();
            public abstract ITechnology CreateTechnology();
        }

        public class TelevisionFactory : ITelevision
        {
            public override IScreen CreateScreen()
            {
                return new Size40();
            }

            public override ITechnology CreateTechnology()
            {
                return new LedTV();
            }
        }

        public class TelevisionFactory2 : ITelevision
        {
            public override IScreen CreateScreen()
            {
                return new Size49();
            }

            public override ITechnology CreateTechnology()
            {
                return new OLEDTV();
            }
        }

        public abstract class IScreen
        {
            public abstract string GetScreenSize();
        }

        public abstract class ITechnology
        {
            public abstract string GetTechnology();
        }

        public class Size40 : IScreen
        {
            public override string GetScreenSize()
            {
                return "40 inç TV";
            }
        }

        public class LedTV : ITechnology
        {
            public override string GetTechnology()
            {
                return "Led TV";
            }
        }

        public class Size49 : IScreen
        {
            public override string GetScreenSize()
            {
                return "49 inç TV";
            }
        }

        public class OLEDTV : ITechnology
        {
            public override string GetTechnology()
            {
                return "OLED TV";
            }
        }

    }
}
