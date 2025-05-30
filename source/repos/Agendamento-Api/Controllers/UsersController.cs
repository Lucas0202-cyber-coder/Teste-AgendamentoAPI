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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var userList = _userService.GetAllUsers();
            return Ok(userList);
            
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);

            if(user == null)
            {
                return BadRequest("User not found");
            }

            return Ok(user);

        }

        [HttpPost]
        public IActionResult CreateUser(Users user)
        {
            if (user == null)
            {
                return BadRequest("Invalid insertion");
            }

            var createUser = _userService.Create(user);

            return Ok(createUser);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, Users user)
        {
            var updated = _userService.Update(id, user);

            if(updated == null)
            {
                return BadRequest("User not found");
            }

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var deletedUser = _userService.Delete(id);

            if (!deletedUser)
            {
                return BadRequest("User not found");
            }

            return Ok(deletedUser);
        }

    }
}
