using Dapper;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using EIP_BACK.Interfaces;

namespace EIP_BACK.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;

        public AuthRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ValidateUserAsync(string userId, string hashedPassword)
        {
            string connectionString = _configuration.GetConnectionString("OracleDb");
            using var connection = new OracleConnection(connectionString);

            string sql = @"SELECT COUNT(1) 
                           FROM ACC_USER 
                           WHERE USER_ID = :UserId 
                             AND PASSWD = :Password 
                             AND IS_ENABLE = 'Y'";

            var count = await connection.ExecuteScalarAsync<int>(sql, new
            {
                UserId = userId,
                Password = hashedPassword
            });

            return count > 0;
        }
    }
}
