using System.Threading.Tasks;

namespace EIP_BACK.Interfaces
{
    public interface IAuthRepository
    {
        Task<bool> ValidateUserAsync(string userId, string hashedPassword);
    }
}
