using System.Collections;
using System.Collections.Generic;
using System.Linq; // for Cast<int>() in AsString()

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    /// <summary>
    /// Insert a new value into the BST.
    /// Creates the root if the tree is empty; otherwise delegates to Node.Insert.
    /// </summary>
    public void Insert(int value)
    {
        if (_root is null)
        {
            _root = new Node(value);
        }
        else
        {
            _root.Insert(value); // Node.Insert enforces "no duplicates"
        }
    }

    /// <summary>
    /// Check to see if the tree contains a certain value.
    /// </summary>
    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    /// <summary>
    /// Non-generic IEnumerable implementation delegates to the generic enumerator.
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Iterate forward (ascending) through the BST using in-order traversal:
    /// Left -> Node -> Right
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    private void TraverseForward(Node? node, List<int> values)
    {
        if (node is null) return;
        TraverseForward(node.Left, values);
        values.Add(node.Data);
        TraverseForward(node.Right, values);
    }

    /// <summary>
    /// Iterate backward (descending) through the BST:
    /// Right -> Node -> Left
    /// </summary>
    public IEnumerable Reverse()
    {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    private void TraverseBackward(Node? node, List<int> values)
    {
        // Problem 3: reverse in-order traversal
        if (node is null) return;
        TraverseBackward(node.Right, values); // larger values first
        values.Add(node.Data);
        TraverseBackward(node.Left, values);  // then smaller values
    }

    /// <summary>
    /// Get the height of the tree (0 if empty).
    /// </summary>
    public int GetHeight()
    {
        if (_root is null) return 0;
        return _root.GetHeight();
    }

    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}

public static class IntArrayExtensionMethods
{
    /// <summary>
    /// Helper used in the tests to pretty-print an IEnumerable of ints.
    /// </summary>
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
