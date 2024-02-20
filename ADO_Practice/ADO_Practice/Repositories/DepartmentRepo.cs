using ADO_Practice.IRepositories;
using ADO_Practice.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ADO_Practice.Repositories
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly SqlConnection _connection;

        public DepartmentRepo(IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("SQLConnection");
            _connection = new SqlConnection(connection);
        }

        public List<Department> GetAll()
        {
            List<Department> result = new List<Department>();   

            SqlDataAdapter adapter = new SqlDataAdapter("select * from Department",_connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet,"Department");
           /* DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var dept = new Department();
                dept.Id = Convert.ToInt32(dr["Id"]);
                dept.DepartmentName = dr["DepartmentName"].ToString();
                result.Add(dept);
            }*/
           foreach (DataRow row in dataSet.Tables["Department"].Rows)
           {
                var dept = new Department();
                dept.Id = Convert.ToInt32(row["Id"]);
                dept.DepartmentName = row["DepartmentName"].ToString();
                result.Add(dept);
            }
            return result;
        }

        public string AddDepartment(Department department)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataSetAdapter = new SqlDataAdapter("select * from Department", _connection);
            dataSetAdapter.Fill(dataSet, "department");

            DataRow newRow = dataSet.Tables["department"].NewRow();
            newRow["DepartmentName"] = department.DepartmentName;
            dataSet.Tables["department"].Rows.Add(newRow);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataSetAdapter);
            int rows= dataSetAdapter.Update(dataSet, "department");

            return rows == 1 ? "Record added successfully" : "error occured";
        }
    }
}
