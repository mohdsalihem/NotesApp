namespace ServerApp.Repositories.Interfaces;

public interface IGenericRepository<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T> Get(int id);
    Task<int> Insert(T item);
    Task<int> Update(T item);
    Task<int> Delete(int id);
    Task<int> DeletePermanent(int id);
}
