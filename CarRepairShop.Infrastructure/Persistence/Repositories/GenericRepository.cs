using System.Linq.Expressions;
using CarRepairShop.Domain;
using CarRepairShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly CrsDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(CrsDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate
        , CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(p => !p.IsDeleted).Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(p => !p.IsDeleted).ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(p => !p.IsDeleted && p.Id == id, cancellationToken);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}