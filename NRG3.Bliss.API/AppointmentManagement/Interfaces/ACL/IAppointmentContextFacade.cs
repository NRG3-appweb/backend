using System.Collections;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.ACL;

/// <summary>
/// Appointment context Facade 
/// </summary>
/// <remarks>
/// This facade is responsible for managing the context of the appointment management module.
/// </remarks>
public interface IAppointmentContextFacade
{
    /// <summary>
    /// Find appointments by user id
    /// </summary>
    /// <param name="userId">
    /// The user id to search for
    /// </param>
    /// <returns>
    /// a list of <see cref="Appointment"/> if found, otherwise null
    /// </returns>
    Task<IEnumerable<Appointment?>> FetchAppointmentsByUserIdAsync(int userId);
}