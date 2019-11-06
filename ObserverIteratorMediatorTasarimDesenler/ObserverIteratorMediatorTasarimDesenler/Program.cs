using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverIteratorMediatorTasarimDesenler
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            
            CustomerObserver customerObserver = new CustomerObserver();
            productManager.Add(customerObserver);

            EmployeeObserver employeeObserver = new EmployeeObserver();
            productManager.Add(employeeObserver);

            productManager.UpdatePrice();

            productManager.Delete(customerObserver);
            productManager.Delete(employeeObserver);

            productManager.UpdatePrice();

            Console.ReadLine();
        }
    }

    class ProductManager
    {
        List<Observer> observers = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Ürünün Fiyatı Değişti");
            Notify();
        }

        public void Add(Observer observer)
        {
            observers.Add(observer);
        }

        public void Delete(Observer observer)
        {
            observers.Remove(observer);
        }

        private void Notify()
        {
            foreach(var kisi in observers)
            {
                kisi.Update();
            }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Customer : Ürünün Fiyatı Değişti");
        }
    }

    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Employee : Ürünün Fiyatı Değişti");
        }
    }
}
