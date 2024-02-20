using Mapper.Interface;
using Model.Entity;
using Model.RequestModel;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Mapper
{
    public  class ServiceMapper : IServiceMapper
    {
        public List<EmployeeView> ConvertToEmployeeView(List<Employee> employee) 
        {

            List<EmployeeView> employeeViews = new List<EmployeeView>();
            foreach(Employee emp in employee)
            {
                EmployeeView employeeView = new EmployeeView();
                employeeView.Id = emp.Id;
                employeeView.EmployeeName = emp.EmployeeName;
                employeeView.EmployeeCode = emp.EmployeeCode;
                employeeView.DeptID = emp.DeptID;
                employeeViews.Add(employeeView);
            }
            return employeeViews;

        }

        public Employee ConvertToEmployee(EmployeeRequest employeeRequest)
        {
            Employee employee = new Employee();
            employee.Id = employeeRequest.Id;
            employee.EmployeeName = employeeRequest.EmployeeName;
            employee.EmployeeCode = employeeRequest.EmployeeCode;
            employee.DeptID= employeeRequest.DeptID;   
            return employee;
        }
    }
}
