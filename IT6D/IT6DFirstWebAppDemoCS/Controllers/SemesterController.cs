using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using IT6DFirstWebAppDemoCS.Models;
using System.Collections;

namespace IT6DFirstWebAppDemoCS.Controllers
{
    public class SemesterController : Controller
    {
        private SqlConnection _Connection { get; set; }
        private SqlDataAdapter _DataAdapter { get; set; }
        private DataSet _DataSet { get; set; }

        private SqlCommandBuilder _commandBuilder;
        public SemesterController()
        {
            _Connection = new SqlConnection("Data Source=DESKTOP-G78QDQR;Initial Catalog=IT6DemoDB;Integrated Security=True;Encrypt=False");
            _DataSet = new DataSet();
            _Connection.Open();
            _DataAdapter = new SqlDataAdapter("SELECT * FROM Semester", _Connection);
            _commandBuilder = new SqlCommandBuilder(_DataAdapter);
            _DataAdapter.Fill(_DataSet, "Semester");
            _Connection.Close();
        }

        public ActionResult Search()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult Search(string semesterName)
        {
            ArrayList semesters =  new ArrayList();
            
            foreach (DataRow row in _DataSet.Tables["Semester"].Rows)
            {
                if (row["SemesterName"].ToString().Contains(semesterName))
                {
                    Semester semester = new Semester
                    {
                        SemesterID = Convert.ToInt32(row["SemesterID"]),
                        SemesterName = row["SemesterName"].ToString()

                    };
                    semesters.Add(semester);
                    //return View("Details", semester);
                }
            }
            return View(semesters);
        }

        public ActionResult ShowAll()
        {
            
            Semester[] semesters = 
                new Semester[_DataSet.Tables["Semester"].Rows.Count];

            for (int i = 0; i < semesters.Length; i++)
            {
                semesters[i] = new Semester
                {
                    SemesterID = Convert.ToInt32(_DataSet.Tables["Semester"].Rows[i]["SemesterID"]),
                    SemesterName = _DataSet.Tables["Semester"].Rows[i]["SemesterName"].ToString()
                };
            }

            return View(semesters);
        }

        // GET: SemesterController
        public ActionResult Index()
        {
            return View(_DataSet.Tables["Semester"]);
        }

        private Semester GetSemesterById(int id)
        {
            Semester semester = new Semester();
            foreach (DataRow row in _DataSet.Tables["Semester"].Rows)
            {
                if (Convert.ToInt32(row["SemesterID"]) == id)
                {
                    semester.SemesterID = Convert.ToInt32(row["SemesterID"]);
                    semester.SemesterName = row["SemesterName"].ToString();
                    break;
                }
            }
            return semester;
        }
        // GET: SemesterController/Details/5
        public ActionResult Details(int id)
        {
            return View(GetSemesterById(id));
        }

        // GET: SemesterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SemesterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Semester newSemester)
        {
            try
            {
                _DataSet.Tables["Semester"].Rows.Add(
                    newSemester.SemesterID,
                    newSemester.SemesterName
                );
                
                _Connection.Open();
                _DataAdapter.Update(_DataSet, "Semester");
                _Connection.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SemesterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetSemesterById(id));
        }

        // POST: SemesterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Semester updatedSemester)
        {
            try
            {
                Semester semester = GetSemesterById(id);
                foreach (DataRow row in _DataSet.Tables["Semester"].Rows)
                {
                    if (Convert.ToInt32(row["SemesterID"]) == id)
                    {
                        row["SemesterName"] = updatedSemester.SemesterName;
                        break;
                    }
                }
                _Connection.Open();
                _DataAdapter.Update(_DataSet, "Semester");
                _Connection.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SemesterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(GetSemesterById(id));
        }

        // POST: SemesterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                foreach (DataRow row in _DataSet.Tables["Semester"].Rows)
                {
                    if (Convert.ToInt32(row["SemesterID"]) == id)
                    {
                        row.Delete();
                        break;
                    }
                }
                _Connection.Open();
                _DataAdapter.Update(_DataSet, "Semester");
                _Connection.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
