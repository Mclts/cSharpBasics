using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFunc
    //Action ve funk dotnette mevcut olan delegelerdir.Action void tipinde metot döndürür.Func ise dönüş tipi olan
    //parametreler için kullanışlıdır.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //İKi parametre ve bir dönüş tipi gösterdik
            Func<int, int, int> add = Topla;
            Console.WriteLine(add(5, 6));

            //Parametresiz metotlar delegasyon yapıyo ama sonucunda int döndürüyor
            Func<int> getRandomNumber = delegate ()
            {
                Random random = new Random();
                return random.Next(1, 100);
            };
            Console.WriteLine(getRandomNumber());

            //Yukarıda yazdığımız kodu daha farklı da yazabiliriz şimdi onu yazalım.
            Func<int> getRandomNumber2 = () => new Random().Next(1, 100);
            Console.WriteLine(getRandomNumber2());

            //Console.WriteLine(Topla(2,3));
            Console.ReadLine();
        }

        static int Topla(int x, int y)
        {
            return x + y;
        }

        private static void ActionDemo()
        {
            /*
             HandleException aslında bir metot ve bu metota bir action göndermişiz ve action aslında void olan metotları
             çalışıtırmak için tasarlanmış bir yapıdır.
             */
            //Yani burası action kullanımıdır
            HandleException(() =>
            {
                Find();
            });
        }

       
        //Try catch yerine oluşturduğumuz merkezi hata yönetim ortamı find'ı alıp onun içeriğini actiona atadık ve 
        //invoke ederek çevirdik
        private static void HandleException(Action action)
        {
            try
            {
                
                action.Invoke();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void Find()
        {
            List<string> students = new List<string> { "Engin", "Derin", "Salih" };

            if (!students.Contains("Ahmet"))
            {
                throw new RecordNotFound("Record Not Found!!");
            }
            else
            {
                Console.WriteLine("Record Found!");
            }
        }

    }
}
