using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Queries;
using NRG3.Bliss.API.AppointmentManagement.Domain.Services;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.ACL;

namespace NRG3.Bliss.API.AppointmentManagement.Application.ACL.Services;

public class AppointmentContextFacade(
    IAppointmentCommandService appointmentCommandService,
    IAppointmentQueryService appointmentQueryService
    ) : IAppointmentContextFacade
{
    public async Task<IEnumerable<Appointment?>> FetchAppointmentsByUserIdAsync(int userId)
    {
        var getAppointmentsByUserIdQuery = new GetAppointmentsByUserIdQuery(userId);
        
        var appointments = await appointmentQueryService.Handle(getAppointmentsByUserIdQuery);
        
        return appointments;
    }
}