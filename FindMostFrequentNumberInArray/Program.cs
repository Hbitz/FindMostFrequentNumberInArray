namespace FindMostFrequentNumberInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FindMostFrequentNumber(new int[] { 1, 3, 2, 3, 4, 1, 3, 2, 2, 2, 5 }); // 2
            FindMostFrequentNumber(new int[] { 7, 7, 5, 5, 1, 1, 1, 2, 2, 2 }); // 1
        }

        private static void FindMostFrequentNumber(int[] numbers)
        {
            // Skapa en dict med LINQ för att räkna förekomsten av siffrorna
            Dictionary<int, int> numberCount = numbers.GroupBy(n => n)
                                     .ToDictionary(g => g.Key, g => g.Count());

            // Hitta den mest förekommande siffran
            var mostFrequent = numberCount.OrderByDescending(kvp => kvp.Value) // Descending för att få största numrerna först
                                          .ThenBy(kvp => kvp.Key) // Om det finns flera antal siffror som förekommer samma antal gåner, välj den minsta
                                          .First();

            Console.WriteLine($"The most frequent number is {mostFrequent.Key} which was found {mostFrequent.Value} times.");
        }
    }
}
