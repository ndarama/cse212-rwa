using System.Collections;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Sum of squares from 1 to n
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case: if n <= 0, return 0
        if (n <= 0)
            return 0;
        
        // Recursive case: n^2 + sum of squares of (n-1)
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Generate permutations of given size
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: if word length equals size, add to results
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case: try each letter that hasn't been used yet
        for (int i = 0; i < letters.Length; i++)
        {
            // Create new string without the current letter
            string newLetters = letters.Remove(i, 1);
            // Recursively generate permutations with current letter added
            PermutationsChoose(results, newLetters, size, word + letters[i]);
        }
    }

    /// <summary>
    /// Problem 3: Count ways to climb stairs with memoization
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initialize memoization dictionary if null
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // Check if result is already memoized
        if (remember.ContainsKey(s))
            return remember[s];

        // Recursive case with memoization
        decimal ways = CountWaysToClimb(s - 1, remember) + 
                      CountWaysToClimb(s - 2, remember) + 
                      CountWaysToClimb(s - 3, remember);
        
        // Store result in memoization dictionary
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// Problem 4: Generate binary strings from pattern with wildcards
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Base case: empty pattern
        if (pattern.Length == 0)
        {
            results.Add("");
            return;
        }

        // Get first character and remaining pattern
        char first = pattern[0];
        string rest = pattern.Length > 1 ? pattern[1..] : "";

        // If first character is not wildcard
        if (first != '*')
        {
            List<string> subResults = new List<string>();
            WildcardBinary(rest, subResults);
            foreach (string subResult in subResults)
            {
                results.Add(first + subResult);
            }
        }
        // If first character is wildcard
        else
        {
            List<string> subResults = new List<string>();
            WildcardBinary(rest, subResults);
            // Add both 0 and 1 possibilities
            foreach (string subResult in subResults)
            {
                results.Add("0" + subResult);
                results.Add("1" + subResult);
            }
        }
    }

    /// <summary>
    /// Problem 5: Find all paths through maze
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize path if null
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // Add current position to path
        currPath.Add((x, y));

        // Base case: if at end, add path to results
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            return;
        }

        // Possible moves: right, down, left, up
        (int dx, int dy)[] directions = { (1, 0), (0, 1), (-1, 0), (0, -1) };

        // Try each direction
        foreach (var (dx, dy) in directions)
        {
            int newX = x + dx;
            int newY = y + dy;

            // If valid move, recursively explore
            if (maze.IsValidMove(currPath, newX, newY))
            {
                SolveMaze(results, maze, newX, newY, new List<ValueTuple<int, int>>(currPath));
            }
        }
    }
}