using SqlKata.Execution;

namespace NotesApp.Server.Helpers.Interfaces;

public interface IUnitOfWork
{
    void BeginTransaction();
    void Commit();
    void Rollback();
}
