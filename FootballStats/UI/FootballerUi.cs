using FootballStats.Data.Entities;
using FootballStats.Data.Repository;
using FootballStats.DataProviders;

namespace FootballStats.UI
{
    public class FootballerUi : IFootballerUi
    {
        private readonly IRepository<Footballer> _repository;
        private readonly IFootballersProvider _footballersProvider;

        public FootballerUi(IRepository<Footballer> repository, IFootballersProvider footballersProvider)
        {
            _repository = repository;
            _footballersProvider = footballersProvider;
        }

        public void AddFootballer()
        {
            Console.WriteLine("Add a new football player:");
            try
            {
                string firstName = Utils.GetStringInput("First name: ");
                string lastName = Utils.GetStringInput("Last name: ");
                int age = (int)Utils.GetIntInput("Age: ")!;
                int number = (int)Utils.GetIntInput("Number: ")!;
                string position = Utils.GetStringInput("Position: ");
                int games = (int)Utils.GetIntInput("Games: ")!;
                int goals = (int)Utils.GetIntInput("Goals: ")!;
                int? cleanSheets = Utils.GetIntInput("Clean sheets (enter to skip): ", true);

                var footballer = new Footballer { FirstName = firstName, LastName = lastName, Age = age, Number = number, Position = position, Games = games, Goals = goals };
                if (cleanSheets.HasValue)
                {
                    footballer.CleanSheets = cleanSheets;
                }
                _repository.Add(footballer);
                _repository.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void RemoveFootballer()
        {
            int id = (int)Utils.GetIntInput("Enter Id of a footballer that you want to remove: ")!;
            var footballer = _repository.GetById(id);
            if (footballer != null)
            {
                _repository.Remove(footballer);
                _repository.Save();
            }
        }

        public void SearchByFirstName()
        {
            string firstName = Utils.GetStringInput("First name: ");
            var result = _footballersProvider.GetByFirstName(firstName);
            Utils.PrintAllItems(result);
        }

        public void SearchByLastName()
        {
            string lastName = Utils.GetStringInput("Last name: ");
            var result = _footballersProvider.GetByLastName(lastName);
            Utils.PrintAllItems(result);
        }

        public void SearchByFullName()
        {
            string firstName = Utils.GetStringInput("First name: ");
            string lastName = Utils.GetStringInput("Last name: ");
            var result = _footballersProvider.GetByFullName(firstName, lastName);
            Utils.PrintAllItems(result);
        }

        public void SearchByAgeRange()
        {
            while (true)
            {
                try
                {
                    int? minAge = Utils.GetIntInput("Minimum age: ");
                    int? maxAge = Utils.GetIntInput("Maximum age: ");

                    if (minAge != null && maxAge != null)
                    {
                        var result = _footballersProvider.GetByAgeRange((int)minAge, (int)maxAge);
                        Utils.PrintAllItems(result);
                        break;
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void SearchByPosition()
        {
            string position = Utils.GetStringInput("Position: ");
            var result = _footballersProvider.GetByPosition(position);
            Utils.PrintAllItems(result);
        }
    }
}
