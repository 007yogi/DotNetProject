using Microsoft.EntityFrameworkCore;
using WebAPI.DBEntity;

var builder = WebApplication.CreateBuilder(args);

// Add connection string.
var connectionString = builder.Configuration.GetConnectionString("EmployeeAppCon") ?? throw new InvalidOperationException("Connection string 'WebAPIContext' not found.");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddMemoryCache();

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();

// Add CORS
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

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
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
