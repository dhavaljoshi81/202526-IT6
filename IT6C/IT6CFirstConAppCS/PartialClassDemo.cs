using IT6CFirstConAppCS.PartialDemo;

namespace IT6CFirstConAppCS
{
    internal class PartialClassDemo
    {
        public static void Main1()
        {
            Student student = new Student();
            student.Read();
            student.Read("C#.NET Core");

            IClassDesign laptop = new Laptop();
            laptop.Display();
        }
    }
}
