using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6DFirstDemoAppCS
{
    public class D
    {
        public D()
        {
            V2 = 10;
            V3 = 20;
        }
        public D(int v2, int v3)
        {
            V2 = v2;
            V3 = v3;
        }
        public int V1 { get; set; }
        private int V2 { get; set; }
        protected int V3 { get; set; }
        
        public override string ToString()
        {
            return "V1:"+ V1 + " V2:" + V2 + " V3:" + V3;
        }
        public virtual void Display()
        {
            Console.WriteLine("D Display");
        }
    }

    public class D2 : D
    {
        public D2(int x1, int y1) : base(x1, y1) 
        {
                
        }
        public override void Display()
        {
            base.Display(); 
            Console.WriteLine("D2 Display");
        }
        public void Display(string str)
        { 
            Console.WriteLine("D2 Display method has word " + str);
        }
        public override string ToString()
        {
            return "This is from D2";
        }
    }
}
