using Lab5.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lab5.Persistence.Repository;

public class EfRepository<T>(AppDbContext context) : IRepository<T> where T : Entity
{
    protected readonly AppDbContext _context = context;
    protected readonly DbSet<T> _entities = context.Set<T>();

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _entities.AddAsync(entity, cancellationToken);
        _context.SaveChanges();
    }

    public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _entities.Remove(entity);
        _context.SaveChanges();
        return Task.CompletedTask;
    }

    public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
    {
        return _entities.FirstOrDefaultAsync(filter, cancellationToken);
    }

    public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includesProperties)
    {
        IQueryable<T>? query = _entities.AsQueryable();

        if (includesProperties.Any())
        {
            foreach (Expression<Func<T, object>> included in includesProperties)
            {
                query = query.Include(included);
            }
        }

        query.Where((e) => e.Id == id);

        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _entities.ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> GetFilteredAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includesProperties)
    {
        IQueryable<T>? query = _entities.AsQueryable();

        if (includesProperties.Any())
        {
            foreach (Expression<Func<T, object>> included in includesProperties)
            {
                query = query.Include(included);
            }
        }

        if (filter is not null)
            query = query.Where(filter);
        
        return await query.ToListAsync(cancellationToken);
    }

    public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
        return Task.CompletedTask;
    }
}
