using ADO_Practice.DTO;
using ADO_Practice.IRepositories;
using ADO_Practice.IServices;
using ADO_Practice.Mapper;
using ADO_Practice.Models;
using ADO_Practice.RequestModel;
using ADO_Practice.ViewModel;

namespace ADO_Practice.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _repo;
        private readonly IMapping _mapping;
        public EmployeeService(IEmployeeRepo repo, IMapping mapping) 
        {
            _repo = repo;
            _mapping = mapping;
        }

        public List<EmployeeViewModel> GetAllEmployee()
        {
            var employees = _repo.GetAllEmployee(); 
            var result = _mapping.ToEmployeeView(employees);

            return result;
        }

        public string AddEmployee(EmployeeRequestModel employee)
        {
            var emp = _mapping.ToEmployee(employee);
            return _repo.AddEmployee(emp);
        }

        public string GetTotalEmployee()
        {
            int total = _repo.GetTotalEmployee();
            return total>0?"The total employees " + total:"There is no Employee";
        }

        public List<EmployeeWithDepartment> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
