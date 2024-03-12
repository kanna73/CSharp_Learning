using Microsoft.AspNetCore.Mvc;
using Workspace.Poc.Ado.Domain.Interface.Service;
using Workspace.Poc.Ado.Domain.ViewModel;

namespace Workspace.Poc.Ado.Web.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult<LocationResponse>> GetLocationById(int id)
        {
            return await _locationService.GetLocationById(id);
        }
    }
}
