using NotesApp.Server.Services.Interfaces;
using NotesApp.Server.Repositories.Interfaces;

namespace NotesApp.Server.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<bool> IsUsernameExist(string username)
    {
        return await userRepository.IsUsernameExist(username);
    }
}