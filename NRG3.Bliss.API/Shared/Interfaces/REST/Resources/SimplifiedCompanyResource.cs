namespace NRG3.Bliss.API.Shared.Interfaces.REST.Resources;

/// <summary>
/// Simplified Resource for a company
/// </summary>
/// <param name="Id">
/// The unique identifier of the company
/// </param>
/// <param name="Name">
/// The name of the company
/// </param>
public record SimplifiedCompanyResource(int Id, string Name);