using Microsoft.AspNetCore.Mvc;
using Workspace.Poc.Ado.Domain.Entity;
using Workspace.Poc.Ado.Domain.Interface.Service;
using Workspace.Poc.Ado.Domain.RequestModel;
using Workspace.Poc.Ado.Domain.ViewModel;

namespace Workspace.Poc.Ado.Web.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetAllUser()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result);
        }

        [HttpPost]

        public async Task<String> RegisterUser(RegisterPayload user)
        {
            return await _userService.AddUser(user);
        }

        [HttpPost]

        public async Task<LoginResponse> AuthenticateUser(LoginPayload user)
        {
            return await _userService.GetByEmail(user);
        }
    }
}
