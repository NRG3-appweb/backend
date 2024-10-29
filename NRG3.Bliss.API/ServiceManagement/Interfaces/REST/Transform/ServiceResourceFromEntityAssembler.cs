using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;

public static class ServiceResourceFromEntityAssembler
{
    public static ServiceResource ToResourceFromEntity(Service entity)
    {
        return new ServiceResource(
            entity.Id, 
            CompanyResourceFromEntityAssembler.ToResourceFromEntity(entity.Company), 
            CategoryResourceFromEntityAssembler.ToResourceFromEntity(entity.Category),
            entity.ServiceName,
            entity.Description,
            entity.Price,
            entity.Duration
        );
    }
}