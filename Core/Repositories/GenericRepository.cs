
using System.Reflection.Metadata.Ecma335;
using FormulaAPI.Data;
using Microsoft.EntityFrameworkCore;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
  protected ApiDbContext _context;
  internal DbSet<T> _dbset;
  protected readonly ILogger _logger;

  public GenericRepository(ApiDbContext context, ILogger logger)
  {
    _context = context;
    _logger = logger;
    _dbset = context.Set<T>();
  }

  public virtual async Task<bool> Add(T entity)
  {
    await _dbset.AddAsync(entity);
    return true;
  }

  public virtual async Task<IEnumerable<T>> AllAsync()
  {
    return await _dbset.AsNoTracking().ToListAsync();
  }

  public virtual async Task<bool> Delete(T entity)
  {
    _dbset.Remove(entity);
    return true;
  }

  public virtual async Task<T?> GetByIDAsync(int id)
  {
    return await _dbset.FindAsync(id);
  }

  public virtual async Task<bool> Update(T entity)
  {
    _dbset.Update(entity);
    return true;
  }
}