using ADO_Practice.Models;

namespace ADO_Practice.IRepositories
{
    public interface IDepartmentRepo
    {
        List<Department> GetAll();
        string AddDepartment(Department department);

    }
}
