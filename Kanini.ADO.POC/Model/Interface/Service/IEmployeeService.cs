using Model.RequestModel;
using Model.ViewModel;

namespace Kanini.Poc.Ado.Domain.Interface.ServiceInterface
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeView> GetAllEmployee();
        IEnumerable<string> AddEmployee(EmployeeRequest employeeRequest);
        IEnumerable<string> UpadteEmployee(EmployeeRequest employeeRequest);
        IEnumerable<string> DeleteEmployee(int id);
        IEnumerable<int> GetEmployeeCount();
        IEnumerable<EmployeeWithDepartment> GetAllEmployeeWithDepartment();
    }
}
