using FootballStats.Data.Entities;
using FootballStats.Data.Repository;
using FootballStats.DataProviders;
using FootballStats.UI;

namespace FootballStats
{
    public class App : IApp
    {
        private readonly IRepository<Footballer> _footballerRepo;
        private readonly IRepository<Coach> _coachRepo;
        private readonly IFootballerUi _footballerUi;
        private readonly ICoachUi _coachUi;
        private readonly IFootballersProvider _footballersProvider;
        private readonly ICoachesProvider _coachesProvider;

        public App(IRepository<Footballer> footballerRepo, IRepository<Coach> coachRepo, IFootballerUi footballerUi, ICoachUi coachUi, IFootballersProvider footballersProvider, ICoachesProvider coachesProvider)
        {
            _footballerRepo = footballerRepo;
            _coachRepo = coachRepo;
            _footballerUi = footballerUi;
            _coachUi = coachUi;
            _footballersProvider = footballersProvider;
            _coachesProvider = coachesProvider;
        }

        public void Run()
        {
            _footballerRepo.ItemAdded += EventLogs.Footballer_Added;
            _footballerRepo.ItemRemoved += EventLogs.Footballer_Removed;
            _coachRepo.ItemAdded += EventLogs.Coach_Added;
            _coachRepo.ItemRemoved += EventLogs.Coach_Removed;

            bool exitApp = false;
            Console.WriteLine("Welcome to Football Stats. Store information about footballers and coaches.");
            while (exitApp != true)
            {
                Console.WriteLine("\n=============== MENU ===============\n");

                Console.WriteLine("----- Footballers -----");
                Console.WriteLine("1. Display all");
                Console.WriteLine("2. Add");
                Console.WriteLine("3. Remove");
                Console.WriteLine("--- Filter/Sort");
                Console.WriteLine("f1. Search by first name");
                Console.WriteLine("f2. Search by last name");
                Console.WriteLine("f3. Search by full name");
                Console.WriteLine("f4. Search by age range");
                Console.WriteLine("f5. Search by position");
                Console.WriteLine("f6. Display ordered by games");
                Console.WriteLine("f7. Display ordered by goals");
                Console.WriteLine("f8. Display ordered by clean sheets");

                Console.WriteLine("\n----- Coaches -----");
                Console.WriteLine("5. Display all");
                Console.WriteLine("6. Add");
                Console.WriteLine("7. Remove");
                Console.WriteLine("--- Filter/Sort");
                Console.WriteLine("c1. Search by first name");
                Console.WriteLine("c2. Search by last name");
                Console.WriteLine("c3. Search by full name");
                Console.WriteLine("c4. Search by licence");
                Console.WriteLine("c5. Search by favorite formation");
                Console.WriteLine("c6. Display ordered by years of experience");

                Console.Write("\nSelect option (q to quit): ");
                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("All football players:");
                        Utils.PrintAllItems(_footballerRepo.GetAll());
                        break;
                    case "2":
                        _footballerUi.AddFootballer();
                        break;
                    case "3":
                        _footballerUi.RemoveFootballer();
                        break;
                    case "f1":
                        _footballerUi.SearchByFirstName();
                        break;
                    case "f2":
                        _footballerUi.SearchByLastName();
                        break;
                    case "f3":
                        _footballerUi.SearchByFullName();
                        break;
                    case "f4":
                        _footballerUi.SearchByAgeRange();
                        break;
                    case "f5":
                        _footballerUi.SearchByPosition();
                        break;
                    case "f6":
                        Console.WriteLine("Display ordered by games");
                        Utils.PrintAllItems(_footballersProvider.GetOrderdedByGames());
                        break;
                    case "f7":
                        Console.WriteLine("Display ordered by goals");
                        Utils.PrintAllItems(_footballersProvider.GetOrderdedByGoals());
                        break;
                    case "f8":
                        Console.WriteLine("Display ordered by clean sheets");
                        Utils.PrintAllItems(_footballersProvider.GetOrderdedByCleanSheets());
                        break;
                    case "5":
                        Console.WriteLine("All coaches:");
                        Utils.PrintAllItems(_coachRepo.GetAll());
                        break;
                    case "6":
                        _coachUi.AddCoach();
                        break;
                    case "7":
                        _coachUi.RemoveCoach();
                        break;
                    case "c1":
                        _coachUi.SearchByFirstName();
                        break;
                    case "c2":
                        _coachUi.SearchByLastName();
                        break;
                    case "c3":
                        _coachUi.SearchByFullName();
                        break;
                    case "c4":
                        _coachUi.SearchByLicence();
                        break;
                    case "c5":
                        _coachUi.SearchByFavoriteFormation();
                        break;
                    case "c6":
                        Console.WriteLine("Display ordered by years of experience");
                        Utils.PrintAllItems(_coachesProvider.GetCoachesOrderedByYearsOfExperience());
                        break;
                    case "q":
                        exitApp = true;
                        break;
                }
            }
            var orderedF = _footballersProvider.GetOrderdedByGoals();
            var orderedC = _coachesProvider.GetCoachesOrderedByYearsOfExperience();

            Console.WriteLine("Ordered footb");
            foreach (var f in orderedF)
            {
                Console.WriteLine(f);
            }
            Console.WriteLine("Ordered coach");
            foreach (var c in orderedC)
            {
                Console.WriteLine(c);
            }
        }
    }
}
