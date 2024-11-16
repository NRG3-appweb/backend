using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.Shared.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.Shared.Interfaces.REST.Transform;

public class SimplifiedServiceResourceFromEntityAssembler
{
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