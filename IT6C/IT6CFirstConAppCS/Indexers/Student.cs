using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6CFirstConAppCS.Indexers
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Semester { get; set; }

        public override string ToString()
        {
            return "ID:" + Id + " Name:" + Name
                 + " Age:" + Age + " Semester:" + Semester;
        }

    }
}
