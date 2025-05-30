using Agendamento_Api.Context;
using Agendamento_Api.Interfaces;
using Agendamento_Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento_Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly APIContext _context;
        private readonly IAuthService _authenticationService;

        public AuthenticationController(APIContext context, IConfiguration configuration, IAuthService authenticationService)
        {
            _context = context;
            _authenticationService = authenticationService;
        }
        
        [HttpPost("login")]
        public IActionResult LoginUser(LoginRequestDTO loginRequest)
        {
            var user = _context.Users.FirstOrDefault(u => u.Name == loginRequest.Login);

            if (user == null || user.Password != loginRequest.Password) 
                return Unauthorized("Acess Denied");

            var token = _authenticationService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
