using ServerApp.Models;
using SqlKata;
using SqlKata.Execution;

namespace ServerApp.Helpers;

public static class SqlKataExtensionMethods
{
    public static Query Query<T>(this QueryFactory queryFactory) => queryFactory.Query(typeof(T).Name.ToLower());
    public static Query WhereNotArchived(this Query query) => query.Where("isarchived", false);

    public static Query InsertDefaults<T>(this Query query, ref T item) where T : Model
    {
        item.CreatedDate = item.ModifiedDate = DateTime.UtcNow;
        item.IsArchived = false;

        return query;
    }

    public static Query UpdateDefaults<T>(this Query query, ref T item) where T : Model
    {
        item.ModifiedDate = DateTime.UtcNow;

        return query;
    }

    public static SqlResult Compile(this Query query)
    {
        return DbAccessor.Compiler.Compile(query);
    }
}
