using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using Dapper;

using System.Security.Cryptography;
using System.Text;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var connectionString = _configuration.GetConnectionString("OracleDb");
        using var connection = new OracleConnection(connectionString);

        // 將密碼進行 SHA256 雜湊
        string hashedPassword = ComputeSha256Hash(request.Password);

        string sql = @"SELECT COUNT(1) 
                       FROM ACC_USER 
                       WHERE USER_ID = :UserId 
                         AND PASSWD = :Password 
                         AND IS_ENABLE = 'Y'";

        var count = await connection.ExecuteScalarAsync<int>(
            sql,
            new { UserId = request.UserId, Password = hashedPassword }
        );

        if (count > 0)
        {
            return Ok(new { message = "登入成功" });
        }
        else
        {
            return Unauthorized(new { message = "帳號或密碼錯誤，或帳號未啟用" });
        }
    }

    // SHA256 雜湊方法
    private static string ComputeSha256Hash(string rawData)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
        var builder = new StringBuilder();
        foreach (var b in bytes)
            builder.Append(b.ToString("x2"));
        return builder.ToString();
    }
}

public class LoginRequest
{
    public string UserId { get; set; }    // 對應 USER_ID
    public string Password { get; set; }  // 對應 PASSWD
}
