using Model.RequestModel;

namespace Kanini.Poc.Ado.Domain.Interface.UspService
{
    public interface IEmployeeUspService
    {
        IEnumerable<string> AddEmployees(IEnumerable<EmployeeRequest> employeeRequests);

        IEnumerable<string> UpdateEmployees(IEnumerable<EmployeeRequest> employeeRequests);

    }
}
