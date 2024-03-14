using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesAndVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Value Types
            //Console.WriteLine("Hello World");

            //integer sınırı 10,000,000,000 kadardır
            int number1 = 10;
            int number2 = -20;
            //int sınırı -2147483648 den +2147483647'ye kadardır.
            int intSınır = -2147483648; //32 bitlik ver kaplar


            //long veri tipi integer'ın iki katı kadar değer tutar.
            long longSinir = -9223372036854775808; //64 bitlik yer kaplar

            short shortSinir = -32768; //16 bitlik yer tutar

            byte byteSinir = 255;  //bellekte 8 bitlik yer tutar

            bool condition = true; //true ya da false değerini tutar

            char character = 'A'; //tek bir karakter tutar

            double doubleNumber = 10.5; //Ondalıklı sayıları tutar (virgülden sonra 15 16 değer)

            decimal decimalNumber = 2.435345345m ; //Ondalıklı sayıları tutar (virgülden sonra 28 29 değer) para değerleinden falan kullanılır

            var varVariables = 10; //tipi atamaya göre algılanır. Başta yapılan atamaya göre değer algılar bundan sonra
            varVariables = 'A'; // Dediğimizde asci koduna göre değer gösteriri

            Console.WriteLine("Number1 is {0}{1}",number1,number2);
            Console.WriteLine("Number1 is {0}", longSinir);
            Console.WriteLine("character is {0}", (int)character);
            Console.WriteLine("Number is {0}", doubleNumber);
            Console.WriteLine((int)Days.Friday);
            Console.ReadLine();
            
        }
    }

    enum Days //Magic String yapmamak için kullanılır.
    {
        Monday=10, Tuesday=20, Wednesday=31, Thursday, Friday, Saturday, Sunday
    }
}
