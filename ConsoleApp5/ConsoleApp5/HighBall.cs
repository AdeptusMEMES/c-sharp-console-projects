using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class HighBall : Flying, IBomb
    {
        protected double He;
        public new event Count OnCount;

        public new void CountOff()
        {
            OnCount = null;
        }

        public HighBall() : base()
        {
            He = 1.0;
        }

        public new void Ent()
        {
            int c=0;
            double a;
            string s;
            base.Ent();
            do
            {
                Console.WriteLine("Введите высоту взрыва(дм):");
                s = Console.ReadLine();
                if (double.TryParse(s, out a))
                {
                    if (double.Parse(s) > 0 && double.Parse(s) <= Hf)
                        c =1;
                    else
                        c =0;
                    try
                    {
                        c = 1 / c;
                    }
                    catch
                    {
                        Console.Write($"Максимальная высота взрыва:{Hf} дм. Минимальная должна быть больше 0!");
                        Console.ReadKey();
                    }
                }
                Console.Clear();
            } while (c != 1);
            He = double.Parse(s);
        }

        public new void Show()
        {
            base.Show();
            Console.Write($"Высота взрыва(дм):{He}\n");
        }

        protected new void Create(char[,] A, int W, int H, int bf, int bp, int l)
        {
            for (int i = 0; i < H; i++) for (int j = 0; j < W; j++) A[i, j] = ' ';
            A[bp, bf] = '*';
            for (int j = bf + 1; j < bf + l + 1; j++) A[bp, j] = '-';
            A[bp, bf + l + 1] = 'П';
        }

        protected void Fly(char[,] A, int W, int H, int bf, int bp, int p, int l, int h, int he)
        {
            Show(A, W, H);
            System.Threading.Thread.Sleep((int)(1000 / Vf));
            Console.Clear();
            sp.SoundLocation = "E:\\C# projects\\ConsoleApp5\\Fly.WAV";
            sp.Play();
            for (int i = bp; i >= bp - h; i--)
            {
                if (i < bp && A[i, bf + l + 1] != 'П') A[i, bf + l + 1] = 'O';
                if (i + 1 < bp && A[i + 1, bf + l + 1] != 'П') A[i + 1, bf + l + 1] = '^';
                if (i + 2 < bp && A[i + 2, bf + l + 1] != 'П') A[i + 2, bf + l + 1] = ' ';
                System.Threading.Thread.Sleep((int)(1000 / Vf));
                Show(A, W, H);
            }
            sp.Stop();
            for (int i = bp - h + 1; i <= bp - he; i++)
            {
                if (A[i, bf + l + 1] != 'П') A[i, bf + l + 1] = 'O';
                if (A[i - 1, bf + l + 1] != 'П') A[i - 1, bf + l + 1] = ' ';
                System.Threading.Thread.Sleep((int)(1000 / Vf));
                Show(A, W, H);
            }
            System.Threading.Thread.Sleep(300);
            if (bp - he + 1 < H) A[bp - he + 1, bf + l + 1] = ' ';
        }

        protected void Blow(char[,] A, int W, int H, int p, int be, int bey)
        {
            for (int i = bey; i < bey + p; i++) for (int j = be; j < W; j++)
            {
                if ((j - be + i - bey) % 2 == 0) A[i, j] = '*';
                else A[i, j] = ' ';
            }
            sp.SoundLocation = "E:\\C# projects\\ConsoleApp5\\Blow.WAV";
            sp.Play();
            for (int k = 0; k < 3; k++)
            {
                Show(A, W, H);
                System.Threading.Thread.Sleep(300);
                Console.Clear();
                System.Threading.Thread.Sleep(300);
            }
            sp.Stop();
            Console.Clear();
        }

        public new void Animate()
        {
            int W, H, be, bey, bf, bp, l, p, h, he;
            if (P - (int)P > 0) p = (int)P + 1;
            else p = (int)P;
            if (L - (int)L > 0) l = (int)L + 1;
            else l = (int)L;
            if (Hf - (int)Hf > 0) h = (int)Hf + 1;
            else h = (int)Hf;
            if (He - (int)He > 0) he = (int)He + 1;
            else he = (int)He;
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
            if (he >= p / 2)
            {
                H = h + p / 2 + p % 2;
                bp = H - 1;
            }
            else
            {
                H = h + p;
                bp = H - p / 2 - 1;
            }
            bey = bp - he - p / 2 - p % 2 + 1;
            char[,] A = new char[H, W];
            Create(A, W, H, bf, bp, l);
            Show(A, W, H);
            Console.ReadKey();
            Burn(A, W, H, bf, bp, l);
            if (OnCount != null)
                OnCount();
            Fly(A, W, H, bf, bp, p, l, h, he);
            Blow(A, W, H, p, be, bey);
        }

        public new void TimeFly()
        {
            Console.Write($"Время полёта: {Math.Round(((2 * Hf - He) / Vf), 3)} с.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

