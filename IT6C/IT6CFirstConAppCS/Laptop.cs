using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6CFirstConAppCS
{
    internal struct Laptop : IClassDesign
    {
        private int ModelNumber { get; set; }
        public string ModelName { get; set; }
        
        public string ModelDescription;
        public int Y
        {
            get => ModelNumber;
            set => ModelNumber = value;
        }

        public void Display()
        {
            Console.WriteLine("Display Laptop");
        }
        public void ShowInfo()
        {
            Console.WriteLine("Laptop Info");
        }

    }
}
