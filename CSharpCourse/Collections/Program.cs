using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Arraylistte tip güvenli olarak çalışamadık
            //ArrayListesi();

            //Listelerde tip güvenli çalıştık ve birkaç özellik ve metoduna baktık
            //List();

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("book", "kitap");
            dictionary.Add("table", "masa");
            dictionary.Add("computer", "bilgisayar");

            //Console.WriteLine(dictionary["table"]);
            //Console.WriteLine(dictionary["glass"]);

            foreach (var item in dictionary)
            {
                Console.WriteLine(item);
                Console.WriteLine(item.Key);
            }

            

            Console.ReadLine();
        }

        private static void List()
        {
            List<string> cities = new List<string>();
            cities.Add("Ankara");
            cities.Add("İstanbul");

            //Şehirlerin arasında Ankara varsa true döndür demektir bu
            //Console.WriteLine(cities.Contains("Ankara"));

            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }

            //1.Yazımı
            //List<Customer> customers = new List<Customer>();
            //customers.Add(new Customer{Id = 1, FirstName = "Engin" });
            //customers.Add(new Customer { Id = 2, FirstName = "Derin" });

            //2.Yazımı
            List<Customer> customers = new List<Customer> {
            new Customer { Id = 1, FirstName = "Engin" },
            new Customer { Id = 2, FirstName = "Derin" }
            };


            //Koleksiyon özellik ve metotlarıyla çalışmak
            var count = customers.Count();
            var customer2 = new Customer { Id = 3, FirstName = "Salih" };

            customers.Add(customer2);
            customers.AddRange(new Customer[2]
            {
                new Customer{Id=4,FirstName="Ali"},
                new Customer{Id=5,FirstName="Ayşe"}
            });

            //Burada yeni bir customer oluşturduğumuz için false dönecek
            Console.WriteLine(customers.Contains(new Customer { Id = 1, FirstName = "Engin" }));
            //Burada da true döner çünkü referans tutan bir değeri sorduk
            Console.WriteLine(customers.Contains(customer2));

            //customers.Clear();

            //Customer2 nin index numarasını döndürecektir.
            var index = customers.IndexOf(customer2);
            Console.WriteLine("Index: {0}", index);
            //Bu da customer2 yi sondan aramaya başlayıp döndürecektir yine aynı değeri verecektir...
            var index2 = customers.LastIndexOf(customer2);
            Console.WriteLine("Index: {0}", index2);

            //Add en sona ekliyorken insert ile istediğimiz indekse değer ekleyebiliyoruz.
            customers.Insert(0, customer2);

            //bulduğu ilk değeri çalıştırı ondan sonra da soruguyu kapatır.
            customers.Remove(customer2);
            customers.RemoveAll(c => c.FirstName == "Salih");

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.FirstName);
            }

            Console.WriteLine("Count {0}", count);
        }


        private static void ArrayListesi()
        {
            ////Dizilerde başında eleman atadığımızda ve yeni eleman ekleme ihtiyacı duyduğumuzda bu şekilde eleman eklersek hata alıyoruz
            //string[] cities = new string[2] { "Ankara", "İstanbul" };
            //cities[2] = "Adana";
            //Console.ReadLine();

            //string[] cities = new string[2] { "Ankara", "İstanbul" }
            ////burada yeni bir referans oluşturduğumuz için bütün değerlerin işi boşaldı.
            //cities = new string[3];
            //Console.WriteLine(cities[0]);

            //Arraylist koleksiyonumuz. Aray bazlı bir mimaridir arkada arrayı yöneten bir yapı söz konusudur.
            //Eğer çalıştığınız listede type safe yoksa arraylisti tercih edebilirsiniz.
            ArrayList cities = new ArrayList();
            cities.Add("Ankara");
            cities.Add("Adana");

            cities.Add("İstanbul");
            cities.Add(1);
            cities.Add('A');

            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }
            //Console.WriteLine(cities[2]);
        }
    }


    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }
}
