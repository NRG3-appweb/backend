
using NRG3.Bliss.API.Shared.Interfaces.Rest.Resources;
using NRG3.Bliss.API.Shared.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

public record AppointmentResource(
    int id,
    SimplifiedUserResource user,
    SimplifiedServiceResource service,
    string appointmentStatus,
    DateTime reservationDate,
    DateTime reservationStartTime,
    string requirements
    );