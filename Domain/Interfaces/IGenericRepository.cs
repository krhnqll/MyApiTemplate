using System.Linq.Expressions;


namespace Domain.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task SaveChangesAsync();
    Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null);
}

