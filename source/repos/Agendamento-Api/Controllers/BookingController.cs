using Agendamento_Api.Enums;
using Agendamento_Api.Interfaces;
using Agendamento_Api.Models;
using Agendamento_Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult GetAllBookings()
        {
            var allBookings = _bookingService.GetAllBookings();
            return Ok(allBookings);

        }
        [HttpGet("filter")]
        public IActionResult FilterBookings(int? userId,int? roomId, DateTime? dateTime, StatusEnum? status )
        {
            var filteredBooking = _bookingService.Filter(userId,roomId,dateTime,status);
            return Ok(filteredBooking);
        }

        [HttpPost]
        public IActionResult GenerateBooking(BookingRequestDTO booking)
        {
            if (booking == null)
            {
                return BadRequest("Invalid insertion");
            }

            var generateBooking = _bookingService.BookMeeting(booking);

            return Ok(booking);
        }

        [HttpPut("CancelBooking")]
        public IActionResult CancelBooking(int bookingId)
        {
            var cancelBooking = _bookingService.CancelBooking(bookingId);

            if (!cancelBooking)
            {
                return BadRequest("No bookings with this id");
            }

            return Ok(cancelBooking);
        }

    }
}
