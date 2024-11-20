using NRG3.Bliss.API.Shared.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

public record ServiceResource(int Id, SimplifiedCompanyResource Company, ServiceCategoryResource Category, string Name, string Description, double Price, double Duration,string ImgUrl);