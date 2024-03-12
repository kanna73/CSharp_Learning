using WebApplication1.Interface.IRepo;
using WebApplication1.Models;

namespace WebApplication1.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public List<Employee> Emp;

        public EmployeeRepo() 
        {
            Emp = new List<Employee>();
            Employee emp1 = new Employee(1, "kannappan");
            Employee emp2 = new Employee(2, "rahul");
            Emp.Add(emp1);
            Emp.Add(emp2);

        }

        public List<Employee> GetEmployees()
        {    
            return Emp;
        }

        public List<Employee> AddEmployee(Employee emp)
        {
            Emp.Add(emp);
            return Emp;
        }
    }
}
