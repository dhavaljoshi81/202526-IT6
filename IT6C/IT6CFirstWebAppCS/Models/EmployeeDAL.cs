using Microsoft.Data.SqlClient;
using System.Collections;
using System.Data;

namespace IT6CFirstWebAppCS.Models
{
    public class EmployeeDAL
    {
        string connectionString = "Data Source=DESKTOP-G78QDQR;Initial Catalog=IT6CDemoDB;Integrated Security=True;Encrypt=False";

        // READ ALL (Using ArrayList)
        public ArrayList GetAllEmployees()
        {
            ArrayList list = new ArrayList();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT e.*, d.DesignationName FROM Employee e JOIN Designation d ON e.Designation = d.DesignationID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee emp = new Employee();
                    emp.EmployeeID = (int)rdr["EmployeeID"];
                    emp.EmployeeName = rdr["EmployeeName"].ToString();
                    emp.Age = (int)rdr["Age"];
                    emp.DesignationName = rdr["DesignationName"].ToString();
                    list.Add(emp);
                }
            }
            return list;
        }

        

        // CREATE
        public void InsertEmployee(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Employee VALUES (@id, @name, @age, @desig)", conn);
                cmd.Parameters.AddWithValue("@id", emp.EmployeeID);
                cmd.Parameters.AddWithValue("@name", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@age", emp.Age);
                cmd.Parameters.AddWithValue("@desig", emp.DesignationID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // UPDATE
        public void UpdateEmployee(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Employee SET EmployeeName=@name, Age=@age, Designation=@desig WHERE EmployeeID=@id", conn);
                cmd.Parameters.AddWithValue("@id", emp.EmployeeID);
                cmd.Parameters.AddWithValue("@name", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@age", emp.Age);
                cmd.Parameters.AddWithValue("@desig", emp.DesignationID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void DeleteEmployee(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Employee WHERE EmployeeID=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // GET BY ID (For Edit/Details)
        public Employee GetEmployeeById(int id)
        {
            Employee emp = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Employee WHERE EmployeeID=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    emp = new Employee
                    {
                        EmployeeID = (int)rdr["EmployeeID"],
                        EmployeeName = rdr["EmployeeName"].ToString(),
                        Age = (int)rdr["Age"],
                        DesignationID = (int)rdr["Designation"]
                    };
                }
            }
            return emp;
        }
        public EmployeeWithDesignation GetAllEmployeesWithDesignation()
        {
            EmployeeWithDesignation employeeWithDesignation = new EmployeeWithDesignation();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT e.*, d.DesignationName FROM Employee e JOIN Designation d ON e.Designation = d.DesignationID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee emp = new Employee();
                    emp.EmployeeID = (int)rdr["EmployeeID"];
                    emp.EmployeeName = rdr["EmployeeName"].ToString();
                    emp.Age = (int)rdr["Age"];
                    emp.DesignationName = rdr["DesignationName"].ToString();
                    employeeWithDesignation.employees.Add(emp);
                }
                rdr.Close();
                string sqlDesignations = "SELECT * FROM Designation";
                SqlCommand cmd1 = new SqlCommand(sqlDesignations, conn);

                rdr = cmd1.ExecuteReader();
                while (rdr.Read())
                {
                    Designation desig = new Designation();
                    desig.DesignationID = (int)rdr["DesignationID"];
                    desig.DesignationName = rdr["DesignationName"].ToString();
                    employeeWithDesignation.designations.Add(desig);
                }
            }

            return employeeWithDesignation;
        }

        public DataTable GetAllDesignations()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                
                SqlCommand cmd = new SqlCommand("SELECT DesignationID, DesignationName FROM Designation", conn);
                conn.Open();
                DataSet dataSet = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataSet,"Designation");
                dt = dataSet.Tables["Designation"];
                
            }
            return dt;

            //DataTable dt = new DataTable();
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    SqlCommand cmd = new SqlCommand("SELECT DesignationID, DesignationName FROM Designation", conn);
            //    conn.Open();
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    da.Fill(dt);
            //}
        }
    }
}
