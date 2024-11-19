
using NRG3.Bliss.API.IAM.Domain.Model.Aggregate;
using NRG3.Bliss.API.IAM.Domain.Model.Queries;
using NRG3.Bliss.API.IAM.Domain.Services;
using NRG3.Bliss.API.IAM.Interfaces.ACL;

namespace NRG3.Bliss.API.IAM.Application.ACL;

public class IAMContextFacade(
    IUserQueryService userQueryService
    ) : IIAMContextFacade
{
    public async Task<User> FetchUserByIdAsync(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var user = await userQueryService.Handle(getUserByIdQuery);
        
        return user ?? throw new Exception("User not found");
    }
}