using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;
using NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;
using NRG3.Bliss.API.AppointmentManagement.Domain.Services;
using NRG3.Bliss.API.IAM.Interfaces.ACL;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using NRG3.Bliss.API.ServiceManagement.Interfaces.ACL;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.AppointmentManagement.Application.Internal.CommandServices;


public class AppointmentCommandService(
    IAppointmentRepository appointmentRepository,
    IUnitOfWork unitOfWork,
    IServiceContextFacade serviceContextFacade,
    IIAMContextFacade iamContextFacade
    )
    : IAppointmentCommandService
{
    
    public async Task<Appointment?> Handle(CreateAppointmentCommand command)
    {
        
        //An appointment for this service at the specified time already exists.
        if (await appointmentRepository.ExistsAppointmentByUserIdAndTimeAsync(
                command.UserId,
                command.ReservationDate,
                command.ReservationStartTime))
        {
            throw new Exception("An appointment for this service at the specified time already exists.");
        }
        
        //The user already has an appointment at the specified time.
        if (await appointmentRepository.ExistsAppointmentByServiceIdAndTimeAsync(
                command.ServiceId,
                command.ReservationDate,
                command.ReservationStartTime))
        {
            throw new Exception("The user already has an appointment at the specified time.");
        }

        var appointment = new Appointment(command);

        try
        {
            await appointmentRepository.AddAsync(appointment);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating the appointment: {e.Message}");
        }
        
        
        var service = await serviceContextFacade.FetchServiceByIdAsync(command.ServiceId);
        var user = await iamContextFacade.FetchUserByIdAsync(command.UserId);
        
        appointment.Service = service;
        appointment.User = user;
        
        return appointment;
    }

    /// <inheritdoc />
    public async Task Handle(DeleteAppointmentCommand command)
    {
        var appointment = await appointmentRepository.FindByIdAsync(command.appointmentId);
        
        if (appointment != null)
        {
            appointmentRepository.Remove(appointment);
            await unitOfWork.CompleteAsync();
        }


    }
    
    
    
}