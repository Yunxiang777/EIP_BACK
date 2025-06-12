using EIP_BACK.DTOs;

namespace EIP_BACK.Interfaces
{
    public interface ILeaveFormService
    {
        Task CreateLeaveFormAsync(CreateLeaveFormRequest request);
    }
}
