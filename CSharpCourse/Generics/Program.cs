using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Verilen listeyi verilen tipte liste haline getir diyoruz burada
            Utilities utilities = new Utilities();
            List<string> result = utilities.BuildList<String>("Ankara", "İzmir", "Adana");

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            List<Customer> result2 = utilities.BuildList<Customer>(new Customer 
            { FirstName= "Engin" }, 
            new Customer { FirstName = "Derin" }, 
            new Customer { FirstName = "Mustafa" }
            );

            foreach (var customer in result2)
            {
                Console.WriteLine(customer.FirstName);
            }

            Console.ReadLine();
        }
    }

    class Utilities 
    {
        public List<T> BuildList<T>(params T[] items)
        {
            return new List<T>(items);
        }
    }

    class Product : IEntity
    {
        
    }

    interface IProductDal : IRepository<Product>
    {
        
    }

    //interface IProductDal
    //{
    //    List<Product> GetAll();
    //    Product Get(int id);
    //    void Add(Product product);
    //    void Delete(Product product);
    //    void Update(Product product);
    //}

    class Customer : IEntity
    {
        public string FirstName {  get; set; }
    }

    //interface ICustomerDal
    //{
    //    List<Customer> GetAll();
    //    Customer Get(int id);
    //    void Add(Customer product);
    //    void Delete(Customer product);
    //    void Update(Customer product);
    //}

    interface ICustomerDal:IRepository<Customer>
    {
        void Custom();
    }

    interface IStudentDal:IRepository<Customer>
    {
        
    }

    class Student:IEntity
    {

    }

    //bu interface şu anlama geliyor IEntity'den implemente edilen bir sınıf veri tabanı nesnedir.
    interface IEntity
    {

    }

    //Generic kısıtları öğrenmek için yapılan örnek "Programcı yanlışlıkla şöyle bir şey yapabilir"
    //Programcı buraya string yazamasın belirli tipleri yazabilsin istoyrsak IRepository'ye where koşılu koyuyoruz
    //interface IStudentDal:IRepository<string>
    //{

    //}

    //Generic Yapı Tanımlama<>  Generic kısıtları ile burada generic olarak verilen t yi kısıtlayabiliyoruz
    //Burada where koşulu ile şunu dedik t referans tip olmak zorundadır ve newlenebilir bir yapı olmalıdır.
    //yani string yapamyız. Daha da profesyonel hale getirmemiz gerekirse sadece veri tabanı nesneleri yazılabilsin istersek
    //Sadece değer tiplerini koymak isteseydik şunu yapacaktır T:struct
    interface IRepository<T> where T:class ,IEntity,new()
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

    class ProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }

    class CustomerDal : ICustomerDal
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Custom()
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
