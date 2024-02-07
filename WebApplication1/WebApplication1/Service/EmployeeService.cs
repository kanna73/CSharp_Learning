using WebApplication1.Interface.IRepo;
using WebApplication1.Interface.IService;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeRepo.GetEmployees();
        }
    }
}
