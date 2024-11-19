using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;
using NRG3.Bliss.API.ServiceManagement.Domain.Services;
using NRG3.Bliss.API.ServiceManagement.Interfaces.ACL;

namespace NRG3.Bliss.API.ServiceManagement.Application.ACL;

public class ServiceContextFacade(
    IServiceQueryService serviceQueryService,
    IServiceCommandService serviceCommandService
    ) : IServiceContextFacade
{
    public async Task<Service> FetchServiceByIdAsync(int serviceId)
    {
        var getServiceByIdQuery = new GetServiceByIdQuery(serviceId);

        var service = await serviceQueryService.Handle(getServiceByIdQuery);
        
        return service ?? throw new Exception("Service not found");
    }
}