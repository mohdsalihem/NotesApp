using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using NotesApp.Server.AppSettings;
using NotesApp.Server.Helpers.Interfaces;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data;

namespace NotesApp.Server.Helpers;

public class DbAccessor : IDbAccessor
{
    public IDbConnection Connection { get; set; }
    public QueryFactory Factory { get; set; }
    public static readonly Compiler Compiler = new SqliteCompiler();
    public DbAccessor(IOptions<ConnectionStrings> connectionStrings)
    {
        Connection = new SqliteConnection(connectionStrings.Value.DefaultConnection);
        Factory = new QueryFactory(Connection, Compiler);
    }
}