using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6CFirstConAppCS.Test
{
    internal class D1 : D
    {
        public D1()
        {
            x = 1;
            z = 2;
            Console.WriteLine("D1 Constructor");
        }
        public D1(int r1, int r2) : base(r1)
        {
            x = 10;
            z = r2;
            Console.WriteLine("D1 Constructor");
        }
    }
}
