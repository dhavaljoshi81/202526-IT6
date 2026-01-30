using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6CFirstConAppCS.Indexers
{
    internal class Students
    {
        private Student[] students = new Student[5];
        private int count = 0;
        public Student[] GetAll 
        { 
            get
            {
                return students;
            }
        }
        public void Add(Student newStudent)
        {
            if (count < students.Length)
            {
                students[count] = newStudent;
                count++;
            }            
        }

        public Student this[int index]
        {
            get 
            {
                foreach (Student s in students)
                {
                    if (s.Id == index)
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
                    if (s.Id == index)
                    {
                        stud = s;
                        stud = value;
                    }
                }
            }
        }

        public Student[] this[string name]
        {
            get 
            {
                Student[] studList = new Student[students.Length];
                int count = 0;

                foreach (Student s in students)
                {
                    if (s != null && s.Name.ToLower().Contains(name.ToLower()))
                    {
                        studList[count++] = s;
                    }
                }
                return studList;
            }
            set { /* set the specified index to value here */ }
        }
    }
}
