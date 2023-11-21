using CoddingChallenge.Entities;

namespace CoddingChallenge.Services
{
    public interface IUserService
    {
        void AddUser(User user); 
        void EditUser(User user);
        User ValidteUser(string email, string password);
       
    }
}
