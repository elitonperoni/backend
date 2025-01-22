using System.Linq.Expressions;

namespace backend.Repository.Interfaces;

public interface IRepository<T>
{
    IQueryable<T> Get();
    Task<T?> GetById(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetFilter(Expression<Func<T, bool>> predicate);
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
}
