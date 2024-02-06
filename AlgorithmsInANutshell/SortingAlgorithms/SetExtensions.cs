using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms;

public static class SetExtensions
{
    public static IEnumerable<T> Set<T>(this T first, params T[] items) => new[] { first }.Concat(items);

    public static IEnumerable<T> StackSort<T>(this IEnumerable<T> items) where T : IComparable<T>
    {
        var input = new Stack<T>();
        foreach (var item in items)
        {
            input.Push(item);
        }

        var output = new Stack<T>();

        while (input.TryPeek(out var current))
        {
            input.Pop();
            while (output.TryPeek(out var top) && current.CompareTo(top) > 0)
            {
                input.Push(top); 
                output.Pop();
            }
            output.Push(current);
        }

        while (output.TryPop(out var popped))
        {
            yield return popped;
        }
    }
}