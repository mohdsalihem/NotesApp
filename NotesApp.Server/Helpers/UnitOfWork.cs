using NotesApp.Server.Helpers.Interfaces;
using System.Data;

namespace NotesApp.Server.Helpers;

public class UnitOfWork : IUnitOfWork
{
    public readonly IDbAccessor dbAccessor;
    private IDbTransaction? Transaction;
    public UnitOfWork(IDbAccessor dbAccessor)
    {
        this.dbAccessor = dbAccessor;
    }
    public void BeginTransaction()
    {
        dbAccessor.Factory.Connection.Open();
        Transaction = dbAccessor.Factory.Connection.BeginTransaction();
    }

    public void Commit()
    {
        Transaction?.Commit();
        dbAccessor.Factory.Connection.Close();
    }

    public void Rollback()
    {
        Transaction?.Rollback();
        dbAccessor.Factory.Connection.Close();
    }
}
