using NotesApp.Server.Models;

namespace NotesApp.Server.Repositories.Interfaces;

public interface IGenericRepository<T> where T : BaseModel
{
    Task<IEnumerable<T>> GetAll();
    Task<T> Get(int id);
    Task<int> Insert(T item);
    Task<int> Update(T item);
    Task<int> Delete(int id);
    Task<int> DeletePermanent(int id);
}
