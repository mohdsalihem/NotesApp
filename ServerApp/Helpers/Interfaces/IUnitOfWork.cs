using SqlKata.Execution;

namespace ServerApp.Helpers.Interfaces;

public interface IUnitOfWork
{
    void BeginTransaction();
    void Commit();
    void Rollback();
}
