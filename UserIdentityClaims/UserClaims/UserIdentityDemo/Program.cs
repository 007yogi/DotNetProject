using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserIdentityDemo;
using UserIdentityDemo.Areas.Identity.Data;
using UserIdentityDemo.Data;
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("myConn") ?? throw new InvalidOperationException("Connection string 'myConn' not found.");

builder.Services.AddDbContext<UserIdentityDemoContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<SampleUserData>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<UserIdentityDemoContext>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<SampleUserData>, AppUserClaimsPrincipalFactory>();

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();

builder.Services.AddAuthorization(option => {
    option.AddPolicy("EmailID", policy => 
    policy.RequireClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "yogeshkumarsam@gmail.com"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
