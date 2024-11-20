using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Services;

public interface IServiceCommandService
{
    Task<Service?> Handle(CreateServiceCommand command);
    Task<Service?> Handle(UpdateServiceCommand command);
    Task Handle(DeleteServiceCommand command);
}