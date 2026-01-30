using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT6DFirstDemoAppCS.PartialClasses;

namespace IT6DFirstDemoAppCS.Indexer
{
    internal class IndexerDemo
    {
        public static void Main()
        {
            Students students = new Students();
            students.Add(new Student { id = 101, Name = "Raj", Age = 20, Semester = "IT4" });
            students.Add(new Student { id = 102, Name = "Keshav", Age = 22, Semester ="IT2" });
            students.Add(new Student { id = 103, Name = "Rajesh", Age = 21, Semester = "IT6" });
            students.Add(new Student { id = 104, Name = "Urvi", Age = 24, Semester = "IT8" });

            foreach (Student s in students.GetAll)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("----------------");
            Student required = students[102];
            Console.WriteLine(required);

            Console.WriteLine("----------------");
            Student[] selectedStudents = students["a"];
            foreach (Student s in selectedStudents)
            {
                if (s != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
