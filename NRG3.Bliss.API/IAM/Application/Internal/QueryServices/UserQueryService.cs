
using NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.ACL;
using NRG3.Bliss.API.IAM.Domain.Model.Aggregate;
using NRG3.Bliss.API.IAM.Domain.Model.Queries;
using NRG3.Bliss.API.IAM.Domain.Repositories;
using NRG3.Bliss.API.IAM.Domain.Services;

namespace NRG3.Bliss.API.IAM.Application.Internal.QueryServices;

public class UserQueryService(
    IUserRepository userRepository,
    IAppointmentContextFacade appointmentContextFacade
    ) : IUserQueryService
{
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.UserId);
    }
}