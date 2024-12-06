namespace AdventOfCode.Common;

public static class EnumerableExtensions
{
    /// <summary>
    ///     Splits the elements of a sequence into chunks delimited by a predicate.
    /// </summary>
    /// <param name="source">
    ///     An <see cref="IEnumerable{T}"/> whose elements to chunk.
    /// </param>
    /// <param name="predicate">
    ///     Used to separate chunks when evaluated to true.
    /// </param>
    /// <typeparam name="TSource">
    ///     The type of the elements of source.
    /// </typeparam>
    /// <returns>
    ///     An <see cref="IEnumerable{T}"/> that contains the elements the input sequence split into chunks delimited by
    ///     the <paramref name="predicate"/>. Items matching the predicate are not included in the returned sequence.
    /// </returns>
    public static IEnumerable<TSource[]> ChunkOn<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        using IEnumerator<TSource> e = source.GetEnumerator();

        var list = new List<TSource>();
        while (e.MoveNext())
        {
            if (predicate(e.Current) && list.Count > 0)
            {
                yield return list.ToArray();
                list.Clear();
                continue;
            }

            list.Add(e.Current);
        }
        yield return list.ToArray();
    }
}