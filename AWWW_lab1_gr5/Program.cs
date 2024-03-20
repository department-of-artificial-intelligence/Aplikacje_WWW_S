using System.Runtime.InteropServices;
using AWWW_lab1_gr5;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
       if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
       else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                 options.UseSqlServer(builder.Configuration.GetConnectionString("MacOSConnection"));
});
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
