using FootballStats.Data.Entities;

namespace FootballStats.Data.Repository
{
    public interface IReadRepository<out T> where T : class, IEntity
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
