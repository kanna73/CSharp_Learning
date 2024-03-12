using Model.Entity;

namespace Kanini.Poc.Ado.Domain.Interface.UspRepostiory
{
    public interface IUspEmployeeRepo
    {
        IEnumerable<int> AddEmployees(IEnumerable<Employee> employees);
        IEnumerable<int> UpdateEmployee(IEnumerable<Employee> employees);
    }
}
