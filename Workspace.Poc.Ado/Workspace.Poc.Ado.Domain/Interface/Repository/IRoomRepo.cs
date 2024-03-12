using Workspace.Poc.Ado.Domain.Entity;

namespace Workspace.Poc.Ado.Domain.Interface.Repository
{
    public interface IRoomRepo
    {
        Task<IEnumerable<Room>> GetMeetingRooms(int locationId);
    }
}
