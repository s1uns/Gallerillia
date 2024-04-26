using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class QueryExtensions
{
    public static async Task<IQueryable<T>> ForEachAsync<T>(this IQueryable<T> query, Func<T, Task> function)
    {
        foreach (var value in query)
        {
            await function(value);
        }

        return query;
    }

    public static async Task ForEachAsync<T>(this List<T> list, Func<T, Task> function)
    {
        foreach (var value in list)
        {
            await function(value);
        }
    }
}
