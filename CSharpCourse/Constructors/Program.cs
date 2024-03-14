using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bu sondaki () parantez constructor'ın paramatresiz bir şekidle çalıştığını gösterir.
            CustomerManager customerManager = new CustomerManager(23);
            customerManager.List();

            Product product = new Product { Id = 1, Name = "Leptop" };
            Product product2 = new Product(2, "Computer");

            EmployeeManager employeeManager=new EmployeeManager(new DatabaseLogger());
            //Logger Interface'ini herhangi bir loger a atayarak onu çalıştırabiliyoruz.....

            //Eski sistemnde kullanımdır
            //employeeManager.Logger=new DatabaseLogger
            employeeManager.Add();

            PersonManager personManager = new PersonManager("Product");
            personManager.Add();

            Teacher.Number = 10;

            Utalities.Validate();

            Manager.DoSomething();
            Manager manager=new Manager();
            manager.DoSomething2();

            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        //private bir field alt çizgi ile başlatılır. Parametre olarak kullanıldığında alt çizgi kullanılmaz
        private int _count=15;

        public CustomerManager(int count)
        {
            _count = count;
        }

        public CustomerManager()
        {

        }

        public void List()
        {
            Console.WriteLine("Listed {0} items",_count);
        }

        public void Add()
        {
            Console.WriteLine("Added!");
        }
    }

    class Product
    {
        public Product()
        {
            
        }

        private int _id;
        private string _name;
        public Product(int id,string name)
        {
            _id = id;
            _name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    interface ILogger
    {
        void Log();
    }

    class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to database");
        }
    }

    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to file");
        }
    }

    ////Burada property ile çalışmak demoda bir yöntemdir constructer ile çalışılmalıdır.
    //class EmployeeManager
    //{
    //    public ILogger Logger { get; set; }
    //    public void Add()
    //    {
    //        Logger.Log();
    //        Console.WriteLine("Added");
    //    }
    //}

    class EmployeeManager
    {
        private ILogger _logger;
        public EmployeeManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Add()
        {
            _logger.Log();
            Console.WriteLine("Added");
        }
    }

    //Kullanıcağımız bütün sınıflardaki ortak parametreleri barındıracak
    class BaseClass
    {
        private string _entity;

        public BaseClass(string entity)
        {
            _entity = entity;
        }
        public void Message()
        {
            Console.WriteLine("{0} message",_entity);
        }
    }

    class PersonManager : BaseClass
    {
        //base classta bir entity belirledik ve onu buradan base clasa atadık
        public PersonManager(string entity):base (entity)
        {
            
        }

        public void Add()
        {
            Console.WriteLine("Added!");
            Message();
        }
    }

    //statik nesneleri hiçbir zaman newleyemeyiz çünkü program çalıştığında oluşturulur.Statik nesnenin bütün özellikleri statik olmalıdır.
    static class Teacher
    {
        public static int Number { get; set; }
    }

    static class Utalities
    {
        //statik bir nesne içinde ,mutlaka çalışmasını istediğiniz bir kod bloğunu çalıştırabilirsiniz.
        static Utalities() 
        {
        
        }
        public static void Validate()
        {
            Console.WriteLine("Validation is done");
        }
    }

    class Manager
    {
        public static void DoSomething()
        {
            Console.WriteLine("Done");
        }

        public void DoSomething2()
        {
            Console.WriteLine("Done2");
        }
    }
}
