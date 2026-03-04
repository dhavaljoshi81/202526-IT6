using IT6CFirstWebAppCS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Data;

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

        private void GetAllDesignationsInList()
        {
            DataTable dt = db.GetAllDesignations();

            ArrayList items = new ArrayList();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    items.Add(new
                    {
                        DesignationID = row["DesignationID"].ToString(),
                        DesignationName = row["DesignationName"].ToString()
                    });
                    Console.WriteLine(row["DesignationName"].ToString());
                }
            }

            ViewBag.DesignationList = 
                new SelectList(items, "DesignationID", "DesignationName");

        }

        public ActionResult Create() 
        { 
            GetAllDesignationsInList();
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
            GetAllDesignationsInList();
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
