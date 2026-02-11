using IT6CFirstWebAppCS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace IT6CFirstWebAppCS.Controllers
{
    [Route("log")]
    public class LogInTestController : Controller
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlDataReader;
        private DataSet dataSet;
        public LogInTestController() 
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=DESKTOP-G78QDQR;Initial Catalog=IT6CDemoDB;Integrated Security=True;Encrypt=False";
            
            Console.WriteLine("LogInTestController created");
        }
        [HttpGet("item")]
        public IActionResult Index()
        {
            Console.WriteLine("Index method called");
            return RedirectToAction(nameof(LogIn));
        }

        [HttpGet("login")]
        public IActionResult LogIn()
        {
            Console.WriteLine("LogIn method called");
            return View();
        }

        //LogIn using SQLCommand
        [HttpPost]
        public IActionResult LogIn(string username, string password)
        {
            Console.WriteLine("LogIn method called with username: " + username + " and password: " + password);
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "select username, password from users";
            sqlConnection.Open();
            dataSet = new DataSet();
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["username"].ToString() == username
                    && sqlDataReader["password"].ToString() == password)
                {
                    User user = new User();
                    user.UserName = username;
                    return RedirectToAction(nameof(Home), "LogInTest", user);
                }
            }
            
            return View(nameof(LogInFail));
        }

        [HttpPost]
        public IActionResult LogIn_SQLDataAdapter(string username, string password)
        {
            sqlConnection.Open();
            dataSet = new DataSet();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select username, password from Users;", sqlConnection);

            sqlDataAdapter.Fill(dataSet, "Users");

            foreach (DataRow row in dataSet.Tables["Users"].Rows)
            {
                if (row["username"].ToString().Equals(username) && row["password"].ToString().Equals(password))
                {
                    User user = new User();
                    user.UserName = username;
                    return RedirectToAction(nameof(Home), "LogInTest", user);
                }
            }
            return View(nameof(LogInFail));
        }

        [HttpPost]
        public IActionResult LogIn_HardCoded(string username, string password)
        {
            if (username.Equals("admin") && password.Equals("pwd123"))
            {
                User user = new User();
                user.UserName = username;
                return RedirectToAction(nameof(Home), "LogInTest", user);
            }
            else
                return View(nameof(LogInFail));
        }
        [HttpGet("home")]
        public IActionResult Home(User user)
        {
            Console.WriteLine("Home method called with user: " + user.UserName);
            string name = user.UserName;
            return View(nameof(Home), name);
        }

        public IActionResult LogInFail()
        {
            Console.WriteLine("LogInFail method called");
            return View();
        }
    }
}
