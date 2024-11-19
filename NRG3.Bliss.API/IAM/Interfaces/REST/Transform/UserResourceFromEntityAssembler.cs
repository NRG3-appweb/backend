
using NRG3.Bliss.API.IAM.Domain.Model.Aggregate;
using NRG3.Bliss.API.IAM.Interfaces.Rest.Resources;

namespace NRG3.Bliss.API.IAM.Interfaces.Rest.Transform;

/// <summary>
/// Assembler class to transform User to UserResource
/// </summary>
public static class UserResourceFromEntityAssembler
{
    /// <summary>
    /// Assembles a UserResource from a User entity
    /// </summary>
    /// <param name="entity">
    /// The <see cref="User"/> entity to assemble the resource from
    /// </param>
    /// <returns>
    /// The <see cref="UserResource"/> resource assembled from the entity
    /// </returns>
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(
            entity.Id,
            entity.FirstName,
            entity.LastName,
            entity.Password,
            entity.Email,
            entity.Phone,
            entity.Dni,
            entity.Address,
            entity.City,
            entity.BirthDate
        );
    }
}