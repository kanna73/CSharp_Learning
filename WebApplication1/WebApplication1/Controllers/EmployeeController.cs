using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interface.IRepo;
using WebApplication1.Interface.IService;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class EmployeeController : Controller
    {

        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeServiceAdd _employeeServiceAdd;
        public EmployeeController(IEmployeeService employeeService,IEmployeeServiceAdd employeeServiceAdd)
        {
            _employeeService = employeeService;
            _employeeServiceAdd = employeeServiceAdd;
        }
        [HttpGet]
        public List<Employee> GetEmployees()
        {
            var result = _employeeService.GetEmployees();
            return result;

        }

        [HttpPost]
        public List<Employee> AddEmployee(Employee employee) 
        {
            var result = _employeeServiceAdd.AddEmployee(employee);
            var result1 = _employeeService.GetEmployees();
            return result1;
        }
    }
}
