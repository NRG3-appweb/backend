using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;

/// <summary>
/// Appointment repository interface
/// </summary>
public interface IAppointmentRepository : IBaseRepository<Appointment>
{
    
    /// <summary>
    /// Find appointments by user id
    /// </summary>
    /// <param name="userId">
    /// The user id to search for
    /// </param>
    /// <returns>
    /// The <see cref="Appointment"/> if found, otherwise null
    /// </returns>
    Task<IEnumerable<Appointment>> FindAppointmentsByUserIdAsync(int userId);
    
    
    /// <summary>
    /// Find appointment by id
    /// </summary>
    /// <param name="appointmentId">
    /// The appointment id to search for
    /// </param>
    /// <returns>
    /// The <see cref="Appointment"/> if found, otherwise null
    /// </returns>
    Task<Appointment?> FindAppointmentByIdAsync(int appointmentId);
    
    Task<bool> ExistsAppointmentByUserIdAndTimeAsync(
        int userId, 
        DateTime reservationDate,
        DateTime reservationStartTime
        );
    
    Task<bool> ExistsAppointmentByServiceIdAndTimeAsync(
        int serviceId, 
        DateTime reservationDate,
        DateTime reservationStartTime
        );
    
}