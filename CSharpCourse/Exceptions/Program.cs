using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ExceptionIntro();

            try
            {
                Find();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            //Method Action delegasyonu
            //()=>{} ben parametresiz bir şey göndericem bu kod bloğunun karşılı da parantezin içi

            /*HandleException aslında bir metot ve ben o metoda bir action göndermişim aslında action bir metot bloğuna
            karşı gelir ve veoid olanları çalıştırmak için tasarlanmış bir mimaridir.
             */

            //Yani burada parametresiz bir metoda delege ediceğimizi söylüyoruz o da bizim kod bloğumuz
            HandleException(() =>
            {
                Find();
            });

            Console.ReadLine();
        }

        /*Merkezi bir hata yönetim metodu oluşturmuştuk.Try in içerisindeki metot ne ise içindeki kod bloğu actiona karşılıl
        geliyor.
         */
        //Action sana bir kod bloğu göndericem onu çalıştır demek döndürmeden
        private static void HandleException(Action action)
        {
            try
            {
                //gönderilen paramtreyi çalıştır demek bu da
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
                //throw hatayı fırlatmak için kullandığımız kod deyimidir
                throw new RecordNotFoundException("Record Not Found!!");
            }
            else
            {
                Console.WriteLine("Record Found!");
            }
        }

        private static void ExceptionIntro()
        {
            //try bloğunda bi hata olursa onu al ve cath de ekrana yazdır
            try
            {
                string[] students = new string[3] { "Engin", "Derin", "Salih" };
                students[3] = "Ahmet";
            }
            //alınan hatanın türü buysa
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (DivideByZeroException exception)
            {
                Console.WriteLine(exception.Message);
            }
            //yukarıdaki hata aşağıdaki exception bloğuna aktarılır.Eğer exception parametresi verilirse verilmezse aktarılmaz
            catch (Exception exception)
            {
                //bi de Innerexception paramtresi ile daha detaylı bilgi alabiliriz.
                Console.WriteLine(exception.Message);
            }
        }
    }
}
