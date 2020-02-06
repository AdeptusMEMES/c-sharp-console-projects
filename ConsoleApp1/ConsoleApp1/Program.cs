using System;

namespace ConsoleApp1
{
    class Program
    {
        static bool Prov(string str)
        {
            bool a = true;
            int p;
            for (int i = 0; i < str.Length; i++)
            {
                p = str[i];
                if ((p > 1103 || p < 1072) && p != 1105) a = false;
            }
            return a;
        }
        static bool Povt(char a, ref char[] arr, int n)
        {
            bool b = true;
            for (int i = 1; i < n; i++) if (a == arr[i]) b = false;
            return b;
        }
        static void Main(string[] args)
        {
            bool r;
            int p, v;
            string k0, s;
            char[] arr;
            char k;

            p = v = 0;
            for (; ; )
            {
                Console.Write("Ведите слово из 3 и более букв (строчными буквами)\n");
                s = Console.ReadLine();
                Console.Clear();
                if (Prov(s) && s.Length >= 3) break;
            }
            arr = new char[s.Length];
            arr[0] = s[0];
            arr[s.Length - 1] = s[s.Length - 1];
            for (int i = 1; i < s.Length - 1; i++) arr[i] = '*';
            while (p < 6 && v < s.Length - 2)
            {
                for (; ; )
                {
                    Console.Write($"Введите букву(строчную).Попыток:{6 - p}\n\n");
                    switch (p)
                    {
                        case 0: Console.Write("____\n|  |\n|\n|\n|\n|\n\n"); break;
                        case 1: Console.Write("____\n|  |\n|  O\n|\n|\n|\n\n"); break;
                        case 2: Console.Write("____\n|  |\n|  O\n|  |\n|\n|\n\n"); break;
                        case 3: Console.Write("____\n|  |\n| _O\n|  |\n|\n|\n\n"); break;
                        case 4: Console.Write("____\n|  |\n| _O_\n|  |\n|\n|\n\n"); break;
                        case 5: Console.Write("____\n|  |\n| _O_\n|  |\n|  Г\n|\n\n"); break;
                    }
                    for (int i = 0; i < s.Length; i++) Console.Write($"{arr[i]}");
                    Console.Write("\n");
                    k0 = Console.ReadLine();
                    if (char.TryParse(k0, out k))
                    {
                        k = char.Parse(k0);
                        if (Povt(k, ref arr, s.Length - 1) && Prov(k0)) break;
                        Console.Clear();
                    }
                    else Console.Clear();
                }
                r = false;
                for (int i = 1; i < s.Length - 1; i++) if (k == s[i])
                    {
                        r = true;
                        arr[i] = k;
                        v++;
                    }
                if (r == false) p++;
                Console.Clear();
            }
            if (p == 6) Console.Write("____\n|  |\n| _O_\n|  |\n|  П \n|\n\nУвы, Вы проиграли(\nА ведь слово было такое простое: ");
            else Console.Write("Поздравляем, Вы выиграли!\nКонечно же, правильный ответ: ");
            Console.Write($"{s}");
            Console.ReadKey();
        }
    }
}