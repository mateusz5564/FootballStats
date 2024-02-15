﻿using FootballStats.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballStats.Data
{
    public class FootballStatsDbContext : DbContext
    {
        public DbSet<Footballer> Footballers => Set<Footballer>();
        public DbSet<Coach> Coach => Set<Coach>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("AppStorage");
        }
    }
}