using Microsoft.EntityFrameworkCore;
using NRG3.Bliss.API.Shared.Domain.Repositories;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Repositories;


/// <summary>
/// Base repository implementation
/// </summary>
/// <typeparam name="TEntity">
/// Entity type for the repository
/// </typeparam>
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    
    protected readonly AppDbContext Context;
    
    /// <summary>
    /// Constructor for base repository
    /// </summary>
    /// <param name="context">
    /// Database context
    /// </param>
    protected BaseRepository(AppDbContext context)
    {
        Context = context;
    }
    
    /// <inheritdoc/>
    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }

    /// <inheritdoc/>
    public async Task<TEntity?> FindByIdAsync(int id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    /// <inheritdoc/>
    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }

    /// <inheritdoc/>
    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }
}