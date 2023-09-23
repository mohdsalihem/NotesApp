namespace ServerApp.Services.Interfaces;

public interface IUserService
{
    Task<bool> IsUsernameExist(string username);
}