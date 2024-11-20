using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Entities;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

namespace NRG3.Bliss.API.IAM.Interfaces.REST.Transform;

public class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.Phone,
            user.Dni,
            user.Address,
            user.City,
            user.BirthDate
            );
    }
}