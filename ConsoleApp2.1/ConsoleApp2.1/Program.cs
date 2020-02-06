using System;

namespace ConsoleApp2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            char[] arr=null;
            char[] mas;
            int n;
            for(int i = s.Length - 1; i >=0;)
            {
                for (; i >= 0 && s[i] == ' '; i--);
                n = 0;
                for(; i >= 0 &&s[i] != ' '; i--)
                {
                    n++;
                    if (n == 1)
                    {
                        arr = new char[n];
                        arr[n - 1] = s[i];
                    }
                    else
                    {
                        mas = new char[n - 1];
                        for (int j = 0; j < n - 1; j++) mas[j] = arr[j];
                        arr = new char[n];
                        for (int j = 0; j < n - 1; j++) arr[j] = mas[j];
                        arr[n - 1] = s[i];
                    }
                }
                for (int k = n - 1; k >= 0; k--) Console.Write(arr[k]);
                Console.Write(" ");
            }
            Console.ReadKey();
        }
    }
}
