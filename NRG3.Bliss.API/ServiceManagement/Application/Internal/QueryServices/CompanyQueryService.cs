using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using NRG3.Bliss.API.ServiceManagement.Domain.Services;

namespace NRG3.Bliss.API.ServiceManagement.Application.Internal.QueryServices;

public class CompanyQueryService(ICompanyRepository companyRepository) : ICompanyQueryService
{
    public async Task<IEnumerable<Company>> Handle(GetAllCompaniesQuery query)
    {
        return await companyRepository.ListAsync();
    }

    public async Task<Company?> Handle(GetCompanyByIdQuery query)
    {
        return await companyRepository.FindByIdAsync(query.CompanyId);
    }
    
}