using Kanini.Poc.Ado.Domain.Interface.Constants;
using Kanini.Poc.Ado.Domain.Interface.MapperInterface;
using Kanini.Poc.Ado.Domain.Interface.UspRepostiory;
using Kanini.Poc.Ado.Domain.Interface.UspService;
using Model.RequestModel;

namespace Kanini.Poc.Ado.Service.UspService
{
    public class EmployeeUspService : IEmployeeUspService
    {
        private readonly IUspEmployeeRepo _employeeRepo;
        private readonly IServiceMapper _serviceMapper;
        private readonly IMessage _message;


        public EmployeeUspService(IUspEmployeeRepo employeeRepo, IServiceMapper serviceMapper, IMessage message)
        {
            _employeeRepo = employeeRepo;
            _serviceMapper = serviceMapper;
            _message = message;
        }

        public IEnumerable<string> AddEmployees(IEnumerable<EmployeeRequest> employeeRequests)
        {
            var employees = _serviceMapper.ConvertToEmployees(employeeRequests);
            var row = _employeeRepo.AddEmployees(employees);
            yield return row.ElementAt(0) != 0 ? _message.EmployeeAddedSuccessfully : _message.ErrorOccurred;
        }

        public IEnumerable<string> UpdateEmployees(IEnumerable<EmployeeRequest> employeeRequests)
        {
            var employees = _serviceMapper.ConvertToEmployees(employeeRequests);
            var row = _employeeRepo.UpdateEmployee(employees);
            yield return row.ElementAt(0) != 0 ? _message.EmployeeUpdateSuccess : _message.ErrorOccurred;

        }
    }
}
