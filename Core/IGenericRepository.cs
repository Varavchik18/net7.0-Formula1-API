public interface IGenericRepository<T> where T : class
{
  Task<IEnumerable<T>> AllAsync();
  Task<T?> GetByIDAsync(int id);
  Task<bool> Add(T entity);
  Task<bool> Update(T entity);
  Task<bool> Delete(T entity);
}