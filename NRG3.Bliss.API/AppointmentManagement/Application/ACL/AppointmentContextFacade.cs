using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Queries;
using NRG3.Bliss.API.AppointmentManagement.Domain.Services;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.ACL;

namespace NRG3.Bliss.API.AppointmentManagement.Application.ACL.Services;

/// <summary>
/// This class is a facade for the appointment context.
/// It is used to abstract the application layer from the domain layer.
/// </summary>
/// <param name="appointmentCommandService">
/// The service that is responsible for handling commands related to appointments.
/// </param>
/// <param name="appointmentQueryService">
/// The service that is responsible for handling queries related to appointments.
/// </param>
public class AppointmentContextFacade(
    IAppointmentCommandService appointmentCommandService,
    IAppointmentQueryService appointmentQueryService
    ) : IAppointmentContextFacade
{
    /// <inheritdoc/>
    public async Task<IEnumerable<Appointment?>> FetchAppointmentsByUserIdAsync(int userId)
    {
        var getAppointmentsByUserIdQuery = new GetAppointmentsByUserIdQuery(userId);
        
        var appointments = await appointmentQueryService.Handle(getAppointmentsByUserIdQuery);
        
        return appointments;
    }
}