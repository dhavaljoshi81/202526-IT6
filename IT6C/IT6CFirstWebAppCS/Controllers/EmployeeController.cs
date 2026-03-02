using IT6CFirstWebAppCS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace IT6CFirstWebAppCS.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL db = new EmployeeDAL();

        public ActionResult Index()
        {
            ArrayList list = db.GetAllEmployees();
            return View(list);
        }

        public ActionResult Index1()
        {
            EmployeeWithDesignation ed = db.GetAllEmployeesWithDesignation();
            return View(ed);
        }

        public ActionResult Create() 
        { 
            return View(); 
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            db.InsertEmployee(emp);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Employee emp = db.GetEmployeeById(id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            db.UpdateEmployee(emp);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            db.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
