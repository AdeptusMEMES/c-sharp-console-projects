using System;
using System.Text.RegularExpressions;

namespace ConsoleApp3
{
    class Flying : Explosiv,IBomb
    {
        protected double Hf, Vf;
        public event Count OnCount;

        public void CountOff()
        {
            OnCount = null;
        }

        public Flying() : base()
        {
            Hf = 1.0;
            Vf = 1.0;
        }

        public new void Ent()
        {
            base.Ent();
            double a;
            string s;
            bool T = false;
            do
            {
                Console.WriteLine("Введите высоту полёта(м):");
                s = Console.ReadLine();
                Console.Clear();
                if (double.TryParse(s, out a))
                {
                    if (double.Parse(s) > 0) T = true;
                    else T = false;
                }
                else T = false;
            } while (T == false);
            Hf = double.Parse(s);
            do
            {
                Console.WriteLine("Введите скорость полёта(<=1000 м/с):");
                s = Console.ReadLine();
                Console.Clear();
                if (double.TryParse(s, out a))
                {
                    if (double.Parse(s) > 0) T = true;
                    else T = false;
                }
                else T = false;
            } while (T == false);
            Vf = double.Parse(s);
        }

        public new void Show()
        {
            base.Show();
            Console.Write($"Высота полёта(м):{Hf}\nСкорость полёта(м/с):{Vf}\n");
        }

        protected void Fly(char[,] A, int W, int H, int bf, int bp, int p, int l)
        {
            Show(A, W, H);
            System.Threading.Thread.Sleep((int)(1000 / Vf));
            Console.Clear();
            sp.SoundLocation = "E:\\C# projects\\ConsoleApp5\\Fly.WAV";
            sp.Play();
            for (int i = bp - 1; i >= p / 2 + p % 2 - 1; i--)
            {
                A[i, bf + l + 1] = 'O';
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
                H = h + p / 2 + p % 2;
                bp = H - 1;
            }
            else
            {
                H = p;
                bp = p / 2 + p % 2 + h - 1;
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

        public void TimeFly()
        {
            Console.Write($"Время полёта: {Math.Round(Hf / Vf, 3)} с.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
