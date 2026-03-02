namespace IT6CFirstWebAppCS.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int Age { get; set; }
        public int DesignationID { get; set; }
        public string DesignationName { get; set; } // For display joins
    }
}
