using CoddingChallenge.DataBase;
using CoddingChallenge.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoddingChallenge.Services
{
    public class UserService : IUserService
    {private readonly ChallengeContext _context;
        public UserService() {
            _context = new ChallengeContext();
        }
        public void AddUser(User user)
        {
            try
            {
                _context.users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void EditUser(User user)
        {
            try
            {

                _context.users.Update(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User ValidteUser(string email, string password)
        {
            return _context.users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
