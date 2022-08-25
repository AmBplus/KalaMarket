namespace KalaMarket.Shared;

public static class Pagination
{
    public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source, int page, int pageSize,
        out int rowsCounts)
    {
        rowsCounts = source.Count();
        return source.Skip((page - 1) * pageSize).Take(pageSize);
    }
}