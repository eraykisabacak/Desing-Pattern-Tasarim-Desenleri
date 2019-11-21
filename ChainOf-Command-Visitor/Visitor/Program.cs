using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager eray = new Manager { Name = "Eray", Salary = 1000 };
            Manager hakan = new Manager { Name = "Hakan", Salary = 1100 };

            Calisan semih = new Calisan { Name = "Semih", Salary = 800 };
            Calisan mustafa = new Calisan { Name = "Mustafa", Salary = 800 };

            eray.employeeBases.Add(hakan);
            hakan.employeeBases.Add(semih);
            hakan.employeeBases.Add(mustafa);

            OrganisationalStructure organisational = new OrganisationalStructure(eray);

            PayrollVisitor payrollVisitor = new PayrollVisitor();
            Payrise payriseVisitor = new Payrise();

            organisational.Accept(payrollVisitor);
            organisational.Accept(payriseVisitor);
            Console.ReadLine();
        }
    }

    class OrganisationalStructure
    {
        private Calisanlar calisanlar;

        public OrganisationalStructure(Calisanlar calisanlar)
        {
            this.calisanlar = calisanlar;
        }

        public void Accept(VisitorBase visitorBase)
        {
            calisanlar.Accept(visitorBase);
        }
    }

    abstract class Calisanlar
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    class Manager : Calisanlar
    {
        public Manager()
        {
            employeeBases = new List<Calisanlar>();
        }
        public List<Calisanlar> employeeBases { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employee in employeeBases)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Calisan : Calisanlar
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Calisan calisan);
        public abstract void Visit(Manager manager);
    }

    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Calisan calisan)
        {
            Console.WriteLine("{0} Maaş : {1}", calisan.Name, calisan.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} Maaş: {1}", manager.Name, manager.Salary);
        }
    }

    class Payrise : VisitorBase
    {
        public override void Visit(Calisan calisan)
        {
            Console.WriteLine("{0} Yeni Maaşınız {1}", calisan.Name, calisan.Salary * (decimal)1.1);

        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} Yeni Maaşınız {1}", manager.Name, manager.Salary * (decimal)1.2);
        }
    }
}
