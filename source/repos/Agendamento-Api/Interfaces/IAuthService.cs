using Agendamento_Api.Models;

namespace Agendamento_Api.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(Users login);
    }
}
