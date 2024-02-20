using ADO_Practice.DTO;
using ADO_Practice.Models;
using ADO_Practice.RequestModel;
using ADO_Practice.ViewModel;

namespace ADO_Practice.IServices
{
    public interface IEmployeeService
    {
        List<EmployeeViewModel> GetAllEmployee();
        string AddEmployee(EmployeeRequestModel employee);
        string GetTotalEmployee();
        List<EmployeeWithDepartment> GetAll();
    }
}
