using System.Security.Cryptography;
using System.Text;
using EIP_BACK.Interfaces;
using EIP_BACK.Entities;

namespace EIP_BACK.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;

        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task<User?> LoginAsync(string userId, string password)
        {
            string hashedPassword = HashPassword(password);
            var user = await _repository.ValidateUserAsync(userId, hashedPassword);
            return user; // 如果找不到就是 null，上層可判斷
        }

        public async Task<bool> UpdateUserAsync(string userCode, User updatedUser)
        {
            return await _repository.UpdateUserAsync(userCode, updatedUser);
        }

        private static string HashPassword(string rawData)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

    }
}
