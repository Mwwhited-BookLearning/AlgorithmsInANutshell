namespace SearchingAlgorithms.BinaryTrees.RedBlackTrees;

public class RedBlackNode<TIndex, TValue> where TIndex : IComparable<TIndex>
{
    public const string NULL = "<null>";

    public bool IsRed { get; internal set; }
    public TIndex Index { get; internal set; }
    public TValue? Value { get; set; }

    public RedBlackNode<TIndex, TValue>? Parent { get; internal set; }
    public RedBlackNode<TIndex, TValue>? Lesser { get; internal set; }
    public RedBlackNode<TIndex, TValue>? Greater { get; internal set; }

    internal static RedBlackNode<TIndex, TValue> RotateLeft(RedBlackNode<TIndex, TValue> node)
    {
        var greater = node.Greater ??= new();
        var lesser = node.Lesser ??= new();
        greater.Lesser = node;
        node.Greater = lesser;
        node.Lesser = greater;
        lesser.Parent = node;

        //if (greater.Lesser != null && greater.Lesser.Value == null)
        //    greater.Lesser = null;
        //if (greater.Greater != null && greater.Greater.Value == null)
        //    greater.Greater = null;

        return greater;
    }
    internal static RedBlackNode<TIndex, TValue> RotateRight(RedBlackNode<TIndex, TValue> node)
    {
        var lesser = node.Lesser ??= new();
        var greater = node.Greater ??= new();
        lesser.Greater = node;
        node.Greater = node;
        node.Lesser = greater;
        node.Parent = lesser;

        //if (lesser.Lesser != null && lesser.Lesser.Value == null)
        //    lesser.Lesser = null;
        //if (lesser.Greater != null && lesser.Greater.Value == null)
        //    lesser.Greater = null;

        return lesser;
    }

    public override string ToString() => ToString(0);
    public string ToString(int depth) =>
        string.Join(Environment.NewLine,
            $"{Value} ({Index}) {(IsRed ? "R" : "B")}",
            new string('\t', depth) + $"L:{Lesser?.ToString(depth + 1) ?? NULL}",
            new string('\t', depth) + $"G:{Greater?.ToString(depth + 1) ?? NULL}"
        );
}
