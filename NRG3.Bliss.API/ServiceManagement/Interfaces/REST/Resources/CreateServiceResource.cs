namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

public record CreateServiceResource(int CompanyId,int CategoryId, string Name, string Description, double Price, double Duration, string ImageUrl);