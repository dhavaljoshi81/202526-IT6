using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6DFirstDemoAppCS
{
    internal class Math
    {
        public int Add(int a, int b)
        {
            Console.WriteLine("Performing Addition:");
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            Console.WriteLine("Performing Subtraction:");
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            Console.WriteLine("Performing Multiplication:");
            return a * b;
        }

        public double Divide(int a, int b)
        {
            Console.WriteLine("Performing Division:");
            if (b == 0)
            {
                throw new DivideByZeroException("Denominator cannot be zero.");
            }
            return (double)a / b;
        }
    }
}
