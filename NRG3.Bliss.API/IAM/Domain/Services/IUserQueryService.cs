
using NRG3.Bliss.API.IAM.Domain.Model.Aggregate;
using NRG3.Bliss.API.IAM.Domain.Model.Queries;

namespace NRG3.Bliss.API.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    
    //TODO: Verify if this is correct (Alex)
    /*
     * lo que pasa es que si se quiere hacer un query que devuelva una lista de citas de un usuario, se debe de hacer en el contexto de appointments y no en el contexto de usuarios, porque estamos devolviendo ps appointments. xd
     */
    //Task<User?> Handle(GetUserAppointmentsById query);
}