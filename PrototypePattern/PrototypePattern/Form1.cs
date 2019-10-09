using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrototypePattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Customer customer = new Customer { FirstName = "Eray", LastName = "Kısabacak",
                City = "Kastamonu", Id = 1 };

            Customer customer2 = (Customer)customer.Clone();
            customer2.FirstName = "Hakan";

            Console.WriteLine(customer.FirstName);
            Console.WriteLine(customer2.FirstName);

        }
    }
}
