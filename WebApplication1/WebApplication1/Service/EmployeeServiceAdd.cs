using WebApplication1.Interface.IRepo;
using WebApplication1.Interface.IService;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class EmployeeServiceAdd: IEmployeeServiceAdd
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeServiceAdd(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public List<Employee> AddEmployee(Employee employee) 
        {
            return _employeeRepo.AddEmployee(employee);
        }
    }
}
