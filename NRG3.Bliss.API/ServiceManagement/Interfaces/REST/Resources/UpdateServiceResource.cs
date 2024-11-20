namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

public record UpdateServiceResource(int CategoryId, string Name, string Description, double Price, double Duration);