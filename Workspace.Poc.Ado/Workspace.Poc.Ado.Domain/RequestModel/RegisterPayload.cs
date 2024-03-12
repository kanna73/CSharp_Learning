using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Poc.Ado.Domain.RequestModel
{
    public class RegisterPayload
    {
        public string? Name { get; set; }

        public string? EmpNo { get; set; }

        public string? Email { get; set; }

        public int? LocationId { get; set; }

        public string? UserPassword { get; set; }
    }
}
