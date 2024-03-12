using Kanini.Poc.Ado.Domain.Interface.ServiceInterface;
using Kanini.Poc.Ado.Domain.Interface.UspService;
using Microsoft.AspNetCore.Mvc;
using Model.RequestModel;
using Model.ViewModel;

namespace Kanini.ADO.POC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IEmployeeUspService _UspService;

        public EmployeeController(IEmployeeService service, IEmployeeUspService UspService)
        {
            _service = service;
            _UspService = UspService;
        }

        [HttpGet]
        public IEnumerable<EmployeeView> GetAllEmployee()
        {
            return _service.GetAllEmployee();
        }

        [HttpPost]
        public IEnumerable<string> AddEmployee(EmployeeRequest employee)
        {
            return _service.AddEmployee(employee);
        }

        [HttpPut]

        public IEnumerable<string> UpdateEmployee(EmployeeRequest employee)
        {
            return _service.UpadteEmployee(employee);
        }
        [HttpDelete]
        public IEnumerable<string> DeleteEmployee(int id)
        {
            return _service.DeleteEmployee(id);
        }

        [HttpGet]
        public IEnumerable<int> GetEmployeeCount()
        {
            return _service.GetEmployeeCount();
        }

        [HttpGet]
        public IEnumerable<EmployeeWithDepartment> GetAllEmployeeWithDepartment()
        {
            return _service.GetAllEmployeeWithDepartment();
        }

        [HttpPost]

        public IEnumerable<string> AddEmployees(IEnumerable<EmployeeRequest> employees)
        {
            return _UspService.AddEmployees(employees);
        }

        [HttpPut]
        public IEnumerable<string> UpdateEmployees(List<EmployeeRequest> employees)
        {
            return _UspService.UpdateEmployees(employees);
        }

    }
}
