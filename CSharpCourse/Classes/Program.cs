using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Claslar propertleri tutar
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add();
            customerManager.Update();

            ProductManager productManager = new ProductManager();
            productManager.Add();
            productManager.Update();

            //Classlarda property kullanımı 1
            Customer customer = new Customer();
            customer.City = "Ankara";
            customer.Id = 1;
            customer.FirstName = "Engin";
            customer.LastName = "Demiroğ";

            //Classlarda property kullanımı 2
            Customer customer2 = new Customer { Id=2,City="İstanbul",FirstName="Derin",LastName="Demiroğ"};
            
            Console.WriteLine(customer2.FirstName);

            Console.ReadLine();
        }
    }
}
