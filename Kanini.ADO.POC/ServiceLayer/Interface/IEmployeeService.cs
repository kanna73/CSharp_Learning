using Model.RequestModel;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public  interface IEmployeeService
    {
        List<EmployeeView> GetAllEmployee();
        string AddEmployee(EmployeeRequest employeeRequest);
        string UpadteEmployee(EmployeeRequest employeeRequest);
        string DeleteEmployee(int id);
        int GetEmployeeCount();
        List<EmployeeWithDepartment> GetAllEmployeeWithDepartment();
    }
}
