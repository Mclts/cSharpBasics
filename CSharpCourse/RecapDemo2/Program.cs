using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecapDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Logger = new SmsLogger();
            customerManager.Add();

            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        //public void Add()
        //{
        //    //Aşağıdaki şekilde kullanım da sadece database'e loglama yapmamıza neden olur bu şekilde kullanım yerine
        //    DatabaseLogger logger = new DatabaseLogger();
        //    logger.Log();
        //    Console.WriteLine("Customer Added!");
        //}


        //Şu şekilde kullanım yapılması gerekiyor
        public ILogger Logger { get; set; }
        public void Add()
        {
            Logger.Log();
            Console.WriteLine("Customer Added!");
        }
    }

    ////Bu class çıplaksa kötü bir kullanımdır manevra hakimiyeti yoktur sürekli newlerek kullanmak gerekir gerkli yerlerde
    //class Logger
    //{
    //    public void Log() 
    //    {
    //        Console.WriteLine("Logged!");
    //    }
    //}

    class DatabaseLogger: ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to Database!");
        }
    }

    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to File!");
        }
    }

    class SmsLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to sms!");
        }
    }

    interface ILogger
    {
        void Log();
    }
}
