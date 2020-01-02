using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.messageSenderBase = new SMSGonderme();
            customerManager.UpdateCustomer();

            customerManager.messageSenderBase = new MailGonderme();
            customerManager.UpdateCustomer();
            Console.ReadLine();
        }
    }

    abstract class MessageSenderBase
    {
        public void MesajKaydet()
        {
            Console.WriteLine("Message saved");
        }

        public abstract void Gonder(Body body);
    }

    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class SMSGonderme : MessageSenderBase
    {
        public override void Gonder(Body body)
        {
            Console.WriteLine("{0} Başlıklı SMS Gönderildi.",body.Title, body.Text);
        }
    }

    class MailGonderme : MessageSenderBase
    {
        public override void Gonder(Body body)
        {
            Console.WriteLine("{0} Başlıklı Mail Gönderildi.",body.Title);
        }
    }

    class CustomerManager
    {
        public MessageSenderBase messageSenderBase { get; set; }
        public void UpdateCustomer()
        {
            messageSenderBase.Gonder(new Body { Title = "Şifre Değişikliği" });
            Console.WriteLine("Update Customer");
        }
    }

}
