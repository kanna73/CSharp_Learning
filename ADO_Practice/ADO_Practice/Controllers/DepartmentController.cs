using ADO_Practice.IServices;
using ADO_Practice.Models;
using ADO_Practice.RequestModel;
using ADO_Practice.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADO_Practice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
                _service = service;
        }

        [HttpGet]

        public List<DepartmentViewModel> GetAll()
        {
            return _service.GetAll();
        }
        [HttpPost]
        public string AddDepartment(DepartmentRequestModel department) 
        { 
            return _service.AddDepartment(department);
        }
    }
}
