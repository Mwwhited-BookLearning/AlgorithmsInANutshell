using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace SortingAlgorithms;

[TestClass]
public class InsertionSort
{
    public TestContext TestContext { get; set; }

    [TestMethod]
    public void InsertionSortTest()
    {
        var rand = new Random();
        var set = Enumerable.Range(0, 100).OrderByDescending(i=>i).ToList(); //.OrderBy(i=>rand.Next()).ToList();

        var items = set; // 1.Set(3, 2, 5, 4);
        this.TestContext.WriteLine("Set: " + string.Join(';', items));

        var sw = new Stopwatch();

        sw.Reset();
        for (var x = 0; x < 100; x++)
        {
            sw.Start();
            this.TestContext.WriteLine("Order: " + string.Join(';', items.Order()));
            sw.Stop();
        }
        var ordered = sw.ElapsedTicks;

        sw.Reset();
        for (var x = 0; x < 100; x++)
        {
            sw.Start();
            this.TestContext.WriteLine("Sort: " + string.Join(';', items.StackSort()));
            sw.Stop();
        }
        var sorted = sw.ElapsedTicks;

        this.TestContext.WriteLine($"{ordered} - {sorted}");

    }

}

public static class SetExtensions
{
    public static IEnumerable<T> Set<T>(this T first, params T[] items) => new[] { first }.Concat(items);

    public static IEnumerable<T> StackSort<T>(this IEnumerable<T> items) where T : IComparable<T>
    {
        var input = new Stack<T>();
        foreach (var item in items)
            input.Push(item);

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
            yield return popped;
    }
}