namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;


public record CreateAppointmentResource(
    int userId,
    int serviceId,
    DateTime reservationDate,
    DateTime reservationStartTime,
    string requirements
    );