namespace EIP_BACK.Interfaces
{
    public interface IWorkTimeRepository
    {
        Task<IEnumerable<DateTime>> GetWorkDatesByUserCodeAsync(string userCode);
    }
}
