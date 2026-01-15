using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6CFirstConAppCS
{
    public class D
    {
        public int x;
        private int y;
        protected int z;

        public D()
        {
            x = 10;
            y = 20;
            z = 30;
            Console.WriteLine("D Constructor");
        }

        public D(int v1, int v2 = 66)
        {
            y = v1;
            z = v2;
            Console.WriteLine("D Constructor");
        }

        public override string ToString()
        {
            return "x:" + x + " y:" + y + " z:" + z;
        }

        public void Display()
        {
            Console.WriteLine("x:" + x + " y:" + y + " z:" + z);
        }
    }

    public class D2
    {

    }
}
