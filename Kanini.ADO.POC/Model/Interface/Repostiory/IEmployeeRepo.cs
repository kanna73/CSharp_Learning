using Model.Entity;
using Model.ViewModel;

namespace Kanini.Poc.Ado.Domain.Interface.RepostioryInterface
{

    public interface IEmployeeRepo
    {
        IEnumerable<Employee> GetAllEmployee();
        IEnumerable<int> AddEmployee(Employee emp);
        IEnumerable<int> UpdateEmployee(Employee emp);
        IEnumerable<int> DeleteEmployee(int id);
        IEnumerable<int> GetEmployeeCount();
        IEnumerable<EmployeeWithDepartment> GetAllEmployeeWithDepartment();
    }

}
