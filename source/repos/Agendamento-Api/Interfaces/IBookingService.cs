using Agendamento_Api.Enums;
using Agendamento_Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Agendamento_Api.Interfaces
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetAllBookings();
        public List<Booking> Filter(int? userId, int? roomId, DateTime? dateTime, StatusEnum? status);
        Booking BookMeeting(BookingRequestDTO request);
        bool CancelBooking(int bookingId);


    }
}
