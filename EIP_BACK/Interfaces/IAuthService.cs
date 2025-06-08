using System.Threading.Tasks;
using EIP_BACK.DTOs;

namespace EIP_BACK.Interfaces
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string userId, string password);
    }
}
