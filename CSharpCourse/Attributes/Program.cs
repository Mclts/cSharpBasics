using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { Id = 1, LastName = "Caliskan", Age = 18 };
            CustomerDal customerDal = new CustomerDal();
            //Bu şekilde gönderdiğimizde kişinin ismini döndürmeden de program çalışabilir
            customerDal.Add(customer);
            Console.ReadLine();
        }
    }

    [ToTable("Customers")]
    [ToTable("TblCustomers")]
    class Customer
    {
        public int Id { get; set; }
        [RequiredProperty]
        public string FirstName { get; set; }
        [RequiredProperty]
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }

    }

    class CustomerDal
    {
        [Obsolete("Don't use Add, instead use AddNew Method")] //Bu bir hazır attributedur. Ve kullandığınız method eskidir anlamına gelir.
        public void Add(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!!", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }

        public void AddNew(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!!", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }
    }

    //Attributes oluşturma
    //Attribure'a da attribute ekleyebiliyoruz
    /*[AttributeUsage(AttributeTargets.All)]*/ //Bu yapıyla attribute'u her yerde kullanabiliyoruz anlamına gelir.
    //[AttributeUsage(AttributeTargets.Class)] //Bu sadece classlarda kullanılır dedik şindi de
    //AllowMultiple da birden fazla kez kullanabiliriz anlamına geliyor.
    [AttributeUsage(AttributeTargets.Property ,AllowMultiple = true)] 
    class RequiredPropertyAttribute:Attribute
    {

    }

    //Birden fazla yere de uygulamak istersek pipe kullanırız ||
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple =true)]
    class ToTableAttribute:Attribute
    {
        private string _tableName;

        public ToTableAttribute(string _tableName)
        {
            this._tableName = _tableName;
        }
    }
}
