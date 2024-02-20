using DataLayer.Interface;
using Microsoft.Data.SqlClient;
using Model.Entity;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repostiory
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly IConnection _connection;

        public EmployeeRepo(IConnection connection)
        {
            _connection = connection;
        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> list = new List<Employee>();
            using (SqlConnection connection = _connection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("select * from Employee", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee emp = new Employee();
                            emp.Id = reader.GetInt32("Id");
                            emp.EmployeeName = reader.GetString("EmployeeName");
                            emp.EmployeeCode = reader.GetString("EmployeeCode");
                            emp.DeptID = reader.GetInt32("DeptID");
                            list.Add(emp);
                        }
                    }
                }
            }
            return list;
        }

        public string AddEmployee(Employee emp)
        {
            using(SqlConnection connection = _connection.GetConnection())
            {
                string query = "insert into Employee (EmployeeName,EmployeeCode,DeptID) values(@EmployeeName,@EmployeeCode,@DeptID)";
                using (SqlCommand cmd = new SqlCommand(query,connection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                    cmd.Parameters.AddWithValue("@EmployeeCode", emp.EmployeeCode);
                    cmd.Parameters.AddWithValue("@DeptID", emp.DeptID);
                    connection.Open();
                    int row = cmd.ExecuteNonQuery();
                    return row == 1 ? "Employee added successfully" : "Error Occured";
                }
            }
        }

        public string UpdateEmployee(Employee emp)
        {
            using( SqlConnection connection = _connection.GetConnection())
            {
                string query = "update  Employee Set EmployeeName=@EmployeeName, EmployeeCode=@EmployeeCode,DeptID=@DeptID where Id=@Id";

                using(SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                    cmd.Parameters.AddWithValue("@EmployeeCode", emp.EmployeeCode);
                    cmd.Parameters.AddWithValue("@DeptID", emp.DeptID);
                    cmd.Parameters.AddWithValue("@Id", emp.Id);
                    connection.Open();
                    int row = cmd.ExecuteNonQuery();
                    return row == 1 ? "Updated successfully" : "Error occured";
                }

            }
        }

        public string DeleteEmployee(int id)
        {
            using(SqlConnection connection = _connection.GetConnection())
            {
                string query = "delet from Employee where Id=@Id";
                using( SqlCommand cmd = new SqlCommand(query,connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    int row = cmd.ExecuteNonQuery();
                    return row == 1 ? "Deleted successfully" : "Error Occured";
                }
            }
        }

        public int GetEmployeeCount()
        {
            using(SqlConnection connection = _connection.GetConnection())
            {
                string query = "Select Count(*) as Total from Employee";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    int total = Convert.ToInt32(command.ExecuteScalar());
                    return total;
                }
            }
        }

        public List<EmployeeWithDepartment> GetAllEmployeeWithDepartment()
        {
            List<EmployeeWithDepartment> list = new List<EmployeeWithDepartment>();   
            using (SqlConnection connection = _connection.GetConnection())
            {
                using(SqlCommand cmd = new SqlCommand("Exec USPGetEmployeeWithDepartment",connection))
                {
                    connection.Open();
                    using(SqlDataReader  reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmployeeWithDepartment employee = new EmployeeWithDepartment();
                            employee.EmployeeName = reader.GetString("EmployeeName");
                            employee.EmployeeCode = reader.GetString("EmployeeCode");
                            employee.DepartmentName = reader.GetString("DepartmentName");
                            list.Add(employee);
                        }
                    }
                }
            }
            return list;

        }
    }
}
