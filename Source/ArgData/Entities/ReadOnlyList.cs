using System.Collections;

namespace ArgData.Entities;

/// <summary>
/// Represents a read-only list of items of type T.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ReadOnlyList<T> : IEnumerable<T>
{
    private readonly IList<T> _items;

    internal ReadOnlyList(IList<T> items)
    {
        _items = items;
    }

    /// <summary>
    /// Returns the item at the specified index.
    /// </summary>
    /// <param name="index">Zero-based index of item to return.</param>
    public T this[int index] => _items[index];

    /// <summary>Returns an enumerator that iterates through the collection.</summary>
    /// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Returns the number of items.
    /// </summary>
    public int Count => _items.Count;

    internal IList<T> List => _items;
}