using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Poc.Ado.Domain.Entity;
using Workspace.Poc.Ado.Domain.RequestModel;

namespace Workspace.Poc.Ado.Domain.Interface.Service
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}
