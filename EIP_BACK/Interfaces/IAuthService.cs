﻿using EIP_BACK.Entities;

namespace EIP_BACK.Interfaces
{
    public interface IAuthService
    {
        Task<User?> LoginAsync(string userId, string password);
    }
}
