using EIP_BACK.Interfaces;

namespace EIP_BACK.Services
{
    public class WorkTimeService : IWorkTimeService
    {
        private readonly IWorkTimeRepository _repository;

        public WorkTimeService(IWorkTimeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DateTime>> GetWorkTimesByUserCodeAsync(string userCode)
        {
            return await _repository.GetWorkDatesByUserCodeAsync(userCode);
        }
    }
}
