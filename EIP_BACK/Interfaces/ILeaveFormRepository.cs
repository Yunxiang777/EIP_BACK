using EIP_BACK.Entities;

namespace EIP_BACK.Interfaces
{
    public interface ILeaveFormRepository
    {
        Task InsertLeaveFormAsync(LeaveForm form);
    }
}
