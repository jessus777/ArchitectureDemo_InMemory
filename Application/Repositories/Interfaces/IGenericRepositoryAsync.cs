namespace Application.Repositories.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        ValueTask<T> CreateAsync(T entity);
        ValueTask UpdateAsync(T entity);
        ValueTask DeleteAsync(T entity);
        ValueTask<T> GetByIdAsync(int id);
        ValueTask<IEnumerable<T>> GetAllAsync();
    }
}
