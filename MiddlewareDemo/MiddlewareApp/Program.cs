using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using MiddlewareApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped<ILogger, Logger>();
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

app.MapControllers();

// calling extention methods
int a = 12;
var b = a.CustomIntExtention();
//var b = IntExtention.CustomIntExtention(a);
Console.WriteLine(b);

string str = "Hello India";
string strVal = str.CustomStringExtension();
Console.WriteLine(strVal);

app.Use(async (context, next) =>
{
    // await context.Response.WriteAsync("Before Invoke from 1st app.Use()\n");
    await next();
    //await context.Response.WriteAsync("After Invoke from 1st app.Use()\n");
});

app.Use(async (context, next) =>
{
    //await context.Response.WriteAsync("Before Invoke from 2nd app.Use()\n");
    await next();
    //await context.Response.WriteAsync("After Invoke from 2nd app.Use()\n");
});

app.MapGet("/m1{id}", (int id) =>
{
    return Results.Ok("MapGet" + id.ToString());
});
//app.Map("/m2", x => {
//    x.Run(async context =>
//    {
//        await context.Response.WriteAsync("Hello from 2nd app.Map()");
//    });
//});
app.UseMyMiddleware();
app.Run();

//static void HandleMapOne(IApplicationBuilder app)
//{
//    app.Run(async context =>
//    {
//        await context.Response.WriteAsync("Hello from 1st app.Map()");
//    });
//}



//www.c-sharpcorner.com/article/overview-of-middleware-in-asp-net-core/