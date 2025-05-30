using Agendamento_Api.Context;
using Agendamento_Api.Interfaces;
using Agendamento_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Agendamento_Api.Services
{
    public class RoomService : IRoomService
    {
        private readonly APIContext _context;
        public RoomService(APIContext context)
        {
            _context = context;
        }

        public IEnumerable<MeetingRoom> GetAllRooms()
        {
            var allRooms = _context.Rooms.ToList();
            return allRooms;

        }

        public MeetingRoom GetRoomById(int id)
        {
            var roomFound = _context.Rooms.FirstOrDefault(u => u.Id == id);
            return roomFound;
        }

        public MeetingRoom Create(MeetingRoom room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return room;

        }

        public MeetingRoom Update(int id, MeetingRoom updatedRoom)
        {
            var roomFound = _context.Rooms.FirstOrDefault(u => u.Id == id);

            if (roomFound == null)
            {
                return null;
            }

            roomFound.Name = updatedRoom.Name;
            roomFound.maximumCapacity = updatedRoom.maximumCapacity;
            _context.SaveChanges();
            return roomFound;
        }

        public bool Delete(int id)
        {
            var roomFound = _context.Rooms.FirstOrDefault(u => u.Id == id);
            if (roomFound == null)
            {
                return false;
            }

            _context.Rooms.Remove(roomFound);
            _context.SaveChanges();
            return true;

        }
    }
}
