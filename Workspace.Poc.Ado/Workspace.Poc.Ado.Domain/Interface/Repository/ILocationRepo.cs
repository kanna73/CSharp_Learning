using Workspace.Poc.Ado.Domain.Entity;

namespace Workspace.Poc.Ado.Domain.Interface.Repository
{
    public interface ILocationRepo
    {
        Task<Location> GetById(int id);
    }
}
