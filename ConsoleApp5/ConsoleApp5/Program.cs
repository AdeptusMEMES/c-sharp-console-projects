using System;
using System.Media;

namespace ConsoleApp3
{
    class Program
    {
        static bool Num(string s, int Max, int Min)
        {
            int a;
            if (!int.TryParse(s, out a)) return false;
            if (int.Parse(s) < Min || int.Parse(s) > Max) return false;
            return true;
        }

        static void Act()
        {
            string s;
            int t = 0;
            Explosiv E = new Explosiv();
            Console.Clear();
            E.Ent();
            do
            {
                E.Show();
                Console.Write($"\n1.Время прогорания\n2.Проверка даты запуска\n3.Анимация\n4.Страна производитель\n\n5.Выход\n");
                s = Console.ReadLine();
                if (Num(s, 5, 1))
                {
                    t = int.Parse(s);
                    switch (t)
                    {
                        case 1: E.Time(); break;
                        case 2:
                            {
                                Console.Write($"\nВведите дату запуска:\n");
                                s = Console.ReadLine();
                                E.Time(s);
                            }; break;
                        case 3: E.Animate(); break;
                        case 4: E.Country(); break;
                        default:; break;
                    }
                }
                Console.Clear();
            } while (t != 5);
        }

        static void ActF(IBomb F)
        {
            string s, OnOf="Выкл";
            int t = 0;
            Console.Clear();
            F.Ent();
            do
            {
                F.Show();
                Console.Write($"\n1.Время прогорания\n2.Время полёта\n3.Проверка даты запуска\n4.Анимация\n5.Страна производитель\n6.Обратный отсчёт:{OnOf}\n\n7.Выход\n");
                s = Console.ReadLine();
                if (Num(s, 7, 1))
                {
                    t = int.Parse(s);
                    switch (t)
                    {
                        case 1: F.Time(); break;
                        case 2: F.TimeFly(); break;
                        case 3:
                            {
                                Console.Write($"\nВведите дату запуска:\n");
                                s = Console.ReadLine();
                                F.Time(s);
                            }; break;
                        case 4: F.Animate(); break;
                        case 5: F.Country(); break;
                        case 6:
                            {
                                if (OnOf == "Выкл")
                                {
                                    F.OnCount += () =>
                                    {
                                        SoundPlayer CD = new SoundPlayer();
                                        CD.SoundLocation = "E:\\C# projects\\ConsoleApp5\\Countdown.wav";
                                        CD.Play();
                                        System.Threading.Thread.Sleep(7000);
                                        CD.Stop();
                                    };
                                    OnOf = "Вкл";
                                }
                                else
                                {
                                    F.CountOff();
                                    OnOf = "Выкл";
                                }
                            } break;
                        default:; break;
                    }
                }
                Console.Clear();
            } while (t != 7);
        }   

        static void Main(string[] args)
        {
            string s;
            int t = 0;
            do
            {
                Console.Write($"Смоделировать запуск пиротехнического изделия:\n");
                Console.Write($"1.Петарды\n2.Взлетающего заряда\n3.Высотного шара\n");
                Console.Write($"4.Одноцветной ракеты\n5.Многоцветной ракеты\n\n6.Выйти\n");
                s = Console.ReadLine();
                if (Num(s, 6, 1))
                {
                    t = int.Parse(s);
                    if(t==1)
                        Act();
                    else
                    {
                        switch (t)
                        {
                            case 2: ActF(new Flying()); break;
                            case 3: ActF(new HighBall()); break;
                            case 4: ActF(new Rocket()); break;
                            case 5: ActF(new CompRock()); break;
                            default:; break;
                        }
                    }
                }
                Console.Clear();
            } while (t != 6);
            Console.Write($"До свидания ;)");
            Console.ReadKey();
        }
    }
}
