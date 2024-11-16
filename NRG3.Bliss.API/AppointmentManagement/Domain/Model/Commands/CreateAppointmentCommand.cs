namespace NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;

public record CreateAppointmentCommand(
    int UserId,
    int ServiceId,
    DateTime ReservationDate,
    DateTime ReservationStartTime,
    string Requirements
    );