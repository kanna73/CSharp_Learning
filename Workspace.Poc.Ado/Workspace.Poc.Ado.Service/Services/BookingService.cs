using AutoMapper;
using Workspace.Poc.Ado.Domain.Entity;
using Workspace.Poc.Ado.Domain.Interface.Repository;
using Workspace.Poc.Ado.Domain.Interface.Service;
using Workspace.Poc.Ado.Domain.RequestModel;
using Workspace.Poc.Ado.Domain.ViewModel;
using Workspace.Poc.Ado.Service.Exceptions;

namespace Workspace.Poc.Ado.Service.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepo _bookingRepo;
        private readonly IMapper _mapper;
        public BookingService(IBookingRepo bookingRepo, IMapper mapper)
        {
            _bookingRepo = bookingRepo;
            _mapper = mapper;
        }

        public async Task<String> AddMeeting(BookingPayload booking)
        {
            BookMeeting newBooking = _mapper.Map<BookMeeting>(booking);
            int row = await _bookingRepo.AddMeeting(newBooking);
            return "Meeting created successfully";
        }

        public async Task<bool> ValidateMeeting(BookingPayload booking)
        {
            BookMeeting newBooking = _mapper.Map<BookMeeting>(booking);
            return await _bookingRepo.ValidateMeeting(newBooking);
        }

        public async Task<IEnumerable<TodaysMeetingResponse>> GetTodayMeeting()
        {
            var result = await _bookingRepo.GetTodayMeeting();
            if (result.Any())
            {
                return result;
            }
            throw new NotFound("There is no meeting Today");
        }
    }
}
