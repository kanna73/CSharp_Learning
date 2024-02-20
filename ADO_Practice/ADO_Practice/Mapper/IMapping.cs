using ADO_Practice.Models;
using ADO_Practice.RequestModel;
using ADO_Practice.ViewModel;
using Microsoft.Data.SqlClient;

namespace ADO_Practice.Mapper
{
    public interface IMapping
    {
        List<EmployeeViewModel> ToEmployeeView(List<Employee> emp);
        Employee ToEmployee(EmployeeRequestModel emp);
        List<DepartmentViewModel> ToDepartmentView(List<Department> department);
        Department ToDepartment(DepartmentRequestModel department);
    }
}
