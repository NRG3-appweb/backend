namespace NRG3.Bliss.API.Shared.Interfaces.REST.Resources;

public record SimplifiedServiceResource(
    int id,
    int companyId,
    int categoryId,
    string serviceName,
    double price
    );