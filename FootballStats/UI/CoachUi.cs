
using FootballStats.Data.Entities;
using FootballStats.Data.Repository;

namespace FootballStats.UI
{
    public class CoachUi
    {
        private readonly IRepository<Coach> _repository;

        public CoachUi(IRepository<Coach> repository)
        {
            _repository = repository;
        }

        public void AddCoach()
        {
            Console.WriteLine("Add a new coach:");
            try
            {
                string firstName = Utils.GetStringInput("First name: ");
                string lastName = Utils.GetStringInput("Last name: ");
                int age = (int)Utils.GetIntInput("Age: ")!;
                string licence = Utils.GetStringInput("Licence: ");
                int yearsOfExperience = (int)Utils.GetIntInput("Years of experience: ")!;
                string favoriteFormation = Utils.GetStringInput("Favorite formation: ");

                var coach = new Coach { FirstName = firstName, LastName = lastName, Age = age, Licence = licence, YearsOfExperience = yearsOfExperience, FavoriteFormation = favoriteFormation };

                _repository.Add(coach);
                _repository.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void RemoveCoach()
        {
            int id = (int)Utils.GetIntInput("Enter Id of a coach that you want to remove: ")!;
            var coach = _repository.GetById(id);
            if (coach != null)
            {
                _repository.Remove(coach);
                _repository.Save();
            }
        }
    }
}
