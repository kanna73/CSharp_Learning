using WebApplication1.Models;

namespace WebApplication1.Interface.IRepo
{
    public interface IEmployeeRepo
    {
        public List<Employee> GetEmployees();
        public List<Employee> AddEmployee(Employee emp);
    }
}
