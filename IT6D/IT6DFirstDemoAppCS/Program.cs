namespace IT6DFirstDemoAppCS
{
    public delegate int MathDelegate(int a, int b);
    internal class Program
    {

        static void Main1(string[] args)
        {
            D objD = new D(30, 40);
            objD.V1 = 1;
            Console.WriteLine(objD);
        }
        static void Main2(string[] args)
        {
            D2 d2 = new D2(22,33);
            d2.V1 = 100;
            Console.WriteLine(d2);
            d2.Display();
            Console.WriteLine("--------");
            d2.Display("abc");
        }
        static void Main3(string[] args)
        {
            Math math = new Math();
            
            MathDelegate mathDelegate = new MathDelegate(math.Add);
            
            Console.WriteLine("Addition " + mathDelegate(10,20));
            Console.WriteLine("--------");
            mathDelegate += new MathDelegate(math.Subtract);
            Console.WriteLine("Subtraction " + mathDelegate(10, 20));
            mathDelegate += new MathDelegate(math.Multiply);
            Console.WriteLine("Final Result " + mathDelegate(10, 20));
        }
        static void Main4(string[] args)
        {
            CallBackDemoClass callBackDemoClass = new CallBackDemoClass();
            callBackDemoClass.GetResult(10, 20);
            callBackDemoClass.mathManager 
                += new MathDelegate(Program.DataChanger);
            Console.WriteLine("--------");
            callBackDemoClass.GetResult(7, 5);
        }

        public static int DataChanger(int x, int y)
        {
            Console.WriteLine("DataChanger called");
            return x + y + 100;
        }
    }
}
