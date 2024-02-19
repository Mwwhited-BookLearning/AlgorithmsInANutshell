//using System.Collections;
//using System.Security.Cryptography;
//using System.Xml.Linq;

//namespace SearchingAlgorithms.BinaryTrees.BTrees;

//public class BTree<T>(
//    int degree
//    ) : IEnumerable<T> where T : IComparable<T>
//{
//    internal BTreeNode<T> _Root = new BTreeNode<T>(degree);

//    public void Search(T key) => _Root?.Search(key);


//    public void Insert(T key)
//    {
//        if (_Root.Count == (2 * degree) - 1)
//        {
//            BTreeNode<T> newRoot = new BTreeNode<T>(degree);
//            newRoot.Children[0] = _Root;
//            SplitChild(newRoot, 0);
//            _Root = newRoot;
//        }
//        InsertNonFull(_Root, key);
//    }

//    private void InsertNonFull(BTreeNode<T> node, T key)
//    {
//        int i = node.Count - 1;
//        if (node.IsLeaf)
//        {
//            while (i >= 0 && key.CompareTo(node.Keys[i]) < 0)
//            {
//                node.Keys[i + 1] = node.Keys[i];
//                i--;
//            }
//            node.Keys[i + 1] = key;
//        }
//        else
//        {
//            while (i >= 0 && key.CompareTo(node.Keys[i]) < 0)
//            {
//                i--;
//            }
//            i++;
//            if (node.Children[i].Count == (2 * degree) - 1)
//            {
//                SplitChild(node, i);
//                if (key.CompareTo(node.Keys[i]) > 0)
//                {
//                    i++;
//                }
//            }
//            InsertNonFull(node.Children[i], key);
//        }
//    }

//    private void SplitChild(BTreeNode<T> parent, int index)
//    {
//        var child = parent.Children[index];
//        var newChild = new BTreeNode<T>(degree);

//        for (int j = 0; j < degree - 1; j++)
//        {
//            newChild.Keys[j] = child.Keys[j + degree];
//        }

//        if (!child.IsLeaf)
//        {
//            for (int j = 0; j < degree; j++)
//            {
//                newChild.Children[j] = child.Children[j + degree];
//            }
//        }

//        for (int j = parent.Count; j > index; j--)
//        {
//            parent.Children[j + 1] = parent.Children[j];
//        }

//        parent.Children[index + 1] = newChild;

//        for (int j = parent.Count - 1; j >= index; j--)
//        {
//            parent.Keys[j + 1] = parent.Keys[j];
//        }

//        parent.Keys[index] = child.Keys[degree - 1];
//    }

//    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
//    public IEnumerator<T> GetEnumerator() => _Root.GetEnumerator();
//}

//public class BTreeNode<T>(
//    int degree
//    ) : IEnumerable<T> where T : struct, IComparable<T>
//{
//    internal readonly T?[] Keys = new T?[2 * degree - 1];
//    internal readonly BTreeNode<T>[] Children = new BTreeNode<T>[2 * degree];
//    internal int Count => Children.Count(c => c != null);
//    internal bool IsLeaf => Children.Any(c => c != null);

//    //IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
//    //public IEnumerator<T> GetEnumerator()
//    //{
//    //    foreach (var child in Keys.Where(c => c != null))
//    //    {
//    //        foreach(var inner in this.)
//    //        {
//    //            yield return inner;
//    //        }

//    //        yield return child;
//    //    }
//    //}

//    //public IEnumerable<T> Traverse()
//    //{
//    //    foreach (var child in Children)
//    //    {

//    //    }

//    //    //    InOrderTraversal<T>(BTreeNode<T> node) where T : IComparable<T>
//    //    //    {
//    //    //        if (node != null)
//    //    //        {
//    //    //            int i;
//    //    //            for (i = 0; i<node.Count; i++)
//    //    //            {
//    //    //                InOrderTraversal(node.Children[i]);
//    //    //    Console.Write(node.Keys[i] + " ");
//    //    //            }
//    //    //InOrderTraversal(node.Children[i]);
//    //    //        }
//    //    //    }
//    //}

//    public void Search(T key)
//    {
//    }

//}
