using backend.Context;
using backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<T> Get()
    {
        return _context.Set<T>();
    }

    public async Task<T?> GetById(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(predicate).SingleOrDefaultAsync();    
    }

    public async Task<List<T>> GetFilter(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
    }

    public void Add(T entity)
    {
        _context.Set<T>().AddAsync(entity);
    }
    
    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<T>().Update(entity);
    }
}

