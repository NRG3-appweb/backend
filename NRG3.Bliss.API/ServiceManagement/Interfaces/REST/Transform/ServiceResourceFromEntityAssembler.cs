using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;
using NRG3.Bliss.API.Shared.Interfaces.REST.Transform;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;

public static class ServiceResourceFromEntityAssembler
{
    public static ServiceResource ToResourceFromEntity(Service entity)
    {
        return new ServiceResource(
            entity.Id, 
            SimplifiedCompanyResourceFromEntityAssembler.ToResourceFromEntity(entity.Company), 
            ServiceCategoryResourceFromEntityAssembler.ToResourceFromEntity(entity.Category),
            entity.Name,
            entity.Description,
            entity.Price,
            entity.Duration,
            entity.ImageUrl
        );
    }
}