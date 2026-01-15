using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6DFirstDemoAppCS
{
    public delegate void MyDelegate(int x);
    internal class DelegateDemo
    {
        public void MethodA(int a)
        {
            Console.WriteLine("Method A called with value: " + a);
        }

        public void MethodB(int b)
        {
            Console.WriteLine("This is MethodB with data " + b * 10);
        }
        static void Main1(string[] args)
        {
            DelegateDemo demo = new DelegateDemo();
            MyDelegate del = new MyDelegate(demo.MethodB);
            del += new MyDelegate(demo.MethodA);
            del(5);
            Console.WriteLine("---- Adding another delegate ----");
            MyDelegate newDel = new MyDelegate(demo.MethodA);
            del += newDel;
            del(11);
            Console.WriteLine("---- Removing a delegate ----");
            del -= newDel;
            del(7);
        }
    }
}
