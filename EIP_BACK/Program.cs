var builder = WebApplication.CreateBuilder(args);

// �Ȥ��\���w����
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:5173") // �Ч令�A���e�ݺ��}
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// �ҥ� CORS�A�Ȥ��\���w����
app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();
