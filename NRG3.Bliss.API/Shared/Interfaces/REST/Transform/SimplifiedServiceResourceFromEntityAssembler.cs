using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.Shared.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.Shared.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to transform a Service entity into a SimplifiedServiceResource.
/// </summary>
public class SimplifiedServiceResourceFromEntityAssembler
{
    /// <summary>
    /// Transforms a Service entity into a SimplifiedServiceResource.
    /// </summary>
    /// <param name="entity">
    /// The <see cref="Service"/> entity to transform.
    /// </param>
    /// <returns>
    /// The transformed <see cref="SimplifiedServiceResource"/>.
    /// </returns>
    public static SimplifiedServiceResource ToResourceFromEntity(Service entity)
    {
        return new SimplifiedServiceResource(
            entity.Id,
            entity.CompanyId,
            entity.CategoryId,
            entity.ServiceName,
            entity.Price
        );
    }
}