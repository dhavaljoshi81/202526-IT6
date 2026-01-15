using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6DFirstDemoAppCS
{
    internal class CallBackDemoClass
    {
        public MathDelegate mathManager { get; set; }
        private Math math = new Math();
        public CallBackDemoClass()
        {
            mathManager = new MathDelegate(math.Multiply);
        }
        public void GetResult(int a, int b)
        {
            if (mathManager != null)
            {
                int result = mathManager(a, b);
                Console.WriteLine("Result: " + result);
            }
            else
            {
                Console.WriteLine("No method assigned to delegate.");
            }
        }
    }
}
