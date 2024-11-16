using NRG3.Bliss.API.Shared.Domain.Repositories;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Repositories;


/// <summary>
/// Unit of work implementation
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    
    /// <summary>
    /// Constructor for unit of work
    /// </summary>
    /// <param name="context">
    /// Database context
    /// </param>
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    
    /// <inheritdoc/>
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}