﻿using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;
using NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;
using NRG3.Bliss.API.AppointmentManagement.Domain.Services;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.AppointmentManagement.Application.Internal.CommandServices;

public class AppointmentCommandService(
    IAppointmentRepository appointmentRepository,
    IServiceRepository serviceRepository,
    ICompanyRepository companyRepository,
    IUnitOfWork unitOfWork)
    : IAppointmentCommandService
{
    public async Task<Appointment?> Handle(CreateAppointmentCommand command)
    {
        var appointment = new Appointment(command);
        await appointmentRepository.AddAsync(appointment);
        await unitOfWork.CompleteAsync();
        var service = await serviceRepository.FindByIdAsync(command.ServiceId);
        var company = await companyRepository.FindByIdAsync(command.CompanyId);
        if (service != null) appointment.ServiceId = service.Id;
        if (company != null) appointment.CompanyId = company.Id;
        return appointment;
    }
}