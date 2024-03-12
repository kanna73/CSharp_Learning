using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Poc.Ado.Domain.ViewModel
{
    public class TodaysMeetingResponse
    {
        public string? RoomName { get; set; }
        public string? MeetingTitle { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public DateTime? BookDate { get; set; }
        public string? LocationName { get; set; }
        public string? EmpName { get; set; }
        public string? Imagepath { get; set; }
    }
}
