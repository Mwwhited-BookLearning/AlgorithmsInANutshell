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
        tree[43] = "fourty-three";
        tree[17] = "seventeen";
        tree[25] = "twenty-five";
        //tree[15] = "fifteen";
        //tree[16] = "sixteen";
        //tree[13] = "thirteen";
        //tree[14] = "fourteen";

        TestContext.WriteLine(tree.ToString());

        //TestContext.WriteLine(tree[43]);

        //TestContext.WriteLine(tree[5] ?? "nope");

        //TestContext.WriteLine(tree.ToString());
    }
}
