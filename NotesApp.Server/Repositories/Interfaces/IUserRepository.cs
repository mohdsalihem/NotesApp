using NotesApp.Server.Models;

namespace NotesApp.Server.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> Get(int id);
    Task<User> Get(string username, string password);
    Task<int> Insert(User user);
    Task<bool> IsUsernameExist(string username);
}
