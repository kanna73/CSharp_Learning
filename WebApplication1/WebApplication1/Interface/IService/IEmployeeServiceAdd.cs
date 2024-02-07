using WebApplication1.Models;

namespace WebApplication1.Interface.IService
{
    public interface IEmployeeServiceAdd
    {
        public List<Employee> AddEmployee(Employee employee);
    }
}
