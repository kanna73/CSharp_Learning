using Kanini.Poc.Ado.Domain.Interface.Constants;
using Kanini.Poc.Ado.Domain.Interface.MapperInterface;
using Kanini.Poc.Ado.Domain.Interface.RepostioryInterface;
using Kanini.Poc.Ado.Domain.Interface.ServiceInterface;
using Model.RequestModel;
using Model.ViewModel;

namespace Kanini.Poc.Ado.Service.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _repo;
        private readonly IServiceMapper _mapper;
        private readonly IMessage _message;

        public EmployeeService(IEmployeeRepo repo, IServiceMapper mapper, IMessage message)
        {
            _mapper = mapper;
            _repo = repo;
            _message = message;
        }

        public IEnumerable<EmployeeView> GetAllEmployee()
        {
            var employee = _repo.GetAllEmployee();
            var result = _mapper.ConvertToEmployeeView(employee);
            return result;
        }

        public IEnumerable<string> AddEmployee(EmployeeRequest employeeRequest)
        {
            var employee = _mapper.ConvertToEmployee(employeeRequest);
            var row = _repo.AddEmployee(employee);
            yield return row.ElementAt(0) == 1 ? _message.EmployeeAddedSuccessfully : _message.ErrorOccurred;
        }

        public IEnumerable<string> UpadteEmployee(EmployeeRequest employeeRequest)
        {
            var employee = _mapper.ConvertToEmployee(employeeRequest);
            var row = _repo.UpdateEmployee(employee);
            yield return row.ElementAt(0) == 1 ? _message.EmployeeUpdateSuccess : _message.ErrorOccurred;

        }

        public IEnumerable<string> DeleteEmployee(int id)
        {
            var row = _repo.DeleteEmployee(id);
            yield return row.ElementAt(0) == 1 ? _message.EmployeeDeleteSuccess : _message.ErrorOccurred;
        }

        public IEnumerable<int> GetEmployeeCount()
        {
            var total = _repo.GetEmployeeCount();
            yield return total.ElementAt(0);
        }

        public IEnumerable<EmployeeWithDepartment> GetAllEmployeeWithDepartment()
        {
            return _repo.GetAllEmployeeWithDepartment();
        }

    }
}
