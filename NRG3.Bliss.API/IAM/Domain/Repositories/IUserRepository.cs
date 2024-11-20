﻿using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Entities;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;

/// <summary>
/// Repository for the User entity
/// </summary>
public interface IUserRepository : IBaseRepository<User>
{
    bool ExistsByEmail(string email);
}