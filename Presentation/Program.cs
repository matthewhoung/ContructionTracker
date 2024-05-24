using Application.Configurations;
using Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);
//dbConnection
builder.Services.AddMySQLConnection(builder.Configuration);

builder.Services.AddRepositories();
builder.Services.AddDomainServices();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();