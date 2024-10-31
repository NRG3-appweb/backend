﻿using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;

public static class CreateAppointmentCommandResourceFromEntityAssembler
{
    public static CreateAppointmentCommand ToCommandFromResource(CreateAppointmentResource resource)
    {
        return new CreateAppointmentCommand();
    }
}