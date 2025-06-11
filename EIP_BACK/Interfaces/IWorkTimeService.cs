namespace EIP_BACK.Interfaces
{
    public interface IWorkTimeService
    {
        Task<IEnumerable<DateTime>> GetWorkTimesByUserCodeAsync(string userCode);
    }
}
