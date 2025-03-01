using Microsoft.EntityFrameworkCore;
using MultipleDatabaseAPI.EFContext;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppConn") ?? throw new InvalidOperationException("Connection string of AppConn 'WebAPIContext' not found.");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

var connString = builder.Configuration.GetConnectionString("LoggingConn") ?? throw new InvalidOperationException("Connection string of LoggingConn 'WebAPIContext' not found.");
builder.Services.AddDbContext<LoggingDbContext>(options => options.UseSqlServer(connString));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
