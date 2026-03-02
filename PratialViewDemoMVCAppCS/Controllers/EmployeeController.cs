using Microsoft.AspNetCore.Mvc;
using PratialViewDemoMVCAppCS.Models;

namespace PratialViewDemoMVCAppCS.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            Employee[] employees = new Employee[3];

            employees[0] = new Employee { Id = 1, Name = "Rajan", Role = "Senior Developer" };
            employees[1] = new Employee { Id = 2, Name = "Suhas", Role = "Product Manager" };
            employees[2] = new Employee { Id = 3, Name = "Vikram", Role = "Designer" };

            return View(employees);
        }
    }
}
