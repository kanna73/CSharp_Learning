using AutoMapper;
using Workspace.Poc.Ado.Domain.Interface.Repository;
using Workspace.Poc.Ado.Domain.Interface.Service;
using Workspace.Poc.Ado.Domain.ViewModel;
using Workspace.Poc.Ado.Service.Exceptions;

namespace Workspace.Poc.Ado.Service.Services
{
    public class LocationService : ILocationService
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepo _locationRepo;

        public LocationService(IMapper mapper, ILocationRepo locationRepo)
        {
            _locationRepo = locationRepo;
            _mapper = mapper;
        }

        public async Task<LocationResponse> GetLocationById(int id)
        {
            var location = await _locationRepo.GetById(id);
            if (location.Id != id)
            {
                throw new NotFound("This Record does not Exist");
            }
            var result = _mapper.Map<LocationResponse>(location);
            return result;

        }
    }
}
