using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Poc.Ado.Domain.ViewModel
{
    public class RoomFilterResponse
    {
        public int Id { get; set; }

        public string? RoomName { get; set; }

        public int? LocationId { get; set; }

        public int? Capacity { get; set; }
    }
}
