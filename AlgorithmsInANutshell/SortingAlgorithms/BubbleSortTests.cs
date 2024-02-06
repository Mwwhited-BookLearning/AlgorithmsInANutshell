using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SortingAlgorithms;

[TestClass]
public class BubbleSortTests
{
    public required TestContext TestContext { get; set; }

    [TestMethod]
    public void BubbleSortTest()
    {
        var items = new[] { 1, 3, 7, 4, 2 };
        TestContext.WriteLine(string.Join(", ", items));
        BubbleSort(items);
        TestContext.WriteLine(string.Join(", ", items));

        CollectionAssert.AreEquivalent(new[] { 1, 2, 3, 4, 7 }, items);
    }

    // https://frontendmasters.com/courses/algorithms/implementing-bubble-sort/
    // https://en.wikipedia.org/wiki/Bubble_sort
    public static T[] BubbleSort<T>(T[] array) where T : IComparable<T>
    {
        for (var j = array.Length - 1; j > 1; j--)
            for (var i = 0; i < j; i++)
                if (array[i].CompareTo(array[i + 1]) > 0)
                    (array[i + 1], array[i]) = (array[i], array[i + 1]);
        return array;
    }
}

