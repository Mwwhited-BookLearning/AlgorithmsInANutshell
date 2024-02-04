namespace SearchingAlgorithms.BinaryTrees.RedBlackTrees;

public class RedBlackNode<TIndex, TValue> :
    IComparable<RedBlackNode<TIndex, TValue>>,
    IComparable<TIndex>,
    IEquatable<NodeColors>,
    IEquatable<RedBlackNode<TIndex, TValue>>
    where TIndex : IComparable<TIndex>
{
    public const string NULL = "<nil>";

    public NodeColors Color { get; internal set; }
    public TIndex Index { get; internal set; }
    public TValue? Value { get; internal set; }

    public RedBlackNode<TIndex, TValue>? Parent { get; internal set; }
    public RedBlackNode<TIndex, TValue>? Lesser { get; internal set; }
    public RedBlackNode<TIndex, TValue>? Greater { get; internal set; }

    public int CompareTo(RedBlackNode<TIndex, TValue>? other) => other == null ? 0 : CompareTo(other.Index);
    public int CompareTo(TIndex? other) => other == null ? 0 : Index.CompareTo(other);
    public bool Equals(NodeColors other) => Color == other;
    public bool Equals(RedBlackNode<TIndex, TValue>? other) => other != null && Index.Equals(other.Index);
    public bool Equals(TIndex? other) => other != null && Index.CompareTo(Index) == 0;

    public override string ToString() => ToString(0);
    public string ToString(int depth) =>
        string.Join(Environment.NewLine,
            $"{Value} ({Index}) {Color}",
            new string('\t', depth) + $"L:{Lesser?.ToString(depth + 1) ?? NULL}",
            new string('\t', depth) + $"G:{Greater?.ToString(depth + 1) ?? NULL}"
        );
}
