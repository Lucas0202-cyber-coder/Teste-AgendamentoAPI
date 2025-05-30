using System.ComponentModel.DataAnnotations;

namespace Agendamento_Api.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

    }
}
