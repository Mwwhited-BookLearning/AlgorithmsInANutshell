using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace SortingAlgorithms;

[TestClass]
public class SortTests
{
    public const int TheBigSort = 100000;

    public required TestContext TestContext { get; set; }

    [TestMethod]
    public void BclListSortTest()
    {
        var rand = new Random(0);
        var items = Enumerable.Range(0, TheBigSort).Shuffle(rand).ToArray();

        TestContext.WriteLine(string.Join(", ", items.Take(10)));
        Array.Sort(items);
        TestContext.WriteLine(string.Join(", ", items.Take(10)));

        var copy = new int[TheBigSort];
        Array.Copy(items, copy, items.Length);
        Array.Sort(copy);

        CollectionAssert.AreEqual(copy, items);
    }



    [TestMethod]
    public void BubbleSortTest()
    {
        var items = new[] { 5, 3, 7, 4, 2 };
        TestContext.WriteLine(string.Join(", ", items));
        BubbleSort(items);
        TestContext.WriteLine(string.Join(", ", items));

        CollectionAssert.AreEqual(new[] { 2, 3, 4, 5, 7 }, items);
    }


    [TestMethod, Ignore]
    public void BubbleSortStupidBigTest()
    {
        var rand = new Random(0);

        var items = Enumerable.Range(0, TheBigSort).Shuffle(rand).ToArray();

        TestContext.WriteLine(string.Join(", ", items.Take(10)));
        BubbleSort(items);
        TestContext.WriteLine(string.Join(", ", items.Take(10)));

        //CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 7 }, items);
    }

    // https://frontendmasters.com/courses/algorithms/implementing-bubble-sort/
    // https://en.wikipedia.org/wiki/Bubble_sort
    public static int[] BubbleSort(int[] array)
    {
        for (var j = array.Length - 1; j > 0; j--)
        {
            for (var i = 0; i < j; i++)
            {

                if (array[i] > array[i + 1])
                {
                    // Console.WriteLine($"b{j}-{i}:  [{string.Join(", ", array)}]");
                    (array[i + 1], array[i]) = (array[i], array[i + 1]);
                    // Console.WriteLine($"a{j}-{i}:  [{string.Join(", ", array)}]");
                }

            }
            Console.WriteLine($"{j}:  [{string.Join(", ", array)}]");
        }
        return array;
    }

    [TestMethod]
    public void TreeSortTest()
    {
        var items = new[] { 5, 1, 3, 7, 4, 2 };
        TestContext.WriteLine(string.Join(", ", items));
        TreeSort(items);
        TestContext.WriteLine(string.Join(", ", items));

        CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 7 }, items);
    }


    [TestMethod]
    public void TreeSortStupidBigTest()
    {
        var rand = new Random(0);

        var items = Enumerable.Range(0, TheBigSort).Shuffle(rand).ToArray();

        TestContext.WriteLine(string.Join(", ", items.Take(10)));
        TreeSort(items);
        TestContext.WriteLine(string.Join(", ", items.Take(10)));

        var copy = new int[TheBigSort];
        Array.Copy(items,copy, items.Length);
        Array.Sort(copy);

        CollectionAssert.AreEqual(copy, items);
    }

    public static int[] TreeSort(int[] array)
    {
        if (array.Length == 0)
            return array;

        var tree = new Node { Value = array[0] };
        for (var i = 1; i < array.Length; i++)
            tree = tree.Add(array[i]);

        Console.WriteLine(tree);

        tree.CopyTo(array);

        return array;
    }

    private class Node
    {
        public int Value { get; init; }

        public Node? Less { get; private set; }
        public Node? Greater { get; private set; }

        public Node Add(int value) => Add(new Node { Value = value });
        public Node Add(Node other)
        {
            if (other.Value > Value)
            {
                if (Greater == null)
                    Greater = other;
                else
                {
                    _ = Greater.Add(other);
                }
            }
            else
            {
                if (Less == null)
                    Less = other;
                else
                {
                 
                    _ = Less.Add(other);
                }
            }


            return this;
        }

        public void CopyTo(int[] items)
        {
            var index = 0;
            CopyTo(items, ref index);
        }

        private void CopyTo(int[] items, ref int index)
        {
            if (Less != null)
            {
                Less.CopyTo(items, ref index);
            }

            items[index] = Value;
            index++;

            if (Greater != null)
            {
                Greater.CopyTo(items, ref index);
            }
        }

    }
}
