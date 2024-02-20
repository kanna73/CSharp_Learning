using Model.Entity;
using Model.RequestModel;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Interface
{
    public  interface IServiceMapper
    {
        List<EmployeeView> ConvertToEmployeeView(List<Employee> employee);
        Employee ConvertToEmployee(EmployeeRequest employeeRequest);

    }
}
