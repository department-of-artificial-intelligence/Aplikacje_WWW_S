using System.Runtime.InteropServices;
using AWWW_lab2_gr2;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyDbContext>(options =>
{
       if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
       else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                 options.UseSqlServer(builder.Configuration.GetConnectionString("MacOSConnection"));
});
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();