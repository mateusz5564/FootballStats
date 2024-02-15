using FootballStats.Data.Entities;

namespace FootballStats.Data.Repository
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
    {
    }
}
