using System;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Problem 1: Insert unique values only.
    /// Recursively places the value; if value == Data, do nothing (no duplicates).
    /// </summary>
    public void Insert(int value)
    {
        // Enforce set semantics: ignore duplicates
        if (value == Data) return;

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else // value > Data
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    /// <summary>
    /// Problem 2: Contains — standard BST search (recursive).
    /// </summary>
    public bool Contains(int value)
    {
        if (value == Data) return true;
        if (value < Data)  return Left?.Contains(value)  ?? false;
        else               return Right?.Contains(value) ?? false;
    }

    /// <summary>
    /// Problem 4: GetHeight — height = 1 + max(leftHeight, rightHeight).
    /// Empty subtree has height 0; single node has height 1.
    /// </summary>
    public int GetHeight()
    {
        int leftH  = Left?.GetHeight()  ?? 0;
        int rightH = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftH, rightH);
    }
}
