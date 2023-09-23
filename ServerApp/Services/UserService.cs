using ServerApp.Services.Interfaces;
using ServerApp.Repositories.Interfaces;

namespace ServerApp.Services;

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