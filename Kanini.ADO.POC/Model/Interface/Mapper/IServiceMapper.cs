using Model.Entity;
using Model.RequestModel;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanini.Poc.Ado.Domain.Interface.MapperInterface
{
    public interface IServiceMapper
    {
        IEnumerable<EmployeeView> ConvertToEmployeeView(IEnumerable<Employee> employee);
        Employee ConvertToEmployee(EmployeeRequest employeeRequest);
        IEnumerable<Employee> ConvertToEmployees(IEnumerable<EmployeeRequest> employeeRequests);
    }
}
