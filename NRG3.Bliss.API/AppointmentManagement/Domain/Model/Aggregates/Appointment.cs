
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.ValueObjects;
using NRG3.Bliss.API.IAM.Domain.Model.Aggregate;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;

namespace NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;

/// <summary>
/// Appointment aggregate root
/// </summary>
/// <remarks>
/// This class represents the appointment aggregate root.
/// It contains the properties and methods to manage the appointment information.
/// </remarks>

public partial class Appointment
{
    public int Id { get; }
    public int UserId { get; internal set; }
    public User User { get; internal set; }
    public int ServiceId { get; set; }
    public Service Service { get; internal set; }
    public EAppointmentStatus AppointmentStatus { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime ReservationStartTime { get; set; }
    public string Requirements { get; set; }

    public Appointment()
    {
        
    }

    /// <summary>
    /// Constructor for the appointment aggregate root
    /// </summary>
    /// <param name="command">
    /// The <see cref="CreateAppointmentCommand"/> to create an appointment
    /// </param>
    public Appointment(CreateAppointmentCommand command)
    {
        UserId = command.UserId;
        ServiceId = command.ServiceId;
        AppointmentStatus = EAppointmentStatus.PENDING; 
        ReservationDate = command.ReservationDate;
        ReservationStartTime = command.ReservationStartTime;
        Requirements = command.Requirements;
    }
    
    
}