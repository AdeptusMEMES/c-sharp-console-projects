using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Col(string S)
        {
            int n;
            for (int k = 0; k < 10; k++)
            {
                n = 0;
                for (int i = 0; i < S.Length; i++) if (S[i] == k + 48) n++;
                Console.Write($"{k}-{n}  ");
            }
        }
        static void Main(string[] args)
        {
            string s = DateTime.Now.ToString("dd MMMM yyyy  HH:mm");
            Console.Write($"{s}\n");
            Col(s);
            string s0 = DateTime.Now.ToString("MM.dd.yy  HH:mm:ss");
            Console.Write($"\n{s0}\n");
            Col(s0);
            Console.ReadKey();
        }
    }
}
