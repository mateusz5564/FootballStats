
namespace FootballStats.Entities
{
    public class Footballer : Person
    {
        public int Number { get; set; }
        public string Position { get; set; }
        public int Games { get; set; }
        public int Goals { get; set; }
        public int? CleanSheets { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Age} years old. #{Number}, {Position}, Games: {Games}, Goals: {Goals}{(CleanSheets != null ? ", Clean sheets: " + CleanSheets : "")}";
        }
    }
}
