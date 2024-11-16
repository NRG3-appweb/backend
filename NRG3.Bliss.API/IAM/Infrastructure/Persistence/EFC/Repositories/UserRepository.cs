
using NRG3.Bliss.API.IAM.Domain.Model.Aggregate;
using NRG3.Bliss.API.IAM.Domain.Repositories;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NRG3.Bliss.API.IAM.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Repository for the User entity
/// </summary>
/// <param name="context">
/// The database context
/// </param>
public class UserRepository(AppDbContext context): BaseRepository<User>(context), IUserRepository
{
    
}