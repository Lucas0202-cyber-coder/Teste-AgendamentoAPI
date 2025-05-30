using System.ComponentModel.DataAnnotations;

namespace Agendamento_Api.Models
{
    public class MeetingRoom
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Capacity must be higher than 0")]
        public int maximumCapacity { get; set; } 
       
    }
}
