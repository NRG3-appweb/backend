
using NRG3.Bliss.API.Shared.Interfaces.Rest.Resources;
using NRG3.Bliss.API.Shared.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

/// <summary>
/// Represents the appointment resource.
/// </summary>
/// <param name="id">
/// The unique identifier of the appointment.
/// </param>
/// <param name="user">
/// The user who made the appointment.
/// </param>
/// <param name="service">
/// The service that the appointment is for.
/// </param>
/// <param name="appointmentStatus">
/// The status of the appointment.
/// </param>
/// <param name="reservationDate">
/// The date of the appointment.
/// </param>
/// <param name="reservationStartTime">
/// The start time of the appointment.
/// </param>
/// <param name="requirements">
/// The requirements of the appointment.
/// </param>
public record AppointmentResource(
    int id,
    SimplifiedUserResource user,
    SimplifiedServiceResource service,
    string appointmentStatus,
    DateTime reservationDate,
    DateTime reservationStartTime,
    string requirements
    );