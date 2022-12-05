using System.Linq.Expressions;
using Directory.Data.Entities;
using Directory.Data.Repositories.Interfaces;

namespace Directory.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
{
    public Task Add(T Entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> Get(Expression<Func<T, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task Remove(T Entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(T Entity)
    {
        throw new NotImplementedException();
    }
}