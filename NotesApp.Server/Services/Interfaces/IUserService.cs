namespace NotesApp.Server.Services.Interfaces;

public interface IUserService
{
    Task<bool> IsUsernameExist(string username);
}