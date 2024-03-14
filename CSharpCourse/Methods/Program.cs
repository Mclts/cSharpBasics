using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Add();
            //Add();
            //Add();
            //var result = Add2(20,30);
            //var result2 = Add3();

            //int number1 = 20;
            //int number2 = 100;
            //var result3 = Add4(ref number1, number2);
            //Console.WriteLine(result3);
            //Console.WriteLine(number1);

            Console.WriteLine(Multiply(2, 4));
            Console.WriteLine(Multiply(2, 4,5));

            Console.WriteLine(Add5(1, 2, 3, 4, 5, 6));
            Console.ReadLine();
        }

        //Metot
        static void Add()
        {
            Console.WriteLine("Added!!!");
        }

        //Parametreli Metot
        static int Add2(int number1,int number2)
        {
            var result = number1+number2;
            return result;
        }

        //Default Parametreli Metot "default parametre metotun son parametresine atanabilir ilk parametrelere atanmaz"
        static int Add3(int number1=1, int number2=30)
        {
            var result = number1 + number2;
            return result;
        }

        //ref keywordu değer tiplerinin referans tipi olarak kullanılmasını sağlar.
        //out da değer tipi referans tipi olarak gönderir ama outta ilk değeri atarken bir değişken vermeye gerek yoktur
        //out ile gönderilen değerin parametre içinde set edilmesi zorunludur!!!!
        static int Add4(ref int number1, int number2)
        {
            number1 = 30;
            return number1 + number2;
        }

        static int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        //Method Overloading
        static int Multiply(int number1, int number2, int number3)
        {
            return number1 * number2 * number3;
        }

        //Params keywordu kullanımı params metodun son parametresi olmak zorunda
        static int Add5(params int[] numbers)
        {
            return numbers.Sum();
        }

    }
}
