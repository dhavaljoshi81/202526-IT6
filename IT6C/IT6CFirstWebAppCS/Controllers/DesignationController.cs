using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using IT6CFirstWebAppCS.Models;
using System.Collections;

namespace IT6CFirstWebAppCS.Controllers
{
    public class DesignationController : Controller
    {
        private SqlConnection _connection;
        private SqlDataAdapter _adapter;
        private DataSet _dataSet;
        private SqlCommandBuilder _commandBuilder;

        public DesignationController()
        {
            _connection = new SqlConnection("Data Source=DESKTOP-G78QDQR;Initial Catalog=IT6CDemoDB;Integrated Security=True;Encrypt=False");
            _dataSet = new DataSet();
            
            _connection.Open();
            _adapter = new SqlDataAdapter("Select * from Designation", _connection);
            
            _commandBuilder = new SqlCommandBuilder(_adapter);
            
            _adapter.Fill(_dataSet, "Designation");
            _connection.Close();
        }

        public ActionResult Search()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Search(string DesignationName)
        {
            ArrayList resultList = new ArrayList();
            foreach (DataRow row in _dataSet.Tables["Designation"].Rows)
            {
                if (row["DesignationName"].ToString().Contains(DesignationName))
                {
                    Designation designation = new Designation
                    {
                        DesignationID = Convert.ToInt32(row["DesignationID"]),
                        DesignationName = row["DesignationName"].ToString()
                    };
                    //return View("Details", designation);
                    resultList.Add(designation);
                }
            }
            return View("SearchResult", resultList);
        }

        public ActionResult SearchResult(ArrayList searchList)
        {

            return View(searchList);
        }

        public ActionResult ListAll()
        {
            Designation[] designation
                = new Designation[_dataSet.Tables["Designation"].Rows.Count];

            for (int i = 0; i < _dataSet.Tables["Designation"].Rows.Count; i++)
            {
                designation[i] = new Designation();
                designation[i].DesignationID 
                    = Convert.ToInt32(_dataSet.Tables["Designation"].Rows[i][0]);
                designation[i].DesignationName
                    = _dataSet.Tables["Designation"].Rows[i][1].ToString();
            }

            return View(designation);
        }

        // GET: DesignationController
        public ActionResult Index()
        {
            return View(_dataSet.Tables["Designation"]);
        }

        // GET: DesignationController/Details/5
        public ActionResult Details(int id)
        {
            return View(GetDesignationByID(id));
        }

        // GET: DesignationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DesignationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Designation newDesignation)
        {
            try
            {
                _connection.Open();
                
                DataRow newRow = _dataSet.Tables["Designation"].NewRow();
                newRow[0] = newDesignation.DesignationID;
                newRow[1] = newDesignation.DesignationName;

                _dataSet.Tables["Designation"].Rows.Add(newRow);

                _adapter.Update(_dataSet, "Designation");

                _connection.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DesignationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetDesignationByID(id));
        }

        // POST: DesignationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Designation updatedDesignation)
        {
            try
            {
                
                foreach (DataRow row in _dataSet.Tables["Designation"].Rows)
                {
                    if (Convert.ToInt32(row["DesignationID"]) == id)
                    {
                        row["DesignationName"] = updatedDesignation.DesignationName;
                        break;
                    }
                }

                _connection.Open();
                _adapter.Update(_dataSet, "Designation");
                _connection.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DesignationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(GetDesignationByID(id));
        }

        // POST: DesignationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                foreach (DataRow row in _dataSet.Tables["Designation"].Rows)
                {
                    if (Convert.ToInt32(row["DesignationID"]) == id)
                    {
                        _dataSet.Tables["Designation"].Rows.Remove(row);
                        break;
                    }
                }

                _connection.Open();
                _adapter.Update(_dataSet, "Designation");
                _connection.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private Designation GetDesignationByID(int id)
        {
            Designation designation = new Designation();

            foreach (DataRow row in _dataSet.Tables["Designation"].Rows)
            {
                if (Convert.ToInt32(row[0]) == id)
                {
                    designation.DesignationID = Convert.ToInt32(row[0]);
                    designation.DesignationName = row[1].ToString();
                }
            }

            return designation;
        }
    }
}
