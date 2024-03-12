using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Poc.Ado.Domain.RequestModel
{
    public class LoginPayload
    {
        public string? Email { get; set; }
        public string? UserPassword { get; set; }
    }
}
