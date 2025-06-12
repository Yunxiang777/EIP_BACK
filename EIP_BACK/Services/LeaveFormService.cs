using EIP_BACK.DTOs;
using EIP_BACK.Entities;
using EIP_BACK.Interfaces;

namespace EIP_BACK.Services
{
    public class LeaveFormService : ILeaveFormService
    {
        private readonly ILeaveFormRepository _repository;

        public LeaveFormService(ILeaveFormRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateLeaveFormAsync(CreateLeaveFormRequest request)
        {
            var form = new LeaveForm
            {
                FORM_ID = request.FormId,
                APPLICANT_CODE = request.ApplicantCode,
                LEAVE_TYPE = request.LeaveType,
                START_DATE = request.StartDate,
                END_DATE = request.EndDate,
                REASON = request.Reason,
                STATUS = request.Status,
                APPLY_DATE = request.ApplyDate,
                LAST_UPDATE = request.LastUpdate
            };

            await _repository.InsertLeaveFormAsync(form);
        }
    }
}
