
using NRG3.Bliss.API.IAM.Domain.Model.Aggregate;
using NRG3.Bliss.API.Shared.Interfaces.Rest.Resources;


/// <summary>
/// Assembler to create a SimplifiedUserResource from a User entity
/// </summary>

public static class SimplifiedUserResourceFromEntityAssembler
{
    
    /// <summary>
    /// Assembles a SimplifiedUserResource from a User entity
    /// </summary>
    /// <param name="entity">
    /// The <see cref="User"/> entity to assemble the resource from
    /// </param>
    /// <returns>
    /// The <see cref="SimplifiedUserResource"/> resource assembled from the entity
    /// </returns>
    public static SimplifiedUserResource ToResourceFromEntity(User entity)
    {
        return new SimplifiedUserResource(entity.Id, entity.FirstName, entity.LastName);
    }
}