namespace FindMostFrequentNumberInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FindMostFrequentNumber(new int[] { 1, 3, 2, 3, 4, 1, 3, 2, 2, 2, 5 }); // 2
            FindMostFrequentNumber(new int[] { 7, 7, 5, 5, 1, 1, 1, 2, 2, 2 }); // 1
            FindMostFrequentNumber(new int[] { 7, 7, 5, 5, 1, 1, 1, 2, 2, 2, -1, -1, -1, -1, -1, -4, -4, -4, -4, -4, -5 }); // -4
        }

        private static void FindMostFrequentNumber(int[] numbers)
        {            
            // Create a dict with LINQ to count frequency of numbers.
            Dictionary<int, int> numberCount = numbers.GroupBy(n => n)
                                     .ToDictionary(g => g.Key, g => g.Count());

            // Find the most frequest number
            var mostFrequent = numberCount.OrderByDescending(kvp => kvp.Value) // Descending to get the most frequest numbers first
                                          .ThenBy(kvp => kvp.Key) // If there are multiple numbers that appears the same number of times, choose the smallest.
                                          .First();

            Console.WriteLine($"The most frequent number is {mostFrequent.Key} which was found {mostFrequent.Value} times.");
        }
    }
}
