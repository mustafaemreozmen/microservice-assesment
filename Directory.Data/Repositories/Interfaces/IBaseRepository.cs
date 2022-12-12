using Directory.Data.Entities;
using System.Linq.Expressions;

namespace Directory.Data.Repositories.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity, new()
{
    void Add(T entity);
    void Remove(T entity);
    void Update(T entity);
    T Get(Expression<Func<T, bool>> filter);
    IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);
}