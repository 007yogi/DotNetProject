using CleanMovie.API.Middleware;
using CleanMovie.Application.Interfaces;
using CleanMovie.Application.Interfaces.IMovies;
using CleanMovie.Application.Interfaces.IServices;
using CleanMovie.Application.Interfaces.ISports;
using CleanMovie.Application.Services;
using CleanMovie.Infrastructure.AppDbContext;
using CleanMovie.Infrastructure.Repositories.Movies;
using CleanMovie.Infrastructure.Repositories.Sports;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add connection string.
var ConnString = builder.Configuration.GetConnectionString("myCon") ?? throw new InvalidOperationException("Connection string 'WebAPIContext' not found.");
builder.Services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(ConnString),ServiceLifetime.Singleton);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ISportsService, SportsService>();

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ICricketRepository, CricketRepository>();
builder.Services.AddScoped<IHockeyRepository, HockeyRepository>();
builder.Services.AddScoped<IFootballRepository, FootballRepository>();

builder.Services.AddMediatR(typeof(SportsService).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalErrorHandling>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
