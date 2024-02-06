using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;

namespace SortingAlgorithms;

[TestClass]
public class InsertionSort
{
    public required TestContext TestContext { get; set; }

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
