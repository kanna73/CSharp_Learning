using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Poc.Ado.Domain.Entity;
using Workspace.Poc.Ado.Domain.RequestModel;
using Workspace.Poc.Ado.Domain.ViewModel;

namespace Workspace.Poc.Ado.Mapper.Mapper
{
    public class MappingProfile : Profile           

    {
        public MappingProfile()
        {
            CreateMap<RegisterPayload, User>().ForMember(dest => dest.EmpName, opt => opt.MapFrom(src => src.Name));
            CreateMap<Location, LocationResponse>();
            CreateMap<Room, RoomFilterResponse>();
            CreateMap<BookingPayload, BookMeeting>();
        }
    }
}
