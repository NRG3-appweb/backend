﻿namespace NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Resources;

//TODO: Check the resource naming (SimplifiedAppointmentResource || ReviewAppointmentResource)(Elvia)
/// <summary>
/// Simplified Resource for an appointment
/// </summary>
/// <param name="ServiceId">
/// The unique identifier of the service
/// </param>
/// <param name="CompanyId">
/// The unique identifier of the company
/// </param>
/// <param name="ReservationStartTime">
/// The start time of the reservation
/// </param>
/// <param name="UserId">
/// The unique identifier of the user
/// </param>
public record SimplifiedAppointmentResource(string ServiceName, string CompanyName, DateTime ReservationStartTime, int UserId);