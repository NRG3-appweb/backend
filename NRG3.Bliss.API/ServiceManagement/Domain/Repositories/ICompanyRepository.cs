using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Repositories;

public interface ICompanyRepository : IBaseRepository<Company>
{
    Task<IEnumerable<Company>> FindCompaniesByCompanyName(string name);
}