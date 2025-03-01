using APIGateway.Ocelot;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Ocelot Configuration
/*builder.Configuration.AddJsonFile("Ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot();*/


// Directory containing Ocelot route configuration files
var configDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Ocelot");

// Merge all configuration files into a single JObject
var mergedConfig = MergeOcelotConfiguration.MergeOcelotConfigurationFiles(configDirectory);

// Save the merged configuration to a temporary file
var tempConfigFilePath = Path.Combine(Path.GetTempPath(), "ocelot.merged.json");
File.WriteAllText(tempConfigFilePath, mergedConfig.ToString());

// Load the merged configuration file
builder.Configuration.AddJsonFile(tempConfigFilePath, optional: false, reloadOnChange: true);
builder.Services.AddOcelot();


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

app.UseOcelot().Wait();

app.Run();