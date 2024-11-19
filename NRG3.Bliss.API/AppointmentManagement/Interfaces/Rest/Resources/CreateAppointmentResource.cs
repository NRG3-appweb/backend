namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

/// <summary>
/// Resource for creating a new appointment
/// </summary>
/// <param name="userId">
/// The user id of the user who is creating the appointment
/// </param>
/// <param name="serviceId">
/// The service id of the service that the user is booking
/// </param>
/// <param name="reservationDate">
/// The date of the appointment
/// </param>
/// <param name="reservationStartTime">
/// The start time of the appointment
/// </param>
/// <param name="requirements">
/// Any requirements that the user has for the appointment
/// </param>
public record CreateAppointmentResource(
    int userId,
    int serviceId,
    DateTime reservationDate,
    DateTime reservationStartTime,
    string requirements
    );