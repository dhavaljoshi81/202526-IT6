using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6CFirstConAppCS
{
    internal class StringManager
    {
        public void PrintUpperCase(string input)
        {
            Console.WriteLine(input.ToUpper());
        }
        public void PrintLowerCase(string input)
        {
            Console.WriteLine(input.ToLower());
        }
        public void ChangeValue(string input)
        {
            Console.WriteLine(input + " Changed Value");
        }
    }
}
