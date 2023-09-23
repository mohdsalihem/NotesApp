using ServerApp.Helpers;
using ServerApp.Helpers.Interfaces;
using ServerApp.Models;
using ServerApp.Repositories.Interfaces;
using SqlKata.Execution;

namespace ServerApp.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbAccessor dbAccessor;
    private readonly IGenericRepository<User> genericRepository;

    public UserRepository(IDbAccessor dbAccessor, IGenericRepository<User> genericRepository)
    {
        this.dbAccessor = dbAccessor;
        this.genericRepository = genericRepository;
    }

    public async Task<User> Get(int id)
    {
        return await dbAccessor.Factory
                    .Query<User>()
                    .Where("id", id)
                    .FirstOrDefaultAsync<User>();
    }

    public async Task<User> Get(string username, string password)
    {
        return await dbAccessor.Factory
                    .Query<User>()
                    .Where(new
                    {
                        username,
                        password
                    })
                    .FirstOrDefaultAsync<User>();
    }

    public async Task<int> Insert(User user)
    {
        return await genericRepository.Insert(user);
    }

    public async Task<bool> IsUsernameExist(string username)
    {
        return await dbAccessor.Factory
                    .Query<User>()
                    .Where("username", username)
                    .CountAsync<bool>();
    }
}
