namespace NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;

/// <summary>
/// Command to create a new appointment
/// </summary>
/// <param name="UserId">
/// The user id of the user who is creating the appointment
/// </param>
/// <param name="ServiceId">
/// The service id of the service that the user is booking
/// </param>
/// <param name="ReservationDate">
/// The date of the appointment
/// </param>
/// <param name="ReservationStartTime">
/// The start time of the appointment
/// </param>
/// <param name="Requirements">
/// Any requirements that the user has for the appointment
/// </param>
public record CreateAppointmentCommand(
    int UserId,
    int ServiceId,
    DateTime ReservationDate,
    DateTime ReservationStartTime,
    string Requirements
    );