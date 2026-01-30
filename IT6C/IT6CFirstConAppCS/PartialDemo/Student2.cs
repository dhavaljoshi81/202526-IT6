using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6CFirstConAppCS.PartialDemo
{
    internal partial class Student
    {
        public int StudentID { get; set; }
        public void Read(string book)
        {
            Console.WriteLine("Reading a book " + book);
        }
    }
}
