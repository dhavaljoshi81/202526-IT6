using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6CFirstConAppCS
{
    public delegate int MathDelegate(int a, int b);

    internal class Math
    {
        public int Add(int a, int b)
        {
            Console.WriteLine("Adding numbers...");
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            Console.WriteLine("Subtracting numbers...");
            return a - b;
        }
        public int Multiply(int a, int b)
        {
            Console.WriteLine("Multiplying numbers...");
            return a * b;
        }
    }
}
