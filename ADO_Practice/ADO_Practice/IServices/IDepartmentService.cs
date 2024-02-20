using ADO_Practice.Models;
using ADO_Practice.RequestModel;
using ADO_Practice.ViewModel;

namespace ADO_Practice.IServices
{
    public interface IDepartmentService
    {
        List<DepartmentViewModel> GetAll();
        string AddDepartment(DepartmentRequestModel department);
    }
}
