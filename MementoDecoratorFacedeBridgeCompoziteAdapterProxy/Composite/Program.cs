using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee eray = new Employee { Name = "Eray", SurName = "Kısabacak" };

            Employee semih = new Employee { Name = "Semih", SurName = "Ünal" };
            eray.AddSubordinates(semih);

            Employee hakan = new Employee { Name = "Hakan", SurName = "Öksüz" };
            eray.AddSubordinates(hakan);

            Employee mustafa = new Employee { Name = "Mustafa", SurName = "Çalmak" };
            semih.AddSubordinates(mustafa);

            Console.WriteLine(eray.Name + " " + eray.SurName);

            foreach(Employee manager in eray)
            {
                Console.WriteLine(" " + manager.Name + " " + manager.SurName);
                foreach(var person in manager)
                {
                    Console.WriteLine(" - >" + person.Name + " " + person.SurName);
                }
            }
            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
        string SurName { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinates(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinates(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index]; 
        }

        public string Name { get; set; }
        public string SurName { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach(var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
