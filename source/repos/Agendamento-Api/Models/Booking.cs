using Agendamento_Api.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendamento_Api.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public StatusEnum Status { get; set; }
        
        [Required]
        public DateTime BookingStart { get; set; }
        
        [Required]
        public DateTime BookingEnd { get; set; }
        
        [ForeignKey("Rooms")]
        public int RoomId { get; set; }
        
        [ForeignKey("Users")]
        public int UserId { get; set; }

        public Users User { get; set; }
        
        public MeetingRoom Room { get; set; }
    }
}
