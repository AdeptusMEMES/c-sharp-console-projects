using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Fraction
    {
        protected int N, M;

        public Fraction()
        {
            N = 1;
            M = 1;
        }

        public Fraction(int n, int m)
        {
            N = n;
            M = m;
        }

        public Fraction(string s)
        {
            string [] S = s.Split('/');
            N = int.Parse(S[0]);
            M = int.Parse(S[1]);
        }

        public int n
        {
            get => N;
            set => N = value;
        }

        public int m
        {
            get => M;
            set
            {
                if (value > 0)
                {
                    M = value;
                }
                else
                    throw new Exception("Число должно быть натуральным!");
            }
        }

        protected static int Gcd(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a<=b)
            {
                a = a + b;
                b = a - b;
                a = a - b;
            }
            while (b!=0)
            {
                a %= b;
                a = a + b;
                b = a - b;
                a = a - b;
            }
            return a;
        }

        protected static Fraction Rfr(Fraction a)
        {
            int k = Gcd(a.m, a.n);
            a.n /= k;
            a.m /= k;
            return a;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction result = new Fraction();
            result.m = a.m * b.m;
            result.n = a.n * result.m / a.m + b.n * result.m / b.m;
            result=Rfr(result);
            return result;
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction result = new Fraction();
            result.m = a.m * b.m;
            result.n = a.n * result.m / a.m - b.n * result.m / b.m;
            result = Rfr(result);
            return result;
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            Fraction result = new Fraction();
            result.m = a.m * b.m;
            result.n = a.n * b.n;
            result = Rfr(result);
            return result;
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            Fraction result = new Fraction();
            result.m = a.m * b.n;
            result.n = a.n * b.m;
            result = Rfr(result);
            return result;
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            if (a.n * b.m > b.n * a.m)
                return true;
            return false;
        }

        public static  bool operator <(Fraction a, Fraction b)
        {
            if (a.n * b.m < b.n * a.m)
                return true;
            return false;
        }

        public static bool operator <=(Fraction a, Fraction b)
        {
            if (a.n * b.m <= b.n * a.m)
                return true;
            return false;
        }

        public static bool operator >=(Fraction a, Fraction b)
        {
            if (a.n * b.m >= b.n * a.m)
                return true;
            return false;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            if (a.n * b.m != b.n * a.m)
                return true;
            return false;
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            if (a.n * b.m == b.n * a.m)
                return true;
            return false;
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", this.n, this.m);
        }

        public override bool Equals(object a)
        {
            if (a.GetType() != this.GetType()) return false;
            Fraction fr = (Fraction)a;
            return (this.n*fr.m == this.m*fr.n);
        }

        public static implicit operator Fraction(int x)
        {
            return new Fraction(x, 1);
        }

        public static explicit operator int(Fraction fr)
        {
            return fr.n/fr.m;
        }
        
        //Math.Round(1.5453, 3)

    }
}
