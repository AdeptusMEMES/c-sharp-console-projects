using System;

namespace ConsoleApp2._2
{
    class Program
    {
        static bool Prov(string str)
        {
            bool a = true;
            for (int i = 0; i < str.Length; i++)if (str[i] > 122 || str[i] < 97) a = false;
            return a;
        }

        static void Main(string[] args)
        {
            string s;
            bool k,k1=false;
            for (; ; )
            {
                s = Console.ReadLine();
                if (Prov(s)) break;
                else Console.Clear();
            }
            char[] arr = new char[s.Length];
            for (int i = 0; i < s.Length; i++) arr[i] = s[i];
            for (int i = 0; i < s.Length; i++)
            {
                k = (arr[i] == 97 || arr[i] == 101 || arr[i] == 105 || arr[i] == 111 || arr[i] == 117 || arr[i] == 121);
                if (k1)
                {
                    if (arr[i] == 122) arr[i] = 'a';
                    else arr[i]++;
                }
                k1 = k;
            }
            for (int i = 0; i < s.Length; i++) Console.Write($"{arr[i]}");
            Console.ReadKey();
        }
    }
}
