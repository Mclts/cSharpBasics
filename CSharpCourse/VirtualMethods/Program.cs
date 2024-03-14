using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlServer sqlServer=new SqlServer();
            sqlServer.Add();
            MySql mySql = new MySql();
            mySql.Add();

            Console.ReadLine();
        }
    }

    class Database
    {
        //sql ya da mysql i kullanan kişi için de bu metotlar normal çalışır
        public virtual void Add()
        {
            Console.WriteLine("Added by default");
        }
        public void Delete()
        {
            Console.WriteLine("Deleted by default");
        }
    }

    class SqlServer : Database
    {
        public override void Add()
        {
            //base.Add();
            Console.WriteLine("Added by Sql Code");
        }
    }

    class MySql : Database
    {

    }
}
