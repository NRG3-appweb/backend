using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.ACL;

public interface IServiceContextFacade
{
    Task<Service> FetchServiceByIdAsync(int serviceId);
}