namespace NRG3.Bliss.API.Shared.Interfaces.REST.Resources;

/// <summary>
/// Simplified Resource for a service
/// </summary>
/// <param name="id">
/// The unique identifier of the service
/// </param>
/// <param name="companyId">
/// The unique identifier of the company that provides the service
/// </param>
/// <param name="categoryId">
/// The unique identifier of the category that the service belongs to
/// </param>
/// <param name="serviceName">
/// The name of the service
/// </param>
/// <param name="price">
/// The price of the service
/// </param>
public record SimplifiedServiceResource(
    int id,
    int companyId,
    int categoryId,
    string serviceName,
    double price
    );