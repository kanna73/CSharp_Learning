using ADO_Practice.DTO;
using ADO_Practice.Models;

namespace ADO_Practice.IRepositories
{
    public interface IEmployeeRepo
    {
        List<Employee> GetAllEmployee();
        string AddEmployee(Employee emp);
        int GetTotalEmployee();
        List<EmployeeWithDepartment> GetAll();
    }
}
