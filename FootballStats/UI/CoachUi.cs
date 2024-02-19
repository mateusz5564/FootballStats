
using FootballStats.Data.Entities;
using FootballStats.Data.Repository;
using FootballStats.DataProviders;

namespace FootballStats.UI
{
    public class CoachUi : ICoachUi
    {
        private readonly IRepository<Coach> _repository;
        private readonly ICoachesProvider _coachesProvider;

        public CoachUi(IRepository<Coach> repository, ICoachesProvider coachesProvider)
        {
            _repository = repository;
            _coachesProvider = coachesProvider;
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

        public void SearchByFirstName()
        {
            string firstName = Utils.GetStringInput("First name: ");
            var result = _coachesProvider.GetByFirstName(firstName);
            Utils.PrintAllItems(result);
        }

        public void SearchByLastName()
        {
            string lastName = Utils.GetStringInput("Last name: ");
            var result = _coachesProvider.GetByLastName(lastName);
            Utils.PrintAllItems(result);
        }

        public void SearchByFullName()
        {
            string firstName = Utils.GetStringInput("First name: ");
            string lastName = Utils.GetStringInput("Last name: ");
            var result = _coachesProvider.GetByFullName(firstName, lastName);
            Utils.PrintAllItems(result);
        }

        public void SearchByFavoriteFormation()
        {
            string formation = Utils.GetStringInput("Formation: ");
            var result = _coachesProvider.GetByFavoriteFormation(formation);
            Utils.PrintAllItems(result);
        }

        public void SearchByLicence()
        {
            string licence = Utils.GetStringInput("Licence: ");
            var result = _coachesProvider.GetByLicence(licence);
            Utils.PrintAllItems(result);
        }
    }
}
