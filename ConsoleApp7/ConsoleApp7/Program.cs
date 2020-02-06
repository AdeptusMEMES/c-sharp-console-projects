using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction A = new Fraction(Console.ReadLine());
            Fraction B = new Fraction(Console.ReadLine());
            Console.Write($"{A} + {B}= {A + B}\n{A} - {B}= {A - B}\n{A} * {B}= {A * B}\n{A} : {B}= {A / B}\n");
            Console.Write($"{A} > {B}  ");
            if (A > B)
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Неверно");
            Console.Write($"{A} < {B}  ");
            if (A < B)
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Неверно");
            Console.Write($"{A} >= {B}  ");
            if (A >= B)
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Неверно");
            Console.Write($"{A} <= {B}  ");
            if (A <= B)
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Неверно");
            Console.Write($"{A} == {B}  ");
            if (A == B)
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Неверно");
            Console.Write($"{A} != {B}  ");
            if (A != B)
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Неверно");
            Console.ReadKey();
        }
    }
}
