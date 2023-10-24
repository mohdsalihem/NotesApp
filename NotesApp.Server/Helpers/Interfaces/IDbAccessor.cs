using SqlKata.Execution;
using System.Data;

namespace NotesApp.Server.Helpers.Interfaces;

public interface IDbAccessor
{
    public IDbConnection Connection { get; set; }
    public QueryFactory Factory { get; set; }
}
