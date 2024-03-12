using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Poc.Ado.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }

        public string? EmpName { get; set; }

        public string? EmpNo { get; set; }

        public string? Email { get; set; }

        public byte[]? Password { get; set; }

        public byte[]? Hashkey { get; set; }

        public int? LocationId { get; set; }
    }
}
