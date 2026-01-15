using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6CFirstConAppCS
{
    public delegate void DisplayDelegate(string message);

    internal class DelegateDemo
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine("Message: " + message);
        }

        static void Main1(string[] args)
        {
            DelegateDemo demo = new DelegateDemo();
            DisplayDelegate display = new DisplayDelegate(demo.ShowMessage);
            display("IT6C .NET");
        }

        static void Main2(string[] args)
        {
            StringManager strManager = new StringManager();

            DisplayDelegate display = new DisplayDelegate(strManager.PrintLowerCase);

            display += new DisplayDelegate(strManager.PrintUpperCase);

            display += new DisplayDelegate(strManager.ChangeValue);

            display("Hello IT6C Div.");
        }

        static void Main3(string[] args)
        {
            StringManager strManager = new StringManager();

            DisplayDelegate displayL = new DisplayDelegate(strManager.PrintLowerCase);

            DisplayDelegate displayU = new DisplayDelegate(strManager.PrintUpperCase);

            DisplayDelegate displayCV = new DisplayDelegate(strManager.ChangeValue);

            //displayL("Hello IT6C Div.");
            //displayU("Hello IT6C Div.");
            //displayCV("Hello IT6C Div.");

            DisplayDelegate displayAll = displayL + displayU + displayCV;
            displayAll("Hello IT6C Div.");
            Console.WriteLine("----- Removing UpperCase Method -----");
            displayAll -= displayU;
            displayAll -= displayL;
            displayAll("Hello IT6C Div.");
        }

        static void Main4(string[] args)
        {
            Math math = new Math();
            
            MathDelegate delM = new MathDelegate(math.Multiply);

            MathDelegate delS = new MathDelegate(math.Subtract);

            MathDelegate delA = new MathDelegate(math.Add);

            MathDelegate del = delA + delM + delS;

            Console.WriteLine(del(5, 7));

            Console.WriteLine("----------");

            del -= delM;

            Console.WriteLine(del(5, 7));
        }

        static void Main5(string[] args)
        {
            DataManager dataManager = new DataManager();
            
            dataManager.displayManager = new DisplayDelegate(ShowNewMessage);
            
            dataManager.displayManager("Hello from IT6C");
        }

        static void ShowNewMessage(string message)
        {
            Console.WriteLine("New Message: " + message);
        }

        static void ShowDataMessage(string message)
        {
            Console.WriteLine("Message for you: " + message);
        }

        static void Main(string[] args)
        {
            DataManager dataManager = new DataManager();
            
            //DisplayDelegate displayDelegate = new DisplayDelegate(ShowNewMessage);

            //dataManager.ShowYourMessage(displayDelegate);

            DisplayDelegate displayDataDelegate 
                = new DisplayDelegate(ShowDataMessage);

            dataManager.ShowYourMessageWithData(
                displayDataDelegate, ""); // "DICT, VNSGU");
        }
    }
}
