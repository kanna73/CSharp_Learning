using Kanini.Poc.Ado.Domain.Interface.MapperInterface;
using Model.Entity;
using Model.RequestModel;
using Model.ViewModel;

namespace Mapper.Mapper
{
    public class ServiceMapper : IServiceMapper
    {
        public IEnumerable<EmployeeView> ConvertToEmployeeView(IEnumerable<Employee> employee)
        {

            List<EmployeeView> employeeViews = new List<EmployeeView>();
            foreach (Employee emp in employee)
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
            employee.DeptID = employeeRequest.DeptID;
            return employee;
        }

        public IEnumerable<Employee> ConvertToEmployees(IEnumerable<EmployeeRequest> employeeRequests)
        {
            List<Employee> employees = new List<Employee>();
            foreach (EmployeeRequest employeeRequest in employeeRequests)
            {
                Employee employee = new Employee();
                employee.Id = employeeRequest.Id;
                employee.EmployeeName = employeeRequest.EmployeeName;
                employee.EmployeeCode = employeeRequest.EmployeeCode;
                employee.DeptID = employeeRequest.DeptID;
                employees.Add(employee);
            }
            return employees;

        }
    }
}
