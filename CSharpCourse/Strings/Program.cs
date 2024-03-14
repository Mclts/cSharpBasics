using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Intro();

            string sentence = "My name is Engin Demiroğ";

            //Boşluk da bir karakterdir ve dizinin boyutunu döndürür.
            var result=sentence.Length;

            //ilgili cümlenin yeni bir referansını da oluşturmaya yarar.
            var result2 = sentence.Clone();
            sentence = "My name is Derin Demiroğ";

            //bu cümle ğ ile bitiyo mu bool döndürür
            bool result3 = sentence.EndsWith("ğ");
            bool result4 = sentence.StartsWith("My Name");

            //cümlede belli bir karakteri ya da ifadeyi aramak için kullanılır.Name kaçıncı karakterde başlar.Bulamazsa -1 döndürür.
            var result5 = sentence.IndexOf("name");
            var result6 = sentence.IndexOf(" "); //burada da ilk bulduğu boşluğu yazdırır
            var result7 = sentence.LastIndexOf(" "); //burada da aramaya sondan başlar
            var result8 = sentence.Insert(0,"Hello, "); //Bir string ifadeye başka bir ifafdeyi yerleştirmek için kullanılır.
            var result9 = sentence.Substring(3); //Bu method metni parçalamak için kullanılır. 3.karakterden itibaren 4 tane al
            var result10 = sentence.ToLower(); //Bütün karakterleri küçüğü çevirir
            var result11 = sentence.ToUpper(); //Bütün karakterleri büyüğe çevirir
            var result12 = sentence.Replace(" ", "-"); //boşlukları yan çizgiye dönüştür.
            var result13 = sentence.Remove(2,4); //ikiden itibaren 4 taneyi üçür anlamına felir

            Console.WriteLine(result8);
            Console.ReadLine();
        }


        private static void Intro()
        {
            string city = "Ankara";
            //Console.WriteLine(city[0]);

            //Stringler char arrayleridir.
            foreach (var item in city)
            {
                Console.WriteLine(item);
            }

            //Stringleri toplamak mümkündür stringleri yan yana getirir.Aşağıda bir bellek alanı kullanıldı bunun yerine daha efektif çözümler bulunabilir.
            string city2 = "İstanbul";
            //string result = city + city2;
            //Aşağıdaki şekilde kod yazıldığında bellekte alan kullanılamıyacaktır.
            Console.WriteLine(String.Format("{0} {1}", city, city2));
        }
    }
}
