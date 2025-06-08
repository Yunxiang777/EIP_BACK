using EIP_BACK.Interfaces;
using EIP_BACK.Services;
using EIP_BACK.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 設定 CORS，只允許特定網域
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // ← 改成你的前端網址
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// 註冊 Controller
builder.Services.AddControllers();

// Swagger（開發用）
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 註冊 DI（倉儲模式）
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

var app = builder.Build();

// 開發環境才開 Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 使用 CORS，必須放在 UseAuthorization 前面
app.UseCors("AllowFrontend");

// 認證授權（目前沒用到，但未來擴充可用）
app.UseAuthorization();

// 映射 Controller 路由
app.MapControllers();

// 啟動應用程式
app.Run();
