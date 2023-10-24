using NotesApp.Server.Helpers;
using NotesApp.Server.Helpers.Interfaces;
using NotesApp.Server.Models;
using NotesApp.Server.Repositories.Interfaces;
using SqlKata.Execution;

namespace NotesApp.Server.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly IDbAccessor dbAccessor;

    public RefreshTokenRepository(IDbAccessor dbAccessor)
    {
        this.dbAccessor = dbAccessor;
    }

    public async Task<int> Insert(RefreshToken refreshToken)
    {
        return await dbAccessor.Factory
                    .Query<RefreshToken>()
                    .InsertGetIdAsync<int>(refreshToken);
    }

    public async Task<RefreshToken> Get(string refreshToken)
    {
        return await dbAccessor.Factory
                    .Query<RefreshToken>()
                    .Where("token", refreshToken)
                    .FirstOrDefaultAsync<RefreshToken>();
    }

    public async Task<int> Update(RefreshToken refreshToken)
    {
        return await dbAccessor.Factory
                    .Query<RefreshToken>()
                    .UpdateAsync(refreshToken);
    }

    public async Task<int> Delete(int id)
    {
        return await dbAccessor.Factory
                    .Query<RefreshToken>()
                    .Where("id", id)
                    .DeleteAsync();
    }

    public async Task<int> DeleteByUserId(int userId)
    {
        return await dbAccessor.Factory
                    .Query<RefreshToken>()
                    .Where("userid", userId)
                    .DeleteAsync();
    }

    public async Task<bool> IsTokenExist(string refreshToken)
    {
        return await dbAccessor.Factory
                    .Query<RefreshToken>()
                    .Where("token", refreshToken)
                    .CountAsync<bool>();
    }


}
