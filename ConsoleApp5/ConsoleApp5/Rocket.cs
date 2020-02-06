using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class Rocket : Flying, IBomb
    {
        protected ConsoleColor Cl;
        public new event Count OnCount;

        public new void CountOff()
        {
            OnCount = null;
        }


        public Rocket() : base()
        {
            ConsoleColor Cl = ConsoleColor.Red;
        }

        public new void Ent()
        {
            int a;
            string s;
            bool T;
            base.Ent();
            do
            {
                T = true;
                Console.WriteLine("Выберите цвет взрыва:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("1.Красный");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("2.Жёлтый");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("3.Зелёный");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("4.Бирюзовый");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("5.Голубой");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("6.Пурпурный");
                Console.ResetColor();
                s = Console.ReadLine();
                if (!int.TryParse(s, out a)) T = false;
                else
                {
                    a = int.Parse(s);
                    switch (a)
                    {
                        case 1: Cl = ConsoleColor.Red; break;
                        case 2: Cl = ConsoleColor.Yellow; break;
                        case 3: Cl = ConsoleColor.Green; break;
                        case 4: Cl = ConsoleColor.Cyan; break;
                        case 5: Cl = ConsoleColor.Blue; break;
                        case 6: Cl = ConsoleColor.Magenta; break;
                        default: T = false; break;
                    }
                }
                Console.Clear();
            } while (!T);
        }

        public new void Show()
        {
            base.Show();
            Console.Write($"Цвет:");
            Console.ForegroundColor = Cl;
            Console.Write($"*\n");
            Console.ResetColor();
        }

        protected new void Create(char[,] A, int W, int H, int bf, int bp, int l)
        {
            for (int i = 0; i < H; i++) for (int j = 0; j < W; j++) A[i, j] = ' ';
            A[bp, bf] = '*';
            for (int j = bf + 1; j < bf + l + 1; j++) A[bp, j] = '-';
            A[bp - 1, bf + l + 1] = 'A';
            A[bp, bf + l + 1] = 'Ш';
        }

        protected new void Show(char[,] A, int W, int H)
        {
            Console.Clear();
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    if (A[i, j] == '*' || A[i, j] == '^') Console.ForegroundColor = Cl;
                    Console.Write($"{A[i, j]}");
                    Console.ResetColor();
                }
                Console.Write($"\n");
            }
        }

        protected new void Blow(char[,] A, int W, int p, int be)
        {
            for (int i = 1; i < p + 1; i++) for (int j = be; j < W; j++)
            {
                if (((j - be) + (i - 1)) % 2 == 0) A[i, j] = '*';
                else A[i, j] = ' ';
            }
            sp.SoundLocation = "E:\\C# projects\\ConsoleApp5\\Blow.WAV";
            sp.Play();
            for (int k = 0; k < 3; k++)
            {

                Show(A, W, p + 1);
                System.Threading.Thread.Sleep(300);
                Console.Clear();
                System.Threading.Thread.Sleep(300);
            }
            sp.Stop();
            Console.Clear();
        }

        protected new void Fly(char[,] A, int W, int H, int bf, int bp, int p, int l)
        {
            sp.SoundLocation = "E:\\C# projects\\ConsoleApp5\\Fly.WAV";
            sp.Play();
            for (int i = bp - 1; i >= p / 2 + p % 2; i--)
            {
                A[i - 1, bf + l + 1] = 'A';
                A[i, bf + l + 1] = 'Ш';
                A[i + 1, bf + l + 1] = '^';
                if (i + 2 < H) A[i + 2, bf + l + 1] = ' ';
                System.Threading.Thread.Sleep((int)(1000 / Vf));
                Show(A, W, H);
            }
            sp.Stop();
            System.Threading.Thread.Sleep(300);
            A[p / 2 + p % 2 - 1, bf + l + 1] = ' ';
            A[p / 2 + p % 2, bf + l + 1] = ' ';
        }

        public new void Animate()
        {
            int W, H, be, bf, bp, l, p, h;
            if (P - (int)P > 0) p = (int)P + 1;
            else p = (int)P;
            if (L - (int)L > 0) l = (int)L + 1;
            else l = (int)L;
            if (Hf - (int)Hf > 0) h = (int)Hf + 1;
            else h = (int)Hf;
            if (l + 1 >= p / 2)
            {
                W = l + 1 + p / 2 + p % 2;
                be = l - p / 2 + 1;
                bf = 0;
            }
            else
            {
                W = p;
                be = 0;
                bf = p / 2 + p % 2 - l - 2;
            }
            if (h >= p / 2)
            {
                H = h + p / 2 + p % 2 + 1;
                bp = H - 1;
            }
            else
            {
                H = p + 1;
                bp = p / 2 + p % 2 + h;
            }
            char[,] A = new char[H, W];
            Create(A, W, H, bf, bp, l);
            Show(A, W, H);
            Console.ReadKey();
            Burn(A, W, H, bf, bp, l);
            if (OnCount != null)
                OnCount();
            Fly(A, W, H, bf, bp, p, l);
            Blow(A, W, p, be);
        }
    }
}

