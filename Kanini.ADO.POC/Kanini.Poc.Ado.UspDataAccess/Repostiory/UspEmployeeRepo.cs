using Kanini.Poc.Ado.Domain.Interface.UspRepostiory;
using Kanini.Poc.Ado.UspDataAccess.Interface;
using Microsoft.Data.SqlClient;
using Model.Entity;
using Newtonsoft.Json;
using System.Data;

namespace Kanini.Poc.Ado.UspDataAccess.Repostiory
{
    public class UspEmployeeRepo : IUspEmployeeRepo
    {
        private readonly IUspConnection _connection;


        public UspEmployeeRepo(IUspConnection connection)
        {
            _connection = connection;
        }

       /* public int AddEmployees(IEnumerable<Employee> employees)
        {
            using(SqlCommand cmd = new SqlCommand("UspAddEmployees", _connection.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                string employeeJson = JsonConvert.SerializeObject(employees);
                cmd.Parameters.AddWithValue("@EmployeeJson", employeeJson);
                cmd.Connection.Open();
                int row=cmd.ExecuteNonQuery();
                return row;
            }
        }*/

        public IEnumerable<int> AddEmployees(IEnumerable<Employee> employees)
        {
            using (SqlCommand cmd = new SqlCommand("UspAddEmployeesWithTVF",_connection.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable tvp = new DataTable();
                tvp.Columns.Add("EmployeeName",typeof(string));// why typeof
                tvp.Columns.Add("EmployeeCode",typeof (string));
                tvp.Columns.Add("DeptID",typeof(int));

                foreach (Employee employee in employees)
                {
                    tvp.Rows.Add(employee.EmployeeName,employee.EmployeeCode,employee.DeptID);
                }

                SqlParameter tvpParam = cmd.Parameters.AddWithValue("@EmployeeTable", tvp);
                tvpParam.SqlDbType = SqlDbType.Structured;
                tvpParam.TypeName = "dbo.EmployeeTableType";

                cmd.Connection.Open();
                int row =  cmd.ExecuteNonQuery() ;
                yield return row;
            }
        }



        public IEnumerable<int> UpdateEmployee (IEnumerable<Employee> employees) 
        {
            using(SqlCommand cmd = new SqlCommand ("UspUpdateEmployees", _connection.GetConnection()))
            { 
                cmd.CommandType=CommandType.StoredProcedure;    
                string employeejson = JsonConvert.SerializeObject(employees);
                cmd.Parameters.AddWithValue("@EmployeeJson", employeejson);
                cmd.Connection.Open();
                int row = cmd.ExecuteNonQuery() ;
                yield return row;
                
            }
        }
    }
}
