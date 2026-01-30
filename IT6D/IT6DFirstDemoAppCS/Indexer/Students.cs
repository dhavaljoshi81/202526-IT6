using IT6DFirstDemoAppCS.PartialClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6DFirstDemoAppCS.Indexer
{
    internal class Students
    {
        private int current = 0;
        private Student[] students = new Student[10];
        public Student[] GetAll 
        {
            get
            {
                return students;
            }
        }

        public void Add(Student newStudent)
        {
            if (current < 10)
            {
                students[current] = newStudent;
                current++;
            }
        }

        public Student this[int index]
        {
            get 
            {
                foreach (Student s in students)
                {
                    if (s.id == index)
                    {
                        return s;
                    }
                }
                return null;
            }
            set 
            {
                Student stud = null;
                foreach (Student s in students)
                {
                    if (s.id == index)
                    {
                        stud = s;
                        stud = value;
                        break;
                    }
                }
            }
        }

        public Student[] this[string name]
        {
            get 
            {
                Student[] result = new Student[students.Length];
                int count = 0;
                foreach (Student s in students)
                {
                    if (s!= null && s.Name.ToLower().Contains(name.ToLower()))
                    {
                        result[count] = s;
                        count++;
                    }
                }
                return result;
            }
            
        }

    }
}
