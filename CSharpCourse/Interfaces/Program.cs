using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //InterfacesIntro();
            //InterfaceIntro2();

            ICustomerDal[] customerDals = new ICustomerDal[3]
            {
                new SqlServerCustomerDal(),
                new OracleServerCustomerDal(),
                new MySqlCustomerDal()
            };

            foreach (var customerDal in customerDals)
            {
                customerDal.Add();
            }

            Console.ReadLine();
        }


        private static void InterfaceIntro2()
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add(new SqlServerCustomerDal());
            Console.ReadLine();
        }

        public static void InterfacesIntro()
        {
            PersonManager manager = new PersonManager();
            //manager.Add(new Customer {Id=1, FirstName="Engin", LastName="Demiroğ", Address="Ankara" });

            Customer customer = new Customer
            {
                Id = 1,
                FirstName = "Engin",
                LastName = "Demiroğ",
                Address = "Ankara"
            };

            Student student = new Student
            {
                Id = 1,
                FirstName = "Derin",
                LastName = "Demiroğ",
                Departmant = "Computer Sciences"
            };

            //manager is katmanına interface değişkeni verdiğimiz için istersek customer istersek student yollayabiliriz manager'e
            manager.Add(customer);

        }
    }

    //soyut nesnedit
    interface IPerson
    {
        int Id { get; set; }
        String FirstName { get; set; }
        String LastName { get; set; }
    }

    //somut nesnedir
    class Customer:IPerson
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public string Address { get; set; }
    }

    //somut nesnedir
    class Student :IPerson
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public string Departmant { get; set; }
    }

    class Worker : IPerson
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public string Departmant { get; set; }
    }

    //Person ifadesi genelde iş katmanı ifadeleri için kullanılır
    class PersonManager
    {
        public void Add(IPerson person)
        {
            Console.WriteLine(person.FirstName);
        }
    }
}
