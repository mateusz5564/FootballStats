
using FootballStats.Data.Entities;

namespace FootballStats.DataProviders
{
    public interface ICoachesProvider
    {
        List<Coach> GetByFirstName(string firstName);
        List<Coach> GetByLastName(string lastName);
        List<Coach> GetByFullName(string firstName, string lastName);
        List<Coach> GetByLicence(string licence);
        List<Coach> GetByFavoriteFormation(string formation);
        List<Coach> GetCoachesOrderedByYearsOfExperience();
    }
}
