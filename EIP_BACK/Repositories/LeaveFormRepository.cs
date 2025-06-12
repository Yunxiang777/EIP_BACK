using Dapper;
using Oracle.ManagedDataAccess.Client;
using EIP_BACK.Entities;
using EIP_BACK.Interfaces;

namespace EIP_BACK.Repositories
{
    public class LeaveFormRepository : ILeaveFormRepository
    {
        private readonly IConfiguration _configuration;

        public LeaveFormRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task InsertLeaveFormAsync(LeaveForm form)
        {
            var sql = @"INSERT INTO LEAVE_FORM 
            (FORM_ID, APPLICANT_CODE, LEAVE_TYPE, START_DATE, END_DATE, REASON, STATUS, APPLY_DATE, LAST_UPDATE)
            VALUES 
            (:FORM_ID, :APPLICANT_CODE, :LEAVE_TYPE, :START_DATE, :END_DATE, :REASON, :STATUS, :APPLY_DATE, :LAST_UPDATE)";

            using var connection = new OracleConnection(_configuration.GetConnectionString("OracleDb"));
            await connection.ExecuteAsync(sql, form);
        }
    }
}
