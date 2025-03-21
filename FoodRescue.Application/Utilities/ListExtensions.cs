namespace FoodRescue.Application.Utilities;

public static class IEnumerableE0tensions
{
    public static IEnumerable<Destination> ConvertAll<Destination, Source>(
        this IEnumerable<Source> source,
        Func<Source, Destination> convertFunc
    )
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (convertFunc == null) throw new ArgumentNullException(nameof(convertFunc));
        return source.Select(convertFunc).ToList();
    }
}
