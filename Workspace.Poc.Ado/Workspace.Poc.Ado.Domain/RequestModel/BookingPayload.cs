using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Poc.Ado.Domain.RequestModel
{
    public class BookingPayload
    {
        public int? MeetingId { get; set; }

        public string? MeetingTitle { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }
        public int? UserId { get; set; }
        public DateTime? BookDate { get; set; }
    }
}
