using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6CFirstConAppCS
{
    internal abstract class absParent
    {
        public int x;
        public int Y { get; set; }

        public abstract void Display();

        public void Test()
        {
            Console.WriteLine("This is a concrete method in abstract class.");
        }
    }

    public interface IClassDesign
    {
        
        public int Y { get; set; }
        void Display();

        public void Test()
        {
            Console.WriteLine("This is a concrete method in abstract class.");
        }
    }
}
