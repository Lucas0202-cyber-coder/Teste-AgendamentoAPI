using Agendamento_Api.Context;
using Agendamento_Api.Enums;
using Agendamento_Api.Interfaces;
using Agendamento_Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Agendamento_Api.Services
{
    public class BookingService : IBookingService
    {
        private readonly APIContext _context;
        public BookingService(APIContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            var allBookings = _context.Bookings.ToList();
            return allBookings;

        }
        public Booking BookMeeting(BookingRequestDTO request)
        {
            if(request.BookingStart.Date != request.BookingEnd.Date)
            {
                throw new Exception("Booking can only start and end on the same day");
            }
            if(request.BookingEnd <= request.BookingStart)
            {
                throw new Exception("Start time cannot be less than End Time");
            }

            bool conflitBooking = _context.Bookings.Any(b =>
                b.RoomId == request.RoomId &&
                request.BookingStart < b.BookingEnd &&
                request.BookingEnd > b.BookingStart);
            
            if(conflitBooking)
            {
                throw new Exception("There is already a booking at that time for this room");
            }
            
            var booking = new Booking ()
            {
                Id = request.Id,
                BookingStart = request.BookingStart,
                BookingEnd = request.BookingEnd,
                UserId = request.UserId,
                RoomId = request.RoomId,
            };
            
            booking.Status = StatusEnum.Active;
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return booking;
        }

        public bool CancelBooking(int bookingId)
        {
            var booking = _context.Bookings.FirstOrDefault(book => book.Id == bookingId);
            if (booking == null) return false;

            booking.Status = Enums.StatusEnum.Canceled;
            _context.Bookings.Update(booking);
            _context.SaveChanges();
            return true;
        }

        public List<Booking> Filter(int? userId,int? roomId, DateTime? dateTime, StatusEnum? status)
        {
            var query = _context.Bookings.AsQueryable();

            if (userId.HasValue)
                query = query.Where(b => b.UserId == userId.Value);

            if (roomId.HasValue)
                query = query.Where(b => b.RoomId == roomId.Value);

            if (dateTime.HasValue)
                query = query.Where(b => b.BookingStart.Date == dateTime.Value.Date);

            if (status.HasValue)
                query = query.Where(b => b.Status == status.Value);

            return query.ToList();
        }
    }
}
