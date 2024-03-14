using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    //Herhangi bir dönüş değeri olmayan void döndüren ve parametre almayan operasyonlara delegelik yapıyor
    public delegate void MyDelegate();

    //Yukarıda parametre almayan bir delege oluşturmuştuk şimdi parametre alan bir delege de oluşturabiliriz.
    public delegate void MyDelegate2(string text);

    //Şimdi de parametre döndüren bir örnek yapalım
    public delegate int MyDelegate3(int number1,int number2);

    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //customerManager.SendMessage();
            //customerManager.ShowAlert();

            //myDelegate customerManager'ın sendmessage'ına delege edilmiş durumda
            MyDelegate myDelegate = customerManager.SendMessage;

            //myDelegate'e ekstradan bir görev daha verdik
            myDelegate += customerManager.ShowAlert;
            //Nasıl işlem ekleyebiliyorsak işlem de çıkartabiliriz
            myDelegate -= customerManager.SendMessage;

            //Aşağıdaki kodda bir parametre istediği için ve biz vermediğimiz için kızıyor
            //MyDelegate2 myDelegate2 = customerManager.SendMessage;
            MyDelegate2 myDelegate2 = customerManager.SendMessage2;
            myDelegate2+= customerManager.ShowAlert2;

            Matematik matematik=new Matematik();
            MyDelegate3 myDelegate3 = matematik.Topla;

            var sonuc=myDelegate3(5,10);
            myDelegate3 += matematik.Carp;
            //Delegelerde eğer bir return type var ise en son verilen delege döndürülür.
            Console.WriteLine(sonuc);

            //Burada şöyle bir kısıt var iki methoda da aynı parametreyi gönderiyor
            myDelegate2("Hello");
            //Tabi delegeyi çağırdığımızda bu işlemi yapar
            myDelegate();

            Console.ReadLine();
        }
    }

    public class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Hello!");
        }

        public void ShowAlert()
        {
            Console.WriteLine("Be Careful!");
        }
        public void SendMessage2(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowAlert2(string alert)
        {
            Console.WriteLine(alert);
        }
    }

    public class Matematik
    {
        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }
        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
    }
}
