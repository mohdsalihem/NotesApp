using ServerApp.Helpers;
using ServerApp.Helpers.Interfaces;
using ServerApp.Models;
using ServerApp.Repositories.Interfaces;
using SqlKata.Execution;

namespace ServerApp.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : Model
{
    private readonly IDbAccessor dbAccessor;
    private readonly IHttpContextHelper httpContextHelper;

    public GenericRepository(IDbAccessor dbAccessor, IHttpContextHelper httpContextHelper)
    {
        this.dbAccessor = dbAccessor;
        this.httpContextHelper = httpContextHelper;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await dbAccessor.Factory
                    .Query<T>()
                    .Where(new
                    {
                        userid = httpContextHelper.UserId,
                        isarchived = false
                    })
                    .GetAsync<T>();
    }

    public async Task<T> Get(int id)
    {
        return await dbAccessor.Factory
                    .Query<T>()
                    .Where(new
                    {
                        id,
                        userid = httpContextHelper.UserId
                    })
                    .WhereNotArchived()
                    .FirstOrDefaultAsync<T>();
    }

    public async Task<int> Insert(T item)
    {
        return await dbAccessor.Factory
                    .Query<T>()
                    .InsertDefaults(ref item)
                    .InsertGetIdAsync<int>(item);
    }

    public async Task<int> Update(T item)
    {
        return await dbAccessor.Factory
                    .Query<T>()
                    .UpdateDefaults(ref item)
                    .Where(new
                    {
                        id = item.Id,
                        userid = httpContextHelper.UserId
                    })
                    .UpdateAsync(item);
    }

    public async Task<int> Delete(int id)
    {
        return await dbAccessor.Factory
                    .Query<T>()
                    .Where(new
                    {
                        id,
                        userid = httpContextHelper.UserId
                    })
                    .UpdateAsync(new
                    {
                        modifieddate = DateTime.UtcNow,
                        isarchived = true
                    });
    }

    public async Task<int> DeletePermanent(int id)
    {
        return await dbAccessor.Factory
                    .Query<T>()
                    .Where(new
                    {
                        id,
                        userid = httpContextHelper.UserId
                    })
                    .DeleteAsync();
    }
}
