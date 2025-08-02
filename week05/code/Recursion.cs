using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class Recursion
{
    // Problem 1: SumSquaresRecursive
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    // Problem 2: PermutationsChoose
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }
        for (int i = 0; i < letters.Length; i++)
        {
            char c = letters[i];
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + c);
        }
    }

    // Problem 3: CountWaysToClimb
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        if (remember.TryGetValue(s, out var cached))
            return cached;

        decimal ways = CountWaysToClimb(s - 1, remember)
                     + CountWaysToClimb(s - 2, remember)
                     + CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    // Problem 4: WildcardBinary
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int idx = pattern.IndexOf('*');
        if (idx < 0)
        {
            results.Add(pattern);
            return;
        }
        // Recurse with '0'
        string with0 = pattern.Substring(0, idx) + '0' + pattern.Substring(idx + 1);
        WildcardBinary(with0, results);
        // Recurse with '1'
        string with1 = pattern.Substring(0, idx) + '1' + pattern.Substring(idx + 1);
        WildcardBinary(with1, results);
    }

    // Problem 5: SolveMaze
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        int n = maze.Maze.Count;

        // Check out of bounds, wall, or visited
        if (x < 0 || y < 0 || x >= n || y >= n
            || maze.Maze[y][x] == '0'
            || currPath.Contains((x, y)))
        {
            return;
        }

        currPath.Add((x, y));

        if (maze.Maze[y][x] == '2')
        {
            // Found the end; record path
            results.Add(string.Join("→", currPath.Select(p => $"({p.Item1},{p.Item2})")));
        }
        else
        {
            // Explore all four directions
            SolveMaze(results, maze, x + 1, y, currPath);
            SolveMaze(results, maze, x - 1, y, currPath);
            SolveMaze(results, maze, x, y + 1, currPath);
            SolveMaze(results, maze, x, y - 1, currPath);
        }

        // Backtrack
        currPath.RemoveAt(currPath.Count - 1);
    }
}
