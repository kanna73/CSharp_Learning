using ADO_Practice.DTO;
using ADO_Practice.IServices;
using ADO_Practice.Models;
using ADO_Practice.Repositories;
using ADO_Practice.RequestModel;
using ADO_Practice.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADO_Practice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {


        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {

            _service = service;
        }

        [HttpGet]

        public List<EmployeeViewModel> GetEmployee()
        {
            var result = _service.GetAllEmployee();
            return result;
        }

        [HttpPost]

        public string AddEmployee(EmployeeRequestModel employee)
        {
            return _service.AddEmployee(employee);
        }

        [HttpGet]

        public string GetTotalEmployee()
        {
            return _service.GetTotalEmployee();
        }

        [HttpGet]
        public List<EmployeeWithDepartment> GetAll()
        {
            return _service.GetAll();
        }


    }
}
