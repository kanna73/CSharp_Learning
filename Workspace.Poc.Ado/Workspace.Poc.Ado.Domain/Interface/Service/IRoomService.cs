using Workspace.Poc.Ado.Domain.ViewModel;

namespace Workspace.Poc.Ado.Domain.Interface.Service
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomFilterResponse>> GetMeetingRooms(int locationId);
    }
}
