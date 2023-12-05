using System;

namespace Tumakov14
{
    [DeveloperInfo("Ganiev Marat", "2023-12-03")]
    internal class RationalNumber
    {
        public int numerator;
        public int denominator;

        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменатель не может быть 0!!!");
            this.numerator = numerator;
            this.denominator = denominator;
            Simplify();
        }

        public static bool operator ==(RationalNumber x, RationalNumber y)
        {
            return x.Equals(y);
        }
        public static bool operator !=(RationalNumber x, RationalNumber y)
        {
            return !x.Equals(y);
        }
        public static RationalNumber operator +(RationalNumber x, RationalNumber y)
        {
            return new RationalNumber(x.numerator * y.denominator + x.denominator * y.numerator, x.denominator * y.denominator);
        }
        public static RationalNumber operator -(RationalNumber x, RationalNumber y)
        {
            return new RationalNumber(x.numerator * y.denominator - x.denominator * y.numerator, x.denominator * y.denominator);
        }
        public static RationalNumber operator *(RationalNumber x, RationalNumber y)
        {
            return new RationalNumber(x.numerator * y.numerator, x.denominator * y.denominator);
        }
        public static RationalNumber operator /(RationalNumber x, RationalNumber y)
        {
            if (y.numerator == 0)
                throw new DivideByZeroException("Деление на ноль!!!");
            return new RationalNumber(x.numerator * y.denominator, x.denominator * y.numerator);
        }
        public static RationalNumber operator %(RationalNumber x, RationalNumber y)
        {
            if (y.numerator == 0)
                throw new DivideByZeroException("Деление на ноль!!!");
            return new RationalNumber(((x.numerator * y.denominator) % (x.denominator * y.numerator)), x.denominator * y.denominator);
        }
        public static bool operator <(RationalNumber x, RationalNumber y)
        {
            return (x.numerator * y.denominator < x.denominator * y.numerator);
        }
        public static bool operator >(RationalNumber x, RationalNumber y)
        {
            return (x.numerator * y.denominator > x.denominator * y.numerator);
        }
        public static bool operator <=(RationalNumber x, RationalNumber y)
        {
            return (x.numerator * y.denominator <= x.denominator * y.numerator);
        }
        public static bool operator >=(RationalNumber x, RationalNumber y)
        {
            return (x.numerator * y.denominator >= x.denominator * y.numerator);
        }
        public static RationalNumber operator ++(RationalNumber x)
        {
            return x + new RationalNumber(1, 1);
        }
        public static RationalNumber operator --(RationalNumber x)
        {
            return x - new RationalNumber(1, 1);
        }
        public override string ToString()
        {
            if (numerator == denominator | numerator == 0)
            {
                return (numerator / denominator).ToString();
            }
            return $"{numerator}/{denominator}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            RationalNumber other = (RationalNumber)obj;
            return numerator == other.numerator && denominator == other.denominator;
        }
        public override int GetHashCode()
        {
            return numerator.GetHashCode() ^ denominator.GetHashCode(); // HashCode.Combine(numerator, denominator);
        }

        public static implicit operator float(RationalNumber rational)
        {
            return (float)rational.numerator / rational.denominator;
        }

        public static implicit operator int(RationalNumber   rational)
        {
            return rational.numerator / rational.denominator;
        }

        public static implicit operator RationalNumber(float num)
        {
            int numerator = (int)(num * (int)Math.Pow(10, 10));
            return new RationalNumber(numerator, (int)Math.Pow(10, 10));
        }
        private void Simplify()
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

        }
        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}