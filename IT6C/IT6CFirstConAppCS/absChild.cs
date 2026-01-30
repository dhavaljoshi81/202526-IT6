using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace IT6CFirstConAppCS
{
    internal class absChild : absParent
    {
        
        public override void Display()
        {
            Console.WriteLine("This is implemented abstract method in child class.");
        }
        
    }

    class IntChild : IClassDesign
    {
        private int y;
        public int Y 
        { 
            get => y; 
            set => y = value; 
        }

        public void Display()
        {
            throw new NotImplementedException();
        }
    }
}
