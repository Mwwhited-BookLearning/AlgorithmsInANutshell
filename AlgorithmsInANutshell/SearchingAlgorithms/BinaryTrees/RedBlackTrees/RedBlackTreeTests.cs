using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchingAlgorithms.BinaryTrees.RedBlackTrees;

[TestClass]
public class RedBlackTreeTests
{
    public required TestContext TestContext { get; set; }

    [TestMethod]
    public void Inserts()
    {
        var tree = new RedBlackTree<int, string>();

        tree[26] = "twenty-six";
        TestContext.WriteLine(new string('=',10) + 26);
        TestContext.WriteLine(tree.ToString());

        tree[43] = "fourty-three";
        TestContext.WriteLine(new string('=', 10) + 43);
        TestContext.WriteLine(tree.ToString());

        tree[17] = "seventeen";
        TestContext.WriteLine(new string('=', 10) + 17);
        TestContext.WriteLine(tree.ToString());

        tree[25] = "twenty-five";
        TestContext.WriteLine(new string('=', 10) + 25);
        TestContext.WriteLine(tree.ToString());

        tree[15] = "fifteen";
        TestContext.WriteLine(new string('=', 10) + 15);
        TestContext.WriteLine(tree.ToString());

        tree[16] = "sixteen";
        TestContext.WriteLine(new string('=', 10) + 16);
        TestContext.WriteLine(tree.ToString());

        tree[13] = "thirteen";
        TestContext.WriteLine(new string('=', 10) + 13);
        TestContext.WriteLine(tree.ToString());

        tree[14] = "fourteen";
        TestContext.WriteLine(new string('=', 10) + 14);
        TestContext.WriteLine(tree.ToString());

        //TestContext.WriteLine(tree[43]);

        //TestContext.WriteLine(tree[5] ?? "nope");

        //TestContext.WriteLine(tree.ToString());


        Assert.AreEqual(tree[26], "twenty-six");
        Assert.AreEqual(tree[43], "fourty-three");
        Assert.AreEqual(tree[17], "seventeen");
        Assert.AreEqual(tree[25], "twenty-five");
        Assert.AreEqual(tree[15], "fifteen");
        Assert.AreEqual(tree[16], "sixteen");
        Assert.AreEqual(tree[13], "thirteen");
        Assert.AreEqual(tree[14], "fourteen");

    }
}
