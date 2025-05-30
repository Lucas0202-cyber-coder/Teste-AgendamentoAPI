using Agendamento_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Agendamento_Api.Context
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {}

        public DbSet<Users> Users { get; set; }
        public DbSet<MeetingRoom> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}
