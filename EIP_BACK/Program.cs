using EIP_BACK.Interfaces;
using EIP_BACK.Services;
using EIP_BACK.Repositories;

var builder = WebApplication.CreateBuilder(args);

// �]�w CORS�A�u���\�S�w����
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // �� �令�A���e�ݺ��}
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// ���U Controller
builder.Services.AddControllers();

// Swagger�]�}�o�Ρ^
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ���U DI�]���x�Ҧ��^
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

var app = builder.Build();

// �}�o���Ҥ~�} Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// �ϥ� CORS�A������b UseAuthorization �e��
app.UseCors("AllowFrontend");

// �{�ұ��v�]�ثe�S�Ψ�A�������X�R�i�Ρ^
app.UseAuthorization();

// �M�g Controller ����
app.MapControllers();

// �Ұ����ε{��
app.Run();
