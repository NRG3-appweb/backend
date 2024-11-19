namespace NRG3.Bliss.API.Shared.Interfaces.REST.Resources;

//TODO: Verify usability of this resource.

/// <summary>
/// Resource for creating a simplified company.
/// </summary>
/// <param name="Name">
/// The name of the company.
/// </param>
public record CreateSimplifiedCompanyResource(string Name);