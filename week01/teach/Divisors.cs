public static class Divisors {
    /// <summary>
    /// Entry point for the Divisors class
    /// </summary>
    public static void Run() {
        List<int> list = FindDivisors(12);
        Console.WriteLine("<List>{" + string.Join(", ", list) + "}"); // <List>{1, 2, 3, 4, 6,}
        List<int> list1 = FindDivisors(17);
        Console.WriteLine("<List>{" + string.Join(", ", list1) + "}"); // <List>{1}
    }

    /// <summary>
    /// Create a list of all divisors for a number including 1
    /// and excluding the number itself. Modulo will be used
    /// to test divisibility.
    /// </summary>
    /// <param name="number">The number to find the divisor</param>
    /// <returns>List of divisors</returns>
    private static List<int> FindDivisors(int number) {
        List<int> results = new();

        for (int i = 1; i < number; i++)
        {
            if (number % i == 0)
            {
                results.Add(i);
            }
            
        }
        return results;
    }
}