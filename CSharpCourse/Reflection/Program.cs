using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Aşağıdaki bütün kodları reflection ile yapmak istiyoruz
            //DortIslem dortIslem = new DortIslem(2, 3);
            //Console.WriteLine(dortIslem.Topla2());
            //Console.WriteLine(dortIslem.Topla(2, 4));

            //Reflection mimarisine girmeden diyoruz ki bu kodla benim çalışacağım bir tip var ve o da dörtislem
            var tip = typeof(DortIslem);

            //DortIslem dortIslem = new DortIslem(2, 3); bununla aynı şeydir
            //Activar ile çalışma anında instance dinamik üretiyoruz....
            //DortIslem dortIslem = (DortIslem)Activator.CreateInstance(tip,6,7);
            //Console.WriteLine(dortIslem.Topla(4, 5));
            //Console.WriteLine(dortIslem.Topla2());

            var instance= Activator.CreateInstance(tip, 6, 7);

            //Invoke dediğimizde getirilen methodu çalıştırıyor
            //Bu kodun biraz daha profesyonelleşmiş versiyonunu yazıcaz şimdi aşağıda.
            //Console.WriteLine(instance.GetType().GetMethod("Topla2").Invoke(instance, null));

            //Reflection'u kullanarak bir metodu bu şekilde çalıştırırız
            MethodInfo methodInfo = instance.GetType().GetMethod("Topla2");

            Console.WriteLine(methodInfo.Invoke(instance, null));

            Console.WriteLine("--------------------------------------------------------------------------");
            var metotlar = tip.GetMethods();

            //Yani bu şekilde ilgili nesnenin metoduna ulaşıldı
            foreach (var info in metotlar)
            {
                Console.WriteLine("Metot Adı: {0}", info.Name);
                foreach (var parameterInfo in info.GetParameters())
                {
                    Console.WriteLine("Parametre: {0}", parameterInfo.Name);
                }

                //Nasıl parametrelerine ulaştıysak attributelarına da ulaşabiliriz
                foreach (var attribute in info.GetCustomAttributes())
                {
                    Console.WriteLine("Attribute Name: {0}", attribute.GetType().Name);
                }
            }

            Console.ReadLine();
        }
    }

    public class DortIslem
    {
        int _sayi1;
        int _sayi2;

        public DortIslem(int sayi1, int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }

        public DortIslem()
        {
            
        }

        public int Topla(int sayi1,int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }

        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }

        [MetodName("Carpma")]
        public int Carp2()
        {
            return _sayi1 * _sayi2;
        }
    }

    public class MetodNameAttribute:Attribute
    {
        public MetodNameAttribute(string name)
        {
            
        }
    }
}
