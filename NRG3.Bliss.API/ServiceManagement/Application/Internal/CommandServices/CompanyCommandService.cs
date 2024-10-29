using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using NRG3.Bliss.API.ServiceManagement.Domain.Services;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.ServiceManagement.Application.Internal.CommandServices;

public class CompanyCommandService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
:ICompanyCommandService
{
    public async Task<Company?> Handle(CreateCompanyCommand command)
    {
        var company = new Company(command);
        await companyRepository.AddAsync(company);
        await unitOfWork.CompleteAsync();
        return company;
    }
}