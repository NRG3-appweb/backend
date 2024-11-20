using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;

public class UpdateServiceCommandResourceFromEntityAssembler
{
    public static UpdateServiceCommand ToCommandFromResource(UpdateServiceResource resource, int serviceId)
    {
        return new UpdateServiceCommand(
            serviceId, resource.CategoryId, 
            resource.ServiceName, resource.Description,
            resource.Price, resource.Duration);
    }
}