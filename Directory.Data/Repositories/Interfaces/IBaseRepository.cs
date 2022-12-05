using Directory.Data.Entities;
using System.Linq.Expressions;

namespace Directory.Data.Repositories.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity, new()
{
    Task Add(T Entity);
    Task Remove(T Entity);
    Task Update(T Entity);
    Task<T> Get(Expression<Func<T, bool>> filter);
    Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter);
}