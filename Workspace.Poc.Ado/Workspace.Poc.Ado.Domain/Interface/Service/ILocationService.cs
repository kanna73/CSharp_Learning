using Workspace.Poc.Ado.Domain.ViewModel;

namespace Workspace.Poc.Ado.Domain.Interface.Service
{
    public interface ILocationService
    {
        Task<LocationResponse> GetLocationById(int id);
    }
}
