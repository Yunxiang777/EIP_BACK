using EIP_BACK.Entities;

namespace EIP_BACK.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> ValidateUserAsync(string userId, string hashedPassword);
        Task<bool> UpdateUserAsync(string userCode, User updatedUser);
    }
}
