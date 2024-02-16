using FootballStats.Data.Entities;

namespace FootballStats.Data.Repository
{
    public static class EventLogs
    {
        private const string _filename = "audit.txt";

        public static void Footballer_Added(object? sender, Footballer e)
        {
            var row = $"{GetTimestamp()}-{e.GetType().Name}Added-{e.FirstName} {e.LastName} {e.Position}";
            AddToFile(row);
        }

        public static void Footballer_Removed(object? sender, Footballer e)
        {
            var row = $"{GetTimestamp()}-{e.GetType().Name}Removed-{e.FirstName} {e.LastName} {e.Position}";
            AddToFile(row);
        }

        public static void Coach_Added(object? sender, Coach e)
        {
            var row = $"{GetTimestamp()}-{e.GetType().Name}Added-{e.FirstName} {e.LastName} {e.Licence}";
            AddToFile(row);
        }

        public static void Coach_Removed(object? sender, Coach e)
        {
            var row = $"{GetTimestamp()}-{e.GetType().Name}Removed-{e.FirstName} {e.LastName} {e.Licence}";
            AddToFile(row);
        }

        public static void AddToFile(string row)
        {
            using (var file = File.AppendText(_filename))
            {
                file.WriteLine(row);
            }
        }

        public static string GetTimestamp()
        {
            return DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fff");
        }
    }
}
