using ServerApp.Data;
using ServerApp.Entities;

namespace ServerApp.Interfaces
{
    public interface IUserService
    {
        AuthResponse Login(AuthRequest request);
        AuthResponse Signup(User user);
        string CheckUsernameExist(string username);
        void DbContext(DataContext context);
    }
}