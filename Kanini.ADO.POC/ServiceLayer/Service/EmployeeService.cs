using DataLayer.Interface;
using Mapper.Interface;
using Model.Entity;
using Model.RequestModel;
using Model.ViewModel;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public  class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepo _repo;
        private readonly IServiceMapper _mapper;

        public EmployeeService(IEmployeeRepo repo,IServiceMapper mapper)
        {
            _mapper= mapper;
            _repo = repo;
        }

        public List<EmployeeView> GetAllEmployee()
        {
            var employee = _repo.GetAllEmployee();
            var result = _mapper.ConvertToEmployeeView(employee);
            return result;
        }

        public string AddEmployee(EmployeeRequest employeeRequest)
        {
            var employee = _mapper.ConvertToEmployee(employeeRequest);
            return _repo.AddEmployee(employee);
        }

        public string UpadteEmployee(EmployeeRequest employeeRequest)
        {
            var employee = _mapper.ConvertToEmployee(employeeRequest);
            return _repo.UpdateEmployee(employee);
        }

        public string DeleteEmployee(int id)
        {
            return _repo.DeleteEmployee(id);
        }

        public int GetEmployeeCount()
        {
            return _repo.GetEmployeeCount();
        }

        public List<EmployeeWithDepartment> GetAllEmployeeWithDepartment()
        {
            return _repo.GetAllEmployeeWithDepartment();
        }

    }
}
