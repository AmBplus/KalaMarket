namespace KalaMarket.Shared;

public static class Pagination
{
    public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source, int? page, byte pageSize,
        out int recordCount)
    {
        recordCount = source.Count();
        return source.Skip(((int)page - 1) * pageSize).Take(pageSize);
    }
    public static IQueryable<TSource> ToPaged<TSource>(this IQueryable<TSource> source, int? page, byte pageSize,
        out int recordCount)
    {
        recordCount = source.Count();
        return source.Skip(((int)page - 1) * pageSize).Take(pageSize);
    }
}