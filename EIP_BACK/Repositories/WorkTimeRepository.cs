using Dapper;
using Oracle.ManagedDataAccess.Client;
using EIP_BACK.Interfaces;

namespace EIP_BACK.Repositories
{
    public class WorkTimeRepository : IWorkTimeRepository
    {
        private readonly IConfiguration _configuration;

        public WorkTimeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<DateTime>> GetWorkDatesByUserCodeAsync(string userCode)
        {
            string connectionString = _configuration.GetConnectionString("OracleDb");
            using var connection = new OracleConnection(connectionString);

            string sql = @"SELECT WORKDATE 
                   FROM WORKTIME 
                   WHERE USER_CODE = :UserCode 
                   ORDER BY WORKDATE DESC";

            var result = await connection.QueryAsync<DateTime>(sql, new { UserCode = userCode });
            return result;
        }
    }
}
