using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConsoleApp1
{
    public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        private BigInteger numerator;
        private BigInteger denominator;

        public MyFrac(BigInteger nom, BigInteger denom)
        {
            if (denom == 0)
                throw new DivideByZeroException("Denominator cannot be zero.");

            numerator = nom;
            denominator = denom;
            Simplify();
        }

        public MyFrac(int nom, int denom) 
        {
            this.numerator = new BigInteger(nom);
            this.denominator = new BigInteger(denom);

            if (denominator == 0)
                throw new DivideByZeroException("Denominator cannot be zero.");

            Simplify();
        }

        public MyFrac(int nom) : this(nom, 1)// виклик конструктора
        {
        }

        public MyFrac Add(MyFrac b)
        {
            return new MyFrac(numerator * b.denominator + b.numerator * denominator, denominator * b.denominator);
        }

        public MyFrac Subtract(MyFrac b)
        {
            return new MyFrac(numerator * b.denominator - b.numerator * denominator, denominator * b.denominator);
        }

        public MyFrac Multiply(MyFrac b)
        {
            return new MyFrac(numerator * b.numerator, denominator * b.denominator);
        }

        public MyFrac Divide(MyFrac b)
        {
            if (b.numerator == 0)
                throw new DivideByZeroException("Cannot divide by zero.");

            return new MyFrac(numerator * b.denominator, denominator * b.numerator);
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        public int CompareTo(MyFrac other)
        {
            BigInteger thisValue = numerator * other.denominator;
            BigInteger otherValue = other.numerator * denominator;

            return thisValue.CompareTo(otherValue);
        }

        private void Simplify()
        {
            BigInteger gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
        }
    }
}
