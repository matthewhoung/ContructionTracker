using Application.Configurations;
using Infrastructure.Configurations;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
//dbConnection
builder.Services.AddMySQLConnection(builder.Configuration);

builder.Services.AddRepositories();
builder.Services.AddDomainServices();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();