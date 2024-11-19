namespace NRG3.Bliss.API.Shared.Domain.Repositories;

/// <summary>
/// Base repository interface
/// </summary>
/// <typeparam name="TEntity">
/// Entity type for the repository
/// </typeparam>
public interface IBaseRepository<TEntity>
{
    Task AddAsync(TEntity entity);
    Task<TEntity?> FindByIdAsync(int id);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<IEnumerable<TEntity>> ListAsync();
}