using Agendamento_Api.Models;

namespace Agendamento_Api.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<MeetingRoom> GetAllRooms();
        MeetingRoom GetRoomById(int id);
        MeetingRoom Create(MeetingRoom room);
        MeetingRoom Update(int id, MeetingRoom room);
        bool Delete(int id);
    }
}
