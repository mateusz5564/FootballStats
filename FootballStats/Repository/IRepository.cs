﻿using FootballStats.Entities;

namespace FootballStats.Repository
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
    {
    }
}
