using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// Returns an array containing the first 'count' multiples of 'start'
    /// </summary>
    /// <param name="start">The number whose multiples are generated</param>
    /// <param name="count">The number of multiples to generate</param>
    /// <returns>Array of multiples</returns>
    public static double[] MultiplesOf(double start, int count)
    {
        // Step 1: Create a result array of length 'count'
        double[] result = new double[count];

        // Step 2: Loop over indices from 0 to count - 1
        for (int i = 0; i < count; i++)
        {
            // Step 3: Compute the multiple: start * (i + 1)
            result[i] = start * (i + 1);
        }

        // Step 4: Return the populated array
        return result;
    }

    /// <summary>
    /// Rotate the 'data' list to the right by 'amount'.
    /// For example: data {1,2,3,4,5,6,7,8,9}, amount=3 => {7,8,9,1,2,3,4,5,6}
    /// </summary>
    /// <param name="data">The list to rotate (modified in place)</param>
    /// <param name="amount">Number of positions to rotate right (1 to data.Count)</param>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Validate inputs: do nothing if data is null/empty or amount is out of range.
        // 2. (Optional) Normalize amount using modulo in case amount > data.Count.
        // 3. Slice the list into two parts:
        //    a) endPart: the last 'amount' elements
        //    b) startPart: the first 'data.Count - amount' elements
        // 4. Clear the original list
        // 5. Add endPart then startPart back into 'data'
        // 6. For testing use dotnet test "code test succeded"

        // Step 1: Input validation
        if (data == null || data.Count == 0 || amount <= 0 || amount > data.Count)
            return;

        // Step 2: Normalize amount
        amount = amount % data.Count;

        // Step 3a: Extract the last 'amount' elements
        List<int> endPart = data.GetRange(data.Count - amount, amount);
        // Step 3b: Extract the remaining front portion
        List<int> startPart = data.GetRange(0, data.Count - amount);

        // Step 4: Clear original list
        data.Clear();

        // Step 5: Reassemble: add rotated tail, then original head
        data.AddRange(endPart);
        data.AddRange(startPart);
    }
}
