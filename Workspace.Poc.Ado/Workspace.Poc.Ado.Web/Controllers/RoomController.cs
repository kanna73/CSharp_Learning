using Microsoft.AspNetCore.Mvc;
using Workspace.Poc.Ado.Domain.Interface.Service;
using Workspace.Poc.Ado.Domain.ViewModel;

namespace Workspace.Poc.Ado.Web.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IEnumerable<RoomFilterResponse>> MeetingRooms(int loactionId)
        {
            return await _roomService.GetMeetingRooms(loactionId);
        }
    }
}
