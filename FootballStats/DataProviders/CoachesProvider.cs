
using FootballStats.Data.Entities;
using FootballStats.Data.Repository;

namespace FootballStats.DataProviders
{
    public class CoachesProvider : ICoachesProvider
    {
        private readonly IRepository<Coach> _repository;

        public CoachesProvider(IRepository<Coach> repository)
        {
            _repository = repository;
        }

        public List<Coach> GetByFavoriteFormation(string formation)
        {
            return _repository.GetAll().Where(c => c.FavoriteFormation == formation).ToList();
        }

        public List<Coach> GetByFirstName(string firstName)
        {
            return _repository.GetAll().Where(c => c.FirstName.ToLower().Contains(firstName.ToLower())).ToList();
        }

        public List<Coach>GetByLastName(string lastName)
        {
            return _repository.GetAll().Where(c => c.LastName.ToLower().Contains(lastName.ToLower())).ToList();
        }

        public List<Coach> GetByFullName(string firstName, string lastName)
        {
            return _repository.GetAll().Where(f => f.FirstName.ToLower().Contains(firstName.ToLower()) && f.LastName.ToLower().Contains(lastName.ToLower())).ToList();
        }

        public List<Coach> GetByLicence(string licence)
        {
            return _repository.GetAll().Where(c => c.Licence.ToLower() == licence.ToLower()).ToList();
        }

        public List<Coach> GetCoachesOrderedByYearsOfExperience()
        {
            return _repository.GetAll().OrderByDescending(c => c.YearsOfExperience).ToList();
        }
    }
}
