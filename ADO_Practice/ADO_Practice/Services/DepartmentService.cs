using ADO_Practice.IRepositories;
using ADO_Practice.IServices;
using ADO_Practice.Mapper;
using ADO_Practice.Models;
using ADO_Practice.Repositories;
using ADO_Practice.RequestModel;
using ADO_Practice.ViewModel;

namespace ADO_Practice.Services
{
    public class DepartmentService :IDepartmentService
    {

        private readonly IDepartmentRepo _repo;
        private readonly IMapping _mapping;


        public DepartmentService(IDepartmentRepo repo,IMapping mapping)
        {
            _repo = repo;
            _mapping = mapping;
        }

        public List<DepartmentViewModel> GetAll()
        {
            var dept = _repo.GetAll();
            var result = _mapping.ToDepartmentView(dept);
            return result;
        }

        public string AddDepartment(DepartmentRequestModel department)
        {
            var dept = _mapping.ToDepartment(department);
            return _repo.AddDepartment(dept);
        }
    }
}
