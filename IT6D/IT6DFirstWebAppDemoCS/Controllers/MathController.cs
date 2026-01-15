using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT6DFirstWebAppDemoCS.Controllers
{
    public class MathController : Controller
    {
        // GET: MathController
        public ActionResult ShowData()
        {
            int i = 15;
            string str = "IT6D";
            return View("ShowData", str);
        }

        // GET: MathController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MathController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MathController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MathController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MathController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MathController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MathController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MathController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
