using LevelUp.Models;

namespace LevelUp.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUserById(int id);
        bool DeleteUser(int id);
        bool UpdateUser(User user);
        bool AddUser(User user);
        User Authenticate(string email, string password);

        bool Save();
    }
}
