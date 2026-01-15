using IT6CFirstConAppCS.Test;

namespace IT6CFirstConAppCS
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            D objD = new D(55);
            objD.x = 100;
            //objD.Display();
            Console.WriteLine(objD);
        }

        static void Main2(string[] args)
        {
            D1 objD1 = new D1(200, 500);
            objD1.Display();
        }
    }
}
