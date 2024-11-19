
using NRG3.Bliss.API.IAM.Domain.Model.Aggregate;

namespace NRG3.Bliss.API.IAM.Interfaces.ACL;

public interface IIAMContextFacade
{
    Task<User> FetchUserByIdAsync(int userId);
}