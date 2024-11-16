using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;
using NRG3.Bliss.API.IAM.Domain.Model.Queries;
using NRG3.Bliss.API.IAM.Domain.Services;
using NRG3.Bliss.API.IAM.Interfaces.Rest.Resources;
using NRG3.Bliss.API.IAM.Interfaces.Rest.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace NRG3.Bliss.API.IAM.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Available User endpoints")]
public class UsersController(IUserQueryService userQueryService) : ControllerBase
{
    
    [HttpGet("{id:int}")]
    [SwaggerOperation(
        Summary ="Get user by id",
        Description = "Get user by id",
        OperationId = "GetUserById")]
    [SwaggerResponse(StatusCodes.Status200OK, "User found", typeof(UserResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "User not found")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);
        var user = await userQueryService.Handle(getUserByIdQuery);
        if (user is null) return NotFound();
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }
    
    //TODO: Verify if this path is correct (api/v1/users/{userId:int}/appointments) (Alex)
    [HttpGet("{userId:int}/appointments")]
    [SwaggerOperation (
        Summary = "Get user appointments by id",
        Description = "Get the appointments a user has",
        OperationId = "GetAppointmentsById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The appointments were found", typeof(IEnumerable<AppointmentResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The appointments were not found.")]
    public async Task<IActionResult> GetUserAppointmentsById([FromRoute] int userId)
    {
        /*
         * var getAllAppointmentsByUserIdQuery = new GetAppointmentsByUserIdQuery(userId);
        var appointments = await appointmentQueryService.Handle(getAllAppointmentsByUserIdQuery);
        var appointmentResources = appointments.Select(
            AppointmentResourceFromEntityAssembler.ToResourceFromEntity
        );
        return Ok(appointmentResources);
         */

        return null;
    }
    
}