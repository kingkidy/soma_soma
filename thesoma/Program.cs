 using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using thesoma.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("thesomaContextConnection") ?? throw new InvalidOperationException("Connection string 'thesomaContextConnection' not found.");

builder.Services.AddDbContext<thesomaContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<thesomaContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<thesoma.Areas.Identity.Data.thesomaUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<thesomaContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Welcome}/{id?}");

app.MapControllerRoute(
    name: "studentProfile",
    pattern: "StudentProfile/{action=StudentProfile}/{id?}",
    defaults: new { controller = "StudentProfile", action = "StudentProfile" });





app.MapRazorPages();
app.Run();
