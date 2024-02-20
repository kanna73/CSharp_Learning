using ADO_Practice.Models;
using ADO_Practice.RequestModel;
using ADO_Practice.ViewModel;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ADO_Practice.Mapper
{
    public class Mapping : IMapping
    {

        public List<EmployeeViewModel> ToEmployeeView(List<Employee> emp )
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();

            foreach(Employee employee in emp)
            {
                var employeeViewModel = new EmployeeViewModel();
                employeeViewModel.Id = employee.Id;
                employeeViewModel.EmployeeName= employee.EmployeeName;
                employeeViewModel.EmployeeCode = employee.EmployeeCode;
                employeeViewModel.DeptID = employee.DeptID;
                employees.Add( employeeViewModel ); 
            }
            return employees;

        }

        public Employee ToEmployee(EmployeeRequestModel emp)
        {
            Employee employee = new Employee();
            employee.Id = emp.Id;
            employee.EmployeeName = emp.EmployeeName;
            employee.EmployeeCode = emp.EmployeeCode;
            employee.DeptID= emp.DeptID;
            return employee;

        }

        public List<DepartmentViewModel> ToDepartmentView(List<Department> department)
        {
            List<DepartmentViewModel> departmentViewModels = new List<DepartmentViewModel>();

            foreach(var dept in department)
            {
                DepartmentViewModel departmentViewModel = new DepartmentViewModel();
                departmentViewModel.Id = dept.Id;
                departmentViewModel.DepartmentName = dept.DepartmentName;
                departmentViewModels.Add( departmentViewModel );
            }
            return departmentViewModels;
        }

        public Department ToDepartment(DepartmentRequestModel department) 
        {
            Department dept = new Department();
            dept.Id = department.Id;
            dept.DepartmentName = department.DepartmentName;
            return dept;
        }

    }
}
