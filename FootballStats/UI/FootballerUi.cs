
using FootballStats.Data.Entities;
using FootballStats.Data.Repository;

namespace FootballStats.UI
{
    public class FootballerUi
    {
        private readonly IRepository<Footballer> _repository;

        public FootballerUi(IRepository<Footballer> repository)
        {
            _repository = repository;
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
    }
}
