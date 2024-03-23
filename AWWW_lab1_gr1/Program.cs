using AWWW_lab1_gr1;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MeBdContext>(options =>
{
<<<<<<< HEAD
   var cs = builder.Configuration.GetConnectionString("DefaultConnection");
=======
var cs = builder.Configuration.GetConnectionString("DefaultConnection");
>>>>>>> 425b59d964d84794849c5e04ea10783c3981069d
options.UseSqlServer(cs);
});

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
