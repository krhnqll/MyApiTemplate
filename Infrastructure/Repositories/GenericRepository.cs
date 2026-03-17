using Domain.Interfaces;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Infrastructure.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
     where TEntity : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<List<TEntity>> GetAllAsync()
       => await _dbSet.ToListAsync();

    public async Task<TEntity?> GetByIdAsync(int id)
        => await _dbSet.FindAsync(id);

    public async Task AddAsync(TEntity entity)
        => await _dbSet.AddAsync(entity);

    public async Task UpdateAsync(TEntity entity)
        => _dbSet.Update(entity);

    public async Task DeleteAsync(TEntity entity)
        => _dbSet.Remove(entity);

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        IQueryable<TEntity> query = _dbSet.AsNoTracking();

        if (predicate != null)
            query = query.Where(predicate);

        return await query.CountAsync();
    }
}
