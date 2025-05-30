using Agendamento_Api.Models;

namespace Agendamento_Api.Interfaces
{
    public interface IUserService
    {
        IEnumerable<Users> GetAllUsers();
        Users GetUserById(int id);
        Users Create(Users user);
        Users Update(int id, Users user);
        bool Delete(int id);
    }
}
