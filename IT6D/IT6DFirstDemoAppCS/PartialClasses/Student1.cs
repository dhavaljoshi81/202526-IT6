using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6DFirstDemoAppCS.PartialClasses
{
    internal partial class Student 
    {
        public override string ToString()
        {
            return "ID:" + id + " Name:" + Name + " Age:" + Age + " Semester:" + Semester ;
        }
        public void Dispaly()
        {
            Console.WriteLine("Dispaly from Student class");
        }

    }
}
