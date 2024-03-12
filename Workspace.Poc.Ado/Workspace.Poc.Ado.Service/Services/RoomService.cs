using AutoMapper;
using Workspace.Poc.Ado.Domain.Interface.Repository;
using Workspace.Poc.Ado.Domain.Interface.Service;
using Workspace.Poc.Ado.Domain.ViewModel;
using Workspace.Poc.Ado.Service.Exceptions;

namespace Workspace.Poc.Ado.Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepo _roomRepo;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepo roomRepo, IMapper mapper)
        {
            _mapper = mapper;
            _roomRepo = roomRepo;
        }

        public async Task<IEnumerable<RoomFilterResponse>> GetMeetingRooms(int locationId)
        {
            var rooms = await _roomRepo.GetMeetingRooms(locationId);
            if(rooms.Any())
            {
                var result = _mapper.Map<List<RoomFilterResponse>>(rooms);
                return result;
            }
            throw new NotFound("There is no room for this location id");
        }
    }
}
