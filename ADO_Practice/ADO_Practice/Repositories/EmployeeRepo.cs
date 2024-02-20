using ADO_Practice.DTO;
using ADO_Practice.IRepositories;
using ADO_Practice.Mapper;
using ADO_Practice.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ADO_Practice.Repositories
{
    public class EmployeeRepo :IEmployeeRepo
    {
        private readonly SqlConnection _connection;
        private readonly IMapping _mapping;
        public EmployeeRepo(IConfiguration configuration,IMapping mapping) 
        {
            string connection = configuration.GetConnectionString("SQLConnection");
            _connection = new SqlConnection(connection);
            _mapping = mapping;
        }

        public  List<Employee> GetAllEmployee()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlCommand cmd = new SqlCommand("select * from Employee", _connection))
            {
                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Employee emp = new Employee();
                        emp.Id = reader.GetInt32("Id");
                        emp.EmployeeName = reader.GetString("EmployeeName");
                        emp.EmployeeCode = reader["EmployeeCode"].ToString();
                        emp.DeptID = Convert.ToInt32(reader["DeptID"]);
                        employees.Add(emp);
                    }
                }
            }
            return employees;
        }

        public string AddEmployee(Employee emp)
        {
            string query = "insert into Employee (EmployeeName,EmployeeCode,DeptID) values(@EmployeeName,@EmployeeCode,@DeptID)";

            using (SqlCommand cmd = new SqlCommand(query,_connection))
            {
                cmd.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@EmployeeCode", emp.EmployeeCode);
                cmd.Parameters.AddWithValue("@DeptID",emp.DeptID);
                _connection.Open();
                int row = cmd.ExecuteNonQuery();
                return row == 1 ? "Employee added sucessfully" : "Error occured";
            }
        }

        public int GetTotalEmployee()
        {
            using(SqlCommand cmd = new SqlCommand("select Count(*) as Total from Employee", _connection))
            {
                _connection.Open();
                int total= (int)cmd.ExecuteScalar();
                return total;
            }
        }

        public List<EmployeeWithDepartment> GetAll()
        {
            List<EmployeeWithDepartment> emp = new List<EmployeeWithDepartment>();
            using(SqlCommand cmd = new SqlCommand("Exec USPGetEmployeeWithDepartment",_connection))
            {
                _connection.Open ();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    foreach (DataRow dr in dt.Rows)
                    {
                        var emp1 = new EmployeeWithDepartment();
                        emp1.EmployeeName = dr["EmployeeName"].ToString();
                        emp1.EmployeeCode = dr["EmployeeCode"].ToString();
                        emp1.DepartmentName = dr["DepartmentName"].ToString();
                        emp.Add(emp1);
                    }
                   /* while (reader.Read()) // why only while loop
                    {
                        var employee = new EmployeeWithDepartment();
                        employee.EmployeeName = reader["EmployeeName"].ToString(); // best approach because it handle null value also
                        employee.EmployeeCode = (string)reader["EmployeeCode"];
                        employee.DepartmentName = (string)reader["DepartmentName"];
                        emp.Add(employee);
                    }*/
                    return emp;
                }

            }
        }
    }
}
