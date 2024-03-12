using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Poc.Ado.Domain.RequestModel;
using Workspace.Poc.Ado.Domain.ViewModel;

namespace Workspace.Poc.Ado.Domain.Interface.Service
{
    public interface IBookingService
    {
        Task<String> AddMeeting(BookingPayload booking);
        Task<bool> ValidateMeeting(BookingPayload booking);
        Task<IEnumerable<TodaysMeetingResponse>> GetTodayMeeting();
    }
}
