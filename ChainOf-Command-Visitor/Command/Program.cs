using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            BuyStok buyStok = new BuyStok(stock);
            SellStok sellStok = new SellStok(stock);

            StockController stockController = new StockController();
            stockController.TakeOrder(buyStok);
            stockController.TakeOrder(buyStok);
            stockController.TakeOrder(sellStok);
            stockController.PlaceOrders();
            Console.ReadLine();
        }
    }

    class Stock
    {
        private string name = "Laptop";
        private int quantity = 10;

        public void Buy()
        {
            quantity++;
            Console.WriteLine("Stok : {0}, {1} alındı", name, quantity);

        }

        public void Sell()
        {
            quantity--;
            Console.WriteLine("Stok : {0}, {1} satıldı", name, quantity);

        }
    }

    interface IOrder
    {
        void Execute();
    }

    class BuyStok : IOrder
    {
        private Stock stock;

        public BuyStok(Stock stock)
        {
            this.stock = stock;
        }

        public void Execute()
        {
            stock.Buy();
        }
    }

    class SellStok : IOrder
    {
        private Stock stock;

        public SellStok(Stock stock)
        {
            this.stock = stock;
        }
        public void Execute()
        {
            stock.Sell();
        }
    }

    class StockController
    {
        List<IOrder> orders = new List<IOrder>();

        public void TakeOrder(IOrder order)
        {
            orders.Add(order);
        }

        public void PlaceOrders()
        {
            foreach (var order in orders)
            {
                order.Execute();
            }

            orders.Clear();
        }
    }
}
