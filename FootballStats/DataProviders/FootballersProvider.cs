
using FootballStats.Data.Entities;
using FootballStats.Data.Repository;

namespace FootballStats.DataProviders
{
    public class FootballersProvider : IFootballersProvider
    {
        private readonly IRepository<Footballer> _repository;

        public FootballersProvider(IRepository<Footballer> repository)
        {
            _repository = repository;
        }

        public List<Footballer> GetByFirstName(string firstName)
        {
            return _repository.GetAll().Where(f => f.FirstName.ToLower().Contains(firstName.ToLower())).ToList();
        }
        public List<Footballer> GetByLastName(string lastName)
        {
            return _repository.GetAll().Where(f => f.LastName.ToLower().Contains(lastName.ToLower())).ToList();
        }

        public List<Footballer> GetByFullName(string firstName, string lastName)
        {
            return _repository.GetAll().Where(f => f.FirstName.ToLower().Contains(firstName.ToLower()) && f.LastName.ToLower().Contains(lastName.ToLower())).ToList();
        }

        public List<Footballer> GetByAgeRange(int minAge, int maxAge)
        {
            if (minAge > maxAge) throw new ArgumentException("Invalid range, min age cannot be greater than max age!");
            if (minAge <= 0) throw new ArgumentException("Min age must be greater than 0!");
            if (maxAge >= 140) throw new ArgumentException("Max age is too high!");

            return _repository.GetAll().Where(f => f.Age >= minAge && f.Age <= maxAge).ToList();
        }

        public List<Footballer> GetByPosition(string position)
        {
            return _repository.GetAll().Where(f => f.Position.ToLower() == position.ToLower()).ToList();
        }

        public List<Footballer> GetOrderdedByCleanSheets()
        {
            return _repository.GetAll().Where(f => f.Position.ToLower() == "goalkeeper").OrderBy(f => f.CleanSheets).ToList();
        }

        public List<Footballer> GetOrderdedByGames()
        {
            return _repository.GetAll().OrderByDescending(f => f.Games).ToList();
        }

        public List<Footballer> GetOrderdedByGoals()
        {
            return _repository.GetAll().OrderByDescending(f => f.Goals).ToList();
        }
    }
}
