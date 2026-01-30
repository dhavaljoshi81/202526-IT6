using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6DFirstDemoAppCS.PartialClasses
{
    internal class PartialDemo
    {
        public static void Main1()
        {
            Student student = new Student();
            student.Name = "Test";
            student.Dispaly();
            Console.WriteLine(student);
        }
    }
}
