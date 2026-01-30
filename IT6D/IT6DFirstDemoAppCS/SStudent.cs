using IT6DFirstDemoAppCS.PartialClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT6DFirstDemoAppCS
{
    internal struct SStudent: IClassDesign
    {
        private int _id;
        public string name;
        public int Age { get; set; }
        public SStudent(int id)
        {
            _id = id;
        }

        public void Dispaly()
        {
            Console.WriteLine("Structure Display");
        }
    }
}
