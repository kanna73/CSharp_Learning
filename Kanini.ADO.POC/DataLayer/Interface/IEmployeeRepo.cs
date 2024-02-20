using Model.Entity;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface
{
    public  interface IEmployeeRepo
    {
        List<Employee> GetAllEmployee();
        string AddEmployee(Employee emp);
        string UpdateEmployee(Employee emp);
        string DeleteEmployee(int id);
        int GetEmployeeCount();
        List<EmployeeWithDepartment> GetAllEmployeeWithDepartment();
    }
}
