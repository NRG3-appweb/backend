namespace NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;

public record CreateServiceCommand(string CompanyId, string CategoryId, string ServiceName, string Description, int Price, int Duration);