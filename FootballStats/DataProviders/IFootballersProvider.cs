
using FootballStats.Data.Entities;

namespace FootballStats.DataProviders
{
    public interface IFootballersProvider
    {
        List<Footballer> GetByFirstName(string firstName);
        List<Footballer> GetByLastName(string lastName);
        List<Footballer> GetByFullName(string firstName, string lastName);
        List<Footballer> GetByAgeRange(int minAge, int maxAge);
        List<Footballer> GetByPosition(string position);
        List<Footballer> GetOrderdedByGoals();
        List<Footballer> GetOrderdedByGames();
        List<Footballer> GetOrderdedByCleanSheets();
    }
}
