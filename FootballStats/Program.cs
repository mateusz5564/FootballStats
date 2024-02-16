using FootballStats.Data;
using FootballStats.Data.Entities;
using FootballStats.Data.Repository;
using FootballStats.UI;

var context = new FootballStatsDbContext();
var footballersRepo = new Repository<Footballer>(context);
var coachesRepo = new Repository<Coach>(context);

footballersRepo.ItemAdded += EventLogs.Footballer_Added;
footballersRepo.ItemRemoved += EventLogs.Footballer_Removed;
coachesRepo.ItemAdded += EventLogs.Coach_Added;
coachesRepo.ItemRemoved += EventLogs.Coach_Removed;

var FootballerUi = new FootballerUi(footballersRepo);
var CoachUi = new CoachUi(coachesRepo);

bool exitApp = false;
Console.WriteLine("Welcome to Football Stats. Store information about footballers and coaches.");
while (exitApp != true)
{
    Console.WriteLine("\n=============== MENU ===============\n");

    Console.WriteLine("----- Footballers -----");
    Console.WriteLine("1. Display all");
    Console.WriteLine("2. Add");
    Console.WriteLine("3. Remove");

    Console.WriteLine("\n----- Coaches -----");
    Console.WriteLine("5. Display all");
    Console.WriteLine("6. Add");
    Console.WriteLine("7. Remove");

    Console.Write("\nSelect option (q to quit): ");
    string input = Console.ReadLine();
    Console.WriteLine();

    switch (input)
    {
        case "1":
            Console.WriteLine("All football players:");
            Utils.PrintAllItems(footballersRepo);
            break;
        case "2":
            FootballerUi.AddFootballer();
            break;
        case "3":
            FootballerUi.RemoveFootballer();
            break;
        case "5":
            Console.WriteLine("All coaches:");
            Utils.PrintAllItems(coachesRepo);
            break;
        case "6":
            CoachUi.AddCoach();
            break;
        case "7":
            CoachUi.RemoveCoach();
            break;
        case "q":
            exitApp = true;
            break;

    }
}

