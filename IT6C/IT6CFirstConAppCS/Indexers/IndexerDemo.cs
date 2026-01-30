using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6CFirstConAppCS.Indexers
{
    internal class IndexerDemo
    {
        public static void Main()
        {
            Students studentList = new Students();
            studentList.Add(new Student
            {
                Id = 101,
                Name = "Pratham",
                Age = 20,
                Semester = "IT3"
            });
            studentList.Add(new Student
            {
                Id = 102,
                Name = "Darshan",
                Age = 23,
                Semester = "IT5"
            });
            studentList.Add(new Student
            {
                Id = 103,
                Name = "Prashant",
                Age = 20,
                Semester = "IT3"
            });
            studentList.Add(new Student
            {
                Id = 104,
                Name = "Roshan",
                Age = 25,
                Semester = "IT7"
            });

            foreach (Student s in studentList.GetAll)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("-------------------");
            Student s1 = studentList[102];
            Console.WriteLine(s1);

            Console.WriteLine("-------------------");
            Student[] result = studentList["sha"];
            foreach (Student stud in result)
            {
                Console.WriteLine(stud);
            }

        }
    }
}
