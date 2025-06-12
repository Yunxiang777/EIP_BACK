namespace EIP_BACK.Entities
{
    public class LeaveForm
    {
        public string FORM_ID { get; set; }
        public string APPLICANT_CODE { get; set; }
        public string LEAVE_TYPE { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime END_DATE { get; set; }
        public string REASON { get; set; }
        public string STATUS { get; set; }
        public DateTime APPLY_DATE { get; set; }
        public DateTime LAST_UPDATE { get; set; }
    }
}
