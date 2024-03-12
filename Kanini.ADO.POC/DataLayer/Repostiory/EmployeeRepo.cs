using DataLayer.Interface;
using Kanini.Poc.Ado.Domain.Interface.RepostioryInterface;
using Microsoft.Data.SqlClient;
using Model.Entity;
using Model.ViewModel;
using System.Data;
using System.Text;

namespace Kanini.Poc.Ado.DataAccess.Repostiory
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly IConnection _connection;

        public EmployeeRepo(IConnection connection)
        {
            _connection = connection;
        }



        public IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> list = new List<Employee>();

            using (SqlCommand cmd = new SqlCommand("select * from Employee", _connection.GetConnection()))
            {
                cmd.Connection.Open();
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

            return list;
        }

        public IEnumerable<int> AddEmployee(Employee emp)
        {

            string query = "insert into Employee (EmployeeName,EmployeeCode,DeptID) values(@EmployeeName,@EmployeeCode,@DeptID)";
            using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@EmployeeCode", emp.EmployeeCode);
                cmd.Parameters.AddWithValue("@DeptID", emp.DeptID);
                cmd.Connection.Open();
                int row = cmd.ExecuteNonQuery();
                yield return row;
            }

        }

        public IEnumerable<int> UpdateEmployee(Employee emp)
        {

            string query = "update  Employee Set EmployeeName=@EmployeeName, EmployeeCode=@EmployeeCode,DeptID=@DeptID where Id=@Id";

            using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@EmployeeCode", emp.EmployeeCode);
                cmd.Parameters.AddWithValue("@DeptID", emp.DeptID);
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Connection.Open();
                int row = cmd.ExecuteNonQuery();
                yield return row;
            }


        }

        public IEnumerable<int> DeleteEmployee(int id)
        {
            string query = "delet from Employee where Id=@Id";
            using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Connection.Open();
                int row = cmd.ExecuteNonQuery();
                yield return row;
            }

        }

        public IEnumerable<int> GetEmployeeCount()
        {

            string query = "Select Count(*) as Total from Employee";
            using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
            {
                cmd.Connection.Open();
                int total = Convert.ToInt32(cmd.ExecuteScalar());
                yield return total;
            }

        }

        public IEnumerable<EmployeeWithDepartment> GetAllEmployeeWithDepartment()
        {
            List<EmployeeWithDepartment> list = new List<EmployeeWithDepartment>();

            using (SqlCommand cmd = new SqlCommand("Exec USPGetEmployeeWithDepartment", _connection.GetConnection()))
            {
                cmd.Connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
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
            return list;

        }
    }
}
