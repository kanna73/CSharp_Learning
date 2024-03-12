using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Poc.Ado.Domain.Entity;

namespace Workspace.Poc.Ado.Domain.Interface.Repository
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetAllUser();

        Task<int> AddUser(User user);

        Task<User> GetByEmail(string email);
    }
}
