using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Poc.Ado.Domain.Entity;
using Workspace.Poc.Ado.Domain.ViewModel;

namespace Workspace.Poc.Ado.Domain.Interface.Repository
{
    public interface IBookingRepo
    {
        Task<int> AddMeeting(BookMeeting bookMeeting);
        Task<bool> ValidateMeeting(BookMeeting bookMeeting);
        Task<IEnumerable<TodaysMeetingResponse>> GetTodayMeeting();
    }
}
