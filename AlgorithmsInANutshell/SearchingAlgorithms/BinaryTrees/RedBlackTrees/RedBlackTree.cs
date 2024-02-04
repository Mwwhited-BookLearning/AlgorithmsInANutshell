namespace SearchingAlgorithms.BinaryTrees.RedBlackTrees;

public class RedBlackTree<TIndex, TValue> where TIndex : IComparable<TIndex>
{
    private RedBlackNode<TIndex, TValue>? _root;

    public TValue? this[TIndex index]
    {
        get => Search(index);
        set
        {
            if (value == null)
            {
                Remove(index);
            }
            else
            {
                Insert(index, value);
            }
        }
    }

    public TValue? Search(TIndex index)
    {
        var found = Find(index, false);
        if (found == null)
            return default;
        return found.Value;
    }
    public RedBlackNode<TIndex, TValue>? Find(TIndex index) => Find(index, false);
    private RedBlackNode<TIndex, TValue>? Find(TIndex index, bool createMissing)
    {
        RedBlackNode<TIndex, TValue>? Create(RedBlackNode<TIndex, TValue>? parent) =>
             (createMissing ? new() { Index = index, Color = NodeColors.Red, Parent = parent, } : null);

        var current = _root ??= Create(null);
        while (current != null)
        {
            var diff = index.CompareTo(current.Index);
            if (diff == 0)
                return current;
            else if (diff < 0)
                current = current.Lesser ??= Create(current);
            else if (diff > 0)
                current = current.Greater ??= Create(current);
        }
        return current;
    }
    public void Insert(TIndex index, TValue? value)
    {
        //1: do binary tree insertion
        if (value == null)
            Remove(index);
        _root ??= new() { Index = index, Value = value, Color = NodeColors.Black, Parent = null, };
        var found = Find(index, true) ?? throw new NotSupportedException();
        found.Value = value;
        RebalanceTree(found);
    }
    public void Remove(TIndex index)
    {
        var found = Find(index);
        if (found == null)
            return;

        //TODO: check balance

        RebalanceTree(found);

        throw new NotImplementedException();
    }
    private void RebalanceTree(RedBlackNode<TIndex, TValue>? found)
    {
        while (found != null)
        {
            //2: if at root ensure color is black
            if (found.Parent == null)
            {
                _root = found;
                _root.Color = NodeColors.Black;
                return;
            }

            //3:Do the following if the color of x’s parent is not BLACK and x is not the root. 
            var parentDifference = found.Parent.Index.CompareTo(found.Index) > 0;
            var uncle = (parentDifference ? found.Parent.Greater : found.Parent.Lesser) ?? new() { Color = NodeColors.None, };
            //  a) If x’s uncle is RED(Grandparent must have been black from property 4)
            if (uncle.Color == NodeColors.Red)
            {
                //      (i)Change the colour of parent and uncle as BLACK.
                uncle.Color = NodeColors.Black;
                found.Parent.Color = NodeColors.Black;
                //      (ii)Colour of a grandparent as RED.
                if (found.Parent.Parent != null)
                    found.Parent.Parent.Color = NodeColors.Red;
                //      (iii)Change x = x’s grandparent, repeat steps 2 and 3 for new x.
                found = found.Parent.Parent;
            }
            //  b) If x’s uncle is BLACK, then there can be four configurations for x, x’s parent(p) and x’s
            //      grandparent(g)(This is similar to AVL Tree)
            else
            {
                var x = found;
                var p = found.Parent;
                var g = found.Parent.Parent;
                if (uncle.Color == NodeColors.Black && found.Color == NodeColors.Red &&  p.Color == NodeColors.Red)
                {

                    var pd = p.CompareTo(x);
                    var gd = g?.CompareTo(p);

                    //      (i) Left Left Case(p is left child of g and x is left child of p)
                    if (pd < 0 && gd < 0)
                    {
                        p = RedBlackNode<TIndex, TValue>.RotateLeft(p);
                        g = RedBlackNode<TIndex, TValue>.RotateLeft(p);
                    }
                    //      (ii) Left Right Case(p is left child of g and x is the right child of p)
                    else if (pd < 0 && gd > 0)
                    {
                        p = RedBlackNode<TIndex, TValue>.RotateLeft(p);
                        g = RedBlackNode<TIndex, TValue>.RotateRight(p);
                    }
                    //      (iii) Right Right Case(Mirror of case i) 
                    else if (pd > 0 && gd > 0)
                    {
                        p = RedBlackNode<TIndex, TValue>.RotateRight(p);
                        g = RedBlackNode<TIndex, TValue>.RotateRight(p);
                    }
                    //      (iv)Right Left Case(Mirror of case ii)
                    else if (pd > 0 && gd < 0)
                    {
                        p = RedBlackNode<TIndex, TValue>.RotateRight(p);
                        g = RedBlackNode<TIndex, TValue>.RotateLeft(p);
                    }
                }

                found = found.Parent;
            }
        }
    }

    public override string ToString() => _root?.ToString() ?? RedBlackNode<TIndex, TValue>.NULL;
}
