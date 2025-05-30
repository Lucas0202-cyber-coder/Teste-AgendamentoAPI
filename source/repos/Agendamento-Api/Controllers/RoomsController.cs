using Agendamento_Api.Interfaces;
using Agendamento_Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var roomList = _roomService.GetAllRooms();
            return Ok(roomList);

        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var room = _roomService.GetRoomById(id);

            if (room == null)
            {
                return BadRequest("Room not found");
            }

            return Ok(room);

        }

        [HttpPost]
        public IActionResult CreateRoom(MeetingRoom room)
        {
            if (room == null)
            {
                return BadRequest("Invalid insertion");
            }

            var createRoom = _roomService.Create(room);

            return Ok(createRoom);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRoom(int id, MeetingRoom room)
        {
            var updatedRoom = _roomService.Update(id, room);

            if (updatedRoom == null)
            {
                return BadRequest("Room not found");
            }

            return Ok(updatedRoom);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var deletedRoom = _roomService.Delete(id);

            if (!deletedRoom)
            {
                return BadRequest("User not found");
            }

            return Ok(deletedRoom);
        }

    }
}
