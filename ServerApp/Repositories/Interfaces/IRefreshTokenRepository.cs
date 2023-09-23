using ServerApp.Models;

namespace ServerApp.Repositories.Interfaces;

public interface IRefreshTokenRepository
{
    Task<int> Insert(RefreshToken refreshToken);
    Task<RefreshToken> Get(string refreshToken);
    Task<int> Update(RefreshToken refreshToken);
    Task<int> Delete(int id);
    Task<int> DeleteByUserId(int userId);
    Task<bool> IsTokenExist(string refreshToken);
}
