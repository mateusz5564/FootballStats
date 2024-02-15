using FootballStats.Data;
using FootballStats.Entities;
using FootballStats.Repository;

var footballers = new List<Footballer>
{
    new Footballer { FirstName = "Robert", LastName = "Lewandowski", Age = 36, Number = 9, Position = "Striker", Games = 750, Goals = 500},
    new Footballer { FirstName = "Leo", LastName = "Messi", Age = 36, Number = 10, Position = "Forward", Games = 800, Goals = 600},
    new Footballer { FirstName = "Łukasz", LastName = "Fabiański", Age = 38, Number = 1, Position = "Goalkeeper", Games = 460, Goals = 0, CleanSheets = 113}
};

var coaches = new List<Coach>
{
    new Coach {FirstName = "Adam", LastName = "Nawałka", Age = 66, Licence = "UEFA Pro", YearsOfExperience = 27, FavoriteFormation = "1-4-4-2"},
    new Coach {FirstName = "Jurgen", LastName = "Klopp", Age = 56, Licence = "UEFA Pro", YearsOfExperience = 35, FavoriteFormation = "1-4-3-3"}
};

var context = new FootballStatsDbContext();
var footballersRepo = new Repository<Footballer>(context);
var coachesRepo = new Repository<Coach>(context);

AddItems(footballersRepo, footballers);
AddItems(coachesRepo, coaches);
PrintAllItems(footballersRepo);
PrintAllItems(coachesRepo);

void AddItems<T>(IRepository<T> repository, IEnumerable<T> items) where T : class, IEntity
{
    foreach (var item in items)
    {
        repository.Add(item);
    }

    repository.Save();
}

void PrintAllItems<T>(IRepository<T> repository) where T : class, IEntity
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}