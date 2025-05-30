using Agendamento_Api.Context;
using Agendamento_Api.Interfaces;
using Agendamento_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Agendamento_Api.Services
{
    public class UserService : IUserService
    {
        private readonly APIContext _context;
        public UserService(APIContext context) 
        {
            _context = context;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            var allUsers = _context.Users.ToList();
            return allUsers;
            
        }

        public Users GetUserById(int id)
        {
            var userFound = _context.Users.FirstOrDefault(u => u.Id == id);
            return userFound;
        }

        public Users Create(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
            
        }

        public Users Update(int id, Users updatedUser)
        {
            var userFound = _context.Users.FirstOrDefault(u => u.Id == id);

            if(userFound == null)
            {
                return null;
            }

            userFound.Name = updatedUser.Name;
            userFound.Password = updatedUser.Password;

            _context.SaveChanges();
            return userFound;
        }

        public bool Delete(int id)
        {
            var userFound = _context.Users.FirstOrDefault(u => u.Id == id);
            if(userFound == null)
            {
                return false;
            }

            _context.Users.Remove(userFound);
            _context.SaveChanges();
            return true;

        }
    }
}
