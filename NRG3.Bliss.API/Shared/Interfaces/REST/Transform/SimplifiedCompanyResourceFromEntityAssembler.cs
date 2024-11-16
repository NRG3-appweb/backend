using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.Shared.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.Shared.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to transform a Company entity into a SimplifiedCompanyResource.
/// </summary>
public static class SimplifiedCompanyResourceFromEntityAssembler
{
    /// <summary>
    /// Transforms a <see cref="Company"/> entity into a <see cref="SimplifiedCompanyResource"/>.
    /// </summary>
    /// <param name="entity">
    /// The <see cref="Company"/> entity to transform.
    /// </param>
    /// <returns>
    /// The transformed <see cref="SimplifiedCompanyResource"/>.
    /// </returns>
    public static SimplifiedCompanyResource ToResourceFromEntity(Company entity)
    {
        return new SimplifiedCompanyResource(entity.Id, entity.Name);
    }
}