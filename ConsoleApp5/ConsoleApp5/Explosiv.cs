using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace ConsoleApp3
{
    class Explosiv
    {
        protected double P, L, V, R;
        protected DateTime D;
        protected int S;
        protected string N, C;
        protected SoundPlayer sp = new SoundPlayer();

        public Explosiv()
        {
            N = "noname";
            C = "0000000000000";
            P = 1.0;
            V = 1.0;
            L = 1.0;
            D = DateTime.Parse("01.01.0001");
            S = 0;
            R = 0.0;
        }

        public double Price
        {
            get
            {
                return R;
            }
        }

        public string Name
        {
            get
            {
                return N;
            }
        }

        public void Ent()
        {
            double a;
            DateTime b;
            int c=0;
            string s;
            bool T = false;
            Console.WriteLine("Введите название продукта:");
            s = Console.ReadLine();
            N = s;
            Console.Clear();
            do
            {
                Console.WriteLine("Введите серийный номер(тринадцатиначный):");
                s = Console.ReadLine();
                if (!(Regex.IsMatch(s, @"^[0-9]{13}$", RegexOptions.Singleline)))
                    c = 0;
                else
                    c = 1;
                try
                {
                    c = 1 / c;
                }
                catch
                {
                    Console.WriteLine("Серийный номер введён неверно!");
                    Console.ReadKey();
                }
                Console.Clear();
            } while (c != 1);
            C = s;
            do
            {
                Console.WriteLine("Введите радиус взрыва(м):");
                s = Console.ReadLine();
                Console.Clear();
                if (double.TryParse(s, out a))
                {
                    if (double.Parse(s) > 0) T = true;
                    else T = false;
                }
                else T = false;
            } while (T == false);
            P = double.Parse(s);
            do
            {
                Console.WriteLine("Введите скорость прогорания(<=1000 м/с):");
                s = Console.ReadLine();
                Console.Clear();
                if (double.TryParse(s, out a))
                {
                    if (double.Parse(s) > 0 && double.Parse(s) <= 1000) T = true;
                    else T = false;
                }
                else T = false;
            } while (T == false);
            V = double.Parse(s);
            do
            {
                Console.WriteLine("Введите длину фитиля(м):");
                s = Console.ReadLine();
                Console.Clear();
                if (double.TryParse(s, out a))
                {
                    if (double.Parse(s) > 0) T = true;
                    else T = false;
                }
                else T = false;
            } while (T == false);
            L = double.Parse(s);
            do
            {
                Console.WriteLine("Введите дату изготовления(dd.mm.yyyy): ");
                s = Console.ReadLine();
                Console.Clear();
            } while (!DateTime.TryParseExact(s, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out b));
            D = DateTime.ParseExact(s, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
            do
            {
                Console.WriteLine("Введите срок годности(годы):");
                s = Console.ReadLine();
                Console.Clear();
                if (int.TryParse(s, out c))
                {
                    if (int.Parse(s) > 0) T = true;
                    else T = false;
                }
                else T = false;
            } while (T == false);
            S = int.Parse(s);
            do
            {
                Console.WriteLine("Введите цену(рубли):");
                s = Console.ReadLine();
                Console.Clear();
            } while (!Regex.IsMatch(s, @"[0-9]+" + @",[0-9]{2}$", RegexOptions.Singleline));
            R = double.Parse(s);
        }

        public void Show()
        {
            Console.Write($"\nНазвание: {N}\nСерийный номер: {C}\nРадиус взрыва(м): {P}\n");
            Console.Write($"Скорость прогорания(м/с): {V}\nДлина фитиля(м): {L}\nДата изготовления: {D.ToString("d")}\n");
            Console.Write($"Срок годности(годы): {S}\nЦена(руб.): {R}\n");
        }

        public void Time()
        {
            Console.Write($"Время прогорания фитиля: {Math.Round(L / V, 3)} с.");
            Console.ReadKey();
            Console.Clear();
        }

        protected void Create(char[,] A, int W, int H, int bf, int bp, int l)
        {
            for (int i = 0; i < H; i++) for (int j = 0; j < W; j++) A[i, j] = ' ';
            A[bp, bf] = '*';
            for (int j = bf + 1; j < bf + l + 1; j++) A[bp, j] = '-';
            A[bp, bf + l + 1] = 'O';
        }

        protected void Show(char[,] A, int W, int H)
        {
            Console.Clear();
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    if (A[i, j] == '*' || A[i, j] == '^') Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{A[i, j]}");
                    Console.ResetColor();
                }
                Console.Write($"\n");
            }
        }

        protected void Burn(char[,] A, int W, int H, int bf, int bp, int l)
        {
            sp.SoundLocation = "E:\\C# projects\\ConsoleApp5\\Burn.WAV";
            sp.PlayLooping();
            for (int j = bf + 1; j < bf + l + 1; j++)
            {
                System.Threading.Thread.Sleep((int)(1000 / V));
                A[bp, j - 1] = ' ';
                A[bp, j] = '*';
                Show(A, W, H);
            }
            sp.Stop();
            System.Threading.Thread.Sleep((int)(300));
            A[bp, bf + l] = ' ';
        }

        protected void Blow(char[,] A, int W, int p, int be)
        {
            for (int i = 0; i < p; i++) for (int j = be; j < W; j++)
            {
                if ((j - be + i) % 2 == 0) A[i, j] = '*';
                else A[i, j] = ' ';
            }
            sp.SoundLocation = "E:\\C# projects\\ConsoleApp5\\Blow.WAV";
            sp.Play();
            for (int k = 0; k < 3; k++)
            {
                Show(A, W, p);
                System.Threading.Thread.Sleep(300);
                Console.Clear();
                System.Threading.Thread.Sleep(300);
            }
            sp.Stop();
            Console.Clear();
        }

        public void Animate()
        {
            int W, be, bf, l, p;
            if (P - (int)P > 0) p = (int)P + 1;
            else p = (int)P;
            if (L - (int)L > 0) l = (int)L + 1;
            else l = (int)L;
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
            char[,] A = new char[p, W];
            Create(A, W, p, bf, p / 2, l);
            Show(A, W, p);
            Console.ReadKey();
            Burn(A, W, p, bf, p / 2, l);
            Blow(A, W, p, be);
        }

        public void Time(string s)
        {
            DateTime DN;
            if (DateTime.TryParseExact(s, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DN))
            {
                DN = DateTime.ParseExact(s, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                if (DN.CompareTo(D) < 0) Console.WriteLine("\nВыбранная дата раньше даты производства\n");
                else
                {
                    DateTime DL = D.AddYears(S);
                    if (DN.CompareTo(DL) > 0) Console.WriteLine("\nНельзя запускать\n");
                    else Console.WriteLine("\nМожно запускать\n");
                }
            }
            else Console.WriteLine("\nНеверный ввод\n");
            Console.ReadKey();
            Console.Clear();
        }

        public void Country()
        {
            List<string> L = new List<string>();
            string country = "Unknown";
            string[] l;
            int N = 0, Max, Min;
            FileStream F = new FileStream("E:\\C# projects\\ConsoleApp5\\Countryes.txt", FileMode.Open);
            StreamReader RF = new StreamReader(F, Encoding.Default);
            while (!RF.EndOfStream)
            {
                L.Add(RF.ReadLine());
            }
            RF.Close();
            F.Close();
            int Code = int.Parse(C.Substring(0, C.Length - 10));
            while (L.Count > 0 && country == "Unknown")
            {
                l = L[L.Count / 2].Split('-');
                Min = int.Parse(l[0]);
                Max = int.Parse(l[l.Length - 2]);
                if (Code >= Min && Code <= Max) country = l[l.Length - 1];
                N = L.Count / 2;
                if (Code > Max) for (int i = 0; i < N + 1; i++) L.Remove(L[0]);
                if (Code < Min) for (int i = 0; i < N; i++) L.Remove(L[L.Count - 1]);
            }
            Console.Write($"\nСтрана производитель: {country}");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
