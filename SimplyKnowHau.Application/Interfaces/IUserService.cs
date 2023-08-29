﻿using SimplyKnowHau.Domain.Entities;

namespace SimplyKnowHau.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> GetById(int id);
    }
}