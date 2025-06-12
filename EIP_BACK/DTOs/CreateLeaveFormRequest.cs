namespace EIP_BACK.DTOs
{
    public class CreateLeaveFormRequest
    {
        public string FormId { get; set; }
        public string ApplicantCode { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime ApplyDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
