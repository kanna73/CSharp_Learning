using Workspace.Poc.Ado.Domain.Entity;
using Workspace.Poc.Ado.Domain.RequestModel;
using Workspace.Poc.Ado.Domain.ViewModel;

namespace Workspace.Poc.Ado.Domain.Interface.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<String> AddUser(RegisterPayload user);
        Task<LoginResponse> GetByEmail(LoginPayload user);
    }
}
