using Microsoft.AspNetCore.Mvc;
using Workspace.Poc.Ado.Domain.Interface.Service;
using Workspace.Poc.Ado.Domain.RequestModel;
using Workspace.Poc.Ado.Domain.ViewModel;

namespace Workspace.Poc.Ado.Web.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<string> Meetings(BookingPayload bookingPayload)
        {
            return await _bookingService.AddMeeting(bookingPayload);
        }

        [HttpPost]
        public async Task<bool> ValidateMeeting(BookingPayload bookingPayload)
        {
            return await _bookingService.ValidateMeeting(bookingPayload);
        }

        [HttpGet]
        public async Task<IEnumerable<TodaysMeetingResponse>> GetTodayMeeting()
        {
            return await _bookingService.GetTodayMeeting();
        }

    }
}


