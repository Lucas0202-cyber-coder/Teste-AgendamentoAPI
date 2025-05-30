namespace Agendamento_Api.Models
{
    public class BookingRequestDTO
    {
        public int Id { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
    }

}
