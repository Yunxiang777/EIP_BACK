using Dapper;
using Oracle.ManagedDataAccess.Client;
using EIP_BACK.Interfaces;
using EIP_BACK.Entities;
using EIP_BACK.DTOs;

namespace EIP_BACK.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;

        public AuthRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<User?> ValidateUserAsync(string userId, string hashedPassword)
        {
            string connectionString = _configuration.GetConnectionString("OracleDb");
            using var connection = new OracleConnection(connectionString);

            string sql = @"
                SELECT USER_CODE, USER_ID, USER_NAME, EMAIL, MOBILE, CRDAT
                FROM ACC_USER 
                WHERE USER_ID = :UserId 
                  AND PASSWD = :Password 
                  AND IS_ENABLE = 'Y'";

            var user = await connection.QueryFirstOrDefaultAsync<User>(sql, new
            {
                UserId = userId,
                Password = hashedPassword
            });

            return user;
        }

        public async Task<bool> UpdateUserAsync(string userCode, User updatedUser)
        {
            string connectionString = _configuration.GetConnectionString("OracleDb");
            using var connection = new OracleConnection(connectionString);

            string sql = @"
                UPDATE ACC_USER
                SET USER_NAME = :UserName,
                    EMAIL = :Email,
                    MOBILE = :Mobile
                WHERE USER_CODE = :UserCode
            ";

            var affectedRows = await connection.ExecuteAsync(sql, new
            {
                UserName = updatedUser.USER_NAME,
                Email = updatedUser.EMAIL,
                Mobile = updatedUser.MOBILE,
                UserCode = userCode
            });

            return affectedRows > 0;
        }
    }
}
