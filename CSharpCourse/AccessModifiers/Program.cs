using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Customer
    {
        //default olarak private tanımlar id'yi.Pricvate değişkenler sadece tanımlandığı bolkalrda kullanılır.Inherit etsen de kullanılmaz
        //Protecdet da tanımlandığı blok içerisinde her yerde geçerlidir.Private'dan farkı tanımlanan değişken inherit edildiği sınıflarda kullanılır
        //En düşük seviye private onun bi üst seviyesi protected unun üstü ise internal
        private int Id { get; set; }

        public void Save()
        {
            
        }

        public void Delete()
        {

        }
    }

    class Student:Customer
    {
        public void Save2()
        {
            
        }
    }

    //bir class'ın default'u internal'dır.Internal'ı bağlı olduğu projede referans ihtiyacı olmadan kullanabilirsiniz
    //üst seviye bir class private protecder olamaz internal veya public olur.İç içe klaslarda olabilir ama
    public class Course
    {
        public string Name { get; set; }

        private class NestedClass
        {

        }
    }
}
