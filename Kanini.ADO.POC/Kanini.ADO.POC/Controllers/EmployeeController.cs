using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.RequestModel;
using Model.ViewModel;
using ServiceLayer.Interface;

namespace Kanini.ADO.POC.Controllers
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
        public ActionResult<List<EmployeeView>> GetAllEmployee()
        {
            return Ok(_service.GetAllEmployee());   
        }

        [HttpPost]
        public string AddEmployee(EmployeeRequest employee)
        {
            return _service.AddEmployee(employee);
        }

        [HttpPut]

        public string UpdateEmployee(EmployeeRequest employee)
        {
            return _service.UpadteEmployee(employee);
        }
        [HttpDelete]
        public string DeleteEmployee(int id)
        {
            return _service.DeleteEmployee(id);
        }

        [HttpGet]
        public int GetEmployeeCount()
        {
            return _service.GetEmployeeCount();
        }

        [HttpGet]
        public List<EmployeeWithDepartment> GetAllEmployeeWithDepartment()
        {
            return _service.GetAllEmployeeWithDepartment();
        }

    }
}
