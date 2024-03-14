using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Method halinde yazımı
            //ForLoop();

            //While döngüsü, while da belirli bir şart sağlanana kadar döngü çalışıyordur.While methodu
            //WhileLoop();

            //do while döngüsünde şart sağlanmasa bile do 1 kere çalışır.Metod halinde
            //DoWhileloop();

            //ForEach dizi temelli bir döngüdür.ForEach ile dönülen elemanları foreach içinde değişemezsiniz.
            //ForEachloop();

            //Asal Sayı Uygulaması
            if (IsPrimeNumber(6))
            {
                Console.WriteLine("This is a prime number");
            }
            else
            {
                Console.WriteLine("This is not a prime number");
            }


            Console.ReadLine();
        }

        //Asal Sayı Uygulaması
        private static bool IsPrimeNumber(int number)
        {
            bool result = true;
            for (int i = 2; i < number-1; i++)
            {
                Console.WriteLine(i);
                if (number%i==0)
                {
                    result = false;
                    i = number;
                }
            }
            return result;
        }

        private static void ForLoop()
        {
            for (int i = 100; i >= 0; i = i - 2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Finished!");

            ////normal döngü halinde yazımı
            //for (int i = 0; i <= 100; i++)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine("Finished!");
        }

        private static void WhileLoop()
        {
            int number = 100;
            while (number >= 0)
            {
                Console.WriteLine(number);
                number--;
            }
            Console.WriteLine("Now number is {0}", number);
        }

        private static void DoWhileloop()
        {
            int number = 10;
            do
            {
                Console.WriteLine(number);
                number--;
            } while (number >= 11);
        }

        private static void ForEachloop() {
            string[] students = new String[3] { "Engin", "Derin", "Salih" };
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
