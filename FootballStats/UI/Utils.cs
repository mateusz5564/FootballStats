
using FootballStats.Data.Entities;
using FootballStats.Data.Repository;

namespace FootballStats.UI
{
    public static class Utils
    {
        public static string GetStringInput(string prompt)
        {
            Console.Write(prompt);
            string firstName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Provided string cannot be empty!");
            }

            return firstName;
        }

        public static int? GetIntInput(string prompt, bool optional = false)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                if (optional)
                {
                    return null;
                }
                else
                {
                    throw new ArgumentException("Input is required");
                }
            }

            if (!int.TryParse(input, out int intInput))
            {
                throw new ArgumentException("It's not an int value");
            }

            return intInput;
        }
        public static void PrintAllItems<T>(IRepository<T> repository) where T : class, IEntity
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
