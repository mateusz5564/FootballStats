using FootballStats;
using FootballStats.Data;
using FootballStats.Data.Entities;
using FootballStats.Data.Repository;
using FootballStats.DataProviders;
using FootballStats.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<DbContext, FootballStatsDbContext>();
services.AddSingleton<IRepository<Footballer>, Repository<Footballer>>();
services.AddSingleton<IRepository<Coach>, Repository<Coach>>();
services.AddSingleton<IFootballersProvider, FootballersProvider>();
services.AddSingleton<ICoachesProvider, CoachesProvider>();
services.AddSingleton<IFootballerUi, FootballerUi>();
services.AddSingleton<ICoachUi, CoachUi>();
services.AddSingleton<IApp, App>();

var app = services.BuildServiceProvider().GetRequiredService<IApp>();
app.Run();