using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void testAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        T aPlusB = a.Add(b);
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Console.WriteLine("(a + b) = " + aPlusB);
        Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
        Console.WriteLine(" = = = ");
        T curr = a.Multiply(a);
        Console.WriteLine("a^2 = " + curr);
        T wholeRightPart = curr;
        curr = a.Multiply(b); // ab
        curr = curr.Add(curr); // ab + ab = 2ab
        Console.WriteLine("2*a*b = " + curr);

        wholeRightPart = wholeRightPart.Add(curr);
        curr = b.Multiply(b);
        Console.WriteLine("b^2 = " + curr);
        wholeRightPart = wholeRightPart.Add(curr);
        Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
        Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
    }

    static void testSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine("=== Starting testing a^2-b^2 and (a-b)*(a+b) with a = " + a + ", b = " + b + " ===");
        T aSquared = a.Multiply(a);
        T bSquared = b.Multiply(b);
        T difference = aSquared.Subtract(bSquared);
        Console.WriteLine("a^2 - b^2 = " + difference);

        T sum = a.Add(b);
        T product = a.Subtract(b).Multiply(sum);
        Console.WriteLine("(a - b) * (a + b) = " + product);

        Console.WriteLine("=== Finishing testing a^2-b^2 and (a-b)*(a+b) with a = " + a + ", b = " + b + " ===");
    }

    static void Main(string[] args)
    {
        MyFrac frac1 = new MyFrac(1, 3);
        MyFrac frac2 = new MyFrac(1, 6);
        MyComplex complex1 = new MyComplex(1, 3);
        MyComplex complex2 = new MyComplex(1, 6);

        testAPlusBSquare(frac1, frac2);
        testAPlusBSquare(complex1, complex2);

        testSquaresDifference(frac1, frac2);
        testSquaresDifference(complex1, complex2);

        // Sorting MyFrac objects
        MyFrac[] fractions = { new MyFrac(3, 4), new MyFrac(1, 2), new MyFrac(1, 4) };
        Array.Sort(fractions);
        Console.WriteLine("Sorted fractions:");
        foreach (var fraction in fractions)
        {
            Console.WriteLine(fraction);
        }

        Console.ReadKey();
    }
    }
}
