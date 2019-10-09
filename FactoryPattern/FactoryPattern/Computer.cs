using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public abstract class Computer
    {
        public abstract string Info();
    }

    public class Notebook : Computer
    {
        public override string Info()
        {
            return "Notebook";
        }
    }

    public class DesktopComputer : Computer
    {
        public override string Info()
        {
            return "Desktop Computer";
        }   
    }

    // Factory
    public abstract class Factory
    {
        public abstract Computer ComputerBuilding();
    }

    public class ComputerFactory : Factory
    {
        public override Computer ComputerBuilding()
        {
            return new Notebook();
        }
    }

 
   
}
