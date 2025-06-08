using System.Security.Cryptography;
using System.Text;
using EIP_BACK.Interfaces;

namespace EIP_BACK.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;

        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> LoginAsync(string userId, string password)
        {
            string hashedPassword = HashPassword(password);
            return await _repository.ValidateUserAsync(userId, hashedPassword);
        }

        private static string HashPassword(string rawData)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
