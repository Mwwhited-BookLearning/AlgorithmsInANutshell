using System.Linq.Expressions;
using System.Security;
using System.Xml.Linq;

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

        if (_root == null)
        {
            _root = new() { Index = index, Value = value, Color = NodeColors.Black, Parent = null, };
            return;
        }
        var current = Find(index, true) ?? throw new NotSupportedException();
        current.Value = value;

        while (current?.Parent != null)
        {
            // The current node’s parent P is black, so requirement 3 holds.Requirement 4 holds also
            // according to the loop invariant.
            if (current.Parent.Equals(NodeColors.Black))
                return;

            // The parent P is red and the root. Because N is also red, requirement 3 is violated. But after
            // switching P’s color the tree is in RB-shape. The black height of the tree increases by 1.
            if (current.Parent.Parent == null)
            {
                current.Parent.Color = NodeColors.Black;
                return;
            }

            //parent is red and grandparent is !null
            //var direction = Direction(current);
            var uncle = Uncle(current);
            if (uncle == null || uncle.Equals(NodeColors.Black))
            {
                // Case_I5 (P red && U black && N inner grandchild of G):


                var n = Rotate(current);
                if (n.Parent == null)
                    _root = n;

                //var n2 = Rotate(current.Parent, Direction(current));

                //if (current.Parent == null)
                //    _root = current;
                //else if (current.Parent.Parent == null)
                //    _root = current.Parent;
                //else if (n2 != null && n2.Parent == null)
                //    _root = n2;
                //else if (n1 != null && n1.Parent == null)
                //    _root = n1;

                ////this aint right
                ////current = current.Parent;
                ////Rotate(current, Direction(current));

                ////TODO: there should be a second rotation here

                return;
            }
            else if (current?.Parent?.Equals(NodeColors.Red) ?? false && uncle.Equals(NodeColors.Red))
            {
                current.Parent.Color = NodeColors.Black;
                uncle.Color = NodeColors.Black;
                current.Parent.Parent.Color = NodeColors.Red;
                current = current.Parent.Parent;
            }
            else
            {
                current = current?.Parent;
            }
        }

        if (current?.Parent == null)
        {
            _root.Color = NodeColors.Black;
            _root = current;
        }

    }
    public void Remove(TIndex index)
    {
        var found = Find(index);
        if (found == null)
            return;

        //TODO: check balance

        throw new NotImplementedException();
    }

    public static RedBlackNode<TIndex, TValue>? Rotate(RedBlackNode<TIndex, TValue>? node) =>
        node == null ? null : Rotate(node, Direction(node));

    public static RedBlackNode<TIndex, TValue>? Rotate(RedBlackNode<TIndex, TValue>? node, RotationDirections direction)
    {
        if (node?.Parent == null)
            return node;

        if (node.Equals(NodeColors.Red) && )

        switch (direction)
        {
            case RotationDirections.Left:
            {
                //var current = node;
                //var parent = current.Parent;
                //var grandParent = current.Parent.Parent;
                //var right = node.Greater;
                //var left = node.Lesser;

                //switch (Direction(current))
                //{
                //    case RotationDirections.Left:
                //        parent.Lesser = right;
                //        break;
                //    case RotationDirections.Right:
                //        parent.Greater = right;
                //        break;
                //}

                //if (left != null)
                //    left.Greater = right?.Lesser;

                //if (right != null)
                //    right.Lesser = left;

                //parent.Parent = node;
                //node.Parent = grandParent

                //// current.Parent = node.Parent.Parent;

                break;
            }
            case RotationDirections.Right:
            {
                var current = node;
                var parent = current.Parent;
                var right = node.Greater;
                var left = node.Lesser;

                switch (Direction(current))
                {
                    case RotationDirections.Left:
                        parent.Greater = left;
                        break;
                    case RotationDirections.Right:
                        parent.Lesser = left;
                        break;
                }

                if (right != null)
                    right.Lesser = left;

                if (left != null)
                    left.Greater = right;

                break;
            }

            default:
            case RotationDirections.None:
                break;
        }
        return node;
    }

    public static RedBlackNode<TIndex, TValue>? Uncle(RedBlackNode<TIndex, TValue> node) =>
        node.Parent?.Parent switch
        {
            null => null,
            _ => node.Parent.Equals(node.Parent.Parent.Greater) ?
                node.Parent.Parent.Lesser :
                node.Parent.Parent.Greater,
        };

    public static RotationDirections Direction(RedBlackNode<TIndex, TValue> node) =>
          node.Parent?.Greater?.Equals(node) switch
          {
              null => RotationDirections.None,
              true => RotationDirections.Right,
              false => RotationDirections.Left,
          };

    public override string ToString() => _root?.ToString() ?? RedBlackNode<TIndex, TValue>.NULL;
}
